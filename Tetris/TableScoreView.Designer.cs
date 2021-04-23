namespace Tetris
{
    partial class TableScoreView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataBaseScore = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseScore)).BeginInit();
            this.SuspendLayout();
            // 
            // dataBaseScore
            // 
            this.dataBaseScore.AllowUserToAddRows = false;
            this.dataBaseScore.AllowUserToDeleteRows = false;
            this.dataBaseScore.AllowUserToResizeColumns = false;
            this.dataBaseScore.AllowUserToResizeRows = false;
            this.dataBaseScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataBaseScore.Location = new System.Drawing.Point(13, 13);
            this.dataBaseScore.Name = "dataBaseScore";
            this.dataBaseScore.RowHeadersWidth = 59;
            this.dataBaseScore.RowTemplate.Height = 24;
            this.dataBaseScore.Size = new System.Drawing.Size(382, 378);
            this.dataBaseScore.TabIndex = 0;
            // 
            // TableScoreView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 404);
            this.Controls.Add(this.dataBaseScore);
            this.Name = "TableScoreView";
            this.ShowIcon = false;
            this.Text = "Score";
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseScore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataBaseScore;
    }
}