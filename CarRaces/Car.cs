using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRaces
{
    public class Car
    {
        public int Id { get; set; }
        public int currentPosition { get; set; }

        public int startPoistion { get; set; }

        public string Name { get; set; }

        public Random random { get; set; }



        public int GetNewPosition()
        {
            random = new Random();
            return  random.Next(1, 15);
        }

    }
}
