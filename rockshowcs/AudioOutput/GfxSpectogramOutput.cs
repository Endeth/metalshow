using System;
using System.Numerics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Metalshow.AudioOutput
{
    internal class GfxSpectogramOutput : BitmapOutput
    {
        public GfxSpectogramOutput( PictureBox box1, PictureBox box2 ) : base( box1, box2 )
        {
            sampleRate = 44100;
            samplesWindow = new FftSharp.Windows.Hanning();
            freqRangePerPixel4096 = SetPixelsRange( bitmapHeight, 4096, 2 );
            freqRangePerPixel8192 = SetPixelsRange( bitmapHeight, 8192, 2 );
            //fftBuffer = new double[16_384];
        }

        // Samples should be normalized; I want length to apply 4096 if has less samples
        // jittering exists because of analyzing different amount of samples
        override protected void DrawOnBitmap( double[] samples, int count )
        {
            int[] freqRange = freqRangePerPixel4096;

            double[] windowed = samplesWindow.Apply( samples );

            Complex[] spectrum = FftSharp.FFT.Forward( windowed );
            double[] psd = FftSharp.FFT.Magnitude( spectrum );
            double[] freq = FftSharp.FFT.FrequencyScale( psd.Length, sampleRate );

            int frequencies = freq.Length;
            double frequencyResolution = (double)frequencies / (double)bitmapHeight;

            int drawIdx = drawBitmapIdx % 2;

            double lastPowIdx = 0;

            for( int h = 0; h < bitmapHeight; h++ )
            {
                double avgPow = 0;
                int s = 0;

                /*
                for(double powI = lastPowIdx; powI < psd.Length && powI < (lastPowIdx + frequencyResolution); powI++ )
                {
                    avgPow += psd[(int)powI];
                    s++;
                }
                avgPow = avgPow * 255 / s;
                //*/

                for( int powIdx = freqRange[h]; h < bitmapHeight - 1 && powIdx < freqRange[h+1]; powIdx++ )
                {
                    avgPow += psd[powIdx];
                    s++;
                }
                avgPow = avgPow * 255 / s;

                int freqPower = Math.Min( Math.Max( (int)avgPow, 0 ), 255 );

                Color pixelColor = Color.FromArgb( freqPower, 0, 0 );
                drawBitmaps[drawIdx].SetPixel( drawX, h, pixelColor );

                lastPowIdx += frequencyResolution;
            }

            drawX++;
        }

        private int[] SetPixelsRange( int rangeLength, int target, double rangeGrowthSpeed )
        {
            int offset = 0;
            target -= offset;
            int[] range = new int[ rangeLength ];
            double initialValue = 1.0;
            double growthFactor = Math.Log( target / initialValue ) / ( rangeLength - 1 );

            double value;
            double lastValue = 1;
            for( int i = 0; i < rangeLength; i++ )
            {
                //double growthMultiplier = Math.Pow( (double)i / ( rangeLength - 1 ), rangeGrowthSpeed );
                value = Math.Exp( growthFactor * i );

                range[i] = (value - lastValue) > 1 ? (int)value : (i + offset);

                lastValue = range[i];
            }

            return range;
        }

        private (double[] psd, double[] frequencies) GetSpectogram( double[] samples, int count )
        {
            double[] windowed = samplesWindow.Apply( samples );

            Complex[] spectrum = FftSharp.FFT.Forward( windowed );
            double[] powers = FftSharp.FFT.Magnitude( spectrum );
            double[] freqs = FftSharp.FFT.FrequencyScale( powers.Length, sampleRate );

            return (powers, freqs);
        }

        private int[] freqRangePerPixel4096;
        private int[] freqRangePerPixel8192;
        private FftSharp.Window samplesWindow;
        private int sampleRate;
    }
}
