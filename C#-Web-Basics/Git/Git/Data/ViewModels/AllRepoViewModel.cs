namespace Git.Data.ViewModels
{
    public class AllRepoViewModel
    {
        public string Id { get; set; }
        public string RepoName { get; set; }

        public string Owner { get; set; }

        public string Date { get; set; }

        public int ComitsCount { get; set; }
    }
}
