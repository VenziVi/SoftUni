using Git.Data.ViewModels;

namespace Git.Contracts
{
    public interface ICommitService
    {
        bool CreateCommit(CommitViewmodel model, string Id, string userId);
    }
}
