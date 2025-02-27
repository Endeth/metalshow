﻿using Metalshow.Nodes;
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

        public void SetAudioListener( IInputNode<double> listener )
        {
            _listener = listener;
        }

        override public void OnUITick( object sender, EventArgs args)
        {
            if( _listener != null )
            {
                double val = 0.0f;
                _listener.GetResult( ref val );
                ListenerValue.Text = val.ToString();
            }
        }

        override public void Cleanup()
        {
            base.Cleanup();

            _timer.Stop();
            _timer.Dispose();

            _listener = null;
        }

        private IInputNode<double> _listener;
        private Timer _timer;
    }
}
