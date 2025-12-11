using System;
using System.Drawing;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Booking_app
{
    public class PaymentForm : Form
    {

        PaymentService paymentService;
        BookingService bookingService;
        StaffService staffService;
        // External values to receive when opening the form
        private ObjectId MemberId { get; set; }
        private ObjectId FacilityId { get; set; }
        private decimal Amount { get; set; }

        private List<(int Start, int End)> SelectedSlots;

        private DateTime BookingDate;

        public event EventHandler PaymentCompleted;

        RadioButton rbCard, rbCash;
        TextBox txtCardNumber, txtFirstName, txtLastName, txtExpiry, txtCvv;
        Button btnPay, btnCancel;

        public PaymentForm(ObjectId memberId,ObjectId facilityid, decimal amount, List<(int Start, int End)> selectedSlots,DateTime bookingDate)
        {

            InitializeComponent();

            paymentService = new PaymentService();
            bookingService = new BookingService();
            staffService = new StaffService();

            bookingService.StaffService = staffService;
            staffService.BookingService = bookingService;

            MemberId = memberId;
            FacilityId = facilityid;
            Amount = amount;
            SelectedSlots = selectedSlots;
            BookingDate = bookingDate;


        }

        private void InitializeComponent()
        {
            this.Text = "Payment";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Width = 350;
            this.Height = 550;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            var lblTitle = new Label()
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
            var lblCardNumber = new Label() { Text = "Card Number", Location = new Point(25, 160), AutoSize = true, Visible = false };
            var lblFirstName = new Label() { Text = "First Name", Location = new Point(25, 200), AutoSize = true, Visible = false };
            var lblLastName = new Label() { Text = "Last Name", Location = new Point(25, 240), AutoSize = true, Visible = false };
            var lblExpiry = new Label() { Text = "Expiry (MM/YY)", Location = new Point(25, 280), AutoSize = true, Visible = false };
            var lblCvv = new Label() { Text = "CVV", Location = new Point(140, 280), AutoSize = true, Visible = false };

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
            rbCard.CheckedChanged += (s, e) =>
            {
                bool show = rbCard.Checked;
                lblCardNumber.Visible = show;
                lblFirstName.Visible = show;
                lblLastName.Visible = show;
                lblExpiry.Visible = show;
                lblCvv.Visible = show;
            };
        }



        private void RbCard_CheckedChanged(object sender, EventArgs e)
        {
            bool show = rbCard.Checked;

            txtCardNumber.Visible = show;
            txtFirstName.Visible = show;
            txtLastName.Visible = show;
            txtExpiry.Visible = show;
            txtCvv.Visible = show;
        }

        private void RbCash_CheckedChanged(object sender, EventArgs e)
        {
            txtCardNumber.Visible = false;
            txtFirstName.Visible = false;
            txtLastName.Visible = false;
            txtExpiry.Visible = false;
            txtCvv.Visible = false;
        }

        private void BtnPay_Click(object sender, EventArgs e)
        {
            string method = rbCard.Checked ? "Card" :
                            rbCash.Checked ? "Cash" : null;

            if (method == null)
            {
                MessageBox.Show("Please select a payment method.");
                return;
            }

            if (method == "Card")
            {
                if (string.IsNullOrWhiteSpace(txtCardNumber.Text) ||
                    string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                    string.IsNullOrWhiteSpace(txtLastName.Text) ||
                    string.IsNullOrWhiteSpace(txtExpiry.Text) ||
                    string.IsNullOrWhiteSpace(txtCvv.Text))
                {
                    MessageBox.Show("Please fill all card fields.");
                    return;
                }
            }


            bookingService.CreateBookings(MemberId, FacilityId, SelectedSlots,BookingDate);
            MessageBox.Show("Payment recorded successfully!");

            this.DialogResult = DialogResult.OK;
            PaymentCompleted.Invoke(this, EventArgs.Empty);
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
