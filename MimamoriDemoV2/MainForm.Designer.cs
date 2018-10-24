namespace jp.co.brycen.MimamoriDemo
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.graphControl1 = new jp.co.brycen.MimamoriDemo.GraphControl();
            this.ucDynamicFlow1 = new jp.co.brycen.MimamoriDemo.UcDynamicFlow();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.画面切替ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.人員構成表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.導線ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.人員構成表ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // graphControl1
            // 
            this.graphControl1.Location = new System.Drawing.Point(941, 18);
            this.graphControl1.Name = "graphControl1";
            this.graphControl1.Size = new System.Drawing.Size(900, 1017);
            this.graphControl1.TabIndex = 0;
            // 
            // ucDynamicFlow1
            // 
            this.ucDynamicFlow1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucDynamicFlow1.Location = new System.Drawing.Point(83, 18);
            this.ucDynamicFlow1.Name = "ucDynamicFlow1";
            this.ucDynamicFlow1.Size = new System.Drawing.Size(770, 950);
            this.ucDynamicFlow1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::jp.co.brycen.MimamoriDemo.Properties.Resources.ブランドマーク;
            this.pictureBox1.Location = new System.Drawing.Point(858, 703);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(453, 276);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.画面切替ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1362, 26);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 画面切替ToolStripMenuItem
            // 
            this.画面切替ToolStripMenuItem.Checked = true;
            this.画面切替ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.画面切替ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.人員構成表ToolStripMenuItem,
            this.導線ToolStripMenuItem,
            this.人員構成表ToolStripMenuItem1});
            this.画面切替ToolStripMenuItem.Name = "画面切替ToolStripMenuItem";
            this.画面切替ToolStripMenuItem.Size = new System.Drawing.Size(68, 22);
            this.画面切替ToolStripMenuItem.Text = "画面表示";
            // 
            // 人員構成表ToolStripMenuItem
            // 
            this.人員構成表ToolStripMenuItem.Name = "人員構成表ToolStripMenuItem";
            this.人員構成表ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.人員構成表ToolStripMenuItem.Text = "人員構成図";
            this.人員構成表ToolStripMenuItem.Click += new System.EventHandler(this.OnPcdMenu_Click);
            // 
            // 導線ToolStripMenuItem
            // 
            this.導線ToolStripMenuItem.Name = "導線ToolStripMenuItem";
            this.導線ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.導線ToolStripMenuItem.Text = "導線構成図";
            this.導線ToolStripMenuItem.Click += new System.EventHandler(this.OnLcdMenu_Click);
            // 
            // 人員構成表ToolStripMenuItem1
            // 
            this.人員構成表ToolStripMenuItem1.Name = "人員構成表ToolStripMenuItem1";
            this.人員構成表ToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.人員構成表ToolStripMenuItem1.Text = "人員構成表";
            this.人員構成表ToolStripMenuItem1.Click += new System.EventHandler(this.OnPctMenu_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1362, 743);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ucDynamicFlow1);
            this.Controls.Add(this.graphControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GraphControl graphControl1;
        private UcDynamicFlow ucDynamicFlow1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 画面切替ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 人員構成表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 導線ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 人員構成表ToolStripMenuItem1;
    }
}

