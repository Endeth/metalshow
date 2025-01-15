using System;
using System.Drawing;
using System.Windows.Forms;

namespace Metalshow.AudioOutput
{
    public abstract class BitmapOutput : IOutputStream
    {
        //Doesn't really matter which box is which
        public BitmapOutput( PictureBox box1, PictureBox box2 )
        {
            drawBitmaps = new Bitmap[2];
            pictureBoxes = new PictureBox[2];

            drawBitmaps[0] = new Bitmap( box1.Width, box1.Height);
            pictureBoxes[0] = box1;
            pictureBoxes[0].Image = drawBitmaps[0];

            drawBitmaps[1] = new Bitmap( box2.Width, box2.Height);
            pictureBoxes[1] = box2;
            pictureBoxes[1].Image = drawBitmaps[1];

            drawBitmapIdx = 0;
            drawX = 0;
            drawBitmapX = box1.Width;
            bitmapHeight = box1.Height;
            finishedBitmapX = 0;
        }

        public void Read( double[] array, int count )
        {
            DrawOnBitmap( array, count );
            MoveBitmaps();
        }

        abstract protected void DrawOnBitmap( double[] array, int count );

        private void MoveBitmaps()
        {
            drawBitmapX--;
            finishedBitmapX--;
            pictureBoxes[drawBitmapIdx % 2].Location = new Point( drawBitmapX, 0 );
            pictureBoxes[(drawBitmapIdx + 1) % 2].Location = new Point( finishedBitmapX, 0 );

            if( drawBitmapX == 0 )
            {
                drawX = 0;
                
                finishedBitmapX = 0;
                drawBitmapX = pictureBoxes[0].Width;

                drawBitmapIdx++;
            }
        }

        protected int bitmapHeight;
        protected int drawX;
        protected int drawBitmapX;
        protected int finishedBitmapX;

        protected int drawBitmapIdx;
        protected PictureBox[] pictureBoxes;
        protected Bitmap[] drawBitmaps;
    }
}
