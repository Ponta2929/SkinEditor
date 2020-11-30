using ImageLayout.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SkinEditor
{
    public class Setting : Serializer<Setting>
    {
        #region Singleton

        /// <summary>
        /// インスタンス
        /// </summary>
        private static Setting instance;

        /// <summary>
        /// インスタンスを取得します。
        /// </summary>
        /// <returns></returns>
        public static Setting GetInstance() => instance ?? (instance = new Setting());

        #endregion

        public int Width { get; set; } = 720;

        public int Height { get; set; } = 450;

        public int X { get; set; } 

        public int Y { get; set; }

        public int RegisteredListForm_Width { get; set; } = 250;

        public int RegisteredListForm_Height { get; set; } = 420;

        public int RegisteredListForm_X { get; set; }

        public int RegisteredListForm_Y { get; set; }

        public int InfomationForm_Height { get; set; } = 350;

        public int InfomationForm_X { get; set; }

        public int InfomationForm_Y { get; set; }

        [XmlIgnore]
        public KeyItem SelectedItem { get; set; }

        [XmlIgnore]
        public BindingList<KeyItem> Keys = new BindingList<KeyItem>();

        [XmlIgnore]
        public string NormalImagePath { get; set; }

        [XmlIgnore]
        public string PressImagePath { get; set; }

        [XmlIgnore]
        public Bitmap NormalImage { get; set; }

        [XmlIgnore]
        public Bitmap PressImage { get; set; }

        [XmlIgnore]
        public int Select_X { get; set; }

        [XmlIgnore]
        public int Select_Y { get; set; }

        [XmlIgnore]
        public int Select_Width { get; set; }

        [XmlIgnore]
        public int Select_Height { get; set; }

        public event EventHandler SettingChanged;
        public event EventHandler SelectedItemChanged;
        public event EventHandler SelectedBorderChanged;

        public void OnSettingChanged() =>
            SettingChanged?.Invoke(this, EventArgs.Empty);
        public void OnSelectedItemChanged() =>
            SelectedItemChanged?.Invoke(this, EventArgs.Empty);
        public void OnSelectedBorderChanged() =>
            SelectedBorderChanged?.Invoke(this, EventArgs.Empty);
    }
}
