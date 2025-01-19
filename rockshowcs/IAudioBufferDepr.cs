using System.IO;

namespace Metalshow
{
    /*
    AudioBuffer - 
    */
    public interface IAudioBufferDepr
    {
        MemoryStream GetReadable();
        MemoryStream GetWriteable();

        //void CopyToArray( double[] array, int count);
        void Write( byte[] buffer, int offset, int count);
        int GetSize();
        int GetCapacity();
        void ReadComplete();
    }

    public class SingleAudioBufferDepr : IAudioBufferDepr
    {
        public SingleAudioBufferDepr( int bufferCapacity )
        {
            capacity = bufferCapacity;
            size = 0;
            buffer = new MemoryStream(capacity);
        }

        public MemoryStream GetReadable()
        {
            return buffer;
        }

        public MemoryStream GetWriteable()
        {
            return buffer;
        }

        public void Write( byte[] buffer, int offset, int count )
        {
            this.buffer.Write( buffer, 0, count );
            size += count;
        }

        public int GetSize()
        {
            return size;
        }

        public int GetCapacity()
        {
            //its dynamic
            return capacity;
        }

        public void ReadComplete()
        {
            size = 0;
            buffer.Position = 0;
        }

        int capacity;
        int size;
        MemoryStream buffer;
    }

    //Not implemented
    public class DoubleAudioBufferDepr : IAudioBufferDepr
    {
        public DoubleAudioBufferDepr( int bufferCapacity )
        {
            capacity = bufferCapacity;
            readIdx = 0;
            writeIdx = 1;
            buffers = new MemoryStream[]{ new MemoryStream( new byte[capacity], 0, 0, true, true ), new MemoryStream( new byte[capacity], 0, 0, true, true ) };
        }

        public MemoryStream GetReadable()
        {
            return buffers[readIdx];
        }

        public MemoryStream GetWriteable()
        {
            return buffers[writeIdx];
        }

        public void Write( byte[] buffer, int offset, int count )
        {
            //this.buffer.Write( buffer, 0, count );
            var stream = GetWriteable();
            stream.Write( buffer, offset, count );
            size = count;
        }

        public int GetSize()
        {
            return size;
        }

        public int GetCapacity()
        {
            return capacity;
        }

        public void ReadComplete()
        {
            var temp = readIdx;
            readIdx = writeIdx;
            writeIdx = temp;
        }

        int capacity;
        int size;
        MemoryStream[] buffers;
        int readIdx;
        int writeIdx;
    }
}
