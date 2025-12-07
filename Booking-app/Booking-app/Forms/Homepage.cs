using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MongoDB.Bson;

namespace Booking_app
{
    public partial class Homepage : Form
    {

        FacilityService facilityService;
        public Homepage()
        {
            InitializeComponent();
            facilityService = new FacilityService();
        }



        private Panel CreateCard(string name,ObjectId facility_id, Image img = null)
        {
            Panel card = new Panel
            {
                Width = 180,
                Height = 150,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10),
                Cursor = Cursors.Hand,
                Tag = facility_id
            };

            PictureBox pb = new PictureBox
            {
                Dock = DockStyle.Top,
                Height = 100,
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = img
            };

            Label label = new Label
            {
                Text = name,
                Dock = DockStyle.Bottom,
                TextAlign = ContentAlignment.MiddleCenter,
                Height = 30
            };

            card.Controls.Add(label);
            card.Controls.Add(pb);

            card.Click += (s, e) => OnCardClick(name);
            pb.Click += (s, e) => OnCardClick(name);
            label.Click += (s, e) => OnCardClick(name);

            card.MouseEnter += (s, e) => card.BackColor = Color.FromKnownColor(KnownColor.ControlDark);
            pb.MouseEnter += (s, e) => card.BackColor = Color.FromKnownColor(KnownColor.ControlDark);
            label.MouseEnter += (s, e) => card.BackColor = Color.FromKnownColor(KnownColor.ControlDark);
            card.MouseLeave += (s, e) => card.BackColor = Color.White;
            pb.MouseLeave += (s, e) => card.BackColor = Color.White;
            label.MouseLeave += (s, e) => card.BackColor = Color.White;

            return card;
        }

        private void OnCardClick(string name)
        {
            MessageBox.Show($"You clicked on {name}");
        }

        private void addFacilitySection(string title, List<Facility> facilities)
        {
            Label label = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                AutoSize = false,
                Height = 40,
                Dock = DockStyle.Top,
                Padding = new Padding(10, 5, 0, 5),
                Margin = new Padding(0, 0, 0, 10)
            };

            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 30),
                Padding = new Padding(10)
            };

            foreach (var facility in facilities)
            {
                flowLayoutPanel.Controls.Add(CreateCard(facility.name,facility.Id));
            }
            mainFlow.Controls.Add(label);
            mainFlow.Controls.Add(flowLayoutPanel);
        }

        private void Homepage_Load(object sender, EventArgs e)
        {
            Console.WriteLine("meow");
            var types = facilityService.GetDistinctTypes();
            Console.WriteLine($"Found {types.Count} types");

            foreach (var type in types)
            {
                var facilities = facilityService.GetByType(type);
                addFacilitySection(type + ":", facilities);
            }
        }

    }
}
