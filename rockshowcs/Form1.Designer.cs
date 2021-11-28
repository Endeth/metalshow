
namespace rockshowcs
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label UserIdLabel;
            System.Windows.Forms.Label IpLabel;
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.UserIDTextBox = new System.Windows.Forms.TextBox();
            this.IPTextBox = new System.Windows.Forms.TextBox();
            this.ExitImage = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.PlaybackAudio = new System.Windows.Forms.Button();
            this.InputLabel = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.LightsLabel = new System.Windows.Forms.Label();
            this.StopShowBtn = new System.Windows.Forms.Button();
            this.StartShowBtn = new System.Windows.Forms.Button();
            this.AsioOptions = new System.Windows.Forms.Button();
            this.AverageTest = new System.Windows.Forms.Label();
            UserIdLabel = new System.Windows.Forms.Label();
            IpLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExitImage)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserIdLabel
            // 
            UserIdLabel.AutoSize = true;
            UserIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            UserIdLabel.ForeColor = System.Drawing.Color.White;
            UserIdLabel.Location = new System.Drawing.Point(15, 76);
            UserIdLabel.Name = "UserIdLabel";
            UserIdLabel.Size = new System.Drawing.Size(55, 17);
            UserIdLabel.TabIndex = 1;
            UserIdLabel.Text = "User ID";
            // 
            // IpLabel
            // 
            IpLabel.AutoSize = true;
            IpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            IpLabel.ForeColor = System.Drawing.Color.White;
            IpLabel.Location = new System.Drawing.Point(15, 14);
            IpLabel.Name = "IpLabel";
            IpLabel.Size = new System.Drawing.Size(75, 17);
            IpLabel.TabIndex = 0;
            IpLabel.Text = "Ip Address";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 102);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(372, 297);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ConnectButton);
            this.panel2.Controls.Add(this.UserIDTextBox);
            this.panel2.Controls.Add(this.IPTextBox);
            this.panel2.Controls.Add(UserIdLabel);
            this.panel2.Controls.Add(IpLabel);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(369, 294);
            this.panel2.TabIndex = 0;
            // 
            // ConnectButton
            // 
            this.ConnectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(86)))), ((int)(((byte)(255)))));
            this.ConnectButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(86)))), ((int)(((byte)(255)))));
            this.ConnectButton.FlatAppearance.BorderSize = 0;
            this.ConnectButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(67)))), ((int)(((byte)(198)))));
            this.ConnectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(109)))), ((int)(((byte)(255)))));
            this.ConnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConnectButton.Location = new System.Drawing.Point(87, 180);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(191, 51);
            this.ConnectButton.TabIndex = 4;
            this.ConnectButton.Text = "Connect To Bridge";
            this.ConnectButton.UseVisualStyleBackColor = false;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // UserIDTextBox
            // 
            this.UserIDTextBox.Location = new System.Drawing.Point(18, 96);
            this.UserIDTextBox.Name = "UserIDTextBox";
            this.UserIDTextBox.Size = new System.Drawing.Size(275, 20);
            this.UserIDTextBox.TabIndex = 3;
            this.UserIDTextBox.Text = "6VTpkX8yKSGYCb-4-jTCoQidSZs0jdIa7QyTxhTf";
            this.UserIDTextBox.TextChanged += new System.EventHandler(this.UserIDTextBox_TextChanged);
            // 
            // IPTextBox
            // 
            this.IPTextBox.Location = new System.Drawing.Point(18, 34);
            this.IPTextBox.Name = "IPTextBox";
            this.IPTextBox.Size = new System.Drawing.Size(109, 20);
            this.IPTextBox.TabIndex = 2;
            this.IPTextBox.Text = "192.168.1.18";
            this.IPTextBox.TextChanged += new System.EventHandler(this.IPTextBox_TextChanged);
            // 
            // ExitImage
            // 
            this.ExitImage.Image = global::rockshowcs.Properties.Resources.xbutton;
            this.ExitImage.Location = new System.Drawing.Point(856, 12);
            this.ExitImage.Name = "ExitImage";
            this.ExitImage.Size = new System.Drawing.Size(50, 50);
            this.ExitImage.TabIndex = 1;
            this.ExitImage.TabStop = false;
            this.ExitImage.Click += new System.EventHandler(this.ExitImage_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel3.Controls.Add(this.AverageTest);
            this.panel3.Controls.Add(this.AsioOptions);
            this.panel3.Controls.Add(this.PlaybackAudio);
            this.panel3.Controls.Add(this.InputLabel);
            this.panel3.Location = new System.Drawing.Point(404, 102);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(502, 297);
            this.panel3.TabIndex = 2;
            // 
            // PlaybackAudio
            // 
            this.PlaybackAudio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(86)))), ((int)(((byte)(255)))));
            this.PlaybackAudio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(67)))), ((int)(((byte)(198)))));
            this.PlaybackAudio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(109)))), ((int)(((byte)(255)))));
            this.PlaybackAudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlaybackAudio.Location = new System.Drawing.Point(280, 207);
            this.PlaybackAudio.Name = "PlaybackAudio";
            this.PlaybackAudio.Size = new System.Drawing.Size(191, 57);
            this.PlaybackAudio.TabIndex = 1;
            this.PlaybackAudio.Text = "Playback";
            this.PlaybackAudio.UseVisualStyleBackColor = false;
            this.PlaybackAudio.Click += new System.EventHandler(this.PlaybackAudio_Click);
            // 
            // InputLabel
            // 
            this.InputLabel.AutoSize = true;
            this.InputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputLabel.ForeColor = System.Drawing.Color.White;
            this.InputLabel.Location = new System.Drawing.Point(18, 17);
            this.InputLabel.Name = "InputLabel";
            this.InputLabel.Size = new System.Drawing.Size(39, 17);
            this.InputLabel.TabIndex = 0;
            this.InputLabel.Text = "Input";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel4.Controls.Add(this.LightsLabel);
            this.panel4.Controls.Add(this.StopShowBtn);
            this.panel4.Controls.Add(this.StartShowBtn);
            this.panel4.Location = new System.Drawing.Point(12, 418);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(894, 297);
            this.panel4.TabIndex = 3;
            // 
            // LightsLabel
            // 
            this.LightsLabel.AutoSize = true;
            this.LightsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LightsLabel.ForeColor = System.Drawing.Color.White;
            this.LightsLabel.Location = new System.Drawing.Point(18, 17);
            this.LightsLabel.Name = "LightsLabel";
            this.LightsLabel.Size = new System.Drawing.Size(46, 17);
            this.LightsLabel.TabIndex = 2;
            this.LightsLabel.Text = "Lights";
            // 
            // StopShowBtn
            // 
            this.StopShowBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(86)))), ((int)(((byte)(255)))));
            this.StopShowBtn.FlatAppearance.BorderSize = 0;
            this.StopShowBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(67)))), ((int)(((byte)(198)))));
            this.StopShowBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(109)))), ((int)(((byte)(255)))));
            this.StopShowBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StopShowBtn.Location = new System.Drawing.Point(324, 206);
            this.StopShowBtn.Name = "StopShowBtn";
            this.StopShowBtn.Size = new System.Drawing.Size(191, 57);
            this.StopShowBtn.TabIndex = 1;
            this.StopShowBtn.Text = "StopShow";
            this.StopShowBtn.UseVisualStyleBackColor = false;
            this.StopShowBtn.Click += new System.EventHandler(this.StopShowBtn_Click);
            // 
            // StartShowBtn
            // 
            this.StartShowBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(86)))), ((int)(((byte)(255)))));
            this.StartShowBtn.FlatAppearance.BorderSize = 0;
            this.StartShowBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(67)))), ((int)(((byte)(198)))));
            this.StartShowBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(109)))), ((int)(((byte)(255)))));
            this.StartShowBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartShowBtn.Location = new System.Drawing.Point(35, 206);
            this.StartShowBtn.Name = "StartShowBtn";
            this.StartShowBtn.Size = new System.Drawing.Size(191, 57);
            this.StartShowBtn.TabIndex = 0;
            this.StartShowBtn.Text = "StartShow";
            this.StartShowBtn.UseVisualStyleBackColor = false;
            this.StartShowBtn.Click += new System.EventHandler(this.StartShowBtn_Click);
            // 
            // AsioOptions
            // 
            this.AsioOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(86)))), ((int)(((byte)(255)))));
            this.AsioOptions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(67)))), ((int)(((byte)(198)))));
            this.AsioOptions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(109)))), ((int)(((byte)(255)))));
            this.AsioOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AsioOptions.Location = new System.Drawing.Point(280, 18);
            this.AsioOptions.Name = "AsioOptions";
            this.AsioOptions.Size = new System.Drawing.Size(191, 57);
            this.AsioOptions.TabIndex = 2;
            this.AsioOptions.Text = "Asio Options";
            this.AsioOptions.UseVisualStyleBackColor = false;
            this.AsioOptions.Click += new System.EventHandler(this.AsioOptions_Click);
            // 
            // AverageTest
            // 
            this.AverageTest.AutoSize = true;
            this.AverageTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AverageTest.ForeColor = System.Drawing.Color.White;
            this.AverageTest.Location = new System.Drawing.Point(335, 99);
            this.AverageTest.Name = "AverageTest";
            this.AverageTest.Size = new System.Drawing.Size(75, 31);
            this.AverageTest.TabIndex = 3;
            this.AverageTest.Text = "Input";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(72)))));
            this.ClientSize = new System.Drawing.Size(918, 761);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.ExitImage);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Rockshow";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExitImage)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox UserIDTextBox;
        private System.Windows.Forms.TextBox IPTextBox;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.PictureBox ExitImage;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label InputLabel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button StartShowBtn;
        private System.Windows.Forms.Button StopShowBtn;
        private System.Windows.Forms.Label LightsLabel;
        private System.Windows.Forms.Button PlaybackAudio;
        private System.Windows.Forms.Button AsioOptions;
        private System.Windows.Forms.Label AverageTest;
    }
}

