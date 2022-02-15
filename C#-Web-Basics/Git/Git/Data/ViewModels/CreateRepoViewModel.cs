using System.ComponentModel.DataAnnotations;

namespace Git.Data.ViewModels
{
    public class CreateRepoViewModel
    {
        [Required]
        [StringLength(10, MinimumLength = 3)]
        public string Name { get; set; }

        public string RepositoryType { get; set; }
    }
}
