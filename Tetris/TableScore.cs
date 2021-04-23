using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    [System.Xml.Serialization.XmlRoot("TableScore")]
    public class TableScore
    {        
        [System.Xml.Serialization.XmlElement("player")]
        public player[] playerArray { get; set; }
    }
    public class player
    {
        [System.Xml.Serialization.XmlAttribute("name", Namespace = "")]
        public string name { get; set; }
        [System.Xml.Serialization.XmlAttribute("score", Namespace = "")]
        public string score { get; set; }
    }
}
