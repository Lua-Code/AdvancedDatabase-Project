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
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblLevel = new System.Windows.Forms.Label();
            this.txtLevel = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblJoinDate = new System.Windows.Forms.Label();
            this.txtJoinDate = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.mainLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 2;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.mainLayout.Controls.Add(this.lblHeader, 0, 0);
            this.mainLayout.Controls.Add(this.lblName, 0, 1);
            this.mainLayout.Controls.Add(this.txtName, 1, 1);
            this.mainLayout.Controls.Add(this.lblEmail, 0, 2);
            this.mainLayout.Controls.Add(this.txtEmail, 1, 2);
            this.mainLayout.Controls.Add(this.lblPhone, 0, 3);
            this.mainLayout.Controls.Add(this.txtPhone, 1, 3);
            this.mainLayout.Controls.Add(this.lblStatus, 0, 4);
            this.mainLayout.Controls.Add(this.txtStatus, 1, 4);
            this.mainLayout.Controls.Add(this.lblPassword, 0, 5);
            this.mainLayout.Controls.Add(this.txtPassword, 1, 5);
            this.mainLayout.Controls.Add(this.lblJoinDate, 0, 6);
            this.mainLayout.Controls.Add(this.txtJoinDate, 1, 6);
            this.mainLayout.Controls.Add(this.lblLevel, 0, 7);
            this.mainLayout.Controls.Add(this.txtLevel, 1, 7);
            this.mainLayout.Controls.Add(this.btnEdit, 0, 9);
            this.mainLayout.Controls.Add(this.btnDelete, 0, 10);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.Padding = new System.Windows.Forms.Padding(20);
            this.mainLayout.RowCount = 11;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.mainLayout.Size = new System.Drawing.Size(600, 650);
            this.mainLayout.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.mainLayout.SetColumnSpan(this.lblHeader, 2);
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeader.Font = new System.Drawing.Font("Arial Rounded MT Bold", 26F);
            this.lblHeader.Location = new System.Drawing.Point(23, 20);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(554, 70);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "My Profile";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEdit
            // 
            this.mainLayout.SetColumnSpan(this.btnEdit, 2);
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnEdit.Location = new System.Drawing.Point(20, 530);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(560, 40);
            this.btnEdit.TabIndex = 15;
            this.btnEdit.Text = "Edit Profile";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Firebrick;
            this.mainLayout.SetColumnSpan(this.btnDelete, 2);
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(20, 580);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(560, 40);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Delete Account";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // lblName
            // 
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblName.Location = new System.Drawing.Point(23, 90);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(190, 45);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name:";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtName.Location = new System.Drawing.Point(219, 93);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(358, 29);
            this.txtName.TabIndex = 2;
            // 
            // lblEmail
            // 
            this.lblEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblEmail.Location = new System.Drawing.Point(23, 135);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(190, 45);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "Email:";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEmail
            // 
            this.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtEmail.Location = new System.Drawing.Point(219, 138);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(358, 29);
            this.txtEmail.TabIndex = 4;
            // 
            // lblPhone
            // 
            this.lblPhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblPhone.Location = new System.Drawing.Point(23, 180);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(190, 45);
            this.lblPhone.TabIndex = 5;
            this.lblPhone.Text = "Phone:";
            this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPhone
            // 
            this.txtPhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPhone.Location = new System.Drawing.Point(219, 183);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(358, 29);
            this.txtPhone.TabIndex = 6;
            // 
            // lblLevel
            // 
            this.lblLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLevel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblLevel.Location = new System.Drawing.Point(23, 225);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(190, 45);
            this.lblLevel.TabIndex = 7;
            this.lblLevel.Text = "Level:";
            this.lblLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLevel
            // 
            this.txtLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLevel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtLevel.Location = new System.Drawing.Point(219, 228);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.ReadOnly = true;
            this.txtLevel.Size = new System.Drawing.Size(358, 29);
            this.txtLevel.TabIndex = 8;
            // 
            // lblStatus
            // 
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblStatus.Location = new System.Drawing.Point(23, 270);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(190, 45);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "Status:";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtStatus
            // 
            this.txtStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStatus.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtStatus.Location = new System.Drawing.Point(219, 273);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(358, 29);
            this.txtStatus.TabIndex = 10;
            // 
            // lblJoinDate
            // 
            this.lblJoinDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblJoinDate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblJoinDate.Location = new System.Drawing.Point(23, 315);
            this.lblJoinDate.Name = "lblJoinDate";
            this.lblJoinDate.Size = new System.Drawing.Size(190, 45);
            this.lblJoinDate.TabIndex = 11;
            this.lblJoinDate.Text = "Join Date:";
            this.lblJoinDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtJoinDate
            // 
            this.txtJoinDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtJoinDate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtJoinDate.Location = new System.Drawing.Point(219, 318);
            this.txtJoinDate.Name = "txtJoinDate";
            this.txtJoinDate.ReadOnly = true;
            this.txtJoinDate.Size = new System.Drawing.Size(358, 29);
            this.txtJoinDate.TabIndex = 12;
            // 
            // lblPassword
            // 
            this.lblPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblPassword.Location = new System.Drawing.Point(23, 360);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(190, 45);
            this.lblPassword.TabIndex = 13;
            this.lblPassword.Text = "Password:";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPassword
            // 
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPassword.Location = new System.Drawing.Point(219, 363);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.ReadOnly = true;
            this.txtPassword.Size = new System.Drawing.Size(358, 29);
            this.txtPassword.TabIndex = 14;
            // 
            // Profilepage
            // 
            this.ClientSize = new System.Drawing.Size(600, 650);
            this.Controls.Add(this.mainLayout);
            this.Name = "Profilepage";
            this.Text = "Profile";
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
