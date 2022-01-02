using System;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class CellsimportDto
    {
        [Range(1, 1000)]
        public int CellNumber { get; set; }

        [Required]
        public string HasWindow { get; set; }
    }
}
//•	CellNumber – integer in the range [1, 1000] (required)
//•	HasWindow – bool(required)