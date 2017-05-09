namespace CompetitionIndice
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.保存FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.竞争指数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.基于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bALToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.与距离有关的竞争指数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.二维图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.三维图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.竞争指数ToolStripMenuItem,
            this.二维图ToolStripMenuItem,
            this.三维图ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1013, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenExcel,
            this.保存FToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            this.文件FToolStripMenuItem.Click += new System.EventHandler(this.文件FToolStripMenuItem_Click);
            // 
            // OpenExcel
            // 
            this.OpenExcel.Name = "OpenExcel";
            this.OpenExcel.Size = new System.Drawing.Size(152, 22);
            this.OpenExcel.Text = "打开(&O)";
            this.OpenExcel.Click += new System.EventHandler(this.OpenExcel_Click);
            // 
            // 保存FToolStripMenuItem
            // 
            this.保存FToolStripMenuItem.Name = "保存FToolStripMenuItem";
            this.保存FToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.保存FToolStripMenuItem.Text = "保存(&F)";
            this.保存FToolStripMenuItem.Click += new System.EventHandler(this.保存FToolStripMenuItem_Click);
            // 
            // 竞争指数ToolStripMenuItem
            // 
            this.竞争指数ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.基于ToolStripMenuItem,
            this.与距离有关的竞争指数ToolStripMenuItem});
            this.竞争指数ToolStripMenuItem.Name = "竞争指数ToolStripMenuItem";
            this.竞争指数ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.竞争指数ToolStripMenuItem.Text = "竞争指数";
            // 
            // 基于ToolStripMenuItem
            // 
            this.基于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bALToolStripMenuItem});
            this.基于ToolStripMenuItem.Name = "基于ToolStripMenuItem";
            this.基于ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.基于ToolStripMenuItem.Text = "与距离无关的竞争指数";
            // 
            // bALToolStripMenuItem
            // 
            this.bALToolStripMenuItem.Name = "bALToolStripMenuItem";
            this.bALToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.bALToolStripMenuItem.Text = "BAL";
            this.bALToolStripMenuItem.Click += new System.EventHandler(this.bALToolStripMenuItem_Click);
            // 
            // 与距离有关的竞争指数ToolStripMenuItem
            // 
            this.与距离有关的竞争指数ToolStripMenuItem.Name = "与距离有关的竞争指数ToolStripMenuItem";
            this.与距离有关的竞争指数ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.与距离有关的竞争指数ToolStripMenuItem.Text = "与距离有关的竞争指数";
            // 
            // 二维图ToolStripMenuItem
            // 
            this.二维图ToolStripMenuItem.Name = "二维图ToolStripMenuItem";
            this.二维图ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.二维图ToolStripMenuItem.Text = "二维图";
            this.二维图ToolStripMenuItem.Click += new System.EventHandler(this.二维图ToolStripMenuItem_Click);
            // 
            // 三维图ToolStripMenuItem
            // 
            this.三维图ToolStripMenuItem.Name = "三维图ToolStripMenuItem";
            this.三维图ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.三维图ToolStripMenuItem.Text = "三维图";
            this.三维图ToolStripMenuItem.Click += new System.EventHandler(this.三维图ToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(506, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 500);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.Location = new System.Drawing.Point(0, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(500, 506);
            this.dataGridView1.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 537);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1013, 22);
            this.statusStrip1.TabIndex = 0;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(506, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // skinEngine1
            // 
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 559);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Competition Indice";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 竞争指数ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 基于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 与距离有关的竞争指数ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 二维图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 三维图ToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenExcel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem bALToolStripMenuItem;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.ToolStripMenuItem 保存FToolStripMenuItem;
    }
}

