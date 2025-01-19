using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Metalshow.Nodes
{
    public interface INode
    {
        void AddChild(INode childNode);
        void RemoveChild( INode childNode );
        void Delete();

        bool Active
        {
            get;
            set;
        }

        INode Parent
        {
            get;
            set;
        }

        List<INode> Children
        {
            get;
        }
    }

    public interface IInputNode<ResultType> : INode
    {
        void Get(ref ResultType resultRef);
    }

    public interface IOutputNode<ArgumentType> : INode
    {
        void Tick();
    }

    public interface IAudioBuffer<DataType>
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

    public class SingleAudioBuffer : IAudioBuffer<double[]>
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
            tempValue++;
        }

        public int Read( double[] buffer, int length )
        {
            buffer[0] = tempValue;
            return tempValue;
        }

        int tempValue = 0;
    }

    public class AudioInputNode : IInputNode<float>
    {
        public AudioInputNode(WaveFormat waveFormat, int deviceIdx)
        {
            Children = new List<INode>();

            _waveIn = new WaveInEvent { DeviceNumber = deviceIdx, WaveFormat = waveFormat };
            _waveIn.DataAvailable += OnDataAvailable;

            _buffer = new SingleAudioBuffer( 2048 );
        }

        public void SetDevice( int deviceIdx )
        {
            _waveIn.DeviceNumber = deviceIdx;
        }

        protected void OnDataAvailable(object sender, WaveInEventArgs args)
        {
            _buffer.Write( args.Buffer, 0, args.Buffer.Length );
        }

        //INode impl
        private bool _active;
        public bool Active
        {
            get => _active;
            set
            {
                _active = value;
                Children.ForEach( child => { child.Active = value; } );

                if( _active )
                {
                    _waveIn.StartRecording();
                }
                else
                {
                    _waveIn.StopRecording();
                }
            }
        }

        private INode _parent;
        public INode Parent
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
            private set;
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
            foreach ( INode childNode in Children )
            {
                childNode.Delete();
            }

            if( Parent != null )
            {
                Parent.RemoveChild( this );
            }
        }

        //IInputNode impl
        public void Get( ref float resultRef )
        {
            resultRef++;
        }

        WaveInEvent _waveIn;
        IAudioBuffer<double[]> _buffer;
    }

    // ui, audio output, console
    // they look at audio at their own framerate
    // generic from inodes (args now lets say lowest possible, ideally would match inode output in basic types)
    // Buffer highest possible
    // this is streaming, right?
    abstract public class AudioProcessNode<InputType, OutputType> : IInputNode<InputType>, IOutputNode<OutputType>
    {
        public AudioProcessNode()
        {
            Children = new List<INode>();
            Active = false;
        }

        //INode
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

        private INode _parent;
        public INode Parent
        {
            get => _parent;
            set
            {
                _parent = value;
                _parent.AddChild( this );

                if(value as IInputNode<InputType> != null)
                {
                    _node = value as IInputNode<InputType>;
                }
            }
        }

        public List<INode> Children
        {
            get;
            private set;
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

        //IInputNode
        public abstract void Get( ref InputType resultRef );

        //IOutputNode
        public abstract void Tick();

        protected IInputNode<InputType> _node;
        protected OutputType _output;
    }

    public class IncrementingNode : AudioProcessNode<float, float>
    {
        public IncrementingNode()
        {
            _output = 0.0f;
        }

        override public void Tick()
        {
            _node.Get( ref _output );
        }

        public override void Get( ref float resultRef )
        {
            resultRef = _output;
        }
    }
}
