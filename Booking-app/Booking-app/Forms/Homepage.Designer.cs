namespace Booking_app
{
    partial class Homepage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.logoutButton = new System.Windows.Forms.Button();
            this.profileButton = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.Label();
            this.myBookingsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainFlow
            // 
            this.mainFlow.AutoScroll = true;
            this.mainFlow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainFlow.BackColor = System.Drawing.SystemColors.ControlLight;
            this.mainFlow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.mainFlow.Location = new System.Drawing.Point(0, 70);
            this.mainFlow.Margin = new System.Windows.Forms.Padding(0);
            this.mainFlow.Name = "mainFlow";
            this.mainFlow.Padding = new System.Windows.Forms.Padding(20);
            this.mainFlow.Size = new System.Drawing.Size(1265, 612);
            this.mainFlow.TabIndex = 0;
            this.mainFlow.WrapContents = false;
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(1145, 12);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(107, 34);
            this.logoutButton.TabIndex = 1;
            this.logoutButton.Text = "Log Out";
            this.logoutButton.UseVisualStyleBackColor = true;
            // 
            // profileButton
            // 
            this.profileButton.Location = new System.Drawing.Point(1032, 13);
            this.profileButton.Name = "profileButton";
            this.profileButton.Size = new System.Drawing.Size(107, 34);
            this.profileButton.TabIndex = 2;
            this.profileButton.Text = "Profile";
            this.profileButton.UseVisualStyleBackColor = true;
            // 
            // name
            // 
            this.name.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(12, 8);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(258, 38);
            this.name.TabIndex = 3;
            this.name.Text = "Ventura Club";
            this.name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // myBookingsButton
            // 
            this.myBookingsButton.Location = new System.Drawing.Point(251, 13);
            this.myBookingsButton.Name = "myBookingsButton";
            this.myBookingsButton.Size = new System.Drawing.Size(107, 34);
            this.myBookingsButton.TabIndex = 4;
            this.myBookingsButton.Text = "My Bookings";
            this.myBookingsButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.myBookingsButton);
            this.Controls.Add(this.name);
            this.Controls.Add(this.profileButton);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.mainFlow);
            this.Name = "Form1";
            this.Text = "Home Page";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Homepage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel mainFlow;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button profileButton;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Button myBookingsButton;
    }
}

