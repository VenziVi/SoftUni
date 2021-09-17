namespace _01.RoyaleArena
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class RoyaleArena : IArena
    {
        private Dictionary<int, BattleCard> battleCards =
            new Dictionary<int, BattleCard>();

        public void Add(BattleCard card)
        {
            this.battleCards.Add(card.Id, card);
        }

        public bool Contains(BattleCard card)
        {
            return this.battleCards.ContainsKey(card.Id);
        }

        public int Count { get => this.battleCards.Count; }

        public void ChangeCardType(int id, CardType type)
        {
            this.DoesCardExists(id);
            this.battleCards[id].Type = type;
        }

        public BattleCard GetById(int id)
        {
            this.DoesCardExists(id);
            return this.battleCards[id];
        }

        public void RemoveById(int id)
        {
            this.DoesCardExists(id);
            this.battleCards.Remove(id);
        }

        public IEnumerable<BattleCard> GetByCardType(CardType type)
        {
            return Filterd(c => c.Type == type);
        }

        public IEnumerable<BattleCard> GetByTypeAndDamageRangeOrderedByDamageThenById(CardType type, int lo, int hi)
        {
            return Filterd(c => c.Type == type && c.Damage > lo && c.Damage < hi);
        }

        public IEnumerable<BattleCard> GetByCardTypeAndMaximumDamage(CardType type, double damage)
        {
            return Filterd(c => c.Type == type && c.Damage <= damage);
        }

        public IEnumerable<BattleCard> GetByNameOrderedBySwagDescending(string name)
        {
            var cards = this.battleCards
                .Select(c => c.Value)
                .Where(c => c.Name == name)
                .OrderByDescending(c => c.Swag)
                .ThenBy(c => c.Id);

            if (cards.Count() == 0) throw new InvalidOperationException();

            return cards;
        }

        public IEnumerable<BattleCard> GetByNameAndSwagRange(string name, double lo, double hi)
        {
            var cards = this.battleCards
                .Select(c => c.Value)
                .Where(c => c.Name == name && c.Swag >= lo && c.Swag < hi)
                .OrderByDescending(c => c.Swag)
                .ThenBy(c => c.Id);

            if (cards.Count() == 0) throw new InvalidOperationException();

            return cards;
        }

        public IEnumerable<BattleCard> FindFirstLeastSwag(int n)
        {
            if (n > this.battleCards.Count)
            {
                throw new InvalidOperationException();
            }

            var cards = this.battleCards
                .Select(c => c.Value)
                .OrderBy(c => c.Swag)
                .ThenBy(c => c.Id)
                .Take(n);

            return cards;
        }

        public IEnumerable<BattleCard> GetAllInSwagRange(double lo, double hi)
        {
            var cards = this.battleCards
                .Select(c => c.Value)
                .Where(c => c.Swag >= lo && c.Swag <= hi)
                .OrderBy(c => c.Swag);

            return cards;
        }


        public IEnumerator<BattleCard> GetEnumerator()
        {
            foreach (var card in battleCards)
            {
                yield return card.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void DoesCardExists(int id)
        {
            if (!this.battleCards.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }
        }

        private IEnumerable<BattleCard> Filterd(Func<BattleCard, bool> predicate)
        {
            var cards = this.battleCards
                .Select(c => c.Value)
                .Where(predicate)
                .OrderByDescending(c => c.Damage)
                .ThenBy(c => c.Id);

            if (cards.Count() == 0) throw new InvalidOperationException();

            return cards;
        }
    }
}