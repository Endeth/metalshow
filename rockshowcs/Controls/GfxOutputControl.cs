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
            parent.MinimumSize = new Size( Size.Width, Size.Height );
            parent.MaximumSize = new Size( Size.Width, Size.Height );

            parent.FormBorderStyle = FormBorderStyle.FixedSingle;

            parent.Text = Name;

            parent.Controls.Add( this );
        }

        public string OutputName
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
    }

    public enum OutputType
    {
        Loudness,
        Spectogram
    }
}
