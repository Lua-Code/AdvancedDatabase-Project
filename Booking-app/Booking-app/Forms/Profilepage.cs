using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MongoDB.Bson;

namespace Booking_app
{
    public partial class Profilepage : Form
    {
        private IUser user;
        AuthService authService;

        public Profilepage()
        {   
            user = Session.CurrentUser;
            InitializeComponent();

            authService = new AuthService();
            LoadUserData();
        }

        private void LoadUserData()
        {
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

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Editpage editForm = new Editpage();
            editForm.FormClosed += (s, args) => LoadUserData(); 
            this.Hide();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Are you sure you want to delete your account?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                authService.Delete(Session.GetUserId);
                MessageBox.Show("Account deleted successfully.");
                this.Close();
            }
        }
    }
}
