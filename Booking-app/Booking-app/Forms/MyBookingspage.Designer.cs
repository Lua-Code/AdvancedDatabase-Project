using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System;


namespace Booking_app
{
    partial class MyBookingspage
    {
        private System.ComponentModel.IContainer components = null;
        public Label label1;
        private DataGridView DGTable;

        private void InitializeComponent()
        {
            label1 = new Label();
            DGTable = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)DGTable).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(1262, 50);
            label1.TabIndex = 2;
            label1.Text = "My Bookings";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DGTable
            // 
            DGTable.AllowUserToAddRows = false;
            DGTable.AllowUserToDeleteRows = false;
            DGTable.AllowUserToResizeColumns = false;
            DGTable.AllowUserToResizeRows = false;
            DGTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DGTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DGTable.BackgroundColor = SystemColors.ButtonHighlight;
            DGTable.BorderStyle = BorderStyle.None;
            DGTable.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            DGTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGTable.EditMode = DataGridViewEditMode.EditProgrammatically;
            DGTable.Location = new Point(113, 101);
            DGTable.Name = "DGTable";
            DGTable.ReadOnly = true;
            DGTable.RowHeadersWidth = 51;
            DGTable.RowTemplate.Height = 29;
            DGTable.Size = new Size(1045, 341);
            DGTable.TabIndex = 1;
            DGTable.CellContentClick += DGTable_CellContentClick;
            // 
            // Form1
            // 
            ClientSize = new Size(1262, 673);
            Controls.Add(label1);
            Controls.Add(DGTable);
            Name = "MyBookingspage";
            Text = "Bookings";
            Load += MyBookingspage_Load;
            ((System.ComponentModel.ISupportInitialize)DGTable).EndInit();
            ResumeLayout(false);
        }


    }
}