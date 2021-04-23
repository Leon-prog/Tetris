using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    class Setting
    {
        public static int w { get; set; }
        public static int h { get; set; }
        public static int res { get; set; }
        public static int score { get; set; }


        public Setting(PictureBox screen)
        {
            w = screen.Width;
            h = screen.Height;
            res = 30;
            score = 0;
        }
    }
}
