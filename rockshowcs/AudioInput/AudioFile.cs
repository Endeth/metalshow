
using NAudio.Wave;

namespace Metalshow.AudioInput
{
    internal class AudioFileInput : AudioStream
    {
        override protected void StartStreaming_Impl()
        {

        }

        override protected void StopStreaming_Impl()
        {

        }
        override protected void OnDataAvailable( object source, WaveInEventArgs args )
        {
        }
    }
}
