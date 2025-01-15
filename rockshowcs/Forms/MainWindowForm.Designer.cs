
namespace Metalshow
{
    partial class MainWindowForm
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
            System.Windows.Forms.Panel LightsControlPanel;
            this.ExitImage = new System.Windows.Forms.PictureBox();
            this.ToggleShowBtn = new System.Windows.Forms.Button();
            this.LoudnessOutputCheckBox = new System.Windows.Forms.CheckBox();
            this.SpectogramCheckboxOutput = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.InputDeviceLabel = new System.Windows.Forms.Label();
            this.InputDevices = new System.Windows.Forms.ComboBox();
            this.BridgeOptions = new System.Windows.Forms.Panel();
            this.GfxBackground = new System.Windows.Forms.Panel();
            this.SpectogramBackground = new System.Windows.Forms.Panel();
            this.Spectogram1 = new System.Windows.Forms.PictureBox();
            this.Spectogram2 = new System.Windows.Forms.PictureBox();
            LightsControlPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ExitImage)).BeginInit();
            LightsControlPanel.SuspendLayout();
            this.BridgeOptions.SuspendLayout();
            this.GfxBackground.SuspendLayout();
            this.SpectogramBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Spectogram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Spectogram2)).BeginInit();
            this.SuspendLayout();
            // 
            // ExitImage
            // 
            this.ExitImage.Image = global::Metalshow.Properties.Resources.xbutton;
            this.ExitImage.Location = new System.Drawing.Point(856, 12);
            this.ExitImage.Name = "ExitImage";
            this.ExitImage.Size = new System.Drawing.Size(50, 50);
            this.ExitImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ExitImage.TabIndex = 1;
            this.ExitImage.TabStop = false;
            this.ExitImage.Click += new System.EventHandler(this.ExitImage_Click);
            // 
            // ToggleShowBtn
            // 
            this.ToggleShowBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ToggleShowBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(86)))), ((int)(((byte)(255)))));
            this.ToggleShowBtn.FlatAppearance.BorderSize = 0;
            this.ToggleShowBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(67)))), ((int)(((byte)(198)))));
            this.ToggleShowBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(109)))), ((int)(((byte)(255)))));
            this.ToggleShowBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToggleShowBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToggleShowBtn.Location = new System.Drawing.Point(16, 25);
            this.ToggleShowBtn.Name = "ToggleShowBtn";
            this.ToggleShowBtn.Size = new System.Drawing.Size(191, 57);
            this.ToggleShowBtn.TabIndex = 0;
            this.ToggleShowBtn.Text = "Start Show";
            this.ToggleShowBtn.UseVisualStyleBackColor = false;
            this.ToggleShowBtn.Click += new System.EventHandler(this.ToggleShowBtn_Click);
            // 
            // LoudnessOutputCheckBox
            // 
            this.LoudnessOutputCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LoudnessOutputCheckBox.AutoSize = true;
            this.LoudnessOutputCheckBox.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.LoudnessOutputCheckBox.Location = new System.Drawing.Point(611, 50);
            this.LoudnessOutputCheckBox.Name = "LoudnessOutputCheckBox";
            this.LoudnessOutputCheckBox.Size = new System.Drawing.Size(107, 17);
            this.LoudnessOutputCheckBox.TabIndex = 1;
            this.LoudnessOutputCheckBox.Text = "Loudness Output";
            this.LoudnessOutputCheckBox.UseVisualStyleBackColor = true;
            this.LoudnessOutputCheckBox.CheckedChanged += new System.EventHandler(this.LoudnessOutputCheckBox_CheckedChanged);
            // 
            // SpectogramCheckboxOutput
            // 
            this.SpectogramCheckboxOutput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SpectogramCheckboxOutput.AutoSize = true;
            this.SpectogramCheckboxOutput.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.SpectogramCheckboxOutput.Location = new System.Drawing.Point(748, 49);
            this.SpectogramCheckboxOutput.Name = "SpectogramCheckboxOutput";
            this.SpectogramCheckboxOutput.Size = new System.Drawing.Size(118, 17);
            this.SpectogramCheckboxOutput.TabIndex = 2;
            this.SpectogramCheckboxOutput.Text = "Spectogram Output";
            this.SpectogramCheckboxOutput.UseVisualStyleBackColor = true;
            this.SpectogramCheckboxOutput.CheckedChanged += new System.EventHandler(this.SpectogramCheckboxOutput_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.checkBox1.Location = new System.Drawing.Point(355, 50);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Signal Analysis";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // LightsControlPanel
            // 
            LightsControlPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            LightsControlPanel.Controls.Add(this.checkBox1);
            LightsControlPanel.Controls.Add(this.SpectogramCheckboxOutput);
            LightsControlPanel.Controls.Add(this.LoudnessOutputCheckBox);
            LightsControlPanel.Controls.Add(this.ToggleShowBtn);
            LightsControlPanel.Location = new System.Drawing.Point(12, 636);
            LightsControlPanel.Name = "LightsControlPanel";
            LightsControlPanel.Size = new System.Drawing.Size(894, 113);
            LightsControlPanel.TabIndex = 3;
            // 
            // InputDeviceLabel
            // 
            this.InputDeviceLabel.AutoSize = true;
            this.InputDeviceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputDeviceLabel.ForeColor = System.Drawing.Color.White;
            this.InputDeviceLabel.Location = new System.Drawing.Point(420, 12);
            this.InputDeviceLabel.Name = "InputDeviceLabel";
            this.InputDeviceLabel.Size = new System.Drawing.Size(107, 17);
            this.InputDeviceLabel.TabIndex = 3;
            this.InputDeviceLabel.Text = "Input Device Idx";
            // 
            // InputDevices
            // 
            this.InputDevices.FormattingEnabled = true;
            this.InputDevices.Location = new System.Drawing.Point(136, 11);
            this.InputDevices.Name = "InputDevices";
            this.InputDevices.Size = new System.Drawing.Size(170, 21);
            this.InputDevices.TabIndex = 7;
            this.InputDevices.SelectedIndexChanged += new System.EventHandler(this.InputDevices_SelectedIndexChanged);
            // 
            // BridgeOptions
            // 
            this.BridgeOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.BridgeOptions.Controls.Add(this.InputDevices);
            this.BridgeOptions.Controls.Add(this.InputDeviceLabel);
            this.BridgeOptions.Location = new System.Drawing.Point(12, 12);
            this.BridgeOptions.Name = "BridgeOptions";
            this.BridgeOptions.Size = new System.Drawing.Size(540, 50);
            this.BridgeOptions.TabIndex = 0;
            // 
            // GfxBackground
            // 
            this.GfxBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.GfxBackground.Controls.Add(this.SpectogramBackground);
            this.GfxBackground.Location = new System.Drawing.Point(138, 107);
            this.GfxBackground.Name = "GfxBackground";
            this.GfxBackground.Size = new System.Drawing.Size(660, 500);
            this.GfxBackground.TabIndex = 4;
            // 
            // SpectogramBackground
            // 
            this.SpectogramBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SpectogramBackground.BackColor = System.Drawing.Color.Black;
            this.SpectogramBackground.Controls.Add(this.Spectogram2);
            this.SpectogramBackground.Controls.Add(this.Spectogram1);
            this.SpectogramBackground.Location = new System.Drawing.Point(10, 10);
            this.SpectogramBackground.Name = "SpectogramBackground";
            this.SpectogramBackground.Size = new System.Drawing.Size(640, 480);
            this.SpectogramBackground.TabIndex = 5;
            // 
            // Spectogram1
            // 
            this.Spectogram1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Spectogram1.Location = new System.Drawing.Point(0, 0);
            this.Spectogram1.Name = "Spectogram1";
            this.Spectogram1.Size = new System.Drawing.Size(640, 480);
            this.Spectogram1.TabIndex = 4;
            this.Spectogram1.TabStop = false;
            // 
            // Spectogram2
            // 
            this.Spectogram2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Spectogram2.Location = new System.Drawing.Point(0, 0);
            this.Spectogram2.Name = "Spectogram2";
            this.Spectogram2.Size = new System.Drawing.Size(640, 480);
            this.Spectogram2.TabIndex = 5;
            this.Spectogram2.TabStop = false;
            // 
            // MainWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(72)))));
            this.ClientSize = new System.Drawing.Size(918, 761);
            this.Controls.Add(this.GfxBackground);
            this.Controls.Add(this.BridgeOptions);
            this.Controls.Add(LightsControlPanel);
            this.Controls.Add(this.ExitImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainWindowForm";
            this.Text = "Rockshow";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWindowForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainWindowForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainWindowForm_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.ExitImage)).EndInit();
            LightsControlPanel.ResumeLayout(false);
            LightsControlPanel.PerformLayout();
            this.BridgeOptions.ResumeLayout(false);
            this.BridgeOptions.PerformLayout();
            this.GfxBackground.ResumeLayout(false);
            this.SpectogramBackground.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Spectogram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Spectogram2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ExitImage;
        private System.Windows.Forms.Button ToggleShowBtn;
        private System.Windows.Forms.CheckBox LoudnessOutputCheckBox;
        private System.Windows.Forms.CheckBox SpectogramCheckboxOutput;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label InputDeviceLabel;
        private System.Windows.Forms.ComboBox InputDevices;
        private System.Windows.Forms.Panel BridgeOptions;
        private System.Windows.Forms.Panel GfxBackground;
        private System.Windows.Forms.Panel SpectogramBackground;
        private System.Windows.Forms.PictureBox Spectogram2;
        private System.Windows.Forms.PictureBox Spectogram1;
    }
}

