using Metalshow.AudioInput;
using Metalshow.Nodes;
using Metalshow.Signal;
using NAudio.SoundFont;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;

namespace Metalshow
{
    public class AudioProcessor
    {
        public AudioProcessor()
        {
            waveFormat = new WaveFormat( 44100, 16, 1 );
            _inputNode = new DeviceReaderNode( null, waveFormat, 0 );
            _sampleReader = new WaveSampleReader( _inputNode, 1024, 16_000 );

            bufferSize = 1024 * waveFormat.Channels;
            //frameRate = waveFormat.SampleRate / bufferSize;
            timerInterval = 500;

            mainLoopTimer = new System.Timers.Timer( timerInterval );
            mainLoopTimer.Elapsed += OnMainLoopTick;
            mainLoopTimer.AutoReset = true;
        }

        private void StartMainLoop()
        {
            mainLoopTimer.Start();

            if( _inputNode != null )
            {
                _inputNode.Start();
            }

            if( _sampleReader != null )
            {
                _sampleReader.Start();
            }

            if(_audioListener != null)
            {
                _audioListener.Start();
            }
        }

        private void StopMainLoop()
        {
            if( _audioListener != null )
            {
                _audioListener.Stop();
            }

            if( _sampleReader != null )
            {
                _sampleReader.Stop();
            }

            if( _inputNode != null )
            {
                _inputNode.Stop();
            }

            mainLoopTimer.Stop();

            mainLoopThread.Join();
            mainLoopThread = null;
        }

        public void OnMainLoopTick( object source, ElapsedEventArgs args )
        {
            if( Active )
            {
                if( _sampleReader != null )
                {
                    _sampleReader.Tick();
                }

                if( _audioListener != null )
                {
                    _audioListener.Tick();
                }
            }
        }

        public void CreateInput( int id )
        {
            if( _inputNode == null )
            {
                return;
            }
            _inputNode = new DeviceReaderNode( null, waveFormat, 0 );
        }

        public void SetInputDevice( int id )
        {
            if( _inputNode == null )
            {
                return;
            }

            _inputNode.SetDevice( id );
        }

        public void AddNode( PeakNode node )
        {
            node.Parent = _sampleReader;
            _audioListener = node;
        }

        public void RemoveNode( PeakNode node )
        {
            _audioListener = null;
        }

        public void StartStream()
        {
            /*if( inputStream == null )
            {
                AudioDeviceInputStream input = new AudioDeviceInputStream( 0, waveFormat );
                inputStream = input;
                //Input will have its on buffer
                input.SetBufferFillHandler( OnMainLoopTick );
            }
            //outputIntervalTimer.Start();
            inputStream.StartStreaming();*/

            mainLoopThread = new Thread( StartMainLoop );
            mainLoopThread.Start();
            Active = true;
        }

        public void StopStream()
        {
            StopMainLoop();
            Active = false;
        }

        public bool ToggleStream()
        {
            if( !Active )
            {
                StartStream();
                return true;
            }
            else
            {
                StopStream();
                return false;
            }
        }

        public void CleanUp()
        {
            mainLoopTimer.Dispose();
            //Stop all audio input
            //Stop threads
        }


        /*public void OnUITick( object source, EventArgs args)
        {
            int samplesRead = 0;
            lock( buffer )
            {
                bufferSize = buffer.GetSize();
                if( bufferSize == 0 )
                {
                    return;
                }

                samplesRead = WavToSamples( waveProvider, dSamplesBuffer, buffer.GetSize() );
                waveProvider.ClearBuffer();

                buffer.ReadComplete();
            }

            foreach( var output in outputStreams )
            {
                output.Write( dSamplesBuffer, samplesRead );
            }

            frameIdx++;
        }*/
        //private float[] samplesBuffer = new float[8192];
        /*private int WavToSamples( BufferedWaveProvider wav, double[] samples, int count, double multiplier = 16_000 )
        {
            var sampleProvider = wav.ToSampleProvider();
            int samplesRead = sampleProvider.Read( samplesBuffer, 0, count );

            for( int i = 0; i < samplesRead; i++ )
            {
                samples[i] = samplesBuffer[i] * multiplier;
            }

            return samplesRead;
        }*/

        private DeviceReaderNode _inputNode;
        private WaveSampleReader _sampleReader;
        private PeakNode _audioListener;

        //private AudioDeviceInputStream inputStream;
        //private List<IOutputStream> outputStreams;

        //Audio info
        WaveFormat waveFormat;
        private int bufferSize;
        private readonly int frameRate;

        public bool Active
        {
            get; private set;
        }

        private Thread mainLoopThread;
        private readonly System.Timers.Timer mainLoopTimer;
        private readonly int timerInterval;
    }
}
