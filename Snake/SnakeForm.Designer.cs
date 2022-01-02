
namespace Snake
{
    partial class Form1
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
            this.snakeHead = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.fruit = new System.Windows.Forms.PictureBox();
            this.labelScore = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.snakeHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fruit)).BeginInit();
            this.SuspendLayout();
            // 
            // snakeHead
            // 
            this.snakeHead.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.snakeHead.BackColor = System.Drawing.SystemColors.Highlight;
            this.snakeHead.Location = new System.Drawing.Point(0, 0);
            this.snakeHead.Name = "snakeHead";
            this.snakeHead.Size = new System.Drawing.Size(40, 40);
            this.snakeHead.TabIndex = 0;
            this.snakeHead.TabStop = false;
            // 
            // fruit
            // 
            this.fruit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.fruit.Location = new System.Drawing.Point(80, 80);
            this.fruit.Name = "fruit";
            this.fruit.Size = new System.Drawing.Size(40, 40);
            this.fruit.TabIndex = 1;
            this.fruit.TabStop = false;
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelScore.Location = new System.Drawing.Point(770, 10);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(88, 25);
            this.labelScore.TabIndex = 2;
            this.labelScore.Text = "Счёт: 0";
            this.labelScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 761);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.fruit);
            this.Controls.Add(this.snakeHead);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.snakeHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fruit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox snakeHead;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox fruit;
        private System.Windows.Forms.Label labelScore;
    }
}

