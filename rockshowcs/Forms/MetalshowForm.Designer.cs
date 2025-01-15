namespace Metalshow.Forms
{
    partial class MetalshowForm
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
            this.InputBackground = new System.Windows.Forms.Panel();
            this.StreamToggle = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LoudnessPanel = new System.Windows.Forms.Panel();
            this.LoudnessCheckBox = new System.Windows.Forms.CheckBox();
            this.SpectPanel = new System.Windows.Forms.Panel();
            this.SpectogramCheckBox = new System.Windows.Forms.CheckBox();
            this.AnalyzerPanel = new System.Windows.Forms.Panel();
            this.AnalyzerCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.InputDevicesComboBox = new System.Windows.Forms.ComboBox();
            this.InputBackground.SuspendLayout();
            this.panel1.SuspendLayout();
            this.LoudnessPanel.SuspendLayout();
            this.SpectPanel.SuspendLayout();
            this.AnalyzerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // InputBackground
            // 
            this.InputBackground.BackColor = System.Drawing.SystemColors.ControlLight;
            this.InputBackground.Controls.Add(this.StreamToggle);
            this.InputBackground.Controls.Add(this.panel1);
            this.InputBackground.Controls.Add(this.label1);
            this.InputBackground.Controls.Add(this.InputDevicesComboBox);
            this.InputBackground.Location = new System.Drawing.Point(39, 57);
            this.InputBackground.Name = "InputBackground";
            this.InputBackground.Size = new System.Drawing.Size(219, 557);
            this.InputBackground.TabIndex = 0;
            // 
            // StreamToggle
            // 
            this.StreamToggle.Location = new System.Drawing.Point(54, 494);
            this.StreamToggle.Name = "StreamToggle";
            this.StreamToggle.Size = new System.Drawing.Size(109, 37);
            this.StreamToggle.TabIndex = 1;
            this.StreamToggle.Text = "Start";
            this.StreamToggle.UseVisualStyleBackColor = true;
            this.StreamToggle.Click += new System.EventHandler(this.StreamToggle_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.LoudnessPanel);
            this.panel1.Controls.Add(this.SpectPanel);
            this.panel1.Controls.Add(this.AnalyzerPanel);
            this.panel1.Location = new System.Drawing.Point(16, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(187, 395);
            this.panel1.TabIndex = 2;
            // 
            // LoudnessPanel
            // 
            this.LoudnessPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LoudnessPanel.Controls.Add(this.LoudnessCheckBox);
            this.LoudnessPanel.Location = new System.Drawing.Point(18, 256);
            this.LoudnessPanel.Name = "LoudnessPanel";
            this.LoudnessPanel.Size = new System.Drawing.Size(147, 98);
            this.LoudnessPanel.TabIndex = 2;
            // 
            // LoudnessCheckBox
            // 
            this.LoudnessCheckBox.AutoSize = true;
            this.LoudnessCheckBox.Location = new System.Drawing.Point(14, 38);
            this.LoudnessCheckBox.Name = "LoudnessCheckBox";
            this.LoudnessCheckBox.Size = new System.Drawing.Size(32, 17);
            this.LoudnessCheckBox.TabIndex = 2;
            this.LoudnessCheckBox.Text = "L";
            this.LoudnessCheckBox.UseVisualStyleBackColor = true;
            this.LoudnessCheckBox.CheckedChanged += new System.EventHandler(this.Loudness_CheckedChanged);
            // 
            // SpectPanel
            // 
            this.SpectPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.SpectPanel.Controls.Add(this.SpectogramCheckBox);
            this.SpectPanel.Location = new System.Drawing.Point(18, 137);
            this.SpectPanel.Name = "SpectPanel";
            this.SpectPanel.Size = new System.Drawing.Size(147, 98);
            this.SpectPanel.TabIndex = 1;
            // 
            // SpectogramCheckBox
            // 
            this.SpectogramCheckBox.AutoSize = true;
            this.SpectogramCheckBox.Location = new System.Drawing.Point(20, 41);
            this.SpectogramCheckBox.Name = "SpectogramCheckBox";
            this.SpectogramCheckBox.Size = new System.Drawing.Size(33, 17);
            this.SpectogramCheckBox.TabIndex = 1;
            this.SpectogramCheckBox.Text = "S";
            this.SpectogramCheckBox.UseVisualStyleBackColor = true;
            this.SpectogramCheckBox.CheckedChanged += new System.EventHandler(this.SpectogramCheckBox_CheckedChanged);
            // 
            // AnalyzerPanel
            // 
            this.AnalyzerPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.AnalyzerPanel.Controls.Add(this.AnalyzerCheckBox);
            this.AnalyzerPanel.Location = new System.Drawing.Point(18, 24);
            this.AnalyzerPanel.Name = "AnalyzerPanel";
            this.AnalyzerPanel.Size = new System.Drawing.Size(147, 98);
            this.AnalyzerPanel.TabIndex = 0;
            // 
            // AnalyzerCheckBox
            // 
            this.AnalyzerCheckBox.AutoSize = true;
            this.AnalyzerCheckBox.Location = new System.Drawing.Point(20, 41);
            this.AnalyzerCheckBox.Name = "AnalyzerCheckBox";
            this.AnalyzerCheckBox.Size = new System.Drawing.Size(33, 17);
            this.AnalyzerCheckBox.TabIndex = 0;
            this.AnalyzerCheckBox.Text = "A";
            this.AnalyzerCheckBox.UseVisualStyleBackColor = true;
            this.AnalyzerCheckBox.CheckedChanged += new System.EventHandler(this.AnalyzerCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Device";
            // 
            // InputDevicesComboBox
            // 
            this.InputDevicesComboBox.FormattingEnabled = true;
            this.InputDevicesComboBox.Location = new System.Drawing.Point(34, 38);
            this.InputDevicesComboBox.Name = "InputDevicesComboBox";
            this.InputDevicesComboBox.Size = new System.Drawing.Size(147, 21);
            this.InputDevicesComboBox.TabIndex = 0;
            this.InputDevicesComboBox.SelectedIndexChanged += new System.EventHandler(this.InputDeviceComboBox_SelectedIndexChanged);
            // 
            // MetalshowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 688);
            this.Controls.Add(this.InputBackground);
            this.Name = "MetalshowForm";
            this.Text = "MetalshowForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MetalshowForm_FormClosing);
            this.InputBackground.ResumeLayout(false);
            this.InputBackground.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.LoudnessPanel.ResumeLayout(false);
            this.LoudnessPanel.PerformLayout();
            this.SpectPanel.ResumeLayout(false);
            this.SpectPanel.PerformLayout();
            this.AnalyzerPanel.ResumeLayout(false);
            this.AnalyzerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel InputBackground;
        private System.Windows.Forms.Button StreamToggle;
        private System.Windows.Forms.ComboBox InputDevicesComboBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel LoudnessPanel;
        private System.Windows.Forms.Panel SpectPanel;
        private System.Windows.Forms.Panel AnalyzerPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox AnalyzerCheckBox;
        private System.Windows.Forms.CheckBox LoudnessCheckBox;
        private System.Windows.Forms.CheckBox SpectogramCheckBox;
    }
}