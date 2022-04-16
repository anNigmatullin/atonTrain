using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atonTrain
{
    internal class Train
    {    
        public Train(int numberOfWagons, List<Wagon> wagons)
        {
            this.numberOfWagons = numberOfWagons;
            this.wagons = wagons;
        }
       public int numberOfWagons { get;  }
       public List<Wagon> wagons { get;  }




       public static Train CreateTrain() {
            var random = new Random();
            int numberOfWagons = random.Next(5,10);

            List<Wagon> wagons = new List<Wagon>();
            for (int i = 0; i < numberOfWagons; i++)
            {
                wagons.Add(Wagon.CreateWagon(i));
            }

            var train = new Train(numberOfWagons,wagons);          
            Console.WriteLine($"Я создал состав вот он\n{train.ToString()}");
            return train;
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < numberOfWagons; i++)
            {
                stringBuilder.Append($"{wagons[i].ToString()}\n") ;
            }
            
            return stringBuilder.ToString();
        }
    }
}
