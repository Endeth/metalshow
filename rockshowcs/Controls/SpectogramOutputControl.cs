using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metalshow.Controls
{
    public partial class SpectogramOutputControl : GfxOutputControl
    {
        public SpectogramOutputControl()
        {
            InitializeComponent();

            width = 640;
            height = 480;
            Name = "Spectogram";
            Type = OutputType.Loudness;
        }

        override public void AdjustParentForm( GfxOutputForm parent )
        {
            base.AdjustParentForm( parent );
        }
    }
}
