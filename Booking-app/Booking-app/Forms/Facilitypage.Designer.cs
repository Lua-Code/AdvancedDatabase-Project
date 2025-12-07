using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Booking_app
{
    partial class Facilitypage : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backButtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.courtName = new System.Windows.Forms.Label();
            this.locationLabel = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.capacityLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.bookButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.datelabel = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // backButtn
            // 
            this.backButtn.Location = new System.Drawing.Point(10, 10);
            this.backButtn.Name = "backButtn";
            this.backButtn.Size = new System.Drawing.Size(64, 20);
            this.backButtn.TabIndex = 0;
            this.backButtn.Text = "back";
            this.backButtn.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(10, 75);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(507, 267);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // courtName
            // 
            this.courtName.AutoSize = true;
            this.courtName.Location = new System.Drawing.Point(212, 45);
            this.courtName.Name = "courtName";
            this.courtName.Size = new System.Drawing.Size(35, 13);
            this.courtName.TabIndex = 2;
            this.courtName.Text = "Name";
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(58, 404);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(48, 13);
            this.locationLabel.TabIndex = 3;
            this.locationLabel.Text = "Location";
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(58, 447);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(31, 13);
            this.typeLabel.TabIndex = 4;
            this.typeLabel.Text = "Type";
            // 
            // capacityLabel
            // 
            this.capacityLabel.AutoSize = true;
            this.capacityLabel.Location = new System.Drawing.Point(58, 495);
            this.capacityLabel.Name = "capacityLabel";
            this.capacityLabel.Size = new System.Drawing.Size(48, 13);
            this.capacityLabel.TabIndex = 5;
            this.capacityLabel.Text = "Capacity";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(735, 357);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(34, 13);
            this.priceLabel.TabIndex = 6;
            this.priceLabel.Text = "Price:";
            // 
            // bookButton
            // 
            this.bookButton.Location = new System.Drawing.Point(719, 385);
            this.bookButton.Name = "bookButton";
            this.bookButton.Size = new System.Drawing.Size(100, 50);
            this.bookButton.TabIndex = 7;
            this.bookButton.Text = "Book Now";
            this.bookButton.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(538, 114);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(514, 212);
            this.listBox1.TabIndex = 8;
            // 
            // datelabel
            // 
            this.datelabel.AutoSize = true;
            this.datelabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datelabel.Location = new System.Drawing.Point(562, 82);
            this.datelabel.Name = "datelabel";
            this.datelabel.Size = new System.Drawing.Size(155, 25);
            this.datelabel.TabIndex = 9;
            this.datelabel.Text = "Select date , time";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(735, 84);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(172, 20);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // Facilitypage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 590);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.datelabel);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.bookButton);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.capacityLabel);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.locationLabel);
            this.Controls.Add(this.courtName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.backButtn);
            this.Name = "Facilitypage";
            this.Text = "Facilitypage";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button backButtn;
        private PictureBox pictureBox1;
        private Label courtName;
        private Label locationLabel;
        private Label typeLabel;
        private Label capacityLabel;
        private Label priceLabel;
        private Button bookButton;
        private ListBox listBox1;
        private Label datelabel;
        private DateTimePicker dateTimePicker1;
    }
}
