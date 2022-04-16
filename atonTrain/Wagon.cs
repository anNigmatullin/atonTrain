using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atonTrain
{
    public class Wagon 
    {
        public Wagon(bool isLight, int wagonNumber)
        {
            this.isLight = isLight;
            this.wagonNumber = wagonNumber;
        }
        public Boolean isLight { get; private set; }
        public int wagonNumber { get; }


      
        public void SetLight(bool item)
        {   
           if (item)
            {
                isLight = true;
            }
            else
            {
                isLight = false;
            }
        }

      public  static Wagon CreateWagon(int wagonNumber)
        {            
            Random random = new Random();
            int value = random.Next(0, 2);
            Boolean light = false;
            if( value == 1 ) {
                 light = true;
            }
            else if ( value == 0 ) 
            {
                 light = false;
            }

            var wagon = new Wagon(light,wagonNumber);
            return wagon;
        }

        public override string ToString()
        {
            return $"Вагон номер - {wagonNumber}, свет - {isLight}";
        }
    }
}
