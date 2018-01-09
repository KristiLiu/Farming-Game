namespace HarvestStarNewEdition
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.tmrRunTime = new System.Windows.Forms.Timer(this.components);
            this.txtName = new System.Windows.Forms.TextBox();
            this.pnlStartGame = new System.Windows.Forms.Panel();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.lblPromptName = new System.Windows.Forms.Label();
            this.btnLoadGame = new System.Windows.Forms.Button();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblEndDay = new System.Windows.Forms.Label();
            this.lblBuyRadish = new System.Windows.Forms.Label();
            this.lblBuyPumpkinSeed = new System.Windows.Forms.Label();
            this.lblBuyWeddingCake = new System.Windows.Forms.Label();
            this.lblSave = new System.Windows.Forms.Label();
            this.lblDayCount = new System.Windows.Forms.Label();
            this.lblSell = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pnlStartGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(230, 32);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(75, 23);
            this.btnNewGame.TabIndex = 0;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // tmrRunTime
            // 
            this.tmrRunTime.Interval = 16;
            this.tmrRunTime.Tick += new System.EventHandler(this.tmrRunTime_Tick);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(93, 53);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 2;
            // 
            // pnlStartGame
            // 
            this.pnlStartGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlStartGame.Controls.Add(this.lblInstructions);
            this.pnlStartGame.Controls.Add(this.lblError);
            this.pnlStartGame.Controls.Add(this.lblPromptName);
            this.pnlStartGame.Controls.Add(this.btnLoadGame);
            this.pnlStartGame.Controls.Add(this.btnNewGame);
            this.pnlStartGame.Controls.Add(this.txtName);
            this.pnlStartGame.Location = new System.Drawing.Point(50, 43);
            this.pnlStartGame.Name = "pnlStartGame";
            this.pnlStartGame.Size = new System.Drawing.Size(557, 361);
            this.pnlStartGame.TabIndex = 3;
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Font = new System.Drawing.Font("Gentium Book Basic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructions.ForeColor = System.Drawing.Color.Black;
            this.lblInstructions.Location = new System.Drawing.Point(3, 96);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(51, 19);
            this.lblInstructions.TabIndex = 6;
            this.lblInstructions.Text = "label1";
            this.lblInstructions.Click += new System.EventHandler(this.lblInstructions_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(124, 153);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 5;
            // 
            // lblPromptName
            // 
            this.lblPromptName.AutoSize = true;
            this.lblPromptName.Location = new System.Drawing.Point(90, 37);
            this.lblPromptName.Name = "lblPromptName";
            this.lblPromptName.Size = new System.Drawing.Size(119, 13);
            this.lblPromptName.TabIndex = 4;
            this.lblPromptName.Text = "Please write your name!";
            // 
            // btnLoadGame
            // 
            this.btnLoadGame.Location = new System.Drawing.Point(230, 61);
            this.btnLoadGame.Name = "btnLoadGame";
            this.btnLoadGame.Size = new System.Drawing.Size(75, 23);
            this.btnLoadGame.TabIndex = 3;
            this.btnLoadGame.Text = "Load Game";
            this.btnLoadGame.UseVisualStyleBackColor = true;
            this.btnLoadGame.Click += new System.EventHandler(this.btnLoadGame_Click);
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.BackColor = System.Drawing.Color.Transparent;
            this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.Location = new System.Drawing.Point(12, 456);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(68, 18);
            this.lblBalance.TabIndex = 2;
            this.lblBalance.Text = "Balance";
            this.lblBalance.Visible = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(12, 429);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(52, 18);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            this.lblName.Visible = false;
            // 
            // lblEndDay
            // 
            this.lblEndDay.AutoSize = true;
            this.lblEndDay.BackColor = System.Drawing.Color.Transparent;
            this.lblEndDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndDay.Location = new System.Drawing.Point(568, 429);
            this.lblEndDay.Name = "lblEndDay";
            this.lblEndDay.Size = new System.Drawing.Size(71, 18);
            this.lblEndDay.TabIndex = 0;
            this.lblEndDay.Text = "End Day";
            this.lblEndDay.Visible = false;
            this.lblEndDay.Click += new System.EventHandler(this.lblEndDay_Click);
            // 
            // lblBuyRadish
            // 
            this.lblBuyRadish.AutoSize = true;
            this.lblBuyRadish.BackColor = System.Drawing.Color.Transparent;
            this.lblBuyRadish.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuyRadish.Location = new System.Drawing.Point(12, 9);
            this.lblBuyRadish.Name = "lblBuyRadish";
            this.lblBuyRadish.Size = new System.Drawing.Size(93, 18);
            this.lblBuyRadish.TabIndex = 3;
            this.lblBuyRadish.Text = "Buy Radish";
            this.lblBuyRadish.Visible = false;
            this.lblBuyRadish.Click += new System.EventHandler(this.lblBuyRadish_Click);
            // 
            // lblBuyPumpkinSeed
            // 
            this.lblBuyPumpkinSeed.AutoSize = true;
            this.lblBuyPumpkinSeed.BackColor = System.Drawing.Color.Transparent;
            this.lblBuyPumpkinSeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuyPumpkinSeed.Location = new System.Drawing.Point(129, 9);
            this.lblBuyPumpkinSeed.Name = "lblBuyPumpkinSeed";
            this.lblBuyPumpkinSeed.Size = new System.Drawing.Size(97, 18);
            this.lblBuyPumpkinSeed.TabIndex = 4;
            this.lblBuyPumpkinSeed.Text = "Buy Pumkin";
            this.lblBuyPumpkinSeed.Visible = false;
            this.lblBuyPumpkinSeed.Click += new System.EventHandler(this.lblBuyPumpkinSeed_Click);
            // 
            // lblBuyWeddingCake
            // 
            this.lblBuyWeddingCake.AutoSize = true;
            this.lblBuyWeddingCake.BackColor = System.Drawing.Color.Transparent;
            this.lblBuyWeddingCake.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuyWeddingCake.Location = new System.Drawing.Point(249, 9);
            this.lblBuyWeddingCake.Name = "lblBuyWeddingCake";
            this.lblBuyWeddingCake.Size = new System.Drawing.Size(150, 18);
            this.lblBuyWeddingCake.TabIndex = 5;
            this.lblBuyWeddingCake.Text = "Buy Wedding Cake";
            this.lblBuyWeddingCake.Visible = false;
            this.lblBuyWeddingCake.Click += new System.EventHandler(this.lblBuyWeddingCake_Click);
            // 
            // lblSave
            // 
            this.lblSave.AutoSize = true;
            this.lblSave.BackColor = System.Drawing.Color.Transparent;
            this.lblSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSave.Location = new System.Drawing.Point(594, 456);
            this.lblSave.Name = "lblSave";
            this.lblSave.Size = new System.Drawing.Size(45, 18);
            this.lblSave.TabIndex = 6;
            this.lblSave.Text = "Save";
            this.lblSave.Visible = false;
            this.lblSave.Click += new System.EventHandler(this.lblSave_Click);
            // 
            // lblDayCount
            // 
            this.lblDayCount.AutoSize = true;
            this.lblDayCount.Location = new System.Drawing.Point(535, 9);
            this.lblDayCount.Name = "lblDayCount";
            this.lblDayCount.Size = new System.Drawing.Size(63, 13);
            this.lblDayCount.TabIndex = 7;
            this.lblDayCount.Text = "DayCounter";
            this.lblDayCount.Visible = false;
            // 
            // lblSell
            // 
            this.lblSell.AutoSize = true;
            this.lblSell.BackColor = System.Drawing.Color.Transparent;
            this.lblSell.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSell.Location = new System.Drawing.Point(568, 401);
            this.lblSell.Name = "lblSell";
            this.lblSell.Size = new System.Drawing.Size(78, 18);
            this.lblSell.TabIndex = 8;
            this.lblSell.Text = "Sell Crop";
            this.lblSell.Visible = false;
            this.lblSell.Click += new System.EventHandler(this.lblSell_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(15, 31);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 13);
            this.lblMessage.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 482);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblSell);
            this.Controls.Add(this.lblDayCount);
            this.Controls.Add(this.lblSave);
            this.Controls.Add(this.lblBuyWeddingCake);
            this.Controls.Add(this.lblBuyPumpkinSeed);
            this.Controls.Add(this.lblEndDay);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.lblBuyRadish);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pnlStartGame);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.pnlStartGame.ResumeLayout(false);
            this.pnlStartGame.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Timer tmrRunTime;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Panel pnlStartGame;
        private System.Windows.Forms.Label lblEndDay;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblBuyRadish;
        private System.Windows.Forms.Label lblBuyPumpkinSeed;
        private System.Windows.Forms.Label lblBuyWeddingCake;
        private System.Windows.Forms.Label lblSave;
        private System.Windows.Forms.Label lblDayCount;
        private System.Windows.Forms.Label lblSell;
        private System.Windows.Forms.Label lblPromptName;
        private System.Windows.Forms.Button btnLoadGame;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Label lblMessage;
    }
}

