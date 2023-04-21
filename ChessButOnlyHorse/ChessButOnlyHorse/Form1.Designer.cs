namespace ChessButOnlyHorse
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_board = new System.Windows.Forms.FlowLayoutPanel();
            this.label_score = new System.Windows.Forms.Label();
            this.button_play = new System.Windows.Forms.Button();
            this.button_size = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel_board
            // 
            this.panel_board.Location = new System.Drawing.Point(11, 55);
            this.panel_board.Margin = new System.Windows.Forms.Padding(0);
            this.panel_board.Name = "panel_board";
            this.panel_board.Size = new System.Drawing.Size(400, 400);
            this.panel_board.TabIndex = 0;
            // 
            // label_score
            // 
            this.label_score.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label_score.AutoSize = true;
            this.label_score.Font = new System.Drawing.Font("Voice In My Head", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_score.Location = new System.Drawing.Point(121, 10);
            this.label_score.Name = "label_score";
            this.label_score.Size = new System.Drawing.Size(181, 39);
            this.label_score.TabIndex = 1;
            this.label_score.Text = "Score: 0";
            this.label_score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_play
            // 
            this.button_play.Font = new System.Drawing.Font("Voice In My Head", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_play.Location = new System.Drawing.Point(154, 468);
            this.button_play.Name = "button_play";
            this.button_play.Size = new System.Drawing.Size(115, 60);
            this.button_play.TabIndex = 2;
            this.button_play.Text = "Play!";
            this.button_play.UseVisualStyleBackColor = true;
            this.button_play.Click += new System.EventHandler(this.button_play_Click);
            // 
            // button_size
            // 
            this.button_size.Font = new System.Drawing.Font("Voice In My Head", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_size.Location = new System.Drawing.Point(93, 468);
            this.button_size.Name = "button_size";
            this.button_size.Size = new System.Drawing.Size(60, 60);
            this.button_size.TabIndex = 2;
            this.button_size.Text = "10x10";
            this.button_size.UseVisualStyleBackColor = true;
            this.button_size.Click += new System.EventHandler(this.button_size_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Voice In My Head", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(275, 468);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(60, 60);
            this.button3.TabIndex = 2;
            this.button3.Text = "?";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 530);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button_size);
            this.Controls.Add(this.button_play);
            this.Controls.Add(this.label_score);
            this.Controls.Add(this.panel_board);
            this.Name = "Form1";
            this.Text = "Kare Defter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panel_board;
        private System.Windows.Forms.Label label_score;
        private System.Windows.Forms.Button button_play;
        private System.Windows.Forms.Button button_size;
        private System.Windows.Forms.Button button3;
    }
}

