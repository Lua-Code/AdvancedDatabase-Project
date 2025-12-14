using System;
using System.Drawing;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Booking_app
{
    public partial class PaymentForm : Form
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


            bookingService.CreateBookings(MemberId, FacilityId, SelectedSlots,BookingDate,method);
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
