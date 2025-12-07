using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using MongoDB.Bson;

namespace Booking_app
{
    public partial class Facilitypage : Form
    {
        private BookingService bookingService;
        private List<Booking> selectedBookings = new List<Booking>();

        public ObjectId FacilityId { get; set; } 

        public Facilitypage(ObjectId facilityId)
        {
            InitializeComponent();
            FacilityId = facilityId;
            bookingService = new BookingService();

            this.Load += Facilitypage_Load;
            dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
            listBox1.SelectionMode = SelectionMode.MultiSimple;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            bookButton.Click += reserve_Click;
            backButtn.Click += backButtn_Click;
        }

        private void Facilitypage_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.Date;
            LoadBookingsForDate(dateTimePicker1.Value.Date);
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.Date;
            LoadBookingsForDate(dateTimePicker1.Value.Date);
            Debug.WriteLine($"Now Checking for date {dateTimePicker1.Value.Date}");
        }

        private List<(int Start, int End)> availableSlots = new List<(int, int)>();

        private void LoadBookingsForDate(DateTime date)
        {
            listBox1.Items.Clear();
            availableSlots = bookingService.GetAvailableSlots(FacilityId, date);

            foreach (var slot in availableSlots)
            {
                listBox1.Items.Add($"{slot.Start}:00-{slot.End}:00");
            }
        }


        private List<(int Start, int End)> selectedSlots = new List<(int, int)>();

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSlots.Clear();

            foreach (int index in listBox1.SelectedIndices)
            {
                if (index < availableSlots.Count)
                {
                    selectedSlots.Add(availableSlots[index]);
                }
            }
        }



        private void reserve_Click(object sender, EventArgs e)
        {
            // open BoookPage
            MessageBox.Show($"You selected {selectedBookings.Count} slot(s) to book.");
        }

        private void backButtn_Click(object sender, EventArgs e)
        {
            Form Homepage = new Homepage();
            Homepage.Show();
            this.Close();
        }



        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e) { }
    }
}
