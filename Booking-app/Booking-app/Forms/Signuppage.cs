using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Booking_app
{
    public partial class Signuppage : Form
    {
        private readonly MemberService _memberService;
        private readonly AuthService _authService;

        public Signuppage()
        {
            InitializeComponent();

            _memberService = new MemberService();
            _authService = new AuthService();

            signUpButton.Click += SignUpButton_Click;
            linkLogin.LinkClicked += LinkLogin_LinkClicked;
        }


        private void SignUpButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text.Trim();
            string email = emailTextBox.Text.Trim().ToLower();
            string password = passwordTextBox.Text.Trim();
            string phone = phoneTextBox.Text.Trim();
            string level = memberLevelComboBox.SelectedItem?.ToString() ?? "Basic";

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Name, Email, and Password are required.");
                return;
            }

            if (!Regex.IsMatch(name, @"^[A-Za-z\s]+$"))
            {
                MessageBox.Show("Name can contain only letters and spaces.");
                return;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            if (!string.IsNullOrWhiteSpace(phone) && !Regex.IsMatch(phone, @"^\d+$"))
            {
                MessageBox.Show("Phone number must contain digits only.");
                return;
            }

            var existingMember = _memberService.GetByEmail(email);
            if (existingMember != null)
            {
                MessageBox.Show("A member with this email already exists.");
                return;
            }

            var newMember = new Member
            {
                Id = MongoDB.Bson.ObjectId.GenerateNewId(), 
                name = name,
                email = email,
                password = password,
                phone = phone,
                membershipLevel = level,
                joinDate = DateTime.Now,
                membershipStatus = "Active"
            };

            _authService.Signup(newMember);

            MessageBox.Show("Member account created successfully!");

            Loginpage loginForm = new Loginpage();
            loginForm.FormClosed += (s, args) => this.Close();
            loginForm.Show();
            this.Hide();
        }

        private void LinkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Loginpage loginForm = new Loginpage();
            loginForm.FormClosed += (s, args) => this.Show();
            loginForm.Show();
            this.Hide();
        }
    }
}
