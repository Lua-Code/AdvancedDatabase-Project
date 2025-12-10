using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;

namespace Booking_app
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Test Program
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Loginpage());
            //Application.Run(new Facilitypage(mockFacility));
            //Application.Run(new MyBookingspage(new ObjectId("692ef10a0efaf54d2d348b3c")));
        }
    }
}
