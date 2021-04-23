namespace Tetris
{
    partial class mainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.labelNextTetr = new System.Windows.Forms.Label();
            this.countScore = new System.Windows.Forms.Label();
            this.resetGame = new System.Windows.Forms.Button();
            this.resetPanel = new System.Windows.Forms.Panel();
            this.exit = new System.Windows.Forms.Button();
            this.endScore = new System.Windows.Forms.Label();
            this.nameGamer = new System.Windows.Forms.Label();
            this.panelMainButton = new System.Windows.Forms.MenuStrip();
            this.exitGame = new System.Windows.Forms.ToolStripMenuItem();
            this.newGame = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutGame = new System.Windows.Forms.ToolStripMenuItem();
            this.tableScore = new System.Windows.Forms.ToolStripMenuItem();
            this.startPanel = new System.Windows.Forms.Panel();
            this.labelWriteName = new System.Windows.Forms.Label();
            this.textboxName = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.imageNextTetromino = new System.Windows.Forms.PictureBox();
            this.screen = new System.Windows.Forms.PictureBox();
            this.resetPanel.SuspendLayout();
            this.panelMainButton.SuspendLayout();
            this.startPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageNextTetromino)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.screen)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTimer
            // 
            this.mainTimer.Interval = 1000;
            // 
            // labelNextTetr
            // 
            this.labelNextTetr.AutoSize = true;
            this.labelNextTetr.Font = new System.Drawing.Font("Arial Narrow", 16.05755F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNextTetr.ForeColor = System.Drawing.SystemColors.Control;
            this.labelNextTetr.Location = new System.Drawing.Point(550, 40);
            this.labelNextTetr.Name = "labelNextTetr";
            this.labelNextTetr.Size = new System.Drawing.Size(194, 36);
            this.labelNextTetr.TabIndex = 1;
            this.labelNextTetr.Text = "Next tetromino";
            // 
            // countScore
            // 
            this.countScore.AutoSize = true;
            this.countScore.Font = new System.Drawing.Font("Arial Narrow", 16.05755F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countScore.ForeColor = System.Drawing.SystemColors.Control;
            this.countScore.Location = new System.Drawing.Point(550, 203);
            this.countScore.Name = "countScore";
            this.countScore.Size = new System.Drawing.Size(115, 36);
            this.countScore.TabIndex = 3;
            this.countScore.Text = "Score: 0";
            // 
            // resetGame
            // 
            this.resetGame.BackColor = System.Drawing.Color.Red;
            this.resetGame.Font = new System.Drawing.Font("Arial Narrow", 16.05755F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resetGame.Location = new System.Drawing.Point(9, 103);
            this.resetGame.Name = "resetGame";
            this.resetGame.Size = new System.Drawing.Size(139, 90);
            this.resetGame.TabIndex = 4;
            this.resetGame.Text = "RESET";
            this.resetGame.UseVisualStyleBackColor = false;
            this.resetGame.Click += new System.EventHandler(this.resetGame_Click);
            // 
            // resetPanel
            // 
            this.resetPanel.BackColor = System.Drawing.Color.White;
            this.resetPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.resetPanel.Controls.Add(this.exit);
            this.resetPanel.Controls.Add(this.endScore);
            this.resetPanel.Controls.Add(this.nameGamer);
            this.resetPanel.Controls.Add(this.resetGame);
            this.resetPanel.Location = new System.Drawing.Point(265, 250);
            this.resetPanel.Name = "resetPanel";
            this.resetPanel.Size = new System.Drawing.Size(307, 200);
            this.resetPanel.TabIndex = 5;
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.Gray;
            this.exit.Font = new System.Drawing.Font("Arial Narrow", 16.05755F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exit.Location = new System.Drawing.Point(154, 103);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(139, 90);
            this.exit.TabIndex = 7;
            this.exit.Text = "EXIT";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // endScore
            // 
            this.endScore.AutoSize = true;
            this.endScore.Font = new System.Drawing.Font("Arial Narrow", 16.05755F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endScore.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.endScore.Location = new System.Drawing.Point(3, 54);
            this.endScore.Name = "endScore";
            this.endScore.Size = new System.Drawing.Size(101, 36);
            this.endScore.TabIndex = 6;
            this.endScore.Text = "Score: ";
            // 
            // nameGamer
            // 
            this.nameGamer.AutoSize = true;
            this.nameGamer.Font = new System.Drawing.Font("Arial Narrow", 16.05755F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameGamer.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.nameGamer.Location = new System.Drawing.Point(3, 0);
            this.nameGamer.Name = "nameGamer";
            this.nameGamer.Size = new System.Drawing.Size(99, 36);
            this.nameGamer.TabIndex = 5;
            this.nameGamer.Text = "Name: ";
            // 
            // panelMainButton
            // 
            this.panelMainButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panelMainButton.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.panelMainButton.ImageScalingSize = new System.Drawing.Size(23, 23);
            this.panelMainButton.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitGame,
            this.newGame,
            this.aboutGame,
            this.tableScore});
            this.panelMainButton.Location = new System.Drawing.Point(0, 0);
            this.panelMainButton.Name = "panelMainButton";
            this.panelMainButton.Size = new System.Drawing.Size(780, 35);
            this.panelMainButton.TabIndex = 7;
            this.panelMainButton.Text = "menuStrip1";
            // 
            // exitGame
            // 
            this.exitGame.Name = "exitGame";
            this.exitGame.Size = new System.Drawing.Size(55, 29);
            this.exitGame.Text = "Exit";
            this.exitGame.Click += new System.EventHandler(this.exitGame_Click);
            // 
            // newGame
            // 
            this.newGame.Name = "newGame";
            this.newGame.Size = new System.Drawing.Size(110, 29);
            this.newGame.Text = "new game";
            this.newGame.Click += new System.EventHandler(this.newGame_Click);
            // 
            // aboutGame
            // 
            this.aboutGame.Name = "aboutGame";
            this.aboutGame.Size = new System.Drawing.Size(75, 29);
            this.aboutGame.Text = "about";
            this.aboutGame.Click += new System.EventHandler(this.aboutGame_Click);
            // 
            // tableScore
            // 
            this.tableScore.Name = "tableScore";
            this.tableScore.Size = new System.Drawing.Size(136, 29);
            this.tableScore.Text = "table of score";
            this.tableScore.Click += new System.EventHandler(this.tableScore_Click);
            // 
            // startPanel
            // 
            this.startPanel.BackColor = System.Drawing.Color.White;
            this.startPanel.BackgroundImage = global::Tetris.Properties.Resources.tetrisImage;
            this.startPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.startPanel.Controls.Add(this.labelWriteName);
            this.startPanel.Controls.Add(this.textboxName);
            this.startPanel.Controls.Add(this.startButton);
            this.startPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startPanel.Location = new System.Drawing.Point(0, 35);
            this.startPanel.Name = "startPanel";
            this.startPanel.Size = new System.Drawing.Size(780, 712);
            this.startPanel.TabIndex = 6;
            // 
            // labelWriteName
            // 
            this.labelWriteName.AutoSize = true;
            this.labelWriteName.BackColor = System.Drawing.Color.Aqua;
            this.labelWriteName.Font = new System.Drawing.Font("Arial Narrow", 16.05755F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWriteName.Location = new System.Drawing.Point(282, 249);
            this.labelWriteName.Name = "labelWriteName";
            this.labelWriteName.Size = new System.Drawing.Size(215, 36);
            this.labelWriteName.TabIndex = 7;
            this.labelWriteName.Text = "Write your name";
            // 
            // textboxName
            // 
            this.textboxName.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textboxName.Font = new System.Drawing.Font("Arial Narrow", 16.05755F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textboxName.Location = new System.Drawing.Point(258, 303);
            this.textboxName.Name = "textboxName";
            this.textboxName.Size = new System.Drawing.Size(262, 43);
            this.textboxName.TabIndex = 6;
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Red;
            this.startButton.Font = new System.Drawing.Font("Arial Narrow", 16.05755F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startButton.Location = new System.Drawing.Point(308, 376);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(170, 90);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // imageNextTetromino
            // 
            this.imageNextTetromino.BackColor = System.Drawing.SystemColors.Control;
            this.imageNextTetromino.Location = new System.Drawing.Point(598, 80);
            this.imageNextTetromino.Name = "imageNextTetromino";
            this.imageNextTetromino.Size = new System.Drawing.Size(120, 120);
            this.imageNextTetromino.TabIndex = 2;
            this.imageNextTetromino.TabStop = false;
            this.imageNextTetromino.Paint += new System.Windows.Forms.PaintEventHandler(this.imageNextTetromino_Paint);
            // 
            // screen
            // 
            this.screen.BackColor = System.Drawing.SystemColors.Control;
            this.screen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.screen.Location = new System.Drawing.Point(9, 40);
            this.screen.Name = "screen";
            this.screen.Size = new System.Drawing.Size(360, 630);
            this.screen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.screen.TabIndex = 0;
            this.screen.TabStop = false;
            this.screen.Paint += new System.Windows.Forms.PaintEventHandler(this.screen_Paint);
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(780, 747);
            this.Controls.Add(this.startPanel);
            this.Controls.Add(this.resetPanel);
            this.Controls.Add(this.countScore);
            this.Controls.Add(this.imageNextTetromino);
            this.Controls.Add(this.labelNextTetr);
            this.Controls.Add(this.screen);
            this.Controls.Add(this.panelMainButton);
            this.MainMenuStrip = this.panelMainButton;
            this.Name = "mainWindow";
            this.ShowIcon = false;
            this.Text = "Screen";
            this.Load += new System.EventHandler(this.mainWindow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainWindow_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mainWindow_KeyUp);
            this.resetPanel.ResumeLayout(false);
            this.resetPanel.PerformLayout();
            this.panelMainButton.ResumeLayout(false);
            this.panelMainButton.PerformLayout();
            this.startPanel.ResumeLayout(false);
            this.startPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageNextTetromino)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.screen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox screen;
        private System.Windows.Forms.Timer mainTimer;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label labelNextTetr;
        private System.Windows.Forms.PictureBox imageNextTetromino;
        private System.Windows.Forms.Label countScore;
        private System.Windows.Forms.Button resetGame;
        private System.Windows.Forms.Panel resetPanel;
        private System.Windows.Forms.Label endScore;
        private System.Windows.Forms.Label nameGamer;
        private System.Windows.Forms.Panel startPanel;
        private System.Windows.Forms.Label labelWriteName;
        private System.Windows.Forms.TextBox textboxName;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.MenuStrip panelMainButton;
        private System.Windows.Forms.ToolStripMenuItem exitGame;
        private System.Windows.Forms.ToolStripMenuItem aboutGame;
        private System.Windows.Forms.ToolStripMenuItem newGame;
        private System.Windows.Forms.ToolStripMenuItem tableScore;
    }
}

