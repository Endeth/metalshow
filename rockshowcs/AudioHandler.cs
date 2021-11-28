using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using NAudio.Wave;
using NAudio.CoreAudioApi;
using System.Windows.Forms;
using NAudio.Wave.SampleProviders;

namespace rockshowcs
{
    class AudioHandler
    {
        private int audioSampleRate = 44100;
        private int audioChunkSize = 2048;
        private int audioChannels = 2;
        private BufferedWaveProvider bufferedWaveProvider;
        private CancellationToken recordingCancelToken;
        private bool isPlaying = false;

        private AsioOut asioInput; //One for input from Katana, one for output on windows?
        private AsioOut asioOutput;
        byte[] buf = new byte[2048];
        int testInt = 0;

        //private AudioInput input;

        public void SetDevices()
        {
        }

        void WriteToBuffer( object sender, WaveInEventArgs eventArgs )
        {
            bufferedWaveProvider.AddSamples( eventArgs.Buffer, 0, eventArgs.BytesRecorded );
        }

        private void AverageTest( byte[] buf )
        {
            int average = 0;
            for( int i = 0; i < buf.Length; i++ )
                average += buf[i];
            Console.WriteLine( average );
        }

        void OnAsioOutAudioAvailable( object sender, AsioAudioAvailableEventArgs eventArgs )
        {
            float[] testtest = new float[eventArgs.SamplesPerBuffer * eventArgs.InputBuffers.Length];
            var samples = eventArgs.GetAsInterleavedSamples( testtest  );
            for( int i = 0; i < eventArgs.InputBuffers.Length; i++ )
            {
                Marshal.Copy( eventArgs.InputBuffers[i], buf, 0, eventArgs.SamplesPerBuffer * 2 );
                bufferedWaveProvider.AddSamples( buf, 0, eventArgs.SamplesPerBuffer * 2 );
            }
            //eventArgs.WrittenToOutputBuffers = true;
            Console.WriteLine( testInt++ );
            AverageTest( buf );
        }

        public async void StartRecording( CancellationToken cancelToken )
        {

            var drivers = AsioOut.GetDriverNames(); //0 - windows; 1 - Katana
            asioInput = new AsioOut( drivers[1] );
            asioOutput = new AsioOut( drivers[0] );

            var inputChannels = asioInput.DriverInputChannelCount;
            var outputChannels = asioOutput.DriverOutputChannelCount;

            bufferedWaveProvider = new BufferedWaveProvider( new NAudio.Wave.WaveFormat( audioSampleRate, audioChannels ) ); //audioSampleRate, 32, 2
            bufferedWaveProvider.DiscardOnBufferOverflow = true;

            //var recordChannelCount = 2;
            asioInput.InitRecordAndPlayback( null, 2, audioSampleRate );
            asioInput.AudioAvailable += new EventHandler<AsioAudioAvailableEventArgs>( OnAsioOutAudioAvailable );

            asioOutput.Init( bufferedWaveProvider );

            asioInput.Play();
            asioOutput.Play();
            isPlaying = true;
        }

        public void StopRecording()
        {
            if( isPlaying )
            {
                if( asioInput != null )
                {
                    asioInput.Stop();
                    asioInput.Dispose();
                }
                if( asioOutput != null )
                {
                    asioOutput.Stop();
                    asioOutput.Dispose();
                }
                isPlaying = false;
            }
        }

        public void ShowASIOControlPanel()
        {
            asioOutput?.ShowControlPanel();
        }

        public void PlaybackAudio()
        {
            //asioOut?.AudioAvailable += OnAsioOutAvailable;
            //asioInput?.Play();
        }

        public void StopPlaybackAudio()
        {
        }
        //public AudioChunkInfo GetSampleInfo()
    }
}
