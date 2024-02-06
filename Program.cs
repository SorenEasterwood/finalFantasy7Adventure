using System;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Security.AccessControl;

namespace greatAdventure
{
    class versionOne
    {
        static void Main(string[] args)
        {
            int lives = 0, magic = 0, health = 0, direction = 0, round = 0;
            Random r = new Random();
            bool win = false;
            Console.Write("What is the name of your character? ");
            string name = Console.ReadLine();
            initValues(ref lives, ref magic, ref health, r);
            while (lives > 0 && magic > 0 && health > 0 && win == false)
            {
                direction = chooseDirection();
                /* the direction impacts the number passed to the actions method
                 * if they choose left, they will only receive bad outcomes
                 * if they choose right, they have a better chance of receiving 
                 * good outcomes along with the bad outcomes */
                if (direction == 1)
                    actions(r.Next(4), ref lives, ref magic, ref health);
                else
                    actions(r.Next(10), ref lives, ref magic, ref health);
                checkResults(ref round, ref lives, ref magic, ref health, ref win);
            }
            if (win)
                Console.WriteLine("Congratulations on successfully completing your journey!");
            else if (lives <= 0)
                Console.WriteLine("You lost too many lives and did not complete your journey");
            else if (magic <= 0)
                Console.WriteLine("You don't have any magic left and cannot complete your journey");
            else
                Console.WriteLine("You are in poor health and had to stop your journey before it's completion");

        }

        private static void checkResults(ref int round, ref int lives, ref int magic, ref int health, ref bool win)
        {
            round += 1;
            Console.WriteLine($"------------------------Round {round}-----------------------------");
            Console.WriteLine($"Lives:{lives} Magic: {magic} Health: {health}");
            if (round >= 25)
            {
                win = true;
            }
        }

        private static void actions(int num, ref int lives, ref int magic, ref int health)
        {
            switch (num)
            {
                case 0:
                    Console.WriteLine("You got in a costly battle with a sandworm");
                    Console.WriteLine("You lost 1 health and magic");
                    health -= 1;
                    magic -= 1;
                    break;
                case 1:
                    Console.WriteLine("You ran into Jenova");
                    Console.WriteLine("You lost 2 health, 2 magic, and 1 life");
                    health -= 2;
                    magic -= 2;
                    lives -= 1;
                    break;
                case 2:
                    Console.WriteLine("You tried to fight Sephiroth, unsurprisingly you lost");
                    Console.WriteLine("You lose 1 life");
                    lives -= 1;
                    break;
                case 3:
                    Console.WriteLine("You find a chest with a Pheonix Down in it");
                    Console.WriteLine("You gain 1 life");
                    lives += 1;
                    break;
                case 4:
                    Console.WriteLine("You find a chest with an elixer in it");
                    Console.WriteLine("You gain 3 magic");
                    magic += 3;
                    break;
                case 5:
                    Console.WriteLine("You defeated a Hell House");
                    Console.WriteLine("You gain 2 health, 2 magic, and 2 lives");
                    health += 2;
                    magic += 2;
                    lives += 2;
                    break;
                case 6:
                    Console.WriteLine("You recruited Vincent");
                    Console.WriteLine("You gain 3 health and 3 magic");
                    health += 3;
                    magic += 3;
                    break;
                case 7:
                    Console.WriteLine("You find a Hi potion");
                    Console.WriteLine("You gain 1 health");
                    health += 1;
                    break;
                case 8:
                    Console.WriteLine("You broke a materia");
                    Console.WriteLine("You lose one magic");
                    magic -= 1;
                    break;
                case 9:
                    Console.WriteLine("You gained bahumut as a summon");
                    Console.WriteLine("You gain 30 magic");
                    magic += 30;
                    break;
                default:
                    Console.WriteLine("You fight the emerald weapon and lose");
                    Console.WriteLine("You lose 2 magic and health");
                    magic -= 2;
                    lives -=2;
                    break;
            }

        }

        private static void initValues(ref int lives, ref int magic, ref int health, Random r)
        {
            lives = r.Next(10) + 1;
            magic = r.Next(15) + 5;
            health = r.Next(14) + 5;
            return;
        }

        private static int chooseDirection()
        {
            int direction = 0;
            Console.WriteLine("You have come to a crossroad, enter 1 to travel left and a 2 to travel right");
            direction = int.Parse(Console.ReadLine());
            while (direction != 1 && direction != 2)
            {
                Console.WriteLine("You entered a invalid number, please enter a 1 for left or a 2 for right");
                direction = int.Parse(Console.ReadLine());
            }
            return direction;
        }
    }
}