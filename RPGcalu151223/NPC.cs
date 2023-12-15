using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RPGcalu151223 
{
    internal class NPC : Base
    {
        private int _xpGiven;
        public int XpGiven { get; set; }
        private Player player;
        public NPC() { }
        public NPC(string name, int hitPoints, int attackDamage, int level, race race, chosenClass chosenClass, int xpGiven, Player player)
        {
            base.Name = name;
            base.HitPoints = hitPoints;
            base.AttackDamage = attackDamage;
            base.Level = level;
            Race = race;
            ChosenClass = chosenClass;
            XpGiven = xpGiven;
            this.player = player; // Store the player instance
        }
        public override string ToString()
        {
            string playerInfo = $"Name: {Name} Hit Points: {HitPoints} Attack Damage: {AttackDamage} Level: {Level} Race: {Race} Class: {ChosenClass} XP on death: {XpGiven}";

            return playerInfo;
        }
        protected override void OnDeath()
        {
            // Add xp to the player, if killed
            if (XpGiven > 0)
            {
                player.AddXP(XpGiven);
            }
        }
        public override void TakeDamage(int damage)
        {
            // NPC variant for taking damage
            HitPoints -= damage;
            Console.WriteLine($"{Name} takes {damage} damage. Remaining HP: {Math.Max(0, HitPoints)}");

            // Check for death after updating hit points
            IsDead();
        }
    }
}

