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
    partial class EditFacilitypage
    {
        private TableLayoutPanel mainLayout;
        private Label lblHeader, lblName, lblType, lblLocation, lblAvailability, lblCapacity, lblJoinDate;
        private TextBox txtName, txtType, txtLocation, txtAvailability, txtCapacity, txtHourlyRate;
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
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblAvailability = new System.Windows.Forms.Label();
            this.txtAvailability = new System.Windows.Forms.TextBox();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.txtCapacity = new System.Windows.Forms.TextBox();
            this.lblJoinDate = new System.Windows.Forms.Label();
            this.txtHourlyRate = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
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
            this.mainLayout.Controls.Add(this.lblType, 0, 2);
            this.mainLayout.Controls.Add(this.txtType, 1, 2);
            this.mainLayout.Controls.Add(this.lblLocation, 0, 3);
            this.mainLayout.Controls.Add(this.txtLocation, 1, 3);
            this.mainLayout.Controls.Add(this.lblAvailability, 0, 4);
            this.mainLayout.Controls.Add(this.txtAvailability, 1, 4);
            this.mainLayout.Controls.Add(this.lblCapacity, 0, 5);
            this.mainLayout.Controls.Add(this.txtCapacity, 1, 5);
            this.mainLayout.Controls.Add(this.lblJoinDate, 0, 6);
            this.mainLayout.Controls.Add(this.txtHourlyRate, 1, 6);
            this.mainLayout.Controls.Add(this.btnSave, 0, 9);
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
            // lblHeader
            // 
            this.mainLayout.SetColumnSpan(this.lblHeader, 2);
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeader.Font = new System.Drawing.Font("Arial Rounded MT Bold", 26F);
            this.lblHeader.Location = new System.Drawing.Point(23, 20);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(554, 70);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Edit Facility";
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
            this.txtName.Size = new System.Drawing.Size(358, 50);
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
            this.txtType.Size = new System.Drawing.Size(358, 50);
            this.txtType.TabIndex = 4;
            // 
            // lblLocation
            // 
            this.lblLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLocation.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblLocation.Location = new System.Drawing.Point(23, 180);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(190, 45);
            this.lblLocation.TabIndex = 5;
            this.lblLocation.Text = "Location:";
            this.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLocation
            // 
            this.txtLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLocation.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtLocation.Location = new System.Drawing.Point(219, 183);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(358, 50);
            this.txtLocation.TabIndex = 6;
            // 
            // lblAvailability
            // 
            this.lblAvailability.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAvailability.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblAvailability.Location = new System.Drawing.Point(23, 225);
            this.lblAvailability.Name = "lblAvailability";
            this.lblAvailability.Size = new System.Drawing.Size(190, 45);
            this.lblAvailability.TabIndex = 7;
            this.lblAvailability.Text = "Availability:";
            this.lblAvailability.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAvailability
            // 
            this.txtAvailability.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAvailability.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAvailability.Location = new System.Drawing.Point(219, 228);
            this.txtAvailability.Name = "txtAvailability";
            this.txtAvailability.Size = new System.Drawing.Size(358, 50);
            this.txtAvailability.TabIndex = 8;
            // 
            // lblCapacity
            // 
            this.lblCapacity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCapacity.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCapacity.Location = new System.Drawing.Point(23, 270);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(190, 45);
            this.lblCapacity.TabIndex = 9;
            this.lblCapacity.Text = "Capacity:";
            this.lblCapacity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCapacity
            // 
            this.txtCapacity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCapacity.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCapacity.Location = new System.Drawing.Point(219, 273);
            this.txtCapacity.Name = "txtCapacity";
            this.txtCapacity.Size = new System.Drawing.Size(358, 50);
            this.txtCapacity.TabIndex = 10;
            // 
            // lblJoinDate
            // 
            this.lblJoinDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblJoinDate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblJoinDate.Location = new System.Drawing.Point(23, 315);
            this.lblJoinDate.Name = "lblJoinDate";
            this.lblJoinDate.Size = new System.Drawing.Size(190, 45);
            this.lblJoinDate.TabIndex = 11;
            this.lblJoinDate.Text = "Hourly Rate";
            this.lblJoinDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtHourlyRate
            // 
            this.txtHourlyRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHourlyRate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtHourlyRate.Location = new System.Drawing.Point(219, 318);
            this.txtHourlyRate.Name = "txtHourlyRate";
            this.txtHourlyRate.Size = new System.Drawing.Size(358, 50);
            this.txtHourlyRate.TabIndex = 12;
            // 
            // btnSave
            // 
            this.mainLayout.SetColumnSpan(this.btnSave, 2);
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(23, 533);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(554, 44);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save Changes";
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
            // EditFacilitypage
            // 
            this.ClientSize = new System.Drawing.Size(600, 650);
            this.Controls.Add(this.mainLayout);
            this.Name = "EditFacilitypage";
            this.Text = "Edit Member Profile";
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
