using Metalshow.AudioInput;
using Metalshow.Nodes;
using Metalshow.Signal;
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
            _inputNode = new AudioInputNode( waveFormat, 0 );

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
                _inputNode.Active = true;
            }

            if(_audioListener != null)
            {
                _audioListener.Active = true;
            }
        }

        private void StopMainLoop()
        {
            if( _audioListener != null )
            {
                _audioListener.Active = false;
            }

            if( _inputNode != null )
            {
                _inputNode.Active = false;
            }

            mainLoopTimer.Stop();

            mainLoopThread.Join();
            mainLoopThread = null;
        }

        public void OnMainLoopTick( object source, ElapsedEventArgs args )
        {
            if( Active )
            {
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
            _inputNode = new Nodes.AudioInputNode( waveFormat, 0 );
        }

        public void SetInputDevice( int id )
        {
            if( _inputNode == null )
            {
                return;
            }

            _inputNode.SetDevice( id );
        }

        public void AddNode( IncrementingNode node )
        {
            node.Parent = _inputNode;
            _audioListener = node;
        }

        public void RemoveNode( IncrementingNode node )
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
            var sampleProvider = waveProvider.ToSampleProvider();
            int samplesRead = sampleProvider.Read( samplesBuffer, 0, count );

            for( int i = 0; i < samplesRead; i++ )
            {
                samples[i] = samplesBuffer[i] * multiplier;
            }

            return samplesRead;
        }*/

        private Nodes.AudioInputNode _inputNode;
        private IncrementingNode _audioListener;

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
