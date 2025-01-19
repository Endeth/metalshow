using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;

namespace Metalshow.Nodes
{
    public abstract class INode
    {
        protected INode(INode parent)
        {
            Children = new List<INode>();

            _parent = parent;
            Active = false;
        }

        virtual public void Start()
        {
            Active = true;
        }
        virtual public void Stop()
        {
            Active = false;
        }

        private bool _active;
        public bool Active
        {
            get => _active;
            protected set
            {
                _active = value;
                Children.ForEach( child => { child.Active = value; } );
            }
        }

        private INode _parent;
        virtual public INode Parent
        {
            get => _parent;
            set
            {
                _parent = value;
                _parent.AddChild( this );
            }
        }

        public List<INode> Children
        {
            get;
            protected set;
        }

        public void AddChild( INode childNode )
        {
            Children.Add( childNode );
        }

        public void RemoveChild( INode childNode )
        {
            Children.Remove( childNode );
        }

        public void Delete()
        {
            foreach( INode childNode in Children )
            {
                childNode.Delete();
            }

            if( Parent != null )
            {
                Parent.RemoveChild( this );
            }
        }
    }

    public interface IInputNode<ResultType>
    {
        void GetResult(ref ResultType resultRef);
    }

    public interface IProcessingNode
    {
        void Tick();
    }

    public interface IWaveSampleReader<WaveType>
    {
        void Read( WaveType wave );
    }

    public class WaveSampleReader : INode, IInputNode<double[]>, IProcessingNode, IWaveSampleReader<BufferedWaveProvider>
    {
        public WaveSampleReader( INode parent, int capacity, double multiplier ) : base( parent )
        {
            //_internalBuffer = new CircularBuffer( capacity );
            _capacity = capacity;
            _internalBuffer = new double[capacity];
            _castBuffer = new float[capacity];
            _input = parent as IInputNode<IWaveSampleReader<BufferedWaveProvider>>;
            _multiplier = multiplier;
        }

        public void GetResult( ref double[] result )
        {
            if( result.Length < _capacity )
                throw new Exception( "Buffer not large enough" );

            Array.Copy( _castBuffer, result, _capacity );
        }

        public void Tick()
        {
            if( Active )
            {
                IWaveSampleReader<BufferedWaveProvider> temp = this;
                _input.GetResult( ref temp );
            }
        }

        public void Read( BufferedWaveProvider wave )
        {
            var sp = wave.ToSampleProvider();
            int samplesRead = sp.Read( _castBuffer, 0, 1024 );

            for( int i = 0; i < samplesRead; i++ )
            {
                _internalBuffer[i] = _castBuffer[i] * _multiplier;
            }
        }

        private IInputNode<IWaveSampleReader<BufferedWaveProvider>> _input;
        private int _capacity;
        private float[] _castBuffer;
        private double[] _internalBuffer;
        private double _multiplier;
        //CircularBuffer _internalBuffer;
    }

    public class DeviceReaderNode : INode, IInputNode<IWaveSampleReader<BufferedWaveProvider>>
    {
        public DeviceReaderNode(INode parent, WaveFormat waveFormat, int deviceIdx) : base(parent)
        {
            _waveIn = new WaveInEvent { DeviceNumber = deviceIdx, WaveFormat = waveFormat };
            _waveIn.DataAvailable += OnDataAvailable;

            _internalBuffer = new BufferedWaveProvider( waveFormat );
        }

        override public void Start()
        {
            base.Start();

            _waveIn.StartRecording();
        }

        override public void Stop()
        {
            base.Stop();

            _waveIn.StopRecording();
        }

        public void SetDevice( int deviceIdx )
        {
            _waveIn.DeviceNumber = deviceIdx;
        }

        protected void OnDataAvailable(object sender, WaveInEventArgs args)
        {
            lock(_internalBuffer)
                _internalBuffer.AddSamples( args.Buffer, 0, args.Buffer.Length );
        }

        //IInputNode
        public void GetResult( ref IWaveSampleReader<BufferedWaveProvider> resultRef )
        {
            lock( _internalBuffer )
            {
                resultRef.Read( _internalBuffer );

                //TODO temp
                _internalBuffer.ClearBuffer();
            }
        }

        WaveInEvent _waveIn;
        BufferedWaveProvider _internalBuffer;
    }

    abstract public class AudioProcessNode<NodeArgs, NodeOutput> : INode, IInputNode<NodeOutput>
    {
        public AudioProcessNode(INode parent) : base(parent)
        {
        }

        override public INode Parent
        {
            get => base.Parent;
            set
            {
                base.Parent = value;

                if( value as IInputNode<NodeArgs> != null )
                {
                    _node = value as IInputNode<NodeArgs>;
                }
            }
        }

        //IInputNode
        public abstract void GetResult( ref NodeOutput result );

        protected IInputNode<NodeArgs> _node;
        protected NodeOutput _output;
    }

    public class PeakNode : AudioProcessNode<double[], double>
    {
        public PeakNode(INode parent) : base(parent)
        {
            _output = 0.0f;
            _peak = 0.0;
        }

        public void Tick()
        {
            if( Active )
            {
                double[] result = new double[1024];
                _node.GetResult( ref result );
                _peak = result.Max();
            }
        }

        public override void GetResult( ref double result )
        {
            result = _peak;
        }

        private double _peak;
    }
}
