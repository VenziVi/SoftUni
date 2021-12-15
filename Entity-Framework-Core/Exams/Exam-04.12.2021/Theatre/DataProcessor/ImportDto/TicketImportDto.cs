using System;
using System.ComponentModel.DataAnnotations;

namespace Theatre.DataProcessor.ImportDto
{
    public class TicketImportDto
    {
        [Range(typeof(decimal), "1.00", "100.00")]
        public decimal Price { get; set; }

        [Range(typeof(sbyte), "1", "10")]
        public sbyte RowNumber { get; set; }

        public int PlayId { get; set; }
    }
}
//•	Price – decimal in the range [1.00….100.00] (required)
//•	RowNumber – sbyte in range[1….10](required)
//•	PlayId – integer, foreign key(required)