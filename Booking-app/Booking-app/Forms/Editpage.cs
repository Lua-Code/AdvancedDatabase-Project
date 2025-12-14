using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MongoDB.Bson;

namespace Booking_app
{
    public partial class Editpage : Form
    {
        private MemberService memberService;
        private StaffService staffService;
        private BookingService bookingService;
        private IUser user;

        public Editpage()
        {
            user = Session.CurrentUser;
            InitializeComponent();

            memberService = new MemberService();
            staffService = new StaffService();
            bookingService = new BookingService();

            bookingService.StaffService = staffService;
            staffService.BookingService = bookingService;

            if (Session.IsMember)
            {
                Member member = (Member)user;

                txtName.Text = member.name;
                txtEmail.Text = member.email;
                txtPhone.Text = member.phone;
                txtStatus.Text = member.membershipStatus;
                txtJoinDate.Text = member.joinDate.ToString("yyyy-MM-dd");
                txtPassword.Text = member.password;

                txtStatus.ReadOnly = true;
                txtJoinDate.ReadOnly = true;
            }
            else if (Session.IsStaff)
            {
                Staff staff = (Staff)user;

                txtName.Text = staff.name;
                txtEmail.Text = staff.email;
                txtPhone.Text = staff.phone;
                txtPassword.Text = staff.password;

                // Staff cannot edit status or join date
                txtStatus.Visible = false;
                txtJoinDate.Visible = false;
            }



            btnSave.Click += BtnSave_Click; 
            btnCancel.Click += BtnCancel_Click;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim().ToLower();
            string phone = txtPhone.Text.Trim();
            string password = txtPassword.Text.Trim();

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

            if (Session.IsMember && !email.Equals(user.email, StringComparison.OrdinalIgnoreCase))
            {
                // Only check email uniqueness against members
                var existing = memberService.GetByEmail(email);
                if (existing != null)
                {
                    MessageBox.Show("This email is already used by another member.");
                    return;
                }
            }

            try
            {
                if (Session.IsMember)
                {
                    Member member = (Member)user;
                    member.name = name;
                    member.email = email;
                    member.phone = phone;
                    member.password = password;

                    memberService.UpdateMember(member);
                    MessageBox.Show("Member updated successfully!");
                }
                else if (Session.IsStaff)
                {
                    Staff staff = (Staff)user;
                    staff.name = name;
                    staff.email = email;
                    staff.phone = phone;
                    staff.password = password;

                    staffService.UpdateStaff(staff);
                    MessageBox.Show("Staff updated successfully!");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating user: {ex.Message}");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
