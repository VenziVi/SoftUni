using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Theatre.DataProcessor.ImportDto
{
    public class TheatresImportDto
    {
        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Name { get; set; }

        [Range(typeof(sbyte), "1", "10")]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Director { get; set; }

        public TicketImportDto[] Tickets { get; set; }
    }
}
//•	Name – text with length [4, 30] (required)
//•	NumberOfHalls – sbyte between[1…10] (required)
//•	Director – text with length [4, 30] (required)
//•	Tickets - a collection of type Ticket
