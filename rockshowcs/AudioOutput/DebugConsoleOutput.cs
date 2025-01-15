using System;
using System.Linq;

namespace Metalshow.AudioOutput
{
    internal class DebugConsoleOutput : IOutputStream
    {
        public void Read( double[] array, int bytesCount )
        {
            WriteBar( array );
        }

        private void WriteBar( double[] array )
        {
            double max = array.Max();
            double fraction = Math.Max( max, 0.0f );

            string bar = new string( '#', (int)( fraction * 70 ) );
            string meter = $"Frac [{fraction}] [" + bar.PadRight( 60, '-' ) + "]";
            Console.CursorLeft = 0;
            Console.CursorVisible = false;
            Console.Write( $"{meter} {fraction * 100:00.0}%" );
        }
    }
}
