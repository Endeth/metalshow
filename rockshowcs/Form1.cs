using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rockshowcs
{
    public partial class Form1 : Form
    {
        private Rockshow rockshow = new Rockshow();
        public Form1()
        {
            InitializeComponent();
            ExitImage.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void IPTextBox_TextChanged( object sender, EventArgs e )
        {

        }

        private void UserIDTextBox_TextChanged( object sender, EventArgs e )
        {

        }

        private void ConnectButton_Click( object sender, EventArgs e )
        {
            var ip = IPTextBox.Text;
            var userId = UserIDTextBox.Text;
            rockshow.Connect();
        }

        private async void ExitImage_Click( object sender, EventArgs e )
        {
            await rockshow.ResetLights();
            rockshow.StopAudio();
            Environment.Exit( 0 );
        }

        private void StartShowBtn_Click( object sender, EventArgs e )
        {
            rockshow.StartShow();
        }

        private void StopShowBtn_Click( object sender, EventArgs e )
        {
            rockshow.StopShow();
        }

        private void PlaybackAudio_Click( object sender, EventArgs e )
        {
            rockshow.Playback();
        }

        private void Form1_Load( object sender, EventArgs e )
        {
        }

        private void AsioOptions_Click( object sender, EventArgs e )
        {
            rockshow.ShowASIOPanel();
        }
    }
}
