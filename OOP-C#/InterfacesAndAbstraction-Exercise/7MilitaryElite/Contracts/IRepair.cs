using System;
using System.Collections.Generic;
using System.Text;

namespace _7MilitaryElite.Contracts
{
    public interface IRepair
    {
        string PartName { get; }

        int HoursWorked { get; }
    }
}
