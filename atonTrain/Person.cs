using System;
using System.Collections.Generic;
using System.Linq;

namespace atonTrain
{
    abstract class Person
    {
        public static int amountOfWagon { get; set; }


        public static void starWalking(Train train)
        {
            Stack<Wagon> stack = new Stack<Wagon>();
            List<Wagon> wagons = train.wagons;
            Console.WriteLine("В первом вагоне свет должен быть включен всегда\n");
            wagons[0].SetLight(true) ;
            while (true)
            {
                Person.RunForward(ref train, ref stack);
                if (Person.RunBack(ref train, ref stack))
                {
                    break;
                }
            }
        }
        public static bool RunBack(ref Train train, ref Stack<Wagon> stack)
        {
            Console.WriteLine("Теперь обратно идти");

            if (stack.Peek().wagonNumber == train.numberOfWagons - 1)
            {
                foreach (var item in stack)
                {
                    if (item.wagonNumber == 0)
                    {
                        item.SetLight(false);
                        Console.WriteLine(item.ToString());
                    }
                    else
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
                Console.WriteLine("Ура свет выключен!");
                Console.WriteLine($"Количество вагонов - {stack.Peek().wagonNumber + 1}");
                return true;
            }
            else
            {
                foreach (var item in stack)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.WriteLine("Свет в нулевом вагоне всё еще включен");
                Console.WriteLine("\n");
                stack.Clear();
                return false;
            }
        }
        public static void RunForward(ref Train train, ref Stack<Wagon> stack)
        {

            List<Wagon> wagons = train.wagons;
            stack.Push(wagons.First());
            amountOfWagon = 0;
            Console.WriteLine("Начинаю своё путешествие!");
            while (true)
            {
                amountOfWagon++;
                if (amountOfWagon == wagons.Count)
                {
                    break;
                }

                if (wagons[amountOfWagon].isLight == false)
                {
                    Console.WriteLine("Иду в следующий вагон");
                    Console.WriteLine(wagons[amountOfWagon].ToString());
                    stack.Push(wagons[amountOfWagon]);
                }
                else if (wagons[amountOfWagon].isLight == true)
                {
                    stack.Push(wagons[amountOfWagon]);
                    wagons[amountOfWagon].SetLight(false);
                    Console.WriteLine($"Нашел вагон со светом! Вагон номер-{amountOfWagon}");
                    Console.WriteLine("Выключу свет в этом вагоне");
                    break;
                }
            }
        }
    }
}
