using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Metalshow.Nodes
{
    public interface IProcessingNode
    {
        void AddChild(IProcessingNode childNode);
        void RemoveChild( IProcessingNode childNode );
        void Delete();

        bool Active
        {
            get;
            set;
        }

        IProcessingNode Parent
        {
            get;
        }

        List<IProcessingNode> Children
        {
            get;
        }
    }

    public interface IAudioBuffer
    {
        int Length
        {
            get;
        }

        int Capacity
        {
            get;
        }

        void Write( byte[] buffer, int offset, int count );
        int Read(double[] buffer, int length);
    }

    public class SingleAudioBuffer : IAudioBuffer
    {
        public SingleAudioBuffer(int capacity)
        {
        }

        public int Length
        {
            get;
            private set;
        }

        public int Capacity
        {
            get;
            private set;
        }

        public void Write( byte[] buffer, int offset, int count )
        {
        }

        public int Read( double[] buffer, int length )
        {
            int tempNumber = 1;

            buffer[0] = 1;

            return tempNumber;
        }
    }

    public abstract class AudioTask
    {
        protected void SetOperation( Func<CancellationToken, Task> op )
        {
            operation = op;
        }

        public void Run()
        {
            var tokenSource = new CancellationTokenSource();
            try
            {
                operation( tokenSource.Token ).GetAwaiter().GetResult();
            }
            catch (Exception e)
            {
                Console.WriteLine( $"Error during synchronous execution: {e.Message}" );
                throw;
            }
        }

        protected Func<CancellationToken, Task> operation;
    }

    public class AudioInputTaskNode : IProcessingNode
    {
        public AudioInputTaskNode(WaveFormat waveFormat, int deviceIdx)
        {
            _waveIn = new WaveInEvent { DeviceNumber = deviceIdx, WaveFormat = waveFormat };
            _waveIn.DataAvailable += OnDataAvailable;

            _buffer = new SingleAudioBuffer( 2048 );
        }

        public void Start()
        {
            _waveIn.StartRecording();
        }

        public void Stop()
        {
            _waveIn.StopRecording();
        }

        public void SetDevice( int deviceIdx )
        {
            _waveIn.DeviceNumber = deviceIdx;
        }

        public int Read( double[] buffer, int length )
        {
            int samplesRead = _buffer.Read( buffer, length );

            return samplesRead;
        }

        protected void OnDataAvailable(object sender, WaveInEventArgs args)
        {
            _buffer.Write( args.Buffer, 0, args.Buffer.Length );
            Console.WriteLine( "Data ready" );
        }

        private bool _active;
        public bool Active
        {
            get => _active;
            set
            {
                _active = value;
                Children.ForEach( child => { child.Active = value; } );
            }
        }

        public IProcessingNode Parent
        {
            get;
            protected set;
        }

        public List<IProcessingNode> Children
        {
            get;
            private set;
        }

        public void AddChild( IProcessingNode childNode )
        {
            Children.Add( childNode );
        }

        public void RemoveChild( IProcessingNode childNode )
        {
            Children.Remove( childNode );
        }

        public void Delete()
        {
            foreach ( IProcessingNode childNode in Children )
            {
                childNode.Delete();
            }

            if( Parent != null )
            {
                Parent.RemoveChild( this );
            }
        }

        WaveInEvent _waveIn;
        IAudioBuffer _buffer;
    }

    // ui, audio output, console
    // they look at audio at their own framerate
    // generic from inodes (args now lets say lowest possible, ideally would match inode output in basic types)
    // Buffer highest possible
    // this is streaming, right?
    public class AudioListener<AudioInputTaskNode, Buffer>
    {
        public AudioListener()
        {
        }

        public void Start()
        {
            Active = true;
        }

        public void Stop()
        {
            Active = false;
        }

        public void Tick()
        {
            Console.WriteLine( "AudioListener tick" );
        }

        public Buffer Get()
        {
            return buffer;
        }

        public void AddNode( AudioInputTaskNode node )
        {
            _node = node;
        }

        public void RemoveNode( AudioInputTaskNode node )
        {
            _node = default;
        }

        public bool Active
        {
            get;
            private set;
        }

        //bool
        Buffer buffer; //return buffer we will watch from another thread
        AudioInputTaskNode _node;
    }
}
