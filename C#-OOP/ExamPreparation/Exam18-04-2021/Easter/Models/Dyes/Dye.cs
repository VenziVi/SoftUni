using Easter.Models.Dyes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        public Dye(int power)
        {
            this.Power = power;
        }

        public int Power { get; private set; }

        //not shure if work
        public bool IsFinished() => this.Power == 0;
  

        public void Use()
        {
            this.Power -= 10;

            if (this.Power < 0)
            {
                this.Power = 0;
            }
        }
    }
}
