﻿using System.Collections.Generic;

namespace ConsoleGame
{
    class Human : PlayerClass
    {
        public int Stamina { get; set; }

        public void Attack(Enemy p)
        {
            Attack(p, Attackz, this.Name);

        }

        public void SpecialAttack(Enemy p)
        {
            SpecialAttack(p, Attackz, specialAttacks, this.Name);

        }

        Dictionary<string, int> specialAttacks = new Dictionary<string, int>
            {
                {"Slash", 10},
                {"Stab", 16},
                {"Heavy Swing", 24},
            };

        public Human(string name, string faction, bool npc) : base(name, faction, npc)
        {
            this.Stamina = 25;
            this.HealthPoints = 85;
            this.MaxHealthPoints = HealthPoints;
            this.Speed = 16;
            this.Type = CharacterType.Human;
            this.SpecialAttacks = specialAttacks;
        }

        public override string ToString()
        {
            return $"The {this.Type} {this.Name} of {this.Faction} => Health Points: {this.HealthPoints} || Speed: {this.Speed} || Stamina: {this.Stamina}";
        }

        public override string GetExtraStat()
        {
            return "Stamina";
        }

        public override int GetExtraStatValue()
        {
            return this.Stamina;
        }
    }
}
