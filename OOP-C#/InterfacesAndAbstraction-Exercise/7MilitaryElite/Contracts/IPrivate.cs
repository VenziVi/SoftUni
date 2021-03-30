using System;
using System.Collections.Generic;
using System.Text;

namespace _7MilitaryElite.Contracts
{
    public interface IPrivate : ISoldier
    {
        decimal Salary { get; }
    }
}
