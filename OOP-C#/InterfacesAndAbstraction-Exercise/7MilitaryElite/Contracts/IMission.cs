using System;
using System.Collections.Generic;
using System.Text;
using _7MilitaryElite.Enums;

namespace _7MilitaryElite.Contracts
{
    public interface IMission
    {
        string CodeName { get; }

        MissionState MissionState { get; }

        void CompleteMission();
    }
}
