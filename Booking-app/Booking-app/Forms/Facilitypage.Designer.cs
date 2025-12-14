using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Runtime.CompilerServices;

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
            this.updateBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // backButtn
            // 
            this.backButtn.Location = new System.Drawing.Point(20, 19);
            this.backButtn.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.backButtn.Name = "backButtn";
            this.backButtn.Size = new System.Drawing.Size(128, 38);
            this.backButtn.TabIndex = 0;
            this.backButtn.Text = "back";
            this.backButtn.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(58, 144);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(976, 513);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // courtName
            // 
            this.courtName.AutoSize = true;
            this.courtName.Location = new System.Drawing.Point(424, 87);
            this.courtName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.courtName.Name = "courtName";
            this.courtName.Size = new System.Drawing.Size(68, 25);
            this.courtName.TabIndex = 2;
            this.courtName.Text = "Name";
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(52, 740);
            this.locationLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(94, 25);
            this.locationLabel.TabIndex = 3;
            this.locationLabel.Text = "Location";
            this.locationLabel.Click += new System.EventHandler(this.locationLabel_Click);
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(52, 812);
            this.typeLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(60, 25);
            this.typeLabel.TabIndex = 4;
            this.typeLabel.Text = "Type";
            this.typeLabel.Click += new System.EventHandler(this.typeLabel_Click);
            // 
            // capacityLabel
            // 
            this.capacityLabel.AutoSize = true;
            this.capacityLabel.Location = new System.Drawing.Point(52, 877);
            this.capacityLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.capacityLabel.Name = "capacityLabel";
            this.capacityLabel.Size = new System.Drawing.Size(96, 25);
            this.capacityLabel.TabIndex = 5;
            this.capacityLabel.Text = "Capacity";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(1470, 687);
            this.priceLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(67, 25);
            this.priceLabel.TabIndex = 6;
            this.priceLabel.Text = "Price:";
            // 
            // bookButton
            // 
            this.bookButton.Location = new System.Drawing.Point(1438, 740);
            this.bookButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.bookButton.Name = "bookButton";
            this.bookButton.Size = new System.Drawing.Size(200, 96);
            this.bookButton.TabIndex = 7;
            this.bookButton.Text = "Book Now";
            this.bookButton.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(1076, 219);
            this.listBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(1024, 404);
            this.listBox1.TabIndex = 8;
            // 
            // datelabel
            // 
            this.datelabel.AutoSize = true;
            this.datelabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datelabel.Location = new System.Drawing.Point(1124, 158);
            this.datelabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.datelabel.Name = "datelabel";
            this.datelabel.Size = new System.Drawing.Size(309, 51);
            this.datelabel.TabIndex = 9;
            this.datelabel.Text = "Select date , time";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(1470, 162);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(340, 31);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(1730, 19);
            this.updateBtn.Margin = new System.Windows.Forms.Padding(6);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(179, 61);
            this.updateBtn.TabIndex = 11;
            this.updateBtn.Text = "Update Facility";
            this.updateBtn.UseVisualStyleBackColor = true;
            // 
            // deleteBtn
            // 
            this.deleteBtn.BackColor = System.Drawing.Color.Red;
            this.deleteBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.deleteBtn.Location = new System.Drawing.Point(1921, 19);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(6);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(179, 61);
            this.deleteBtn.TabIndex = 12;
            this.deleteBtn.Text = "Delete Facility";
            this.deleteBtn.UseVisualStyleBackColor = false;
            // 
            // Facilitypage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2166, 1135);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.updateBtn);
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
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
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
        private Button updateBtn;
        private Button deleteBtn;
    }
}
