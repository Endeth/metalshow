using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Metalshow.AudioOutput
{
    internal class GfxLoudnessOutput : BitmapOutput
    {
        public GfxLoudnessOutput( PictureBox box1, PictureBox box2 ) : base( box1, box2 )
        {

        }

        override protected void DrawOnBitmap( double[] array, int count )
        {
            double fraction = Math.Max( array.Max(), 0.0f );

            int drawIdx = drawBitmapIdx % 2;
            int colorValue = (int)( fraction * 255 );
            Color pixelColor = Color.FromArgb( colorValue, colorValue, colorValue );
            Brush brush = new SolidBrush( pixelColor );

            var gfx = Graphics.FromImage( drawBitmaps[drawIdx] );
            gfx.FillRectangle( brush, new Rectangle( drawX, 0, 1, bitmapHeight ) );

            drawX++;
        }
    }
}
