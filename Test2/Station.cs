using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test2
{
    public class Station
    {
        public string Name { get; private set; }

        public Queue<Passenger> Passengers { get; set; }

        public Station()
        {
            Passengers = new Queue<Passenger>();
        }

        public void AddPassenger(Passenger pass)
        {
            Passengers.Enqueue(pass);
        }


        public void BusIsComing(Bus bus)
        {

        }      
    }
}
