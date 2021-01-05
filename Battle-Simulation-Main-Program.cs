using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//way to subtract the damage from hp without sending to main program - combine 2 instances in one method
//add extensions - random miss, random regain hp

namespace Battle
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            //variables
            int character;
            int move;
            int special; //can miss/gain hp
            int won = 0;

            //create instance of class
            Class1 h;
            h = new Class1();
            Class1 e;
            e = new Class1();

            //get user to choose hero and setup stats
            Console.WriteLine("1. Cinderella");
            Console.WriteLine("2. Snow White");
            Console.WriteLine("3. Rapunzel");
            Console.Write("Which hero would you like to be (1/2/3): ");
            character = Int32.Parse(Console.ReadLine());
            h.setup(character);
            e.setup(4);
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("\nYou are battling your evil stepmother");

            //while alive keep battling
            while (h.gethp() > 0 && e.gethp() > 0)
            {
                System.Threading.Thread.Sleep(1000);
                special = rand.Next(1, 7); //1/6 chance to gain hp
                if (special == 1)
                {
                    h.gainhp(rand.Next(5, 21)); //gain 5 - 20 points
                    System.Threading.Thread.Sleep(1000);
                }
                h.selectmove();
                move = Int32.Parse(Console.ReadLine());
                special = rand.Next(1, 5); //1/4 chance that attack misses
                System.Threading.Thread.Sleep(1000);
                if (special == 1) 
                {
                    Console.WriteLine("\nYou have missed");
                }
                else
                {
                    h.damage(move);
                    e.subtractdamage(h);
                    Console.Write("\nYou damaged your evil stepmother's hp by ");
                    h.outputdamage();
                }
                Console.Write("Your evil stepmother's hp is now ");
                e.outputhp();
                if (e.gethp() < 1) //check if enemy has died
                {
                    won = 1; //hero won
                    break;
                }
                System.Threading.Thread.Sleep(1000);
                special = rand.Next(1, 7); //1/6 chance to gain hp
                if (special == 1)
                {
                    e.gainhp(rand.Next(5, 21)); //gain 5 - 20 points
                    System.Threading.Thread.Sleep(1000);
                }
                special = rand.Next(1, 5); //1/4 chance that attack misses
                if (special == 1) //misses if equal to 1
                {
                    Console.WriteLine("\nYour evil stepmother has missed");
                }
                else
                {
                    move = rand.Next(1, 3); //select random move
                    e.damage(move);
                    h.subtractdamage(e);
                    Console.Write("\nYour evil stepmother chose to ");
                    e.outputmove(move);
                    Console.Write("Your evil stepmother damaged your hp by ");
                    e.outputdamage();
                }
                Console.Write("Your hp is now ");
                h.outputhp();
                won = 2; //enemy won
            }

            //declare who won
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine();
            if (won == 1)
            {
                h.outputname();
                Console.Write(" has killed ");
                e.outputname();
                Console.WriteLine();
                h.outputname();
                Console.WriteLine(" has won ");
            }
            else if (won == 2)
            {
                e.outputname();
                Console.Write(" has killed ");
                h.outputname();
                Console.WriteLine();
                e.outputname();
                Console.WriteLine(" has won ");
            }

            //exit
            Console.WriteLine("\nPress any key to exit");
            Console.ReadKey();
        }
    }
}
