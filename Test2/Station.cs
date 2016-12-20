using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test2
{
    public class Station
    {
        public string Name { get; private set; }

        public Queue<Passenger> Passengers { get; set; }

        public bool IsBusStand { get; set; }

        public Station()
        {
            Passengers = new Queue<Passenger>();
        }

        public void AddPassenger(Passenger p)
        {
            Passengers.Enqueue(p);
        }

        public void AddPassengers(IEnumerable<Passenger> pass)
        {
            foreach (var p in pass)
            { 
                Passengers.Enqueue(p);
            }
        }


        public void BusIsComing(Bus bus)
        {
            IsBusStand = true;

            Thread enteringThread = new Thread(() => 
                {
                    while (IsBusStand && Passengers.Count > 0)
                    {
                        if (bus.IsDoorOpen && bus.IsSeatsExist)
                        {
                            var pass = Passengers.Dequeue();
                            bus.AddPassenger(pass);
                        }
                    }
                });

            enteringThread.Start();  
        }

        public void BusIsGoingAway(Bus bus)
        {
            IsBusStand = false;
        }
    }
}
