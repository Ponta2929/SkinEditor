using ImageLayout.Utility;
using KeyTouchView.Utility.Hook;
using KeyTouchView.Utility.Reflection.Win32API;
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
    public partial class RegisteredListForm : Form
    {
        private Setting setting = Setting.GetInstance();
        private KeyboardHook keyboardHook = KeyboardHook.GetInstance();

        public RegisteredListForm()
        {
            InitializeComponent();

            // initi
            Initialize();
        }

        private void Initialize()
        {
            setting.Keys.ListChanged += Keys_ListChanged;
            keyboardHook.KeyboardHooked += KeyboardHooked;
            ListBox_Registered.DataSource = setting.Keys;
            ListBox_Registered.FormattingEnabled = true;
        }

        private void KeyboardHooked(object sender, KeyboardHookedEventArgs e)
        {
            if (e.UpDown == KeyboardUpDown.Up && API.GetForegroundWindow() == Handle)
            {
                var item = setting.Keys.FirstOrDefault(target => target.Key == e.KeyCode);

                if (item != null)
                {
                    ListBox_Registered.SelectedItem = item;
                }
            }
        }

        private void Keys_ListChanged(object sender, ListChangedEventArgs e)
        {

        }

        private void ListBox_Registered_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.DesiredType == typeof(string))
            {
                var key = (KeyItem)e.Value;

                // 置換
                e.Value = string.Format("{0} : X:{1}, Y:{2}, Width:{3}, Height:{4} ", Enum.GetName(typeof(Keys), key.Key), key.X, key.Y, key.Width, key.Height);
            }
        }

        private void Button_Delete_Click(object sender, EventArgs e)
        {
            if (ListBox_Registered.SelectedItem != null)
            {
                setting.Keys.Remove((KeyItem)ListBox_Registered.SelectedItem);
            }
        }

        private void ListBox_Registered_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBox_Registered.SelectedIndex != -1)
            {
                setting.SelectedItem = (KeyItem)ListBox_Registered.SelectedItem;

                // Select
                setting.OnSelectedItemChanged();
            }
        }

        private void RegisteredListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
            else
            {
                setting.RegisteredListForm_Width = Width;
                setting.RegisteredListForm_Height = Height;
                setting.RegisteredListForm_X = Left;
                setting.RegisteredListForm_Y = Top;
            }
        }
    }
}
