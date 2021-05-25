using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private readonly Dictionary<string, Character> party;
		private readonly Stack<Item> itemPool;

		public WarController()
		{
			party = new Dictionary<string, Character>();
			itemPool = new Stack<Item>();
		}

		public string JoinParty(string[] args)
		{
			string type = args[0];
			string name = args[1];

			Character character = null;

            if (type == nameof(Warrior))
            {
				character = new Warrior(name);
            }
            else if (type == nameof(Priest))
            {
				character = new Priest(name);
            }
            else
            {
				throw new ArgumentException(string.Format(Constants.ExceptionMessages.InvalidCharacterType, type));
			}

			party.Add(name, character);
			return string.Format(Constants.SuccessMessages.JoinParty, name);
		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];

			Item item = null;

            if (itemName == nameof(HealthPotion))
            {
				item = new HealthPotion();
            }
            else if (itemName == nameof(FirePotion))
            {
				item = new FirePotion();
            }
            else
            {
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
            }

			itemPool.Push(item);
			return string.Format(Constants.SuccessMessages.AddItemToPool, itemName);
		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];

            if (!party.ContainsKey(characterName))
            {
				throw new ArgumentException(string.Format(Constants.ExceptionMessages.CharacterNotInParty, characterName));
            }

            if (itemPool.Count == 0)
            {
				throw new InvalidOperationException(string.Format(Constants.ExceptionMessages.ItemPoolEmpty));
			}

			Item item = itemPool.Pop();
			Character character = party[characterName];

			character.Bag.AddItem(item);
			return string.Format(Constants.SuccessMessages.PickUpItem, characterName, item.GetType().Name);
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];

            if (!party.ContainsKey(characterName))
            {
				throw new ArgumentException(string.Format(Constants.ExceptionMessages.CharacterNotInParty, characterName));
			}

			Character character = party[characterName];
			Item item = character.Bag.GetItem(itemName);
			character.UseItem(item);

			return string.Format(Constants.SuccessMessages.UsedItem, characterName, itemName);
		}

		public string GetStats()
		{
			StringBuilder sb = new StringBuilder();
			string condition = string.Empty;

            foreach (var character in party.OrderByDescending(c => c.Value.IsAlive).ThenByDescending(c => c.Value.Health))
            {
                condition = character.Value.IsAlive ? "Alive" : "Dead";

				sb.AppendLine($"{character.Key} - HP: {character.Value.Health}/{character.Value.BaseHealth}, " +
					$"AP: {character.Value.Armor}/{character.Value.BaseArmor}, Status: {condition}");
            }

			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string receiverName = args[1];

			if (!party.ContainsKey(attackerName))
			{
				throw new ArgumentException(string.Format(Constants.ExceptionMessages.CharacterNotInParty, attackerName));
			}
			if (!party.ContainsKey(receiverName))
			{
				throw new ArgumentException(string.Format(Constants.ExceptionMessages.CharacterNotInParty, receiverName));
			}

			Character attacker = party[attackerName];
			Character receiver = party[receiverName];

			if (attacker.GetType().Name != "Warrior")
			{
				throw new ArgumentException($"{attacker.Name} cannot attack!");
			}

			var lastAttacker = (Warrior)attacker;

			lastAttacker.Attack(receiver);

			StringBuilder sb = new StringBuilder();

			sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} " +
				$"hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} " +
				$"HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (receiver.IsAlive == false)
            {
				sb.AppendLine($"{receiver.Name} is dead!");
            }

			return sb.ToString().TrimEnd();
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string receiverName = args[1];

			if (!party.ContainsKey(healerName))
			{
				throw new ArgumentException(string.Format(Constants.ExceptionMessages.CharacterNotInParty, healerName));
			}

			if (!party.ContainsKey(receiverName))
			{
				throw new ArgumentException(string.Format(Constants.ExceptionMessages.CharacterNotInParty, receiverName));
			}

			Character healer = party[healerName];
			Character receiver = party[receiverName];

            if (healer.GetType().Name != "Priest")
            {
				throw new ArgumentException($"{healer.Name} cannot heal!");
			}

			var lastHealer = (Priest)healer;
			lastHealer.Heal(receiver);

			return string.Format(Constants.SuccessMessages.HealCharacter, healer.Name, receiver.Name, healer.AbilityPoints, receiver.Name, receiver.Health);
		}
	}
}
