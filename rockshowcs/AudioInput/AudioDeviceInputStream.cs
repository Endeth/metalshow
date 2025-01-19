using System;
using Metalshow.AudioInput;
using NAudio.Wave;

namespace Metalshow
{
    internal class AudioDeviceInputStream : AudioStream
    {
        public AudioDeviceInputStream( int deviceIdx, WaveFormat waveFormat )
        {
            waveIn = new WaveInEvent { DeviceNumber = deviceIdx, WaveFormat = waveFormat, BufferMilliseconds = 20 };
            waveIn.DataAvailable += OnDataAvailable;
        }
        override protected void OnDataAvailable( object source, WaveInEventArgs args )
        {
            /*
            lock( buffer )
            {
                waveProvider.AddSamples( args.Buffer, 0, args.Buffer.Length );
                buffer.Write( args.Buffer, 0, args.Buffer.Length );
            }
            */
        }

        public void SetInputDevice( int deviceIdx )
        {
            waveIn.DeviceNumber = deviceIdx;
        }

        override protected void StartStreaming_Impl()
        {
            waveIn.StartRecording();
        }

        override protected void StopStreaming_Impl()
        {
            waveIn.StopRecording();
        }

        WaveInEvent waveIn;
    }
}
