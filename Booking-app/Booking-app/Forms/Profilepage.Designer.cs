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
    partial class Profilepage : Form
    {
        private TableLayoutPanel mainLayout;
        private Label lblHeader, lblName, lblEmail, lblPhone, lblLevel, lblStatus, lblJoinDate, lblPassword;
        private TextBox txtName, txtEmail, txtPhone, txtLevel, txtStatus, txtJoinDate, txtPassword;
        private Button btnEdit, btnDelete;
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

            btnEdit = new Button();
            btnDelete = new Button();

            SuspendLayout();

            // mainLayout
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

            // header label
            lblHeader.Text = "My Profile";
            lblHeader.Font = new Font("Arial Rounded MT Bold", 26F);
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            lblHeader.Dock = DockStyle.Fill;
            mainLayout.SetColumnSpan(lblHeader, 2);

            // labels
            lblName.Text = "Name:";
            lblName.Font = new Font("Segoe UI", 12F);
            lblName.Dock = DockStyle.Fill;
            lblName.TextAlign = ContentAlignment.MiddleLeft;

            lblEmail.Text = "Email:";
            lblEmail.Font = new Font("Segoe UI", 12F);
            lblEmail.Dock = DockStyle.Fill;
            lblEmail.TextAlign = ContentAlignment.MiddleLeft;

            lblPhone.Text = "Phone:";
            lblPhone.Font = new Font("Segoe UI", 12F);
            lblPhone.Dock = DockStyle.Fill;
            lblPhone.TextAlign = ContentAlignment.MiddleLeft;

            lblLevel.Text = "Level:";
            lblLevel.Font = new Font("Segoe UI", 12F);
            lblLevel.Dock = DockStyle.Fill;
            lblLevel.TextAlign = ContentAlignment.MiddleLeft;

            lblStatus.Text = "Status:";
            lblStatus.Font = new Font("Segoe UI", 12F);
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;

            lblJoinDate.Text = "Join Date:";
            lblJoinDate.Font = new Font("Segoe UI", 12F);
            lblJoinDate.Dock = DockStyle.Fill;
            lblJoinDate.TextAlign = ContentAlignment.MiddleLeft;

            lblPassword.Text = "Password:";
            lblPassword.Font = new Font("Segoe UI", 12F);
            lblPassword.Dock = DockStyle.Fill;
            lblPassword.TextAlign = ContentAlignment.MiddleLeft;

            // textboxes
            txtName.Font = new Font("Segoe UI", 12F);
            txtName.Dock = DockStyle.Fill;
            txtName.ReadOnly = true;

            txtEmail.Font = new Font("Segoe UI", 12F);
            txtEmail.Dock = DockStyle.Fill;
            txtEmail.ReadOnly = true;

            txtPhone.Font = new Font("Segoe UI", 12F);
            txtPhone.Dock = DockStyle.Fill;
            txtPhone.ReadOnly = true;

            txtLevel.Font = new Font("Segoe UI", 12F);
            txtLevel.Dock = DockStyle.Fill;
            txtLevel.ReadOnly = true;

            txtStatus.Font = new Font("Segoe UI", 12F);
            txtStatus.Dock = DockStyle.Fill;
            txtStatus.ReadOnly = true;

            txtJoinDate.Font = new Font("Segoe UI", 12F);
            txtJoinDate.Dock = DockStyle.Fill;
            txtJoinDate.ReadOnly = true;

            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Dock = DockStyle.Fill;
            txtPassword.ReadOnly = true;
            txtPassword.PasswordChar = '*';

            // edit
            btnEdit.Text = "Edit Profile";
            btnEdit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnEdit.Dock = DockStyle.Fill;
            btnEdit.Margin = new Padding(0, 0, 0, 10);
            mainLayout.SetColumnSpan(btnEdit, 2);
            btnEdit.Click += BtnEdit_Click;

            // delete
            btnDelete.Text = "Delete Account";
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDelete.BackColor = Color.Firebrick;
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Dock = DockStyle.Fill;
            btnDelete.Margin = new Padding(0, 0, 0, 10);
            mainLayout.SetColumnSpan(btnDelete, 2);
            btnDelete.Click += BtnDelete_Click;

            // mainLayout Controls
            mainLayout.Controls.Add(lblHeader, 0, 0);

            mainLayout.Controls.Add(lblName, 0, 1);
            mainLayout.Controls.Add(txtName, 1, 1);

            mainLayout.Controls.Add(lblEmail, 0, 2);
            mainLayout.Controls.Add(txtEmail, 1, 2);

            mainLayout.Controls.Add(lblPhone, 0, 3);
            mainLayout.Controls.Add(txtPhone, 1, 3);

            mainLayout.Controls.Add(lblLevel, 0, 4);
            mainLayout.Controls.Add(txtLevel, 1, 4);

            mainLayout.Controls.Add(lblStatus, 0, 5);
            mainLayout.Controls.Add(txtStatus, 1, 5);

            mainLayout.Controls.Add(lblJoinDate, 0, 6);
            mainLayout.Controls.Add(txtJoinDate, 1, 6);

            mainLayout.Controls.Add(lblPassword, 0, 7);
            mainLayout.Controls.Add(txtPassword, 1, 7);

            mainLayout.Controls.Add(btnEdit, 0, 9);
            mainLayout.Controls.Add(btnDelete, 0, 10);

            // form
            this.ClientSize = new Size(600, 650);
            this.Controls.Add(mainLayout);
            this.Text = "Member Profile";

            ResumeLayout(false);
        }
    }
}
