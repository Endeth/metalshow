
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;

namespace Metalshow.AudioInput
{
    //More like a buffer iirc
    internal class WaveGenerator : IOutputStream
    {
        public WaveGenerator()
        {
            waveGenerator = new SignalGenerator()
            {
                Gain = 0.2,
                Frequency = 500,
                Type = SignalGeneratorType.Sin
            }.Take( TimeSpan.FromSeconds( 1 ) );
        }

        public void Read( double[] array, int count )
        {
        }    

        private ISampleProvider waveGenerator;
    }
}
