﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DTO.Import
{
    [XmlType("partId")]
    public class CarPartsImport
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
