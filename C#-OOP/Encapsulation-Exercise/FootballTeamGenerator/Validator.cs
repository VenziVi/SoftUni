using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public static class Validator
    {
        public static void SkillValidation(int min, int max, int value, string message)
        {
            if (value < min || value >  max)
            {
                throw new ArgumentOutOfRangeException(message);
            }
        }
    }
}
