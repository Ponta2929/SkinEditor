
namespace SkinEditor
{
    partial class RegisteredListForm
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
            this.ListBox_Registered = new System.Windows.Forms.ListBox();
            this.Panel_Edit = new System.Windows.Forms.Panel();
            this.Button_Delete = new System.Windows.Forms.Button();
            this.Panel_Edit.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListBox_Registered
            // 
            this.ListBox_Registered.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBox_Registered.FormattingEnabled = true;
            this.ListBox_Registered.IntegralHeight = false;
            this.ListBox_Registered.ItemHeight = 12;
            this.ListBox_Registered.Location = new System.Drawing.Point(0, 0);
            this.ListBox_Registered.Name = "ListBox_Registered";
            this.ListBox_Registered.Size = new System.Drawing.Size(234, 352);
            this.ListBox_Registered.TabIndex = 0;
            this.ListBox_Registered.SelectedIndexChanged += new System.EventHandler(this.ListBox_Registered_SelectedIndexChanged);
            this.ListBox_Registered.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.ListBox_Registered_Format);
            // 
            // Panel_Edit
            // 
            this.Panel_Edit.Controls.Add(this.Button_Delete);
            this.Panel_Edit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel_Edit.Location = new System.Drawing.Point(0, 352);
            this.Panel_Edit.Name = "Panel_Edit";
            this.Panel_Edit.Size = new System.Drawing.Size(234, 29);
            this.Panel_Edit.TabIndex = 1;
            // 
            // Button_Delete
            // 
            this.Button_Delete.Location = new System.Drawing.Point(3, 3);
            this.Button_Delete.Name = "Button_Delete";
            this.Button_Delete.Size = new System.Drawing.Size(75, 23);
            this.Button_Delete.TabIndex = 1;
            this.Button_Delete.Text = "削除(&D)";
            this.Button_Delete.UseVisualStyleBackColor = true;
            this.Button_Delete.Click += new System.EventHandler(this.Button_Delete_Click);
            // 
            // RegisteredListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 381);
            this.Controls.Add(this.ListBox_Registered);
            this.Controls.Add(this.Panel_Edit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "RegisteredListForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "登録情報";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegisteredListForm_FormClosing);
            this.Panel_Edit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListBox_Registered;
        private System.Windows.Forms.Panel Panel_Edit;
        private System.Windows.Forms.Button Button_Delete;
    }
}