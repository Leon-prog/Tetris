using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Tetris
{
    public partial class TableScoreView : Form
    {
        private string path = @"C:\Users\админ\Desktop\лабы\Tetris\Tetris\TableOfScore.xml";

        public TableScoreView()
        {
            InitializeComponent();
            LoadXML();
        }

        private void LoadXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            BindingSource bs1 = new BindingSource();

            MemoryStream rawData = new MemoryStream(File.ReadAllBytes(path));
            XmlSerializer xmls = new XmlSerializer(typeof(TableScore));
            var xmlList = (TableScore)xmls.Deserialize(rawData);

            bs1.DataSource = xmlList.playerArray;

            dataBaseScore.DataSource = bs1;
        }      

    }
}
