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
            string capacity = txtCapacity.Text.Trim();
            int capacityInt = Convert.ToInt32(capacity);
            string hourlyRate = txtHourlyRate.Text.Trim();
            decimal hourlyRateDecimal = Convert.ToDecimal(hourlyRate);

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(type) || string.IsNullOrWhiteSpace(location) || string.IsNullOrWhiteSpace(capacity) || string.IsNullOrWhiteSpace(hourlyRate))
            {
                MessageBox.Show("Please Fill in all the Fields.");
                return;
            }

            if (!Regex.IsMatch(capacity, @"^\d+$")) 
            {
                MessageBox.Show("Please enter a valid number.");
                return;
            }


            if (!Regex.IsMatch(hourlyRate, @"^(0*[1-9]\d*(\.\d+)?|0*\d*\.\d*[1-9]\d*)$"))
            {
                MessageBox.Show("Please enter a valid number.");
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
                    MessageBox.Show("Facility Added Successfully!");
                    this.Close();
                }
                else {
                    throw new Exception("A facility with the same name, location, and type already exists.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Creating Facility: {ex.Message}");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
