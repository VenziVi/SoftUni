using _7MilitaryElite.Enums;

namespace _7MilitaryElite.Contracts
{
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}
