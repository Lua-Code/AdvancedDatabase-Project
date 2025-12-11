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
    public partial class Homepage : Form
    {

        FacilityService facilityService;
        MemberService memberService;
        AuthService authService;
        public Homepage()
        {
            InitializeComponent();
            facilityService = new FacilityService();
            memberService = new MemberService();
            authService = new AuthService();

            myBookingsButton.Click += (s, e) =>
            {
                if(Session.IsStaff)
                {
                    MessageBox.Show("Staff members do not have bookings. :(((");
                    return;
                }
                Form myBookingsForm = new MyBookingspage();
                myBookingsForm.Show();
            };

            logoutButton.Click += (s, e) =>
            {
                authService.Logout();
                Loginpage loginpage = new Loginpage();
                loginpage.Show();
                this.Close();
            };

            profileButton.Click += (s, e) =>
            {
                Profilepage profilepage = new Profilepage();
                profilepage.Show();


            };

            if(Session.IsStaff)
            {
                myBookingsButton.Visible = false;
                if (Session.getStaffRole() != "Supervisor") { 
                    addStaffButton.Visible = false;
                }

            }
            if (Session.IsMember) { 
                addStaffButton.Visible= false;
                addFacilityButton.Visible= false;
                usageLogsButton.Visible= false;
            }


        }



        private Panel CreateCard(string name, ObjectId facility_id, string type)
        {
            string imagePath;
            if (type == "Room") {
                string typeOfRoom = name.Split(' ')[0]; 
                imagePath = Path.Combine(Application.StartupPath, "Assets", typeOfRoom + ".jpg");
            }
            else if (type == "Football")
            {
                imagePath = Path.Combine(Application.StartupPath, "Assets", "Football.webp");
            }
            else
            {
                imagePath = Path.Combine(Application.StartupPath, "Assets", type + ".jpg");

            }
            Image img = File.Exists(imagePath) ? Image.FromFile(imagePath) : null;

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
                SizeMode = PictureBoxSizeMode.StretchImage,
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

            card.Click += (s, e) => OnCardClick(facility_id);
            pb.Click += (s, e) => OnCardClick(facility_id);
            label.Click += (s, e) => OnCardClick(facility_id);

            card.MouseEnter += (s, e) => card.BackColor = Color.FromKnownColor(KnownColor.ControlDark);
            pb.MouseEnter += (s, e) => card.BackColor = Color.FromKnownColor(KnownColor.ControlDark);
            label.MouseEnter += (s, e) => card.BackColor = Color.FromKnownColor(KnownColor.ControlDark);
            card.MouseLeave += (s, e) => card.BackColor = Color.White;
            pb.MouseLeave += (s, e) => card.BackColor = Color.White;
            label.MouseLeave += (s, e) => card.BackColor = Color.White;

            return card;
        }


        private void OnCardClick(ObjectId facility_id)
        {
            Facilitypage facilityPage = new Facilitypage(facility_id);
            facilityPage.Show();
            this.Hide();
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
                flowLayoutPanel.Controls.Add(CreateCard(facility.name,facility.Id,facility.type));
            }
            mainFlow.Controls.Add(label);
            mainFlow.Controls.Add(flowLayoutPanel);
        }

        private void Homepage_Load(object sender, EventArgs e)
        {
            var types = facilityService.GetDistinctTypes();

            foreach (var type in types)
            {
                var facilities = facilityService.GetByType(type);
                addFacilitySection(type + ":", facilities);
            }
        }



    }
}
