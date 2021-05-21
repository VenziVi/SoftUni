using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            IDye dye = null;

            while (!egg.IsDone())
            {
                
                if (dye == null || dye.IsFinished())
                {
                    dye = bunny.Dyes.FirstOrDefault(d => d.Power > 0);

                    if (dye == null)
                    {
                        break;
                    }
                }
                dye.Use();
                bunny.Work();                
                egg.GetColored();

                if (bunny.Energy == 0)
                {
                    break;
                }
            }
        }
    }
}
