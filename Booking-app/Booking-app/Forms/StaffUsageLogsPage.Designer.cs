using System;
using System.Windows.Forms;

namespace Booking_app
{
    partial class StaffUsageLogsPage
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvPending;
        private DataGridView dgvExisting;
        private Button btnAddLog;
        private Button btnBack;
        private Label lblPendingTitle;
        private Label lblExistingTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvPending = new DataGridView();
            this.dgvExisting = new DataGridView();
            this.btnAddLog = new Button();
            this.btnBack = new Button();
            this.lblPendingTitle = new Label();
            this.lblExistingTitle = new Label();
            this.SuspendLayout();

            // Labels
            lblPendingTitle.Text = "Pending Bookings";
            lblPendingTitle.Location = new System.Drawing.Point(20, 10);
            lblPendingTitle.AutoSize = true;

            lblExistingTitle.Text = "Existing Usage Logs";
            lblExistingTitle.Location = new System.Drawing.Point(20, 230);
            lblExistingTitle.AutoSize = true;

            // dgvPending
            dgvPending.Location = new System.Drawing.Point(20, 30);
            dgvPending.Size = new System.Drawing.Size(700, 180);
            dgvPending.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPending.MultiSelect = false;
            dgvPending.AllowUserToAddRows = false;
            dgvPending.ReadOnly = true;
            dgvPending.ColumnCount = 5;
            dgvPending.Columns[0].Name = "Booking ID";
            dgvPending.Columns[1].Name = "Member Name";
            dgvPending.Columns[2].Name = "Facility Name";
            dgvPending.Columns[3].Name = "Start Time";
            dgvPending.Columns[4].Name = "End Time";

            // dgvExisting
            dgvExisting.Location = new System.Drawing.Point(20, 250);
            dgvExisting.Size = new System.Drawing.Size(700, 180);
            dgvExisting.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExisting.AllowUserToAddRows = false;
            dgvExisting.ReadOnly = true;
            dgvExisting.ColumnCount = 6;
            dgvExisting.Columns[0].Name = "Usage Log ID";
            dgvExisting.Columns[1].Name = "Booking ID";
            dgvExisting.Columns[2].Name = "Member Name";
            dgvExisting.Columns[3].Name = "Facility Name";
            dgvExisting.Columns[4].Name = "Start Time";
            dgvExisting.Columns[5].Name = "End Time";

            // Buttons
            btnAddLog.Text = "Add Usage Log";
            btnAddLog.Location = new System.Drawing.Point(740, 50);

            btnBack.Text = "Back";
            btnBack.Location = new System.Drawing.Point(740, 100);

            // Form
            this.ClientSize = new System.Drawing.Size(900, 450);
            this.Controls.Add(lblPendingTitle);
            this.Controls.Add(dgvPending);
            this.Controls.Add(lblExistingTitle);
            this.Controls.Add(dgvExisting);
            this.Controls.Add(btnAddLog);
            this.Controls.Add(btnBack);
            this.Text = "Staff Usage Logs";

            ((System.ComponentModel.ISupportInitialize)(dgvPending)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dgvExisting)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
