using Metalshow.Controls;
using Metalshow;
using System;
using System.Windows.Forms;
using Metalshow.Nodes;

namespace Metalshow.Forms
{
    public partial class MetalshowForm : Form
    {
        public event EventHandler<GfxOutputFormToggleEventArgs> OnGfxFormToggle;

        public MetalshowForm(MetalshowController controller)
        {
            InitializeComponent();
            metalshowController = controller;

            InitUIData();
        }

        private void InitUIData()
        {
            var inputDevices = AudioDevice.GetInputDevices();

            int supportedDevices = 0;
            inputDevices.ForEach( x => { if( x.Id >= 0 ) supportedDevices++; } );

            string[] inputDevicesNames = new string[supportedDevices];
            foreach( var inputDevice in inputDevices )
            {
                if( inputDevice.Id >= 0 )
                    inputDevicesNames[inputDevice.Id] = inputDevice.Name;
            }

            InputDevicesComboBox.Items.AddRange( inputDevicesNames );
            InputDevicesComboBox.SelectedIndex = 0;
        }

        private void InputDeviceComboBox_SelectedIndexChanged( object sender, EventArgs e )
        {
            metalshowController.SetInputDevice( InputDevicesComboBox.SelectedIndex );
        }

        private void AnalyzerCheckBox_CheckedChanged( object sender, EventArgs e )
        {
        }

        private void SpectogramCheckBox_CheckedChanged( object sender, EventArgs e )
        {
        }

        private void Loudness_CheckedChanged( object sender, EventArgs e )
        {
            if( LoudnessCheckBox.Checked )
            {
                metalshowController.CreateListener();
            }
            else
            {
                metalshowController.RemoveListener(null);
            }
        }

        private void StreamToggle_Click( object sender, EventArgs e )
        {
            bool streaming = metalshowController.ToggleStream();

            if( streaming )
            {
                InputDevicesComboBox.Enabled = false;
                StreamToggle.Text = "Stop Streaming";
            }
            else
            {
                InputDevicesComboBox.Enabled = true;
                StreamToggle.Text = "Start Streaming";
            }
        }

        MetalshowController metalshowController;


        private void MetalshowForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            metalshowController.Exit();
        }
    }
}
