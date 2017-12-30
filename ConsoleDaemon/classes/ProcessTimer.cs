using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleDaemon.classes
{
    public class ProcessTimer
    {
        public delegate Task ProcessClock();
        public event ProcessClock OnClkProcess;
        Timer clk;

        public ProcessTimer(int period)
        {
            clk = new Timer(period);
            clk.Elapsed += Clk_Elapsed;
            clk.Start();
        }

        private void Clk_Elapsed(object sender, ElapsedEventArgs e)
        {
            OnClkProcess();
        }
    }
}
