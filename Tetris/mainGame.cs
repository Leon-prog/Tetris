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
    public partial class mainWindow : Form
    {
        public mainWindow()
        {
            InitializeComponent();
        }

        Graphics g;

        private string path = @"C:\Users\админ\Desktop\лабы\Tetris\Tetris\TableOfScore.xml";
        public string name = null;
        public int index = 0;

        #region работа с xml файлом
        private bool getNameXml(string name)
        {
            int id = 0;
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            MemoryStream rawData = new MemoryStream(File.ReadAllBytes(path));
            XmlSerializer xmls = new XmlSerializer(typeof(TableScore));
            var xmlList = (TableScore)xmls.Deserialize(rawData);

            foreach (player player in xmlList.playerArray)
            {                
                if (player.name == name)
                {
                    index = id;
                    return true;
                }
                id++;
            }
            index = id;
            return false;
        }
        private int getScoreXml(string name)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            MemoryStream rawData = new MemoryStream(File.ReadAllBytes(path));
            XmlSerializer xmls = new XmlSerializer(typeof(TableScore));
            var xmlList = (TableScore)xmls.Deserialize(rawData);

            foreach (player player in xmlList.playerArray)
            {
                if (player.name == name)
                    return Convert.ToInt32(player.score);
            }

            return 0;
        }
        private void createPlayerXml(int score)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlElement xRoot = doc.DocumentElement;

            XmlElement playerElem = doc.CreateElement   ("player");
            XmlAttribute nameAttr = doc.CreateAttribute ("name");
            XmlAttribute scoreAttr = doc.CreateAttribute("score");

            XmlText nameText = doc.CreateTextNode(name);
            XmlText urlText = doc.CreateTextNode(Convert.ToString(score));

            nameAttr.AppendChild(nameText);
            scoreAttr.AppendChild(urlText);

            playerElem.Attributes.Append(nameAttr);
            playerElem.Attributes.Append(scoreAttr);

            xRoot.AppendChild(playerElem);
            doc.Save(path);
        }
        private void delPlayerXml()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlElement xRoot = doc.DocumentElement;

            XmlNode node = xRoot.ChildNodes.Item(index);
            xRoot.RemoveChild(node);
            doc.Save(path);
        }
        #endregion

        //объявляю массив со всеми фигурами
        string[] tetromino = new string[] {
                                                   "..X." +
                                                   "..X." +
                                                   "..X." +
                                                   "..X.",
                                                   "..X." +
                                                   ".XX." +
                                                   "..X." +
                                                   "....",
                                                   "...." +
                                                   ".XX." +
                                                   ".XX." +
                                                   "....",
                                                   "..X." +
                                                   ".XX." +
                                                   ".X.." +
                                                   "....",
                                                   ".X.." +
                                                   ".XX." +
                                                   "..X." +
                                                   "....",
                                                   ".X.." +
                                                   ".X.." +
                                                   ".XX." +
                                                   "....",
                                                   "..X." +
                                                   "..X." +
                                                   ".XX." +
                                                   "...."
        };         

        private Color GetColorForTetromino(int col)
        {
            Color a = Color.FromArgb(255, 0, 0, 0);
            switch (col)
            {
                case 0:
                    //black
                    a = Color.FromArgb(255, 0, 0, 0);
                    break;
                case 1:
                    //red
                    a = Color.FromArgb(255, 255, 0, 0);
                    break;
                case 2:
                    //blue
                    a = Color.FromArgb(255, 0, 255, 0);
                    break;
                case 3:
                    //green
                    a = Color.FromArgb(255, 0, 0, 255);
                    break;
                case 4:
                    //orange
                    a = Color.FromArgb(255, 255, 190, 0);
                    break;
                case 5:
                    //pink
                    a = Color.FromArgb(255, 255, 0, 255);
                    break;
                case 6:
                    //yellow
                    a = Color.FromArgb(255, 190, 190, 0);
                    break;
                case 7:
                    //blue2
                    a = Color.FromArgb(255, 0, 255, 255);
                    break;
                case 8:
                    //white
                    a = Color.FromArgb(255, 255, 255, 255);
                    break;
                case 9:
                    //white
                    a = Color.FromArgb(255, 100, 100, 100);
                    break;
            }
            
            return a;
        }

        public static int nFieldWidth = 12; //ширина поля, учитывая стены  
        public static int nFieldHeight = 21; //высота поля, учитывая пол
        public int[] pField = null; // масссив поля, одномерный для оптимизации по памяти

        // метод который возвращает номер символа из tetromino, в зависимости от поворота
        private int Rotate(int px, int py, int r)
        {
            int pi = 0;
            switch (r % 4)
            {
                case 0: // 0 degrees			// 0  1  2  3
                    pi = py * 4 + px;           // 4  5  6  7
                    break;                      // 8  9 10 11
                                                //12 13 14 15

                case 1: // 90 degrees			//12  8  4  0
                    pi = 12 + py - (px * 4);    //13  9  5  1
                    break;                      //14 10  6  2
                                                //15 11  7  3

                case 2: // 180 degrees			//15 14 13 12
                    pi = 15 - (py * 4) - px;    //11 10  9  8
                    break;                      // 7  6  5  4
                                                // 3  2  1  0

                case 3: // 270 degrees			// 3  7 11 15
                    pi = 3 - py + (px * 4);     // 2  6 10 14
                    break;                      // 1  5  9 13
            }                                   // 0  4  8 12

            return pi;
        }

        // проверка на столкновение; false если есть пересечение фигур
        bool DoesPieceFit(int nTetromino, int nRotation, int nPosX, int nPosY)
        {
            for (int px = 0; px < 4; px++)
                for (int py = 0; py < 4; py++)
                {
                    // берем индекс фигуры 
                    int pi = Rotate(px, py, nRotation);

                    // берем индекс положения фигуры на поле
                    int fi = (nPosY + py) * nFieldWidth + (nPosX + px);

                    // ограничение на стены
                    if (nPosX + px >= 0 && nPosX + px < nFieldWidth)
                    {
                        // ограничение на пол и потолок
                        if (nPosY + py >= 0 && nPosY + py < nFieldHeight)
                        {
                            // проверка на столкновение
                            if (tetromino[nTetromino][pi] != '.' && pField[fi] != 0)
                                return false;
                        }
                    }
                }
                
            return true;
        }

        private void StartGame()
        {
            bstartGame = true;

            //загрузка основных настроек
            new Setting(screen);

            //убираем из видимости панели
            resetPanel.Visible = false;
            resetPanel.Enabled = false;
            startPanel.Visible = false;
            startPanel.Enabled = false;
            newGame.Enabled = true;
            aboutGame.Enabled = false;
            tableScore.Enabled = false;

            //запуск таймера на обновления кадров
            mainTimer.Interval = 10;
            mainTimer.Tick += updateGame;
            mainTimer.Start();

            //запуск таймера для опускания фигура вниз
            gameTimer.Interval = 800;
            gameTimer.Tick += DownTetromino;
            gameTimer.Start();

            //заполняем поле, учитывая стены и пол
            pField = new int[nFieldHeight * nFieldWidth];
            for (int x = 0; x < nFieldWidth; x++)
                for (int y = 0; y < nFieldHeight; y++)
                    pField[y * nFieldWidth + x] = (x == 0 || x == nFieldWidth - 1 || y == nFieldHeight - 1) ? 9 : 0;

            //рандомно выбираем первую и вторую фигуру
            nCurrentPiece = r.Next(0, 7);
            nBufferPiece = r.Next(0, 7);

        }

        // переменный для логики игры
        public bool bstartGame = false;
        public bool[] bKey = new bool[4]; //массив нажатых клавиш
        public int nCurrentPiece = 0;     //номер текущей фигуры
        public int nBufferPiece = 0;      //номер 2 фигуры
        public int nCurrentRotation = 0;  //поворот текущей фигуры
        public int nCurrentX = nFieldWidth / 2; //координтат Х фигуры
        public int nCurrentY = 0;         //координтат У фигуры
        public bool bKeyHold = true;      //переменная сосотояния зажатия клавиши
        public bool bGameOver = false;    //переменная сосотояния конца игры
        public Random r = new Random();
        public List<int> lines = new List<int>(); //список тетрисов

        private void updateGame(object sender, EventArgs e)
        {
            //движение фигуры 
            if (bKey[0]) //сдвиг вправо
            {
                nCurrentX += (bKeyHold && DoesPieceFit(nCurrentPiece, nCurrentRotation, nCurrentX + 1, nCurrentY)) ? 1 : 0;
                bKeyHold = false;
            }
            else if(bKey[1]) //сдвиг влево
            {
                nCurrentX -= (bKeyHold && DoesPieceFit(nCurrentPiece, nCurrentRotation, nCurrentX - 1, nCurrentY)) ? 1 : 0;
                bKeyHold = false;
            }
            else if (bKey[3]) //поворот фигуры
            {
                nCurrentRotation += (bKeyHold && DoesPieceFit(nCurrentPiece, nCurrentRotation + 1, nCurrentX, nCurrentY)) ? 1 : 0;
                bKeyHold = false;
            }
            else
                bKeyHold = true;

            //движение фигуры вниз
            nCurrentY += (bKey[2] && DoesPieceFit(nCurrentPiece, nCurrentRotation, nCurrentX, nCurrentY + 1)) ? 1 : 0;

            //проеврка на конец игры
            if (bGameOver)
            {
                //записываем счёт
                endScore.Text = "Score: " + Convert.ToString(Setting.score);
                nameGamer.Text = "Name: " + name;
                if (getScoreXml(name) < Setting.score)
                {
                    delPlayerXml();
                    createPlayerXml(Setting.score);
                }
                Setting.score = 0;

                //останавливаемм таймеры
                bGameOver = false;
                mainTimer.Stop();
                gameTimer.Stop();

                mainTimer.Tick -= updateGame;
                gameTimer.Tick -= DownTetromino;

                //включаем панель перезагрузки
                resetPanel.Visible = true;
                resetPanel.Enabled = true;
                aboutGame.Enabled  = true;
                tableScore.Enabled = true;
                newGame.Enabled = false;

            }

            screen.Refresh();
        }

        private void DownTetromino(object sender, EventArgs e)
        {
            // проверка, может ли опустится фигуры вниз
            if (DoesPieceFit(nCurrentPiece, nCurrentRotation, nCurrentX, nCurrentY + 1))
                nCurrentY++;
            else
            {
                //делаем фигурку частью поля 
                for (int px = 0; px < 4; px++)
                    for (int py = 0; py < 4; py++)
                    {
                        if (tetromino[nCurrentPiece][Rotate(px, py, nCurrentRotation)] != '.')
							pField[(nCurrentY + py) * nFieldWidth + (nCurrentX + px)] = nCurrentPiece + 1;
                    }

                //проверяем нет ли тетрисов
                for (int py = 0; py < 4; py++)
                    if (nCurrentY + py < nFieldHeight - 1)
                    {
                        bool bLine = true;
                        for (int px = 1; px < nFieldWidth - 1; px++)
                            bLine &= (pField[(nCurrentY + py) * nFieldWidth + px]) != 0;

                        if (bLine)
                        {
                            //добавляем кординату линии по У
                            for (int px = 1; px < nFieldWidth - 1; px++)
                                pField[(nCurrentY + py) * nFieldWidth + px] = 9;
                            lines.Add(nCurrentY + py);
                            Setting.score += 50;
                        }
                    }
                //удаление линии
                if(lines.Count > 0)
                {
                    foreach(int v in lines)
                        for (int px = 1; px < nFieldWidth - 1; px++)
                        {
                            //перемещаем всё, что выше вниз
                            for (int py = v; py > 0; py--)
                                pField[py * nFieldWidth + px] = pField[(py - 1) * nFieldWidth + px];
                            pField[px] = 0;
                        }
                    //отчищаем список
                    lines.Clear();
                }

                // создаём следующую фигуру
                nCurrentX = nFieldWidth / 2;
                nCurrentY = 0;
                nCurrentRotation = 0;
                nCurrentPiece = nBufferPiece;
                nBufferPiece = r.Next(0, 7);

                //обновляем счёт
                countScore.Text = "Score: " + Convert.ToString(Setting.score);

                // проверка на конец игры
                bGameOver = !DoesPieceFit(nCurrentPiece, nCurrentRotation, nCurrentX, nCurrentY);
            }
        }

        //отрисовка поля и фигур
        private void screen_Paint(object sender, PaintEventArgs e)
        {
            if (bstartGame)
            {
                g = e.Graphics;
                //отрисовка поля
                for (int x = 0; x < nFieldWidth; x++)
                    for (int y = 0; y < nFieldHeight; y++)
                        g.FillRectangle(new SolidBrush(GetColorForTetromino(pField[y * nFieldWidth + x])), x * 30, y * 30, 30, 30);

                // рисуем текущую фигуру
                for (int px = 0; px < 4; px++)
                    for (int py = 0; py < 4; py++)
                        if (tetromino[nCurrentPiece][Rotate(px, py, nCurrentRotation)] != '.')
                            g.FillRectangle(new SolidBrush(GetColorForTetromino(nCurrentPiece + 1)), (nCurrentX + px) * 30, (nCurrentY + py) * 30, 30, 30);

                //рисуем следующую фигуру
                imageNextTetromino.Refresh();
            }
        }

        private void imageNextTetromino_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            for (int px = 0; px < 4; px++)
                for (int py = 0; py < 4; py++)
                    if (tetromino[nBufferPiece][Rotate(px, py, 0)] != '.')
                        g.FillRectangle(new SolidBrush(GetColorForTetromino(nBufferPiece + 1)), px * 30, py * 30, 30, 30);
        }

        //события нажатия на клавиши
        private void mainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                bKey[1] = true;
            }
            else if (e.KeyCode == Keys.Right)
            {
                bKey[0] = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                bKey[2] = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                bKey[3] = true;
            }
        }

        private void mainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                bKey[1] = false;
            }
            else if (e.KeyCode == Keys.Right)
            {
                bKey[0] = false;
            }
            else if (e.KeyCode == Keys.Down)
            {
                bKey[2] = false;
            }
            else if (e.KeyCode == Keys.Up)
            {
                bKey[3] = false;
            }
        }

        private void resetGame_Click(object sender, EventArgs e)
        {
            //перезапускаем игру
            nCurrentX = nFieldWidth / 2;
            nCurrentY = 0;
            nCurrentRotation = 0;

            StartGame();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            name = textboxName.Text;
            if (!getNameXml(name))
            {
                createPlayerXml(0);
            }
            StartGame(); // запуск игры
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit(); //выход из игры
        }

        private void exitGame_Click(object sender, EventArgs e)
        {
            Application.Exit(); //выход из игры
        }

        private void mainWindow_Load(object sender, EventArgs e)
        {
            newGame.Enabled = false;
        }

        private void newGame_Click(object sender, EventArgs e)
        {
            bGameOver = true;
        }

        private void aboutGame_Click(object sender, EventArgs e)
        {
            using (About reference = new About())
            {
                reference.ShowDialog();
            }
        }

        private void tableScore_Click(object sender, EventArgs e)
        {
            using (TableScoreView table = new TableScoreView())
            {
                table.ShowDialog();
            }
        }
    }
}
