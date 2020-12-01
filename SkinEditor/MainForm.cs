using ImageLayout.Utility;
using KeyTouchView.Utility.Hook;
using KeyTouchView.Utility.Reflection.Win32API;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SkinEditor
{
    public partial class MainForm : Form
    {
        #region グローバル変数

        private Setting setting = Setting.GetInstance();
        private KeyboardHook keyboardHook = KeyboardHook.GetInstance();

        private InfomationForm infomationForm;
        private RegisteredListForm registeredListForm;

        private int x, y;
        private int m_dx, m_dy;
        private int r_x, r_y;
        private Color color_mode = Color.Red;

        private string filter = "読み込み可能なファイル|*.bmp;*.jpg;*.jpeg;*.png";
        private bool first, second;

        private Panel[] RubberBand = new Panel[8];
        private bool readWait = false;
        #endregion


        public MainForm()
        {
            InitializeComponent();

            // 初期化
            Initialize();
        }

        private void Initialize()
        {
            for (var i = 0; i < RubberBand.Length; i++)
            {
                RubberBand[i] = new Panel();
                RubberBand[i].Name = $"RubberBand_{i}";
                RubberBand[i].Width = RubberBand[i].Height = 9;
                RubberBand[i].BackColor = Color.White;
                RubberBand[i].BorderStyle = BorderStyle.FixedSingle;
                RubberBand[i].Visible = false;
                RubberBand[i].MouseMove += RubberBand_MouseMove;
                RubberBand[i].MouseUp += RubberBand_MouseUp;

                // コントロール追加
                Panel_Owner.Controls.Add(RubberBand[i]);
            }

            // カーソル指定
            RubberBand[0].Cursor = RubberBand[7].Cursor = Cursors.SizeNWSE;
            RubberBand[1].Cursor = RubberBand[6].Cursor = Cursors.SizeNS;
            RubberBand[2].Cursor = RubberBand[5].Cursor = Cursors.SizeNESW;
            RubberBand[3].Cursor = RubberBand[4].Cursor = Cursors.SizeWE;

            // 最前面に配置
            Panel_Owner.Controls.SetChildIndex(PictureBox_Viewer, Panel_Owner.Controls.Count - 1);

            // キーリストを作成
            var keys = (Keys[])Enum.GetValues(typeof(Keys));

            // キー
            var key = Keys.None;

            for (var i = 0; i < keys.Length; i++)
            {
                if (key != keys[i])
                {
                    ToolStripComboBox_Keys.Items.Add(keys[i]);
                }

                // 値を設定
                key = keys[i];
            }
            try
            {
                // 設定読み込み
                setting.FileDeserialize($"{Application.StartupPath}\\setting.xml");
            }
            catch
            {

            }
            finally
            {
                infomationForm = new InfomationForm();
                registeredListForm = new RegisteredListForm();

                // MainForm
                Height = setting.Height;
                Width = setting.Width;
                Top = setting.Y;
                Left = setting.X;

                // RegisteredListForm
                registeredListForm.Height = setting.RegisteredListForm_Height;
                registeredListForm.Width = setting.RegisteredListForm_Width;
                registeredListForm.Top = setting.RegisteredListForm_Y;
                registeredListForm.Left = setting.RegisteredListForm_X;

                // InfomationForm
                infomationForm.Height = setting.InfomationForm_Height;
                infomationForm.Top = setting.InfomationForm_Y;
                infomationForm.Left = setting.InfomationForm_X;
            }

            ToolStripComboBox_Keys.SelectedIndex = 0;

            // イベント設定
            keyboardHook.KeyboardHooked += KeyboardHooked;
            setting.SettingChanged += SettingChanged;
            setting.SelectedBorderChanged += SelectedBorderChanged;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // ツールウィンドウ表示
            registeredListForm.Show(this);
            infomationForm.Show(this);
        }

        private void SelectedBorderChanged(object sender, EventArgs e)
        {
            RubberBand[0].Left = setting.Select_X - 4;
            RubberBand[0].Top = setting.Select_Y - 4;

            RubberBand[1].Left = setting.Select_X + (setting.Select_Width / 2) - 4;
            RubberBand[1].Top = setting.Select_Y - 4;

            RubberBand[2].Left = setting.Select_X + setting.Select_Width - 4;
            RubberBand[2].Top = setting.Select_Y - 4;

            RubberBand[3].Left = setting.Select_X - 4;
            RubberBand[3].Top = setting.Select_Y + (setting.Select_Height / 2) - 4;

            RubberBand[4].Left = setting.Select_X + setting.Select_Width - 4;
            RubberBand[4].Top = setting.Select_Y + (setting.Select_Height / 2) - 4;

            RubberBand[5].Left = setting.Select_X - 4;
            RubberBand[5].Top = setting.Select_Y + setting.Select_Height - 4;

            RubberBand[6].Left = setting.Select_X + (setting.Select_Width / 2) - 4;
            RubberBand[6].Top = setting.Select_Y + setting.Select_Height - 4;

            RubberBand[7].Left = setting.Select_X + setting.Select_Width - 4;
            RubberBand[7].Top = setting.Select_Y + setting.Select_Height - 4;
        }

        private void RubberBand_MouseUp(object sender, MouseEventArgs e) =>
            setting.OnSettingChanged();

        private void RubberBand_MouseMove(object sender, MouseEventArgs e)
        {
            var rubberBand = (Panel)sender;

            if (e.Button == MouseButtons.Left)
            {
                var b_x = rubberBand.Left;
                var b_y = rubberBand.Top;

                if (rubberBand.Name == "RubberBand_0")
                {
                    rubberBand.Left += e.X - 4;
                    rubberBand.Top += e.Y - 4;
                    setting.Select_X = rubberBand.Left + 4;
                    setting.Select_Y = rubberBand.Top + 4;
                    setting.Select_Width += b_x - rubberBand.Left;
                    setting.Select_Height += b_y - rubberBand.Top;
                }
                else if (rubberBand.Name == "RubberBand_1")
                {
                    rubberBand.Top += e.Y - 4;
                    setting.Select_Y = rubberBand.Top + 4;
                    setting.Select_Height += b_y - rubberBand.Top;
                }
                else if (rubberBand.Name == "RubberBand_2")
                {
                    rubberBand.Left += e.X - 4;
                    rubberBand.Top += e.Y - 4;
                    setting.Select_Y = rubberBand.Top + 4;
                    setting.Select_Width += e.X - 4;
                    setting.Select_Height += b_y - rubberBand.Top;
                }
                else if (rubberBand.Name == "RubberBand_3")
                {
                    rubberBand.Left += e.X - 4;
                    setting.Select_X = rubberBand.Left + 4;
                    setting.Select_Width += b_x - rubberBand.Left;
                }
                else if (rubberBand.Name == "RubberBand_4")
                {
                    rubberBand.Left += e.X - 4;
                    setting.Select_Width += e.X - 4;
                }
                else if (rubberBand.Name == "RubberBand_5")
                {
                    rubberBand.Left += e.X - 4;
                    rubberBand.Top += e.Y - 4;
                    setting.Select_X = rubberBand.Left + 4;
                    setting.Select_Width += b_x - rubberBand.Left;
                    setting.Select_Height += e.Y - 4;
                }
                else if (rubberBand.Name == "RubberBand_6")
                {
                    rubberBand.Top += e.Y - 4;
                    setting.Select_Height += e.Y - 4;
                }
                else if (rubberBand.Name == "RubberBand_7")
                {
                    rubberBand.Left += e.X - 4;
                    rubberBand.Top += e.Y - 4;
                    setting.Select_Width += e.X - 4;
                    setting.Select_Height += e.Y - 4;
                }

                // 座標反転
                AxisNormalization();
                setting.OnSelectedBorderChanged();
            }

            // 画面更新
            PictureBox_Viewer.Refresh();
        }

        private void SettingChanged(object sender, EventArgs e)
        {
            setting.OnSelectedBorderChanged();

            // 画面更新
            PictureBox_Viewer.Refresh();
        }

        private void KeyboardHooked(object sender, KeyboardHookedEventArgs e)
        {
            if (e.UpDown == KeyboardUpDown.Up && API.GetForegroundWindow() == Handle && !ToolStripTextBox_SkinName.Focused)
            {
                e.Cancel = true;

                // 選択
                ToolStripComboBox_Keys.SelectedItem = e.KeyCode;
            }
        }

        private void PictureBox_Viewer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                for (var i = 0; i < RubberBand.Length; i++)
                {
                    RubberBand[i].Visible = false;
                }

                if (setting.Select_X < e.X && setting.Select_X + setting.Select_Width > e.X &&
                    setting.Select_Y < e.Y && setting.Select_Y + setting.Select_Height > e.Y)
                {
                    r_x = e.X - setting.Select_X;
                    r_y = e.Y - setting.Select_Y;
                }
                else
                {
                    setting.Select_X = 0;
                    setting.Select_Y = 0;
                    setting.Select_Width = 0;
                    setting.Select_Height = 0;
                    m_dx = e.X;
                    m_dy = e.Y;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (color_mode == Color.Red)
                {
                    color_mode = Color.Lime;
                }
                else if (color_mode == Color.Lime)
                {
                    color_mode = Color.Blue;
                }
                else if (color_mode == Color.Blue)
                {
                    color_mode = Color.Red;
                }
            }
        }

        private void PictureBox_Viewer_MouseMove(object sender, MouseEventArgs e)
        {
            if (!readWait)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (setting.Select_X < e.X && setting.Select_X + setting.Select_Width > e.X &&
                        setting.Select_Y < e.Y && setting.Select_Y + setting.Select_Height > e.Y)
                    {
                        setting.Select_X += e.X - setting.Select_X - r_x;
                        setting.Select_Y += e.Y - setting.Select_Y - r_y;
                    }
                    else
                    {
                        x = e.X;
                        y = e.Y;

                        setting.Select_X = m_dx;
                        setting.Select_Y = m_dy;
                        setting.Select_Width = x - m_dx;
                        setting.Select_Height = y - m_dy;
                    }

                    // 座標反転
                    AxisNormalization();
                }
                else
                {
                    if (setting.Select_X < e.X && setting.Select_X + setting.Select_Width > e.X &&
                        setting.Select_Y < e.Y && setting.Select_Y + setting.Select_Height > e.Y)
                    {
                        PictureBox_Viewer.Cursor = Cursors.SizeAll;
                    }
                    else
                    {
                        PictureBox_Viewer.Cursor = Cursors.Default;
                    }
                }
            }

            // 画面更新
            PictureBox_Viewer.Refresh();
        }

        private void PictureBox_Viewer_MouseUp(object sender, MouseEventArgs e)
        {
            if (setting.Select_Width == 0 && setting.Select_Height == 0)
            {
                for (var i = 0; i < RubberBand.Length; i++)
                {
                    RubberBand[i].Visible = false;
                }
            }
            else
            {
                for (var i = 0; i < RubberBand.Length; i++)
                {
                    RubberBand[i].Visible = true;
                }
            }

            setting.OnSelectedBorderChanged();
            setting.OnSettingChanged();
        }
        
        private void PictureBox_Viewer_Paint(object sender, PaintEventArgs e) =>
            e.Graphics.DrawRectangle(new Pen(color_mode), new Rectangle(setting.Select_X, setting.Select_Y, setting.Select_Width, setting.Select_Height));

        private void ToolStripMenuItem_Open_Click(object sender, EventArgs e)
        {
            if (!first)
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Title = "１番目の画像を選択してください。";
                    ofd.Filter = filter;

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        setting.NormalImagePath = ofd.FileName;
                        PictureBox_Viewer.Image = setting.NormalImage = (Bitmap)Bitmap.FromFile(ofd.FileName);

                        // 画像読み込みフラグ
                        first = true;
                    }
                }
            }
            if (!second)
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Title = "２番目の画像を選択してください。";
                    ofd.Filter = filter;

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        setting.PressImagePath = ofd.FileName;
                        setting.PressImage = (Bitmap)Bitmap.FromFile(ofd.FileName);

                        // 画像読み込みフラグ
                        second = true;
                    }
                }
            }

            readWait = true;
            Timer_ReadWait.Start();
        }


        private void ToolStripButton_Add_Click(object sender, EventArgs e)
        {
            // 選択された部分を追加
            try
            {
                setting.Keys.Add(new KeyItem()
                {
                    Key = (Keys)ToolStripComboBox_Keys.SelectedItem,
                    X = setting.Select_X,
                    Y = setting.Select_Y,
                    Width = setting.Select_Width,
                    Height = setting.Select_Height,
                });
            }
            catch
            {

            }
        }

        private void ToolStripMenuItem_Exit_Click(object sender, EventArgs e) =>
            Close();

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 設定値
            setting.X = Left;
            setting.Y = Top;
            setting.Width = Width;
            setting.Height = Height;

            try
            {
                setting.FileSerialize($"{Application.StartupPath}\\setting.xml");
            }
            catch
            {

            }
        }

        private void Timer_ReadWait_Tick(object sender, EventArgs e)
        {
            readWait = false;
            Timer_ReadWait.Stop();
        }

        private void ToolStripMenuItem_Close_Click(object sender, EventArgs e)
        {
            // 編集中のデータをすべてクリア
            for (var i = 0; i < RubberBand.Length; i++)
            {
                RubberBand[i].Visible = false;
            }
            first = second = false;

            setting.Keys.Clear();
            setting.SelectedItem = null;
            PictureBox_Viewer.Image = null;
            setting.NormalImage.Dispose();
            setting.NormalImage = null;
            setting.NormalImagePath = "";
            setting.PressImage.Dispose();
            setting.PressImage = null;
            setting.PressImagePath = "";
            setting.Select_Height = 0;
            setting.Select_Width = 0;
            setting.Select_X = 0;
            setting.Select_Y = 0;
            setting.OnSettingChanged();
        }

        private void ToolStripMenuItem_Save_Click(object sender, EventArgs e)
        {
            if (!first)
            {
                MessageBox.Show(this, "１番目の画像が選択されていません。", "保存エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (!second)
            {
                MessageBox.Show(this, "２番目の画像が選択されていません。", "保存エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (first && second)
            {
                using (SaveFileDialog ofd = new SaveFileDialog())
                {
                    ofd.Title = "名前を付けて保存";
                    ofd.Filter = "XML File Format|*.xml";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        // スキン情報作成
                        var info = new SkinInfomation()
                        {
                            SkinName = ToolStripTextBox_SkinName.Text,
                            NormalImage = Path.GetFileName(setting.NormalImagePath),
                            PressImage = Path.GetFileName(setting.PressImagePath),
                            Keys = setting.Keys.ToArray()
                        };

                        // 書き込み
                        var xml = Serializer.XmlSerialize<SkinInfomation>(info);
                        using (var stream = new FileStream(ofd.FileName, FileMode.Create, FileAccess.Write))
                        using (var writer = new StreamWriter(stream))
                        {
                            writer.Write(xml);
                        }
                    }
                }
                MessageBox.Show(this, "使用したリソースは、保存したXMLファイルと同一フォルダに保存してください。", "保存が完了しました。", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        /// <summary>
        /// 座標修正します。
        /// </summary>
        private void AxisNormalization()
        {
            if (setting.Select_Width < 0)
            {
                setting.Select_X = setting.Select_X + setting.Select_Width;
                setting.Select_Width = -setting.Select_Width;
            }
            if (setting.Select_Height < 0)
            {
                setting.Select_Y = setting.Select_Y + setting.Select_Height;
                setting.Select_Height = -setting.Select_Height;
            }
            if (setting.Select_X < 0)
            {
                setting.Select_X = 0;
            }
            if (setting.Select_Y < 0)
            {
                setting.Select_Y = 0;
            }
            if (setting.Select_X + setting.Select_Width > setting.NormalImage.Width)
            {
                setting.Select_Width = setting.NormalImage.Width - setting.Select_X;
            }
            if (setting.Select_Y + setting.Select_Height > setting.NormalImage.Height)
            {
                setting.Select_Height = setting.NormalImage.Height - setting.Select_Y;
            }
        }
    }
}
