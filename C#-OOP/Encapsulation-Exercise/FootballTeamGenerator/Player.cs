using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private const int minStat = 0;
        private const int maxStat = 100;

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sptint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public string Name 
        {
            get => this.name; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }
        }

        public int Endurance
        {
            get => this.endurance;
            private set
            {
                Validator.SkillValidation(
                    minStat, 
                    maxStat, 
                    value, 
                    $"{nameof(this.Endurance)} should be between {minStat} and {maxStat}.");

                this.endurance = value;
            }
        }

        public int Sprint
        {
            get => this.sprint;
            private set
            {
                Validator.SkillValidation(
                    minStat,
                    maxStat,
                    value,
                    $"{nameof(this.Sprint)} should be between {minStat} and {maxStat}.");

                this.sprint = value;
            }
        }

        public int Dribble
        {
            get => this.dribble;
            private set
            {
                Validator.SkillValidation(
                    minStat,
                    maxStat,
                    value,
                    $"{nameof(this.Dribble)} should be between {minStat} and {maxStat}.");

                this.dribble = value;
            }
        }

        public int Passing
        {
            get => this.passing;
            private set
            {
                Validator.SkillValidation(
                    minStat,
                    maxStat,
                    value,
                    $"{nameof(this.Passing)} should be between {minStat} and {maxStat}.");

                this.passing = value;
            }
        }

        public int Shooting
        {
            get => this.shooting;
            private set
            {
                Validator.SkillValidation(
                    minStat,
                    maxStat,
                    value,
                    $"{nameof(this.Shooting)} should be between {minStat} and {maxStat}.");

                this.shooting = value;
            }
        }

        public double PlayerSkillLevel
        {
            get => Math.Round((this.endurance + this.sprint + this.dribble + this.passing + this.shooting) / 5.0);
        }
    }
}
