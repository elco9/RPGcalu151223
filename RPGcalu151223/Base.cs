using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGcalu151223
{
    public enum race{Goblin, Orc, Troll, Ogre, Human,Elf }
    public enum chosenClass{Warrior,Wizard,Rogue,Cleric,Ranger}
    internal abstract class Base
    {
        private int _HitPoints;
        private int _AttackDamage;
        private int _Level;
        private string _Name;
        private race _Race;
        private chosenClass _Class;

        public int HitPoints
        {
            get { return _HitPoints; }
            set { _HitPoints = value; }
        }
        public int AttackDamage
        {
            get { return _AttackDamage; }
            set { _AttackDamage = value; }
        }
        public int Level
        { 
            get { return _Level; } 
            set {  _Level = value; } 
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public race Race 
        { 
            get { return _Race; } 
            set { _Race = value; }        
        }
        public chosenClass ChosenClass
        {
            get { return _Class; }
            set { _Class = value; }
        }
        public void IsDead()
        {
            if (HitPoints <= 0)
            {
                OnDeath();
            }
        }
        protected virtual void OnDeath()
        {
           
        }
        public void Attack(Base target)
        {
            // Base attack method for attacking the player who attacked
            Console.WriteLine($"{Name} attacks {target.Name} for {AttackDamage} damage!");
            target.TakeDamage(AttackDamage);
        }
        public virtual void TakeDamage(int damage)
        {
            // Common logic for taking damage
            HitPoints -= damage;
            Console.WriteLine($"{Name} takes {damage} damage. Remaining HP: {HitPoints}");
        }

    }
}
/*

*/