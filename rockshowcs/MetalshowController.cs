using Metalshow.Controls;
using Metalshow.Nodes;
using Metalshow.Signal;
using System;
using System.Windows.Forms.VisualStyles;

namespace Metalshow
{
    public class MetalshowController
    {
        public MetalshowController( AudioProcessor audioProcessor, MetalshowContext context )
        {
            _processor = audioProcessor;
            _viewContext = context;
        }

        public void CreateInput( int inputDevice )
        {
            _processor.SetInputDevice( inputDevice );
        }

        public void SetInputDevice( int inputDevice)
        {
            _processor.SetInputDevice( inputDevice );
        }

        public IncrementingNode CreateListener()
        {
            testListener = new IncrementingNode();
            _processor.AddNode( testListener );

            loudnessCtrl = new LoudnessOutputControl();
            loudnessCtrl.SetAudioListener( testListener );

            var cb = new EventHandler( ( s, e ) =>
            {
                if( testListener != null )
                {
                    RemoveListener( testListener );
                }

                if( loudnessCtrl != null )
                {
                    loudnessCtrl.Cleanup();
                    loudnessCtrl.SetAudioListener( null );
                    loudnessCtrl = null;
                }
            } );

            GfxOutputFormToggleEventArgs loudnessOutput = new GfxOutputFormToggleEventArgs( loudnessCtrl, true, cb );
            _viewContext.ToggleOutputForm( loudnessOutput );
            return testListener;
        }

        public void RemoveListener( IncrementingNode listener)
        {
            testListener = null;
            _processor.RemoveNode( listener );

            GfxOutputFormToggleEventArgs loudnessOutput = new GfxOutputFormToggleEventArgs( loudnessCtrl, false, null );
            _viewContext.ToggleOutputForm( loudnessOutput );
        }

        public bool ToggleStream()
        {
            return _processor.ToggleStream();
        }

        public void Exit()
        {
            _processor.CleanUp();
        }

        IncrementingNode testListener;
        LoudnessOutputControl loudnessCtrl;
        SpectogramOutputControl spectCtrl;

        private readonly AudioProcessor _processor;
        private readonly MetalshowContext _viewContext;
    }
}
