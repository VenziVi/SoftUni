using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters.Contracts
{
    public class Priest : Character, IHealer
    {
        private const double InitialHealth = 50;
        private const double InitialArmor = 25;
        private const double InitialAbility = 40;

        public Priest(string name)
            : base(name, InitialHealth, InitialArmor, InitialAbility, new Backpack())
        {
            this.BaseHealth = InitialHealth;
            this.BaseArmor = InitialArmor;
        }

        public void Heal(Character character)
        {
            if (this.IsAlive == false)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }

            if (character.IsAlive == false)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }

            character.Health += this.AbilityPoints;
        }
    }
}
