using System.Numerics;

namespace RPGcalu151223
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Player player1 = new Player("The Hero", 100, 20, 3, race.Human, chosenClass.Warrior,0);
            Player player2 = new Player("Player2", 80, 15, 1, race.Elf, chosenClass.Wizard,100);
            Player player3 = new Player("Player3", 100, 10, 1, race.Elf, chosenClass.Cleric,50);

            Player mainCharacter = new Player();
            mainCharacter.ChooseCharacterDetails();
            
            // Display player information
            Console.WriteLine($"\n{mainCharacter.Name} Information:\n" + mainCharacter);
            NPC Enemy1 = new NPC("The Monster", 100, 20, 1, race.Elf, chosenClass.Cleric, 150, mainCharacter);
            // Display player information
            //Console.WriteLine($"{player1.Name} Information:\n" + player1);
            ////Console.WriteLine("\nPlayer 2 Information:\n" + player2);
            ////Console.WriteLine("\nPlayer 3 Information:\n" + player3);
            //Console.WriteLine($"\n{Enemy1.Name} Information:\n" + Enemy1);

            //player1.Attack(Enemy1); // Player attacks NPC
            //Enemy1.Attack(player1); // NPC attacks Player

            //Console.WriteLine($"\n{Enemy1.Name} Information:\n" + Enemy1);

            Console.WriteLine($"You see a fierce enemy infront of you, and you recognize him, it's {Enemy1.Name}!");
            Console.WriteLine($"{Enemy1.Name} is the nasty {Enemy1.Race} {Enemy1.ChosenClass} that has given you so much trouble,\n basically he is your mortal enemy!\n Do you want to start a fight to the death with him? (y/n)");

            // User input loop
            while (true)
            {
                char userInput = Console.ReadKey().KeyChar;
                Console.WriteLine(); // Move to the next line after the user's input

                if (userInput == 'y')
                {
                    Console.WriteLine("The battle begins!");
                    break; // Exit the loop to start the battle
                }
                else if (userInput == 'n')
                {
                    Console.WriteLine("You look awkwardly at each other...");
                    Console.WriteLine($"{Enemy1.Name}: 'Erm... So are we going to fight or?'  (y/n)");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'y' to start the fight or 'n' to reconsider.");
                }
            }
            // Battle loop
            while (mainCharacter.HitPoints > 0 && Enemy1.HitPoints > 0)
            {
                // Player attacks NPC
                mainCharacter.Attack(Enemy1);
                Console.WriteLine("");

                // Check if NPC is dead after player's attack
                Enemy1.IsDead();
                if (Enemy1.HitPoints <= 0)
                {
                    Console.WriteLine($"{Enemy1.Name} has been defeated!");
                    Console.WriteLine($"\n{mainCharacter.Name} Information:\n" + mainCharacter);
                    break; // Exit the loop if the NPC is defeated
                }

                // Introduce a delay before NPC's attack
                Thread.Sleep(4000);

                // NPC attacks Player
                Enemy1.Attack(mainCharacter);
                Console.WriteLine();
                // Introduce a delay before Player's attack
                Thread.Sleep(4000);
                // Check if Player is dead after NPC's attack
                mainCharacter.IsDead();
                if (mainCharacter.HitPoints <= 0)
                {
                    Console.WriteLine($"{mainCharacter.Name} has been defeated!");
                    break; // Exit the loop if the Player is defeated
                }

                // Display current status
                //Console.WriteLine($"\nPlayer 1 Information:\n" + player1);
                //Console.WriteLine($"\n{Enemy1.Name} Information:\n" + Enemy1);
            }

            // End of battle
        }

    }
    }

