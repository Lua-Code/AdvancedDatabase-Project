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
    public partial class Loginpage : Form
    {
        MemberService memberService;
        AuthService authService;
        public Loginpage()
        {
            InitializeComponent();
            memberService = new MemberService();
            authService = new AuthService();

            button1.Click += button1_Click;
            linkLabel2.Click += linkLabel2_LinkClicked;
        }

        private void linkLabel2_LinkClicked(object sender, EventArgs e)
        {
            Signuppage memberSignForm = new Signuppage();
            memberSignForm.FormClosed += (s, args) => this.Show();
            memberSignForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both email and password.");
                return;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            IUser user = authService.Login(email, password);

            if (user == null)
            {
                MessageBox.Show("Invalid login.");
                return;
            }

            if (user is Member member)
            {
                if (member.membershipStatus?.ToLower() == "suspended")
                {
                    MessageBox.Show("Your membership is suspended. You cannot login.");
                    return;
                }
            }


            // MemberProfile profileForm = new MemberProfile(member);
            //profileForm.FormClosed += (s, args) => this.Show(); 
            //profileForm.Show();
            Homepage homepage = new Homepage();

            homepage.Show();
            this.Hide(); 
        }




    }
}
