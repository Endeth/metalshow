using System;

namespace Metalshow
{
    public interface IInputStream
    {
        void StartStreaming();
        void StopStreaming();
        bool IsStreaming();
    }

    public interface IOutputStream
    {
        void Read( double[] array, int count );
    }

    public interface IOutputReceiver
    {
        void Receive( double[] array, int count );
    }
}
