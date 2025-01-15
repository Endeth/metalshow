using System;
using System.Drawing;
using System.Windows.Forms;

namespace Metalshow
{
    public partial class MainWindowForm : Form
    {
        private AudioProcessor audioProcessor = new AudioProcessor();
        private MetalshowController controller;

        public MainWindowForm(MetalshowController cont)
        {
            InitializeComponent();
            /*ExitImage.SizeMode = PictureBoxSizeMode.StretchImage;
            Spectogram1.SizeMode = PictureBoxSizeMode.StretchImage;
            Spectogram1.ClientSize = new Size( 640, 480 );

            InitUIData();*/
        }

        private void InitUIData()
        {
            /*var inputDevices = AudioDevice.GetInputDevices();

            int supportedDevices = 0;
            inputDevices.ForEach( x => { if( x.Id >= 0 ) supportedDevices++; } );

            string[] inputDevicesNames = new string[supportedDevices];
            foreach( var inputDevice in inputDevices )
            {
                if( inputDevice.Id >= 0 )
                    inputDevicesNames[inputDevice.Id] = inputDevice.Name;
            }

            InputDevices.Items.AddRange( inputDevicesNames );
            InputDevices.SelectedIndex = 0;*/
        }

        public event EventHandler<GfxOutputFormToggleEventArgs> OnGfxFormToggle;

        IOutputStream consoleOutput;
        IOutputStream bitmapOutput;

        private bool mouseDown;
        private Point lastLocation;

        //TODO remove nonwindowform magic from windowform
        private void MainWindowForm_MouseDown( object sender, MouseEventArgs e )
        {
            /*Spectogram1.Refresh();
            mouseDown = true;
            lastLocation = e.Location;*/
        }

        private void MainWindowForm_MouseMove( object sender, MouseEventArgs e )
        {
            /*
            if( mouseDown )
            {
                Location = new Point(
                    ( Location.X - lastLocation.X ) + e.X, ( Location.Y - lastLocation.Y ) + e.Y );

                Update();
            }
            */
        }

        private void MainWindowForm_MouseUp( object sender, MouseEventArgs e )
        {
            //mouseDown = false;
        }

        private void ExitImage_Click( object sender, EventArgs e )
        {
            //Environment.Exit( 0 );
        }

        private void ToggleShowBtn_Click( object sender, EventArgs e )
        {
            //TODO move to text box
            /*audioProcessor.SetInputDevice( InputDevices.SelectedIndex );

            audioProcessor.ToggleStream();

            if( audioProcessor.IsStreaming() )
            {
                //TODO
                //expaning blocks our (currently) main processing thread;
                InputDevices.Enabled = false;
                ToggleShowBtn.Text = "Stop Streaming";
            }
            else
            {
                InputDevices.Enabled = true;
                ToggleShowBtn.Text = "Start Streaming";
            }*/
        }

        private void InputDevices_SelectedIndexChanged( object sender, EventArgs e )
        {
            audioProcessor.SetInputDevice( InputDevices.SelectedIndex );
        }

        private void SignalAnalysis_CheckedChanged( object sender, EventArgs e )
        {
            /*bool val = SignalAnalysis.Checked;
            if( val )
                audioProcessor.CreateSignalAnalyzer();
            else
                audioProcessor.RemoveSignalAnalyzer();*/
        }

        private void LoudnessOutputCheckBox_CheckedChanged( object sender, EventArgs e )
        {
            /*bool checkboxState = LoudnessOutputCheckBox.Checked;
            Console.WriteLine( "Test l" );

            LoudnessOutputControl ctrl = new LoudnessOutputControl();
            SignalAnalyzer spect = audioProcessor.CreateSignalAnalyzer();
            ctrl.SetProcessingNode();
            ctrl.ControlRemoved += new ControlEventHandler( (this, new ControlEventArgs(ctrl)) => { } );
            GfxOutputFormToggleEventArgs output = new GfxOutputFormToggleEventArgs( ctrl, checkboxState );
            OnGfxFormToggle.Invoke( this, output );

            if( checkboxState )
            {
                if( consoleOutput == null )
                {
                    consoleOutput = new AudioOutput.DebugConsoleOutput();
                }
                //audioProcessor.CreateOutput( consoleOutput );
            }
            else
            {
                audioProcessor.RemoveOutput( consoleOutput );
            }*/
        }

        private void SpectogramCheckboxOutput_CheckedChanged( object sender, EventArgs e )
        {
            /*bool checkboxState = SpectogramCheckboxOutput.Checked;
            Console.WriteLine( "Test s" );

            SpectogramOutputControl ctrl = new SpectogramOutputControl();
            audioProcessor.SetSpectogramControl( ctrl );
            GfxOutputFormToggleEventArgs output = new GfxOutputFormToggleEventArgs( ctrl, checkboxState );
            OnGfxFormToggle.Invoke( this, output );

            //To remove
            if( checkboxState )
            {
                if( bitmapOutput == null )
                {
                    bitmapOutput = new AudioOutput.GfxSpectogramOutput( Spectogram1, Spectogram2 );

                }
                audioProcessor.CreateOutput( bitmapOutput );
            }
            else
            {
                audioProcessor.RemoveOutput( bitmapOutput );
            }*/
        }

        private void InputDeviceIdx_ValueChanged( object sender, EventArgs e )
        {

        }
    }
}
