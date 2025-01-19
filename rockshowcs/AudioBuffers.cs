
namespace Metalshow
{
    public abstract class AudioBuffer
    {
        protected AudioBuffer( int capacity )
        {
            _capacity = capacity;
        }

        private int _size;
        public int Size
        {
            get => _size;
            protected set
            {
                _size = value;
            }
        }

        private int _capacity;
        public int Capacity
        {
            get => _capacity;
            protected set
            {
                _capacity = value;
            }
        }

        public abstract void Write( double[] buffer, int offset, int count );
        public abstract int Read( double[] buffer, int length );
    }

    public class LockingAudioBuffer : AudioBuffer
    {
        public LockingAudioBuffer( int capacity ) : base( capacity )
        {
            _internalBuffer = new double[capacity];
        }

        override public void Write( double[] buffer, int offset, int count )
        {
        }

        override public int Read( double[] buffer, int length )
        {
            return 1;
        }

        double[] _internalBuffer;
    }

    public class DoubleAudioBuffer : AudioBuffer
    {
        public DoubleAudioBuffer( int capacity ) : base( capacity )
        {
        }

        override public void Write( double[] buffer, int offset, int count )
        {
        }

        override public int Read( double[] buffer, int length )
        {
            return 1;
        }
    }

    public class CircularBuffer : AudioBuffer
    {
        public CircularBuffer( int capacity ) : base( capacity )
        {
        }

        override public void Write( double[] buffer, int offset, int count )
        {
        }

        override public int Read( double[] buffer, int length )
        {
            return 1;
        }
    }
}
