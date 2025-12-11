using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MongoDB.Bson;

namespace Booking_app
{
    public partial class AddStaffpage : Form
    {
        private MemberService memberService;
        private StaffService staffService;
        private BookingService bookingService;

        public AddStaffpage()
        {
            InitializeComponent();

            memberService = new MemberService();
            staffService = new StaffService();
            bookingService = new BookingService();

            bookingService.StaffService = staffService;
            staffService.BookingService = bookingService;

            btnAdd.Click += BtnAdd_Click;
            btnCancel.Click += BtnCancel_Click;

            
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim().ToLower();
            string phone = txtPhone.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role = txtRole.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Name, Email, and Password are required.");
                return;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            if (!Regex.IsMatch(phone, @"^\d+$"))
            {
                MessageBox.Show("Phone number should contain only digits.");
                return;
            }

            if (!Regex.IsMatch(name, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Name should contain only letters and spaces.");
                return;
            }

            var existingStaff = staffService.GetByEmail(email);
            if (existingStaff != null) {
                MessageBox.Show("Email entered already exists, try another mate :/");
                return;
            }

            try
            {
                Staff newStaff = new Staff
                {
                    Id = ObjectId.GenerateNewId(),
                    name = name,
                    email = email,
                    phone = phone,
                    password = password,
                    role = role

                };
                staffService.AddStaff(newStaff);
                MessageBox.Show("Staff Added Succesfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Creating Staff: {ex.Message}");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
