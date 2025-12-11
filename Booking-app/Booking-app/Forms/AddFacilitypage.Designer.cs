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
    partial class AddFacilitypage
    {
        private TableLayoutPanel mainLayout;
        private Label lblHeader, lblType, lblRole;
        private TextBox txtName, txtType, txtLocation, txtCapacity, txtHourlyRate;
        private Button btnAdd, btnCancel;
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
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.txtCapacity = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtHourlyRate = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.mainLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 2;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.mainLayout.Controls.Add(this.lblLocation, 0, 3);
            this.mainLayout.Controls.Add(this.lblHeader, 0, 0);
            this.mainLayout.Controls.Add(this.lblName, 0, 1);
            this.mainLayout.Controls.Add(this.txtName, 1, 1);
            this.mainLayout.Controls.Add(this.lblType, 0, 2);
            this.mainLayout.Controls.Add(this.txtType, 1, 2);
            this.mainLayout.Controls.Add(this.txtLocation, 1, 3);
            this.mainLayout.Controls.Add(this.lblRole, 0, 4);
            this.mainLayout.Controls.Add(this.txtCapacity, 1, 4);
            this.mainLayout.Controls.Add(this.lblPhone, 0, 5);
            this.mainLayout.Controls.Add(this.txtHourlyRate, 1, 5);
            this.mainLayout.Controls.Add(this.btnAdd, 0, 9);
            this.mainLayout.Controls.Add(this.btnCancel, 0, 10);
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
            // lblLocation
            // 
            this.lblLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLocation.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblLocation.Location = new System.Drawing.Point(23, 180);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(190, 45);
            this.lblLocation.TabIndex = 17;
            this.lblLocation.Text = "Location:";
            this.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.lblHeader.Text = "Add New Facility";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtName.Location = new System.Drawing.Point(219, 93);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(358, 29);
            this.txtName.TabIndex = 2;
            // 
            // lblType
            // 
            this.lblType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblType.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblType.Location = new System.Drawing.Point(23, 135);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(190, 45);
            this.lblType.TabIndex = 3;
            this.lblType.Text = "Type:";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtType
            // 
            this.txtType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtType.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtType.Location = new System.Drawing.Point(219, 138);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(358, 29);
            this.txtType.TabIndex = 4;
            // 
            // txtLocation
            // 
            this.txtLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLocation.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtLocation.Location = new System.Drawing.Point(219, 183);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(358, 29);
            this.txtLocation.TabIndex = 6;
            // 
            // lblRole
            // 
            this.lblRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblRole.Location = new System.Drawing.Point(23, 225);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(190, 45);
            this.lblRole.TabIndex = 7;
            this.lblRole.Text = "Capacity:";
            this.lblRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCapacity
            // 
            this.txtCapacity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCapacity.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCapacity.Location = new System.Drawing.Point(219, 228);
            this.txtCapacity.Name = "txtCapacity";
            this.txtCapacity.Size = new System.Drawing.Size(358, 29);
            this.txtCapacity.TabIndex = 8;
            // 
            // lblPhone
            // 
            this.lblPhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblPhone.Location = new System.Drawing.Point(23, 270);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(190, 45);
            this.lblPhone.TabIndex = 9;
            this.lblPhone.Text = "Hourly Rate:";
            this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtHourlyRate
            // 
            this.txtHourlyRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHourlyRate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtHourlyRate.Location = new System.Drawing.Point(219, 273);
            this.txtHourlyRate.Name = "txtHourlyRate";
            this.txtHourlyRate.Size = new System.Drawing.Size(358, 29);
            this.txtHourlyRate.TabIndex = 10;
            // 
            // btnAdd
            // 
            this.mainLayout.SetColumnSpan(this.btnAdd, 2);
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Location = new System.Drawing.Point(23, 533);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(554, 44);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "Add";
            // 
            // btnCancel
            // 
            this.mainLayout.SetColumnSpan(this.btnCancel, 2);
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(23, 583);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(554, 44);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            // 
            // AddFacilitypage
            // 
            this.ClientSize = new System.Drawing.Size(600, 650);
            this.Controls.Add(this.mainLayout);
            this.Name = "AddFacilitypage";
            this.Text = "Edit Member Profile";
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.ResumeLayout(false);

        }
        private Label lblLocation;
        private Label lblName;
        private Label lblPhone;
    }
}
