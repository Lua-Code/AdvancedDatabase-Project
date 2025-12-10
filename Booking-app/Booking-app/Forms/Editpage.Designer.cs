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
    partial class Editpage
    {
        private TableLayoutPanel mainLayout;
        private Label lblHeader, lblName, lblEmail, lblPhone, lblLevel, lblStatus, lblJoinDate, lblPassword;
        private TextBox txtName, txtEmail, txtPhone, txtLevel, txtStatus, txtJoinDate, txtPassword;
        private Button btnSave, btnCancel;
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            mainLayout = new TableLayoutPanel();

            lblHeader = new Label();
            lblName = new Label();
            lblEmail = new Label();
            lblPhone = new Label();
            lblLevel = new Label();
            lblStatus = new Label();
            lblJoinDate = new Label();
            lblPassword = new Label();

            txtName = new TextBox();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            txtLevel = new TextBox();
            txtStatus = new TextBox();
            txtJoinDate = new TextBox();
            txtPassword = new TextBox();

            btnSave = new Button();
            btnCancel = new Button();

            SuspendLayout();

            // table layout
            mainLayout.ColumnCount = 2;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));

            mainLayout.RowCount = 11;

            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));   
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));   
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));   
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));   
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));   
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));   
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));   
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));   
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));   
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));  
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));  

            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Padding = new Padding(20);

            // header
            lblHeader.Text = "Edit Profile";
            lblHeader.Font = new Font("Arial Rounded MT Bold", 26F);
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            lblHeader.Dock = DockStyle.Fill;
            mainLayout.SetColumnSpan(lblHeader, 2);

            // labels
            lblName.Text = "Name:";
            lblName.Font = new Font("Segoe UI", 12F);
            lblName.TextAlign = ContentAlignment.MiddleRight;
            lblName.Dock = DockStyle.Fill;

            lblEmail.Text = "Email:";
            lblEmail.Font = new Font("Segoe UI", 12F);
            lblEmail.TextAlign = ContentAlignment.MiddleRight;
            lblEmail.Dock = DockStyle.Fill;

            lblPhone.Text = "Phone:";
            lblPhone.Font = new Font("Segoe UI", 12F);
            lblPhone.TextAlign = ContentAlignment.MiddleRight;
            lblPhone.Dock = DockStyle.Fill;

            lblLevel.Text = "Level:";
            lblLevel.Font = new Font("Segoe UI", 12F);
            lblLevel.TextAlign = ContentAlignment.MiddleRight;
            lblLevel.Dock = DockStyle.Fill;

            lblStatus.Text = "Status:";
            lblStatus.Font = new Font("Segoe UI", 12F);
            lblStatus.TextAlign = ContentAlignment.MiddleRight;
            lblStatus.Dock = DockStyle.Fill;

            lblJoinDate.Text = "Join Date:";
            lblJoinDate.Font = new Font("Segoe UI", 12F);
            lblJoinDate.TextAlign = ContentAlignment.MiddleRight;
            lblJoinDate.Dock = DockStyle.Fill;

            lblPassword.Text = "Password:";
            lblPassword.Font = new Font("Segoe UI", 12F);
            lblPassword.TextAlign = ContentAlignment.MiddleRight;
            lblPassword.Dock = DockStyle.Fill;

            // text boxes
            Font tbFont = new Font("Segoe UI", 12F);

            txtName.Font = tbFont;
            txtName.Dock = DockStyle.Fill;

            txtEmail.Font = tbFont;
            txtEmail.Dock = DockStyle.Fill;

            txtPhone.Font = tbFont;
            txtPhone.Dock = DockStyle.Fill;

            txtLevel.Font = tbFont;
            txtLevel.Dock = DockStyle.Fill;
            txtLevel.ReadOnly= true;

            txtStatus.Font = tbFont;
            txtStatus.Dock = DockStyle.Fill;
            txtStatus.ReadOnly = true;

            txtJoinDate.Font = tbFont;
            txtJoinDate.Dock = DockStyle.Fill;
            txtJoinDate.ReadOnly = true;

            txtPassword.Font = tbFont;
            txtPassword.Dock = DockStyle.Fill;
            txtPassword.PasswordChar = '*';

            // buttons
            btnSave.Text = "Save Changes";
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSave.Dock = DockStyle.Fill;
            mainLayout.SetColumnSpan(btnSave, 2);
            btnSave.Click += BtnSave_Click;

            btnCancel.Text = "Cancel";
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCancel.Dock = DockStyle.Fill;
            mainLayout.SetColumnSpan(btnCancel, 2);
            btnCancel.Click += BtnCancel_Click;

            // controls
            mainLayout.Controls.Add(lblHeader, 0, 0);

            mainLayout.Controls.Add(lblName, 0, 1); mainLayout.Controls.Add(txtName, 1, 1);
            mainLayout.Controls.Add(lblEmail, 0, 2); mainLayout.Controls.Add(txtEmail, 1, 2);
            mainLayout.Controls.Add(lblPhone, 0, 3); mainLayout.Controls.Add(txtPhone, 1, 3);
            mainLayout.Controls.Add(lblLevel, 0, 4); mainLayout.Controls.Add(txtLevel, 1, 4);
            mainLayout.Controls.Add(lblStatus, 0, 5); mainLayout.Controls.Add(txtStatus, 1, 5);
            mainLayout.Controls.Add(lblJoinDate, 0, 6); mainLayout.Controls.Add(txtJoinDate, 1, 6);
            mainLayout.Controls.Add(lblPassword, 0, 7); mainLayout.Controls.Add(txtPassword, 1, 7);

            mainLayout.Controls.Add(btnSave, 0, 9);
            mainLayout.Controls.Add(btnCancel, 0, 10);

            // form 
            this.ClientSize = new Size(600, 650);
            this.Controls.Add(mainLayout);
            this.Text = "Edit Member Profile";

            ResumeLayout(false);
        }
    }
}
