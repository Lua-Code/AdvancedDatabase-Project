using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System;

namespace Booking_app{



    partial class PaymentForm {
        Label lblTitle;

        Label lblCardNumber;
        Label lblFirstName;
        Label lblLastName;
        Label lblExpiry;
        Label lblCvv;
        private void InitializeComponent()
        {
            this.Text = "Payment";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Width = 350;
            this.Height = 550;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            lblTitle = new Label()
            {
                Text = "Payment",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(120, 20)
            };

            var lblMethod = new Label()
            {
                Text = "Select payment method:",
                Font = new Font("Segoe UI", 10),
                AutoSize = true,
                Location = new Point(20, 70)
            };

            rbCard = new RadioButton()
            {
                Text = "Credit / Debit Card",
                Location = new Point(25, 100),
                AutoSize = true
            };
            rbCard.CheckedChanged += RbCard_CheckedChanged;

            rbCash = new RadioButton()
            {
                Text = "Cash",
                Location = new Point(25, 130),
                AutoSize = true
            };
            rbCash.CheckedChanged += RbCash_CheckedChanged;

            // Labels for card fields
            lblCardNumber = new Label() { Text = "Card Number", Location = new Point(25, 160), AutoSize = true, Visible = false };
            lblFirstName = new Label() { Text = "First Name", Location = new Point(25, 200), AutoSize = true, Visible = false };
            lblLastName = new Label() { Text = "Last Name", Location = new Point(25, 240), AutoSize = true, Visible = false };
            lblExpiry = new Label() { Text = "Expiry (MM/YY)", Location = new Point(25, 280), AutoSize = true, Visible = false };
            lblCvv = new Label() { Text = "CVV", Location = new Point(140, 280), AutoSize = true, Visible = false };

            txtCardNumber = new TextBox() { Location = new Point(25, 180), Width = 250, Visible = false };
            txtFirstName = new TextBox() { Location = new Point(25, 220), Width = 250, Visible = false };
            txtLastName = new TextBox() { Location = new Point(25, 260), Width = 250, Visible = false };
            txtExpiry = new TextBox() { Location = new Point(25, 300), Width = 100, Visible = false };
            txtCvv = new TextBox() { Location = new Point(140, 300), Width = 80, Visible = false };

            btnPay = new Button() { Text = "Pay", Location = new Point(25, 350), Width = 120, Height = 30 };
            btnPay.Click += BtnPay_Click;

            btnCancel = new Button() { Text = "Cancel", Location = new Point(155, 350), Width = 120, Height = 30 };
            btnCancel.Click += BtnCancel_Click;

            this.Controls.Add(lblTitle);
            this.Controls.Add(lblMethod);
            this.Controls.Add(rbCard);
            this.Controls.Add(rbCash);

            this.Controls.Add(lblCardNumber);
            this.Controls.Add(lblFirstName);
            this.Controls.Add(lblLastName);
            this.Controls.Add(lblExpiry);
            this.Controls.Add(lblCvv);

            this.Controls.Add(txtCardNumber);
            this.Controls.Add(txtFirstName);
            this.Controls.Add(txtLastName);
            this.Controls.Add(txtExpiry);
            this.Controls.Add(txtCvv);

            this.Controls.Add(btnPay);
            this.Controls.Add(btnCancel);

            // show/hide labels together with textboxes

        }



    }




}
