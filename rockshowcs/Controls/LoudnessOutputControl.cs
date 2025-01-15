using System;
using System.Windows.Forms;

namespace Metalshow.Controls
{
    public partial class LoudnessOutputControl : GfxOutputControl
    {
        public LoudnessOutputControl()
        {
            InitializeComponent();

            Name = "Loudness";
            Type = OutputType.Loudness;

            _timer = new Timer
            {
                Interval = 100
            };

            _timer.Tick += new EventHandler( OnUITick );
            _timer.Start();
        }

        override public void AdjustParentForm( GfxOutputForm parent )
        {
            base.AdjustParentForm( parent );
        }

        public void SetAudioListener( Nodes.AudioListener<Nodes.AudioInputTaskNode, bool> listener )
        {
            _listener = listener;
        }

        override public void OnUITick( object sender, EventArgs args)
        {
            Console.WriteLine( "tick" );
            if( _listener != null )
            {
                Console.WriteLine( _listener.Get() );
            }
        }

        override public void Cleanup()
        {
            base.Cleanup();

            _timer.Stop();
            _timer.Dispose();

            _listener = null;
        }

        private Nodes.AudioListener<Nodes.AudioInputTaskNode, bool> _listener;
        private Timer _timer;
    }
}
