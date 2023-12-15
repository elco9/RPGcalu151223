using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RPGcalu151223
{
    internal class Player : Base
    {
        public List<Equipment> Equipment { get; set; }
        public int XP { get; set; }

        public Player()
        {
            Equipment = new List<Equipment>(); // Initialize Equipment list
        }

        public Player(string name, int hitPoints, int attackDamage, int level, race race, chosenClass chosenClass, int XP)
        {
            base.Name = name;
            base.HitPoints = (hitPoints > 0) ? hitPoints : 100; // Set default to 100 if not provided
            base.AttackDamage = (attackDamage > 0) ? attackDamage : 20; // Set default to 20 if not provided
            base.Level = (level > 0) ? level : 1; // Set default to 1 if not provided
            Race = race;
            ChosenClass = chosenClass;
            this.XP = XP;
            EquipmentChosen();
            levelUp();
        }

        private void EquipmentChosen()
        {
            Equipment = new List<Equipment>();
            switch (ChosenClass)
            {
                case chosenClass.Warrior:
                    Equipment.Add(new Equipment { Weapon = "Sword", Weight = 5, Damage = 10, HpInc = 0 });
                    break;
                case chosenClass.Wizard:
                    Equipment.Add(new Equipment { Weapon = "Staff", Weight = 3, Damage = 5, HpInc = 0 });
                    break;
                case chosenClass.Rogue:
                    Equipment.Add(new Equipment { Weapon = "Dagger", Weight = 2, Damage = 8, HpInc = 0 });
                    break;
                case chosenClass.Cleric:
                    Equipment.Add(new Equipment { Weapon = "Holy Book", Weight = 1, Damage = 3, HpInc = 15 });
                    break;
                case chosenClass.Ranger:
                    Equipment.Add(new Equipment { Weapon = "Bow", Weight = 4, Damage = 7, HpInc = 0 });
                    break;
                default:
                    break;
            }
            foreach (var item in Equipment)
            {
                base.HitPoints += item.HpInc;
                base.AttackDamage += item.Damage;
            }
        }


        private void levelUp()
        {
            while (XP >= 100)
            {
                base.Level++;
                XP -= 100;

                // Adjust HitPoints and AttackDamage for the current level
                base.HitPoints += 5;
                base.AttackDamage += 2;
            }
        }
        //Add xp to player after killing monster
        public void AddXP(int xpToAdd)
        {
            this.XP += xpToAdd;
            levelUp();
        }
        //The attack done by the player to the enemy
        public void Attack(NPC target)
        {
            Console.WriteLine($"{Name} attacks NPC {target.Name} for {AttackDamage} damage!");
            target.TakeDamage(AttackDamage);
        }
        //The character creation through the console
        public void ChooseCharacterDetails()
        {
            Console.Write("Enter your name: ");
            base.Name = Console.ReadLine();

            Console.WriteLine("Choose your race:");
            foreach (var race in Enum.GetValues(typeof(race)))
            {
                Console.WriteLine($"{(int)race}. {race}");
            }
            int raceChoice;
            while (!int.TryParse(Console.ReadLine(), out raceChoice) || !Enum.IsDefined(typeof(race), raceChoice))
            {
                Console.WriteLine("Invalid choice. Please enter a valid race.");
            }
            base.Race = (race)raceChoice;

            Console.WriteLine("Choose your class:");
            foreach (var chosenClass in Enum.GetValues(typeof(chosenClass)))
            {
                Console.WriteLine($"{(int)chosenClass}. {chosenClass}");
            }
            int classChoice;
            while (!int.TryParse(Console.ReadLine(), out classChoice) || !Enum.IsDefined(typeof(chosenClass), classChoice))
            {
                Console.WriteLine("Invalid choice. Please enter a valid class.");
            }
            base.ChosenClass = (chosenClass)classChoice;

            // Set default values if the user doesn't provide them
            base.HitPoints = 100;
            base.AttackDamage = 20;
            base.Level = 1;

            EquipmentChosen(); // Initialize Equipment based on chosen class
            levelUp(); // Level up if XP is greater than or equal to 100
        }
        public override string ToString()
        {
            string playerInfo = $"Name: {Name} Hit Points: {HitPoints} Attack Damage: {AttackDamage} Level: {Level} Race: {Race} Class: {ChosenClass}";

            playerInfo += "\nEquipment:";
            foreach (var item in Equipment)
            {
                playerInfo += $"\n{item}";
            }

            return playerInfo;
        }
    }
}


