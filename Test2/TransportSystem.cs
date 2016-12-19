using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    public class TransportSystem
    {
        public TransportSystem()
        {
            Bus bus1 = new Bus();
            Station station1 = new Station();
            bus1.BusCome += station1.BusIsComing;
            bus1.BusComing();
        }

        public string Iterate()
        {
            return "iterate";
        }
    }
}
