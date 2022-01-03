using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class DepartmentsImportDto
    {
        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string Name { get; set; }

        public CellsimportDto[] Cells { get; set; }
    }
}
//•	Name – text with min length 3 and max length 25 (required)