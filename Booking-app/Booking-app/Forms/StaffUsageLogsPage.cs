using MongoDB.Bson;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Booking_app
{
    public partial class StaffUsageLogsPage : Form
    {
        private BookingService bookingService;
        private UsageLogService usageLogService;
        private MemberService memberService;
        private FacilityService facilityService;

        public StaffUsageLogsPage()
        {
            InitializeComponent();

            if (!Session.IsStaff)
            {
                MessageBox.Show("Unauthorized access");
                Close();
                return;
            }

            bookingService = new BookingService();
            usageLogService = new UsageLogService();
            memberService = new MemberService();
            facilityService = new FacilityService();

            Load += (s, e) => RefreshGrids();
            btnBack.Click += (s, e) => Close();
            btnAddLog.Click += BtnAddLog_Click;
        }

        private void RefreshGrids()
        {
            LoadPendingBookings();
            LoadExistingLogs();
        }

        private void LoadPendingBookings()
        {
            dgvPending.Rows.Clear();
            var now = DateTime.Now;

            var pendingBookings = bookingService
                .GetBookingsByStaffId(Session.GetUserId)
                .Where(b => !usageLogService.ExistsForBooking(b.Id))
                .Where(b => b.Status != "Cancelled")
                .Where(b =>
                 {
                      var bookingEnd = b.bookingDate.Date.AddHours(b.endTime);
                      return bookingEnd <= now;                
                 })
                .OrderBy(b => b.bookingDate)
                .ThenBy(b => b.startTime)
                .ToList();

            foreach (var b in pendingBookings)
            {
                var member = memberService.GetById(b.member_id);
                var facility = facilityService.GetById(b.facility_id);

                dgvPending.Rows.Add(
                    b.Id.ToString(),
                    member?.name ?? "Unknown",
                    facility?.name ?? "Unknown",
                    b.startTime + ":00",
                    b.endTime + ":00"
                );
            }
        }

        private void LoadExistingLogs()
        {
            dgvExisting.Rows.Clear();

            var logs = usageLogService.GetLogsByStaff(Session.GetUserId)
                .OrderBy(l => l.startTime)
                .ToList();

            foreach (var log in logs)
            {
                var member = memberService.GetById(log.member_id);
                var facility = facilityService.GetById(log.facility_id);

                dgvExisting.Rows.Add(
                    log.Id.ToString(),
                    log.booking_id.ToString(),
                    member?.name ?? "Unknown",
                    facility?.name ?? "Unknown",
                    log.startTime + ":00",
                    log.endTime + ":00"
                );
            }
        }

        private void BtnAddLog_Click(object sender, EventArgs e)
        {
            if (dgvPending.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a booking first.");
                return;
            }

            ObjectId bookingId = ObjectId.Parse(
                dgvPending.SelectedRows[0].Cells[0].Value.ToString()
            );

            using (AddUsage addUsageForm = new AddUsage(bookingId))
            {
                addUsageForm.ShowDialog();
            }

            RefreshGrids();
        }
    }
}
