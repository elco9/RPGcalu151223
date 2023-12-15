using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGcalu151223
{
    internal class Equipment
    {
        public string Weapon { get; set; }
        public int Weight { get; set; }
        public int Damage { get; set; }
        public int HpInc { get; set; }
        //Creating weapon type
        public override string ToString()
        {
            return $"Weapon: {Weapon} Weight: {Weight} Damage: {Damage} Health Increase: {HpInc}";
        }
    }
}
