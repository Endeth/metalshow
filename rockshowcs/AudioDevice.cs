using NAudio.Wave;
using System;
using System.Collections.Generic;

namespace Metalshow
{
    internal class AudioDevice
    {
        AudioDevice(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name
        {
            get;
        }

        public int Id
        {
            get;
        }

        static public List<AudioDevice> GetInputDevices()
        {
            var list = new List<AudioDevice>();

            for( int n = -1; n < WaveIn.DeviceCount; n++ )
            {
                var caps = WaveIn.GetCapabilities( n );
                list.Add( new AudioDevice(n, caps.ProductName ) );
            }

            return list;
        }

        static public List<AudioDevice> GetOutputDevices()
        {
            var list = new List<AudioDevice>();

            for( int n = -1; n < WaveOut.DeviceCount; n++ )
            {
                var caps = WaveOut.GetCapabilities( n );
                list.Add( new AudioDevice( n, caps.ProductName ) );
            }

            return list;
        }
    }
}
