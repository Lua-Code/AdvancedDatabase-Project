using System;
using System.Windows.Forms;

namespace Booking_app
{
    partial class AddUsage
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblBookingInfo;
        private NumericUpDown numStart;
        private NumericUpDown numEnd;
        private Label lblDuration;
        private Button btnSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblBookingInfo = new Label();
            this.numStart = new NumericUpDown();
            this.numEnd = new NumericUpDown();
            this.lblDuration = new Label();
            this.btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.numStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEnd)).BeginInit();
            this.SuspendLayout();

            // lblBookingInfo
            lblBookingInfo.Location = new System.Drawing.Point(20, 20);
            lblBookingInfo.Size = new System.Drawing.Size(300, 60);
            lblBookingInfo.AutoSize = true;

            // numStart
            numStart.Location = new System.Drawing.Point(20, 90);
            numStart.Minimum = 0;
            numStart.Maximum = 23;

            // numEnd
            numEnd.Location = new System.Drawing.Point(150, 90);
            numEnd.Minimum = 0;
            numEnd.Maximum = 23;

            // lblDuration
            lblDuration.Location = new System.Drawing.Point(20, 130);
            lblDuration.AutoSize = true;

            // btnSave
            btnSave.Text = "Save Usage Log";
            btnSave.Location = new System.Drawing.Point(20, 170);

            // Form
            this.ClientSize = new System.Drawing.Size(400, 220);
            this.Controls.Add(lblBookingInfo);
            this.Controls.Add(numStart);
            this.Controls.Add(numEnd);
            this.Controls.Add(lblDuration);
            this.Controls.Add(btnSave);
            this.Text = "Add Usage Log";

            ((System.ComponentModel.ISupportInitialize)(numStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(numEnd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
