using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Metalshow.Controls;
using Metalshow.Forms;
using NAudio.Wave;

namespace Metalshow
{
    public class MetalshowContext : ApplicationContext
    {
        public MetalshowContext()
        {
            audioProcessor = new AudioProcessor();
            metalshowController = new MetalshowController( audioProcessor, this );

            mainWindow = new MetalshowForm( metalshowController );
            mainWindow.FormClosed += new FormClosedEventHandler( OnFormClosed );
            mainWindow.OnGfxFormToggle += new EventHandler<GfxOutputFormToggleEventArgs>( ToggleGfxOutputForm );

            _outputForms = new Dictionary<GfxOutputControl, GfxOutputForm>();

            mainWindow.Show();

            frameRate = 30;
            timerInterval = 1000 / frameRate;

            uiFrameTimer = new Timer();
            uiFrameTimer.Tick += new EventHandler( OnUITick );
            uiFrameTimer.Interval = timerInterval;
        }
        public void OnUITick( object source, EventArgs args )
        {
            foreach( var uiTask in uiTasks )
            {
                //Copy data from input streams to input children
            }

            //Start ops
            
            //
        }

        public void ToggleOutputForm( GfxOutputFormToggleEventArgs args )
        {
            if( args.Value )
            {
                var toggledForm = new GfxOutputForm( args.GfxOutputControl );
                toggledForm.Name = args.GfxOutputControl.OutputName;
                toggledForm.Show();
                toggledForm.FormClosed += new FormClosedEventHandler( ( s, e ) => {
                    args.OnExitCb.Invoke( this, null );
                    _outputForms.Remove( args.GfxOutputControl );
                } );

                _outputForms.Add( args.GfxOutputControl, toggledForm );
            }
            else
            {
                _outputForms[args.GfxOutputControl].Close();
            }
        }

        public void ToggleGfxOutputForm( object sender, GfxOutputFormToggleEventArgs args )
        {
        }

        private void OnFormClosed( object sender, EventArgs args )
        {
            if( sender is MetalshowForm )
            {
                ExitThread();
            }
        }

        private AudioProcessor audioProcessor;
        private MetalshowController metalshowController;

        private MetalshowForm mainWindow;
        private Dictionary<GfxOutputControl, GfxOutputForm> _outputForms;
        private GfxOutputForm spectOutput;
        private GfxOutputForm loudnessOutput;

        private readonly Timer uiFrameTimer;
        private readonly int frameRate;
        private readonly int timerInterval;

        private List<Nodes.AudioTask> uiTasks;
    }
}
