using MongoDB.Bson;
using System;
using System.Windows.Forms;

namespace Booking_app
{
    public partial class AddUsage : Form
    {
        private ObjectId bookingId;
        private BookingService bookingService;
        private UsageLogService usageLogService;
        private MemberService memberService;

        public AddUsage(ObjectId bookingId)
        {
            InitializeComponent();

            if (!Session.IsStaff)
            {
                MessageBox.Show("Unauthorized access");
                Close();
                return;
            }

            this.bookingId = bookingId;

            bookingService = new BookingService();
            usageLogService = new UsageLogService();
            memberService = new MemberService();

            Load += AddUsage_Load;
            btnSave.Click += BtnSave_Click;
            numStart.ValueChanged += UpdateDuration;
            numEnd.ValueChanged += UpdateDuration;
        }

        private void AddUsage_Load(object sender, EventArgs e)
        {
            var booking = bookingService.GetById(bookingId);
            var member = memberService.GetById(booking.member_id);

            lblBookingInfo.Text =
                $"Member: {member?.name ?? "Unknown"}\n" +
                $"Date: {booking.bookingDate.ToShortDateString()}\n" +
                $"Booked: {booking.startTime}:00 - {booking.endTime}:00";

            numStart.Value = booking.startTime;
            numEnd.Value = booking.endTime;

            UpdateDuration(null, null);
        }

        private void UpdateDuration(object sender, EventArgs e)
        {
            lblDuration.Text = $"Duration: {numEnd.Value - numStart.Value} hours";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (numEnd.Value <= numStart.Value)
            {
                MessageBox.Show("End time must be after start time.");
                return;
            }

            var booking = bookingService.GetById(bookingId);

            var log = new UsageLog
            {
                Id = ObjectId.GenerateNewId(),
                booking_id = bookingId,
                member_id = booking.member_id,
                facility_id = booking.facility_id,
                startTime = (int)numStart.Value,
                endTime = (int)numEnd.Value,
                duration = (int)(numEnd.Value - numStart.Value)
            };

            usageLogService.Create(log);
            booking.Status = "Finished";
            bookingService.UpdateBooking(booking);
            MessageBox.Show("Usage log saved successfully.");
            Close();
        }
    }
}
