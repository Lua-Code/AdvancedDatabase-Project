using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using MongoDB.Bson;
using System.Drawing;

namespace Booking_app
{
    public partial class Facilitypage : Form
    {
        private BookingService bookingService;
        private StaffService staffService;
        private FacilityService facilityService;
        private List<Booking> selectedBookings = new List<Booking>();

        public ObjectId FacilityId { get; set; } 

        public Facilitypage(ObjectId facilityId)
        {
            InitializeComponent();
            FacilityId = facilityId;
            bookingService = new BookingService();
            staffService = new StaffService();
            facilityService = new FacilityService();

            bookingService.StaffService = staffService;
            staffService.BookingService = bookingService; 

            this.Load += Facilitypage_Load;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
            bookButton.Click += reserve_Click;
            backButtn.Click += backButtn_Click;

            if(Session.IsStaff) { bookButton.Visible = false; }

        }

        private void Facilitypage_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Loading Faiclity");
            dateTimePicker1.Value = dateTimePicker1.Value.Date;
            LoadBookingsForDate(dateTimePicker1.Value.Date);

            var facility = facilityService.GetById(FacilityId);
            courtName.Text = facility.name.ToString();
            locationLabel.Text = "Location: " + facility.location.ToString();
            typeLabel.Text = "Type: " + facility.type.ToString();
            capacityLabel.Text = "Capacity: " + facility.capacity.ToString();
            priceLabel.Text = "Price: "+ facilityService.GetPriceByMembershipLevel(Session.GetUserId,FacilityId);

            string imagePath;
            if (facility.type == "Room")
            {
                string typeOfRoom = facility.name.Split(' ')[0];
                Console.WriteLine($"Type of room: {typeOfRoom}");
                imagePath = Path.Combine(Application.StartupPath, "Assets", typeOfRoom + ".jpg");
            }
            else if (facility.type == "Football")
            {
                imagePath = Path.Combine(Application.StartupPath, "Assets", "Football.webp");
            }
            else
            {
                imagePath = Path.Combine(Application.StartupPath, "Assets", facility.type + ".jpg");

            }
            Image img = File.Exists(imagePath) ? Image.FromFile(imagePath) : null;

            pictureBox1.Image = img;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

        }


        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.Date;
            LoadBookingsForDate(dateTimePicker1.Value.Date);
            Console.WriteLine($"Now Checking for date {dateTimePicker1.Value.Date}");
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

            Console.WriteLine("Available slots:");
            foreach (var slot in availableSlots)
            {
                Console.WriteLine($"{slot.Start}:00 - {slot.End}:00");
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
            Console.WriteLine(selectedSlots.Count);

            var hourlyRate = facilityService.GetPriceByMembershipLevel(Session.GetUserId, FacilityId);

            priceLabel.Text = "Price: " + hourlyRate* selectedSlots.Count;


        }

        private void paymentCompleted_Event(object sender, EventArgs e) {

            LoadBookingsForDate(dateTimePicker1.Value.Date);
        }



        private void reserve_Click(object sender, EventArgs e)
        {

            var hourlyRate = facilityService.GetPriceByMembershipLevel(Session.GetUserId, FacilityId);
            decimal totalAmount = hourlyRate * selectedSlots.Count;
            ObjectId memId = Session.GetUserId;


            PaymentForm paymentPage = new PaymentForm(memId, FacilityId, totalAmount, selectedSlots, dateTimePicker1.Value.Date);
            paymentPage.Show();
            paymentPage.PaymentCompleted += paymentCompleted_Event;
            //MessageBox.Show($"You selected {selectedSlots.Count} slot(s) to book.");
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

        private void locationLabel_Click(object sender, EventArgs e)
        {

        }

        private void typeLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
