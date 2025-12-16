using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MongoDB.Bson;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Booking_app
{
    public partial class EditFacilitypage : Form
    {
        public event EventHandler FacilityUpdated;
        private MemberService memberService;
        private StaffService staffService;
        private BookingService bookingService;
        private FacilityService facilityService;
        private Facility facility;
        private IUser user;

        public EditFacilitypage(Facility fac)
        {
            user = Session.CurrentUser;
            facility = fac;
            InitializeComponent();

            memberService = new MemberService();
            staffService = new StaffService();
            bookingService = new BookingService();
            facilityService = new FacilityService();

            bookingService.StaffService = staffService;
            staffService.BookingService = bookingService;




            btnSave.Click += BtnSave_Click; 
            btnCancel.Click += BtnCancel_Click;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string type = txtType.Text.Trim().ToLower();
            string location = txtLocation.Text.Trim();
            string availability = txtAvailability.Text.Trim();
            string capacityStr = txtCapacity.Text.Trim();
            string hourlyRateStr = txtHourlyRate.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(type) ||
                string.IsNullOrWhiteSpace(location) || string.IsNullOrWhiteSpace(availability) ||
                string.IsNullOrWhiteSpace(capacityStr) || string.IsNullOrWhiteSpace(hourlyRateStr))
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }

            if (!int.TryParse(capacityStr, out int capacityInt) || capacityInt <= 0)
            {
                MessageBox.Show("Please enter a valid positive number for capacity.");
                return;
            }

            if (!decimal.TryParse(hourlyRateStr, out decimal hourlyRateDecimal) || hourlyRateDecimal <= 0)
            {
                MessageBox.Show("Please enter a valid positive number for hourly rate.");
                return;
            }

            try
            {
                Facility updatedFacility = new Facility
                {
                    Id = facility.Id,
                    name = name,
                    type = type,
                    location = location,
                    availability = availability,
                    capacity = capacityInt,
                    hourlyRate = hourlyRateDecimal
                };

                facilityService.UpdateFacility(updatedFacility);
                FacilityUpdated?.Invoke(this, EventArgs.Empty);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating facility: {ex.Message}");
            }
        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
