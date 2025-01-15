using System;
using System.Windows.Forms;

namespace Metalshow
{
    public partial class GfxOutputForm : Form
    {
        public GfxOutputForm(GfxOutputControl output)
        {
            InitializeComponent();

            outputControl = output;
            outputControl.AdjustParentForm(this);
        }

        GfxOutputControl outputControl;
    }
    public class GfxOutputFormToggleEventArgs : EventArgs
    {
        public GfxOutputFormToggleEventArgs( GfxOutputControl ctrl, bool val, EventHandler cb )
        {
            GfxOutputControl = ctrl;
            Value = val;
            OnExitCb = cb;
        }

        public EventHandler OnExitCb
        {
            get;
        }

        public GfxOutputControl GfxOutputControl
        {
            get;
        }

        public bool Value
        {
            get;
        }
    }
}
