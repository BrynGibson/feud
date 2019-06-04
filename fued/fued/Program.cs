using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

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
            Sort(contestants);
            Menu(contestants);
            //Print(contestants);
            //Finalists(contestants);
            Console.ReadLine();

        }

        public static void Menu(Contestant[] contestants)
        {
            Console.Clear();
            int x;
            Console.WriteLine("1   Print contestant details \n2   Change contestants intrests\n3   Play Family Feud!");
            x = Convert.ToInt32(Console.ReadLine());
            switch (x)
            {
                case 1: Print(contestants);
                    break;
                case 2: Edit(contestants);
                    break;
                case 3: Finalists(contestants);
                    break;
                default: Console.WriteLine("Command not recognized! Please enter the corresponding value to the option you would like to choose.\n\n Enter to return to menu...");
                    Console.ReadLine();
                    Menu(contestants);
                    break;
            }

        }



        public static void Edit(Contestant[] contestants)
        {
            int change;
            string newintrest;

            Console.Clear();
            Console.WriteLine("Current contestant details...\n");

            for (int i = 0; i < 43; i++)
            {
                Console.WriteLine("First name: " + contestants[i].firstName);
                Console.WriteLine("Last name: " + contestants[i].lastName);
                Console.WriteLine("Intrest: " + contestants[i].intrest);
                Console.WriteLine("Contestant number: " + contestants[i].number);
                Console.WriteLine();
            }

            Console.WriteLine("Please enter the contestant number of the contestant you would like to update the intrest feild for");
            change = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("\nPlease enter the new intrest");
            newintrest = Console.ReadLine();

            for (int i = 0; i < 43; i++)
            {
                if (change == contestants[i].number)
                {
                    contestants[i].intrest = newintrest;

                    Console.Clear();
                    Console.WriteLine("\nUpdated. Press enter to continue");
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
            Console.Clear();
            Console.WriteLine("Contestant details...\n");

            for (int i = 0; i < 43; i++)
            {
                Console.WriteLine("First name: " + contestants[i].firstName);
                Console.WriteLine("Last name: " + contestants[i].lastName);
                Console.WriteLine("Intrest: " + contestants[i].intrest);
                Console.WriteLine("Contestant number: " + contestants[i].number);
                Console.WriteLine();
            }
            Console.WriteLine("Enter to continue...");
            Console.ReadLine();

            Menu(contestants);
        }

        public static Contestant Finalists(Contestant[] contestants)
        {
            Contestant finalist;
            Random rand = new Random();
            int[] finalists = new int[10];
            int temp, place1, place2, ifinalist;

            int[] potfinalists = new int[43];

            Console.WriteLine("Choosing finalists! ...");
            Thread.Sleep(2000);

            for (int x = 0; x < 43; x++)
            {
                potfinalists[x] = x;
            }



            for (int i = 0; i < 1000; i++)
            {
                place1 = rand.Next(0, 43);
                place2 = rand.Next(0, 43);

                if (place1 != place2)
                {
                    temp = potfinalists[place1];
                    potfinalists[place1] = potfinalists[place2];
                    potfinalists[place2] = temp;
                }

            }


            for (int u = 0; u < 10; u++)
            {
                finalists[u] = potfinalists[u];
            }

            Console.Clear();
            Console.WriteLine("The finalists are ....\n");

            for(int g = 0; g < 10; g++)
            {
                Console.WriteLine(contestants[finalists[g]].firstName + " " + contestants[finalists[g]].lastName);

            }

            Console.WriteLine("\nOnly one of these will make it to the grand final!");
            Console.WriteLine("\nPress enter to continue...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("And the grand finalist is...\n");
            Thread.Sleep(2000);
            Console.WriteLine("...\n");
            Thread.Sleep(2000);
        

            ifinalist = finalists[rand.Next(0, 10)];
            finalist = contestants[ifinalist];

            Console.WriteLine(finalist.firstName + " " + finalist.lastName);
            return finalist;


        }   
    }
}
