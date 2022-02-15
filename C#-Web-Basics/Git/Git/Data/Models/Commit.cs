﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Git.Data.Models
{
    public class Commit
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(Creator))]
        public string CreatorId { get; set; }

        public User Creator { get; set; }

        [ForeignKey(nameof(Repository))]
        public string RepositryId { get; set; }

        public Repository Repository { get; set; }


    }
}
