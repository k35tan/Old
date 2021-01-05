using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle
{
    class Class1
    {
        Random rand = new Random();

        //character name
        private string name;
        //starting hp
        private int hp;
        //attack names
        private string one;
        private string two;
        //attack power
        private int hitonemin;
        private int hitonemax;
        private int hittwomin;
        private int hittwomax;
        private int hit;

        //set hp, attack names, attack power range
        public void setup(int character)
        {
            if (character == 1)
            {
                name = "Cinderella";
                hp = 100;
                one = "get help from fairy godmother";
                two = "disobey your stepmother";
                //5-10, 5-15
                hitonemin = 5;
                hitonemax = 11;
                hittwomin = 5;
                hittwomax = 16;
            }
            else if (character == 2)
            {
                name = "Snow White";
                hp = 80;
                one = "run away from your stepmother";
                two = "get help from the 7 dwarfs";
                //5-10, 10-15
                hitonemin = 5;
                hitonemax = 11;
                hittwomin = 10;
                hittwomax = 16;
            }
            else if (character == 3)
            {
                name = "Rapunzel";
                hp = 60;
                one = "let your hair down for the prince";
                two = "sing so the prince can find you";
                //10-15, 5-20
                hitonemin = 10;
                hitonemax = 16;
                hittwomin = 5;
                hittwomax = 21;
            }
            else if (character == 4)
            {
                name = "The Evil Stepmother";
                hp = 80;
                one = "lock you up";
                two = "poison you";
                //5-15, 1-20
                hitonemin = 5;
                hitonemax = 16;
                hittwomin = 1;
                hittwomax = 21;
            }
        }

        public void gainhp(int amount)
        {
            hp = hp + amount;
            Console.WriteLine("\n" + name + " has found a potion and gained " + amount + " hp");
            Console.WriteLine(name + "'s new hp is " + hp);
        }

        public void selectmove()
        {
            Console.WriteLine("\n1. " + one);
            Console.WriteLine("2. " + two);
            Console.Write("Which move would you like to use " + name + ": ");
        }

        //generate random damage (within range)
        public void damage(int move)
        {
            if (move == 1)
            {
                hit = rand.Next(hitonemin, hitonemax);
            }
            else if (move == 2)
            {
                hit = rand.Next(hittwomin, hittwomax);
            }
        }

        public void outputdamage()
        {
            Console.WriteLine(hit);
        }

        public void outputmove(int move)
        {
            if (move == 1)
            {
                Console.WriteLine(one);
            }
            else if (move == 2)
            {
                Console.WriteLine(two);
            }
        }

        public void outputhp()
        {
            Console.WriteLine(hp);
        }

        public int gethp()
        {
            return hp;
        }

        public void attacked(int decrease)
        {
            hp = hp - decrease;
        }

        public void outputname()
        {
            Console.Write(name);
        }

        public void subtractdamage (Class1 attacker)
        {
            hp = hp - attacker.hit;
        }
    }
}
