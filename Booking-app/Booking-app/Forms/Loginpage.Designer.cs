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
    partial class Loginpage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.formLayout = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.mainLayout.SuspendLayout();
            this.formLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.mainLayout.SetColumnSpan(this.label1, 3);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 28F);
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(536, 47);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sports Club Bookings";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 3;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.mainLayout.Controls.Add(this.label1, 0, 0);
            this.mainLayout.Controls.Add(this.formLayout, 1, 2);
            this.mainLayout.Controls.Add(this.button1, 1, 3);
            this.mainLayout.Controls.Add(this.linkLabel2, 1, 5);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 7;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainLayout.Size = new System.Drawing.Size(540, 286);
            this.mainLayout.TabIndex = 0;
            // 
            // formLayout
            // 
            this.formLayout.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.formLayout.AutoSize = true;
            this.formLayout.BackColor = System.Drawing.Color.White;
            this.formLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.formLayout.ColumnCount = 2;
            this.formLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.formLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.formLayout.Controls.Add(this.label2, 0, 0);
            this.formLayout.Controls.Add(this.textBox1, 1, 0);
            this.formLayout.Controls.Add(this.label3, 0, 1);
            this.formLayout.Controls.Add(this.textBox2, 1, 1);
            this.formLayout.Location = new System.Drawing.Point(180, 105);
            this.formLayout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.formLayout.Name = "formLayout";
            this.formLayout.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.formLayout.RowCount = 2;
            this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.formLayout.Size = new System.Drawing.Size(179, 65);
            this.formLayout.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Email";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(68, 9);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(101, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 39);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(68, 36);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(101, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(246, 182);
            this.button1.Margin = new System.Windows.Forms.Padding(0, 10, 0, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Log In";
            // 
            // linkLabel2
            // 
            this.linkLabel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(181, 213);
            this.linkLabel2.Margin = new System.Windows.Forms.Padding(0, 5, 0, 3);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(178, 13);
            this.linkLabel2.TabIndex = 6;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Dont have an account? Create one!";
            // 
            // Loginpage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 286);
            this.Controls.Add(this.mainLayout);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Loginpage";
            this.Text = "Login";
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.formLayout.ResumeLayout(false);
            this.formLayout.PerformLayout();
            this.ResumeLayout(false);

        }




        #endregion

        private Label label1;
        private TableLayoutPanel formLayout;
        private TableLayoutPanel mainLayout;
        private Label label2;
        private Label label3;
        private Button button1;
        private LinkLabel linkLabel2;
        private TextBox textBox1;
        private TextBox textBox2;
    }
}