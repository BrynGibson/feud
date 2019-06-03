using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace fued
{
    public struct Contestant
    {
        public string lastName;
        public string firstName;
        public string intrest;
        public int number;
        

    }

    class Program
    {

        static void Main(string[] args)
        {
            Contestant[] contestants = new Contestant[43];

            Read(contestants);
            //Sort(contestants);
            //Print(contestants);
            Finalists(contestants);
            Console.ReadLine();

        }

        public static void Menu(Contestant[] contestants)
        {
            int x;
            Console.WriteLine("1   Print contestants \n");
            x = Convert.ToInt32(Console.ReadLine());
            switch (x)
            {
                case 1: Print(contestants);
                    break;
            }

        }



        public static void Edit(Contestant[] contestants)
        {
            int change;
            string newintrest;

            Console.WriteLine("Please Enter the contestant number of the contestant you would like to update the intrest feild for");
            change = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Please enter the new intrest");
            newintrest = Console.ReadLine();

            for (int i = 0; i < 43; i++)
            {
                if (change == contestants[i].number)
                {
                    contestants[i].intrest = newintrest;

                    Console.Clear();
                    Console.WriteLine("Updated. Press enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                    

                   
                }

            }

            Menu(contestants);
        }

        public static void Read (Contestant[] contestants)
        {


            StreamReader sr = new StreamReader(@"C:\Users\SlinkyMalinki\Desktop\familygame\familyFeud.txt");

            int count = 0;

            while (!sr.EndOfStream)
            {
                contestants[count].firstName = sr.ReadLine();
                contestants[count].lastName = sr.ReadLine();
                contestants[count].intrest = sr.ReadLine();
                contestants[count].number = count + 1;

                count = count + 1;
            }
            sr.Close();

        }

        public static void Sort(Contestant[] contestants)
        {
            Contestant temp;

            for (int i = 0; i < contestants.Length - 1; i++)
            {
                for (int pos = 0; pos < contestants.Length - 1; pos++)
                {
                    if (contestants[pos + 1].lastName.CompareTo(contestants[pos].lastName) < 0)
                    {
                        temp = contestants[pos + 1];
                        contestants[pos + 1] = contestants[pos];
                        contestants[pos] = temp;
                    }

                }
            }

        }

        public static void Print(Contestant[] contestants)
        {
            for (int i = 0; i < 43; i++)
            {
                Console.WriteLine("First name: " + contestants[i].firstName);
                Console.WriteLine("Last name: " + contestants[i].lastName);
                Console.WriteLine("Intrest: " + contestants[i].intrest);
                Console.WriteLine("Contestant number: " + contestants[i].number);
                Console.WriteLine();
            }
        }

        public static void Finalists(Contestant[] contestants)
        {
            Random rand = new Random();
            int[] finalists = new int[10];
            int temp, place1, place2;

            int[] potfinalists = new int[43];

            for(int x = 0; x < 43; x++)
            {
                potfinalists[x] = x + 1;
            }
            
            

            for(int i = 0; i < 1000; i++)
            {
                place1 = rand.Next(0, 43);
                place2 = rand.Next(0, 43);
                if(place1 != place2)
                {
                    temp = potfinalists[place1];
                    potfinalists[place1] = potfinalists[place2];
                    potfinalists[place2] = temp;
                }

            }
           

            for(int u = 0; u < 10; u++)
            {
                finalists[u] = potfinalists[u];
            }

            for (int t = 0; t < 10; t++)
            {
                Console.WriteLine(finalists[t]);
            }
                    





            //finalists[1] = rand.Next(1, 44);

                //for(int i = 1; i < 10; i++)
                //{
                //    temp = rand.Next(1, 44);
                //    foreach( int item in finalists)
                //    {
                //        if(temp == finalists[i])
                //        {

                //        }
                //    }
                //}
            }
    }
}
