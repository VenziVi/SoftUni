using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        Dictionary<string, Ingredient> Ingredients;

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {

            Ingredients = new Dictionary<string, Ingredient>();

            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int MaxAlcoholLevel { get; set; }

        public int CurrentAlcoholLevel { get => Ingredients.Values.Sum(x => x.Alcohol); }


        public void Add(Ingredient ingredient)
        {
            int currAlcohol = Ingredients.Values.Sum(i => i.Alcohol);
            //int currQuantity = Ingredients.Values.Sum(i => i.Quantity);

            if (!Ingredients.ContainsKey(ingredient.Name))
            {
                if ((currAlcohol + ingredient.Alcohol) <= this.MaxAlcoholLevel &&
                    (Ingredients.Count + 1) <= this.Capacity)
                {
                    Ingredients.Add(ingredient.Name, ingredient);
                }
            }
        }

        public bool Remove(string name)
        {
            if (Ingredients.ContainsKey(name))
            {
                Ingredients.Remove(name);
                return true;
            }
            return false;
        }

        public Ingredient FindIngredient(string name)
        {
            if (Ingredients.ContainsKey(name))
            {
                return Ingredients[name];
            }

            return null;
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            List<Ingredient> ingr = Ingredients.Values.OrderByDescending(x => x.Alcohol).ToList();

            Ingredient curr = ingr.First();

            return curr;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {this.CurrentAlcoholLevel}");

            foreach (var ingredent in Ingredients)
            {
                sb.AppendLine($"{ingredent.Value.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }


    }
}
