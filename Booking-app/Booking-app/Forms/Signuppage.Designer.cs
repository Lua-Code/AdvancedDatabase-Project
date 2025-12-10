using System.Drawing;
using System.Windows.Forms;

namespace Booking_app
{
    partial class Signuppage
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.headerLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.memberLevelLabel = new System.Windows.Forms.Label();
            this.memberLevelComboBox = new System.Windows.Forms.ComboBox();
            this.signUpButton = new System.Windows.Forms.Button();
            this.linkLogin = new System.Windows.Forms.LinkLabel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.mainLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 2;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.mainLayout.Controls.Add(this.headerLabel, 0, 0);
            this.mainLayout.Controls.Add(this.nameLabel, 0, 1);
            this.mainLayout.Controls.Add(this.nameTextBox, 1, 1);
            this.mainLayout.Controls.Add(this.emailLabel, 0, 2);
            this.mainLayout.Controls.Add(this.emailTextBox, 1, 2);
            this.mainLayout.Controls.Add(this.passwordLabel, 0, 3);
            this.mainLayout.Controls.Add(this.passwordTextBox, 1, 3);
            this.mainLayout.Controls.Add(this.phoneLabel, 0, 4);
            this.mainLayout.Controls.Add(this.phoneTextBox, 1, 4);
            this.mainLayout.Controls.Add(this.memberLevelLabel, 0, 5);
            this.mainLayout.Controls.Add(this.memberLevelComboBox, 1, 5);
            this.mainLayout.Controls.Add(this.signUpButton, 0, 7);
            this.mainLayout.Controls.Add(this.linkLogin, 0, 8);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.Padding = new System.Windows.Forms.Padding(20);
            this.mainLayout.RowCount = 9;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.mainLayout.Size = new System.Drawing.Size(600, 500);
            this.mainLayout.TabIndex = 0;
            // 
            // headerLabel
            // 
            this.headerLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.headerLabel.AutoSize = true;
            this.mainLayout.SetColumnSpan(this.headerLabel, 2);
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.headerLabel.Location = new System.Drawing.Point(248, 20);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(103, 32);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Sign Up";
            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(175, 93);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Name:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.Location = new System.Drawing.Point(219, 90);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(358, 20);
            this.nameTextBox.TabIndex = 2;
            // 
            // emailLabel
            // 
            this.emailLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(178, 133);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(35, 13);
            this.emailLabel.TabIndex = 3;
            this.emailLabel.Text = "Email:";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.emailTextBox.Location = new System.Drawing.Point(219, 130);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(358, 20);
            this.emailTextBox.TabIndex = 4;
            // 
            // passwordLabel
            // 
            this.passwordLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(157, 173);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordLabel.TabIndex = 5;
            this.passwordLabel.Text = "Password:";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordTextBox.Location = new System.Drawing.Point(219, 170);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(358, 20);
            this.passwordTextBox.TabIndex = 6;
            // 
            // phoneLabel
            // 
            this.phoneLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Location = new System.Drawing.Point(172, 213);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(41, 13);
            this.phoneLabel.TabIndex = 7;
            this.phoneLabel.Text = "Phone:";
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.phoneTextBox.Location = new System.Drawing.Point(219, 210);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(358, 20);
            this.phoneTextBox.TabIndex = 8;
            // 
            // memberLevelLabel
            // 
            this.memberLevelLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.memberLevelLabel.AutoSize = true;
            this.memberLevelLabel.Location = new System.Drawing.Point(117, 253);
            this.memberLevelLabel.Name = "memberLevelLabel";
            this.memberLevelLabel.Size = new System.Drawing.Size(96, 13);
            this.memberLevelLabel.TabIndex = 9;
            this.memberLevelLabel.Text = "Membership Level:";
            // 
            // memberLevelComboBox
            // 
            this.memberLevelComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.memberLevelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.memberLevelComboBox.Items.AddRange(new object[] {
            "Basic",
            "Premium",
            "VIP"});
            this.memberLevelComboBox.Location = new System.Drawing.Point(219, 249);
            this.memberLevelComboBox.Name = "memberLevelComboBox";
            this.memberLevelComboBox.Size = new System.Drawing.Size(358, 21);
            this.memberLevelComboBox.TabIndex = 10;
            // 
            // signUpButton
            // 
            this.signUpButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mainLayout.SetColumnSpan(this.signUpButton, 2);
            this.signUpButton.Location = new System.Drawing.Point(225, 330);
            this.signUpButton.Name = "signUpButton";
            this.signUpButton.Size = new System.Drawing.Size(150, 40);
            this.signUpButton.TabIndex = 11;
            this.signUpButton.Text = "Create Account";
            // 
            // linkLogin
            // 
            this.linkLogin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.linkLogin.AutoSize = true;
            this.mainLayout.SetColumnSpan(this.linkLogin, 2);
            this.linkLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline);
            this.linkLogin.Location = new System.Drawing.Point(217, 380);
            this.linkLogin.Name = "linkLogin";
            this.linkLogin.Size = new System.Drawing.Size(165, 19);
            this.linkLogin.TabIndex = 12;
            this.linkLogin.TabStop = true;
            this.linkLogin.Text = "Already have an account?";
            // 
            // statusLabel
            // 
            this.statusLabel.Location = new System.Drawing.Point(0, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(100, 23);
            this.statusLabel.TabIndex = 0;
            // 
            // statusComboBox
            // 
            this.statusComboBox.Location = new System.Drawing.Point(0, 0);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(121, 21);
            this.statusComboBox.TabIndex = 0;
            // 
            // Signuppage
            // 
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Controls.Add(this.mainLayout);
            this.Name = "Signuppage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sign Up";
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel mainLayout;

        private Label headerLabel;
        private Label nameLabel;
        private Label emailLabel;
        private Label passwordLabel;
        private Label phoneLabel;
        private Label memberLevelLabel;
        private Label statusLabel;

        private TextBox nameTextBox;
        private TextBox emailTextBox;
        private TextBox passwordTextBox;
        private TextBox phoneTextBox;

        private ComboBox memberLevelComboBox;
        private ComboBox statusComboBox;

        private Button signUpButton;
        private LinkLabel linkLogin;
    }
}
