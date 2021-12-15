using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ExportDto
{
    [XmlType("Actor")]
    public class ActorsExportDto
    {
        [XmlAttribute("FullName")]
        public string FullName { get; set; }

        [XmlAttribute("MainCharacter")]
        public string MainCharacter { get; set; }
    }
}
//           < Actors >       
//             < Actor FullName = "Sylvia Felipe" MainCharacter = "Plays main character in 'A Raisin in the Sun'." /> 
