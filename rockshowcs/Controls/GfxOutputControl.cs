using Metalshow.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Metalshow
{
    public partial class GfxOutputControl : UserControl
    {
        public GfxOutputControl()
        {
            InitializeComponent();
        }

        virtual public void AdjustParentForm( GfxOutputForm parent )
        {
            parent.MinimumSize = new Size(width, height);
            parent.MaximumSize = new Size(width, height);

            parent.FormBorderStyle = FormBorderStyle.FixedSingle;

            parent.Text = Name;
        }

        public string OutputName
        {
            get;
            protected set;
        }

        public OutputType Type
        {
            get;
            protected set;
        }

        virtual public void OnUITick( object sender, EventArgs args )
        {
        }

        virtual public void Cleanup()
        {
        }

        protected int width;
        protected int height;
    }

    public enum OutputType
    {
        Loudness,
        Spectogram
    }
}
