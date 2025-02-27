﻿
using NAudio.Wave;
using System;
using System.Collections.Generic;

namespace Metalshow.AudioInput
{
    public abstract class AudioStream : IInputStream, IOutputStream
    {
        public void StartStreaming()
        {
            if( isStreaming )
                return;

            isStreaming = true;

            StartStreaming_Impl();
        }

        public void StopStreaming()
        {
            if( !isStreaming )
                return;

            isStreaming = false;

            StopStreaming_Impl();
        }

        public bool IsStreaming()
        {
            return isStreaming;
        }

        public void ResetStream()
        {
            if( isStreaming )
                StopStreaming();

            StartStreaming();
        }

        abstract protected void StartStreaming_Impl();
        abstract protected void StopStreaming_Impl();

        virtual public void Read( double[] array, int count )
        {
             //buffer.CopyToArray( out array, count );
        }

        abstract protected void OnDataAvailable( object source, WaveInEventArgs args );

        public void AddReceiver(IOutputReceiver receiver)
        {
            receivers.Add( receiver );
        }

        protected bool isStreaming = false;
        protected BufferedWaveProvider waveProvider;
        //protected IAudioBufferDepr buffer;

        protected List<IOutputReceiver> receivers;
    }
}
