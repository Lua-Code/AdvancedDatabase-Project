using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MongoDB.Bson;

namespace Booking_app
{
    public partial class MyBookingspage : Form
    {
        private BookingService _bookingService;
        private FacilityService _facilityService;
        private StaffService _staffService;
        private ObjectId _memberId = Session.CurrentUser.Id;

        public MyBookingspage()
        {
            InitializeComponent();
            _bookingService = new BookingService();
            _facilityService = new FacilityService();
            _staffService = new StaffService();

            _bookingService.StaffService = _staffService;
            _staffService.BookingService = _bookingService;


        }

        private void MyBookingspage_Load(object sender, EventArgs e)
        {
            LoadBookings(_memberId);
        }

        private void LoadBookings(ObjectId memberId)
        {
            try
            {
                var bookingsList = _bookingService.GetBookingsByMemberId(memberId);

                DataTable table = new DataTable();

                table.Columns.Add("Facility");
                table.Columns.Add("Staff Assigned");
                table.Columns.Add("Staff Phone Number");
                table.Columns.Add("Booking Date", typeof(DateTime));
                table.Columns.Add("Start Time", typeof(int));
                table.Columns.Add("End Time", typeof(int));
                table.Columns.Add("Status");
                table.Columns.Add("Creation Date", typeof(DateTime));
                table.Columns.Add("Booking Id");

                foreach (var b in bookingsList)
                {
                    var facility = _facilityService.GetById(b.facility_id);
                    var staff = _staffService.GetById(b.staff_id);

                    table.Rows.Add(
                        facility?.name ?? "Unknown",
                        staff?.name ?? "N/A",
                        staff?.phone ?? "N/A",
                        b.bookingDate,
                        b.startTime,
                        b.endTime,
                        b.Status,
                        b.creationDate,
                        b.Id.ToString()
                    );
                }

                DGTable.DataSource = table;

                DGTable.Columns["Booking Id"].Visible = false;

                if (DGTable.Columns["UnbookButton"] == null)
                {
                    DataGridViewButtonColumn btnUnbook = new DataGridViewButtonColumn
                    {
                        Name = "UnbookButton",
                        Text = "Unbook",
                        UseColumnTextForButtonValue = true
                    };
                    DGTable.Columns.Add(btnUnbook);
                }

                foreach (DataGridViewRow row in DGTable.Rows)
                {
                    if (row.IsNewRow) continue; 

                    string status = row.Cells["Status"].Value?.ToString();
                    Console.WriteLine($"[{status}]");

                    if (!string.IsNullOrEmpty(status) && status.Trim().Equals("Cancelled", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Disabling button for cancelled booking");
                        row.Cells["UnbookButton"].Value = "";
                        row.Cells["UnbookButton"].ReadOnly = true;
                        row.Cells["UnbookButton"].Style.ForeColor = Color.Gray;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading bookings: " + ex.Message);
            }
        }



        private void DGTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGTable.Columns["UnbookButton"].Index && e.RowIndex >= 0)
            {
                var bookingId = DGTable.Rows[e.RowIndex].Cells["Booking Id"].Value.ToString();

                if (_bookingService.UnbookBooking(bookingId))
                {
                    MessageBox.Show("Booking successfully cancelled!");
                    LoadBookings(_memberId);
                }
                else
                {
                    MessageBox.Show("Error cancelling booking.");
                }
            }
        }
    }
}
