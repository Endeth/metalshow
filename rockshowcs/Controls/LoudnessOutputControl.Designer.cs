namespace Metalshow.Controls
{
    partial class LoudnessOutputControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ListenerValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ListenerValue
            // 
            this.ListenerValue.Location = new System.Drawing.Point(253, 205);
            this.ListenerValue.Name = "ListenerValue";
            this.ListenerValue.Size = new System.Drawing.Size(100, 20);
            this.ListenerValue.TabIndex = 0;
            this.ListenerValue.Text = "0";
            // 
            // LoudnessOutputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ListenerValue);
            this.Name = "LoudnessOutputControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ListenerValue;
    }
}
