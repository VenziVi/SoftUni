using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
		private string name;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.Health = health;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }

        public string Name 
		{
			get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
					throw new ArgumentException(Constants.ExceptionMessages.CharacterNameInvalid);
                }

				this.name = value;
            } 
		}

        public double BaseHealth { get; protected set; }

        public double Health { get; set; }

        public double BaseArmor { get; protected set; }

        public double Armor { get; private set; }

        public double AbilityPoints { get; private set; }

        public Bag Bag { get; private set; }

        public bool IsAlive { get; set; } = true;


        public void TakeDamage(double hitPoints)
        {
            if (this.IsAlive == false)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }

            double hitPointsLeft = hitPoints - this.Armor;

            this.Armor -= hitPoints;

            if (this.Armor < 0)
            {
                this.Armor = 0;
                this.Health -= hitPointsLeft;

                if (this.Health <= 0)
                {
                    this.Health = 0;
                    this.IsAlive = false;
                }
            }
        }

        public void UseItem(Item item)
        {
            item.AffectCharacter(this);
        }


        protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
	}
}