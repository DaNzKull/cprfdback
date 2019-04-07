using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRFeedbackER
{
    class Timer
    {
        private int elapsedTime { get; set; }

        Stopwatch sw = new Stopwatch();
        public Timer()
        {
        }

        public int getElapsedSec()
        {
            return elapsedTime;
        }

        public void startTimer()
        {
            sw.Start();
        }

        public void stopTimer()
        {
            sw.Stop();
        }

        public void resetTimer()
        {
            sw.Reset();
        }
        
    }
}
