using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MongoDB.Bson;

namespace Booking_app
{
    public partial class AddFacilitypage : Form
    {
        private FacilityService facilityService;
        public event EventHandler FacilityUpdated;

        public AddFacilitypage()
        {
            InitializeComponent();
            facilityService = new FacilityService();
            

            btnAdd.Click += BtnAdd_Click;
            btnCancel.Click += BtnCancel_Click;

            
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string type = txtType.Text.Trim();
            string location = txtLocation.Text.Trim();
            string capacityStr = txtCapacity.Text.Trim();
            string hourlyRateStr = txtHourlyRate.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(type) ||
                string.IsNullOrWhiteSpace(location) || string.IsNullOrWhiteSpace(capacityStr) ||
                string.IsNullOrWhiteSpace(hourlyRateStr))
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
                Facility newFacility = new Facility
                {
                    Id = ObjectId.GenerateNewId(),
                    name = name,
                    type = type,
                    location = location,
                    availability = "Available",
                    capacity = capacityInt,
                    hourlyRate = hourlyRateDecimal
                };

                bool facilityAdded = facilityService.AddFacility(newFacility);
                if (facilityAdded)
                {
                    FacilityUpdated?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show("Facility added successfully!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("A facility with the same name, location, and type already exists.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating facility: {ex.Message}");
            }
        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
