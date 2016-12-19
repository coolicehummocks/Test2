using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    public class Bus
    {
        public delegate void EventBusHandler(Bus bus);

        public event EventBusHandler BusCome;

        public void BusComing()
        {
            this.BusCome(this);
        }
    }
}
