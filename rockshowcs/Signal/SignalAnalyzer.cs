using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metalshow.Signal
{
    public abstract class SignalAnalyzer : IOutputReceiver, IOutputStream
    {
        abstract public void Read( double[] array, int count );

        abstract public void Receive( double[] array, int count );
    }

    public class FFTAnalyzer : SignalAnalyzer
    {
        public double[] Powers
        {
            get;
            private set;
        }
        public double[] Frequencies
        {
            get;
            private set;
        }
        override public void Read( double[] array, int count )
        {
        }

        override public void Receive( double[] array, int count )
        {
        }
    }
}
