using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        private const double InitialBaseHealth = 100;
        private const double InitialBaseArmor = 50;
        private const double Ability = 40;

        public Warrior(string name)
            : base(name, InitialBaseHealth, InitialBaseArmor, Ability, new Satchel())
        {
            this.BaseHealth = InitialBaseHealth;
            this.BaseArmor = InitialBaseArmor;
        }

        public void Attack(Character character)
        {
            if (this.IsAlive == false)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }

            if (character.IsAlive == false)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }

            if (this.Name == character.Name)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
