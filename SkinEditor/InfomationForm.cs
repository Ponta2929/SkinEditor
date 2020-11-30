using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkinEditor
{
    public partial class InfomationForm : Form
    {
        private Setting setting = Setting.GetInstance();

        public InfomationForm()
        {
            InitializeComponent();

            // init
            Initialize();
        }

        private void Initialize()
        {
            setting.SettingChanged += SettingChanged;
            setting.SelectedItemChanged += SelectedItemChanged;
        }

        private void SelectedItemChanged(object sender, EventArgs e)
        {
            if (setting.SelectedItem != null)
            {
                numericUpDown1.Value = setting.SelectedItem.X;
                numericUpDown2.Value = setting.SelectedItem.Y;
                numericUpDown3.Value = Panel_Image.Width = setting.SelectedItem.Width;
                numericUpDown4.Value = Panel_Image.Height = setting.SelectedItem.Height;
            }
        }

        private void SettingChanged(object sender, EventArgs e)
        {
            if (setting.NormalImage == null)
            {
                // 最大値設定
                numericUpDown1.Maximum = 0;
                numericUpDown2.Maximum = 0;
                numericUpDown3.Maximum =0;
                numericUpDown4.Maximum = 0;

                numericUpDown1.Value =0;
                numericUpDown2.Value = 0;
                numericUpDown3.Value = Panel_Image.Width = 0;
                numericUpDown4.Value = Panel_Image.Height = 0;

                Label_NormalPath.Text = "";
                Label_PressPath.Text = "";
            }
            else
            {
                // 最大値設定
                numericUpDown1.Maximum = setting.NormalImage.Width;
                numericUpDown2.Maximum = setting.NormalImage.Height;
                numericUpDown3.Maximum = setting.NormalImage.Width;
                numericUpDown4.Maximum = setting.NormalImage.Height;

                numericUpDown1.Value = setting.Select_X;
                numericUpDown2.Value = setting.Select_Y;
                numericUpDown3.Value = Panel_Image.Width = setting.Select_Width;
                numericUpDown4.Value = Panel_Image.Height = setting.Select_Height;

                Label_NormalPath.Text = setting.NormalImagePath;
                Label_PressPath.Text = setting.PressImagePath;
            }

            Panel_Image.Invalidate();
        }

        private void Capture_Value_Changed(object sender, EventArgs e)
        {
            if (sender is NumericUpDown)
            {
                if (sender == numericUpDown1)
                {
                    setting.Select_X = (int)numericUpDown1.Value;
                }
                else if (sender == numericUpDown2)
                {
                    setting.Select_Y = (int)numericUpDown2.Value;
                }
                else if (sender == numericUpDown3)
                {
                    setting.Select_Width = (int)numericUpDown3.Value;
                }
                else if (sender == numericUpDown4)
                {
                    setting.Select_Height = (int)numericUpDown4.Value;
                }

                setting.OnSettingChanged();
            }
        }

        private void Panel_Image_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            if (setting.NormalImage != null)
            {
                g.DrawImage(setting.NormalImage, new Rectangle(0, 0, setting.Select_Width, setting.Select_Height), new Rectangle(setting.Select_X, setting.Select_Y, setting.Select_Width, setting.Select_Height), GraphicsUnit.Pixel);
            }
        }

        private void InfomationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
            else
            {
                setting.InfomationForm_Height = Height;
                setting.InfomationForm_X = Left;
                setting.InfomationForm_Y = Top;
            }
        }
    }
}
