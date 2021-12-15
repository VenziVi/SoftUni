using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ExportDto
{
    [XmlType("Play")]
    public class PlaysExportDto
    {
        [XmlAttribute("Title")]
        public string Title { get; set; }

        [XmlAttribute("Duration")]
        public string Duration { get; set; }

        [XmlAttribute("Rating")]
        public string Rating { get; set; }

        [XmlAttribute("Genre")]
        public string Genre { get; set; }

        [XmlArray("Actors")]
        public ActorsExportDto[] Actors { get; set; }
    }
}
//< Play Title = "A Raisin in the Sun" Duration = "01:40:00" Rating = "5.4" Genre = "Drama" >       
//           < Actors >       
//             < Actor FullName = "Sylvia Felipe" MainCharacter = "Plays main character in 'A Raisin in the Sun'." />          
//                < Actor FullName = "Sella Mains" MainCharacter = "Plays main character in 'A Raisin in the Sun'." />             
//                   < Actor FullName = "Sela Hillett" MainCharacter = "Plays main character in 'A Raisin in the Sun'." />                                                      
//</ Actors >                                        
//</ Play >
