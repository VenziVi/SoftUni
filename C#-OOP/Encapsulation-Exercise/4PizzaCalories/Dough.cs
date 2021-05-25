using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const int minWeight = 1;
        private const int maxWeight = 200;

        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                string lowerValue = value.ToLower();
                if (lowerValue != "white" &&
                    lowerValue != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                string lowerValue = value.ToLower();
                HashSet<string> bakingType = new HashSet<string> { "crispy", "chewy", "homemade" };
                Validators.TypeValidator(
                    bakingType, 
                    lowerValue, 
                    "Invalid type of dough.");

                this.bakingTechnique = value;
            }
        }

        public int Weight
        {
            get => this.weight;
            private set
            {
                Validators.RangeValidator(
                    minWeight, 
                    maxWeight, 
                    value, 
                    $"Dough weight should be in the range [{minWeight}..{maxWeight}].");

                this.weight = value;
            }
        }

        public double DoughCalories()
        {
            double flourrModifier = GetFlourModifier();
            double bakingModifier = GetBakingModifier();
            return 2 * this.weight * flourrModifier * bakingModifier;
        }

        private double GetBakingModifier()
        {
            if (this.bakingTechnique.ToLower() == "crispy")
            {
                return 0.9;
            }
            if (this.bakingTechnique.ToLower() == "chewy")
            {
                return 1.1;
            }
            return 1.0;
        }

        private double GetFlourModifier()
        {
            if (this.flourType.ToLower() == "white")
            {
                return 1.5;
            }

            return 1.0;
        }
    }
}
