
namespace SkinEditor
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
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Panel_Owner = new System.Windows.Forms.Panel();
            this.PictureBox_Viewer = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem_Close = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripLabel_SkinName = new System.Windows.Forms.ToolStripLabel();
            this.ToolStripTextBox_SkinName = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripLabel_Keys = new System.Windows.Forms.ToolStripLabel();
            this.ToolStripComboBox_Keys = new System.Windows.Forms.ToolStripComboBox();
            this.ToolStripButton_Add = new System.Windows.Forms.ToolStripButton();
            this.Timer_ReadWait = new System.Windows.Forms.Timer(this.components);
            this.Panel_Owner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Viewer)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_Owner
            // 
            this.Panel_Owner.AutoScroll = true;
            this.Panel_Owner.Controls.Add(this.PictureBox_Viewer);
            this.Panel_Owner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Owner.Location = new System.Drawing.Point(0, 49);
            this.Panel_Owner.Name = "Panel_Owner";
            this.Panel_Owner.Size = new System.Drawing.Size(704, 340);
            this.Panel_Owner.TabIndex = 0;
            // 
            // PictureBox_Viewer
            // 
            this.PictureBox_Viewer.Location = new System.Drawing.Point(0, 0);
            this.PictureBox_Viewer.Name = "PictureBox_Viewer";
            this.PictureBox_Viewer.Size = new System.Drawing.Size(0, 0);
            this.PictureBox_Viewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox_Viewer.TabIndex = 0;
            this.PictureBox_Viewer.TabStop = false;
            this.PictureBox_Viewer.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_Viewer_Paint);
            this.PictureBox_Viewer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox_Viewer_MouseDown);
            this.PictureBox_Viewer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox_Viewer_MouseMove);
            this.PictureBox_Viewer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox_Viewer_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(704, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルFToolStripMenuItem
            // 
            this.ファイルFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Open,
            this.ToolStripMenuItem_Save,
            this.toolStripMenuItem1,
            this.ToolStripMenuItem_Close,
            this.toolStripMenuItem2,
            this.ToolStripMenuItem_Exit});
            this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
            this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.ファイルFToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // ToolStripMenuItem_Open
            // 
            this.ToolStripMenuItem_Open.Name = "ToolStripMenuItem_Open";
            this.ToolStripMenuItem_Open.Size = new System.Drawing.Size(181, 22);
            this.ToolStripMenuItem_Open.Text = "開く(&O)...";
            this.ToolStripMenuItem_Open.Click += new System.EventHandler(this.ToolStripMenuItem_Open_Click);
            // 
            // ToolStripMenuItem_Save
            // 
            this.ToolStripMenuItem_Save.Name = "ToolStripMenuItem_Save";
            this.ToolStripMenuItem_Save.Size = new System.Drawing.Size(181, 22);
            this.ToolStripMenuItem_Save.Text = "名前をつけて保存(&S)...";
            this.ToolStripMenuItem_Save.Click += new System.EventHandler(this.ToolStripMenuItem_Save_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(178, 6);
            // 
            // ToolStripMenuItem_Close
            // 
            this.ToolStripMenuItem_Close.Name = "ToolStripMenuItem_Close";
            this.ToolStripMenuItem_Close.Size = new System.Drawing.Size(181, 22);
            this.ToolStripMenuItem_Close.Text = "閉じる(&C)";
            this.ToolStripMenuItem_Close.Click += new System.EventHandler(this.ToolStripMenuItem_Close_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(178, 6);
            // 
            // ToolStripMenuItem_Exit
            // 
            this.ToolStripMenuItem_Exit.Name = "ToolStripMenuItem_Exit";
            this.ToolStripMenuItem_Exit.Size = new System.Drawing.Size(181, 22);
            this.ToolStripMenuItem_Exit.Text = "終了(&X)";
            this.ToolStripMenuItem_Exit.Click += new System.EventHandler(this.ToolStripMenuItem_Exit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 389);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(704, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(689, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "おしらせ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripLabel_SkinName,
            this.ToolStripTextBox_SkinName,
            this.toolStripSeparator1,
            this.ToolStripLabel_Keys,
            this.ToolStripComboBox_Keys,
            this.ToolStripButton_Add});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(704, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ToolStripLabel_SkinName
            // 
            this.ToolStripLabel_SkinName.Name = "ToolStripLabel_SkinName";
            this.ToolStripLabel_SkinName.Size = new System.Drawing.Size(46, 22);
            this.ToolStripLabel_SkinName.Text = "スキン名";
            // 
            // ToolStripTextBox_SkinName
            // 
            this.ToolStripTextBox_SkinName.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.ToolStripTextBox_SkinName.Name = "ToolStripTextBox_SkinName";
            this.ToolStripTextBox_SkinName.Size = new System.Drawing.Size(150, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolStripLabel_Keys
            // 
            this.ToolStripLabel_Keys.Name = "ToolStripLabel_Keys";
            this.ToolStripLabel_Keys.Size = new System.Drawing.Size(67, 22);
            this.ToolStripLabel_Keys.Text = "キャプチャキー";
            // 
            // ToolStripComboBox_Keys
            // 
            this.ToolStripComboBox_Keys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ToolStripComboBox_Keys.Name = "ToolStripComboBox_Keys";
            this.ToolStripComboBox_Keys.Size = new System.Drawing.Size(121, 25);
            // 
            // ToolStripButton_Add
            // 
            this.ToolStripButton_Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripButton_Add.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_Add.Image")));
            this.ToolStripButton_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_Add.Name = "ToolStripButton_Add";
            this.ToolStripButton_Add.Size = new System.Drawing.Size(35, 22);
            this.ToolStripButton_Add.Text = "追加";
            this.ToolStripButton_Add.Click += new System.EventHandler(this.ToolStripButton_Add_Click);
            // 
            // Timer_ReadWait
            // 
            this.Timer_ReadWait.Interval = 1000;
            this.Timer_ReadWait.Tick += new System.EventHandler(this.Timer_ReadWait_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 411);
            this.Controls.Add(this.Panel_Owner);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SkinEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Panel_Owner.ResumeLayout(false);
            this.Panel_Owner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Viewer)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Owner;
        private System.Windows.Forms.PictureBox PictureBox_Viewer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Open;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Exit;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox ToolStripComboBox_Keys;
        private System.Windows.Forms.ToolStripButton ToolStripButton_Add;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Save;
        private System.Windows.Forms.ToolStripLabel ToolStripLabel_SkinName;
        private System.Windows.Forms.ToolStripTextBox ToolStripTextBox_SkinName;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel ToolStripLabel_Keys;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Close;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.Timer Timer_ReadWait;
    }
}

