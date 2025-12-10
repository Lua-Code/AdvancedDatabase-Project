using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MongoDB.Bson;

namespace Booking_app
{
    public partial class Editpage : Form
    {
        AuthService authService;
        private IUser user;

        public Editpage()
        {
            user = Session.CurrentUser;
            InitializeComponent();

            if (Session.IsMember)
            {
                Member member = (Member)user;
                txtName.Text = member.name;
                txtEmail.Text = member.email;
                txtPhone.Text = member.phone;
                txtStatus.Text = member.membershipStatus;
                txtJoinDate.Text = member.joinDate.ToString("yyyy-MM-dd");
                txtPassword.Text = member.password;

            }
            else if (Session.IsStaff)
            {
                Staff staff = (Staff)user;
                txtName.Text = staff.name;
                txtEmail.Text = staff.email;
                txtPhone.Text = staff.phone;
                txtPassword.Text = staff.password;
                txtStatus.Visible = false;
                txtJoinDate.Visible = false;


            }


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
            if (!email.Equals(user.email, StringComparison.OrdinalIgnoreCase))
            {
                var existing = _memberService.GetByEmail(email);
                if (existing != null)
                {
                    MessageBox.Show("This email is already used by another member.");
                    return;
                }
            }

            _currentMember.name = name;
            _currentMember.email = email;
            _currentMember.phone = phone;
            _currentMember.password = password;

            try
            {
                _memberService.Update(_currentMember); 
                MessageBox.Show("Member updated successfully!");
                this.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating member: {ex.Message}");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
