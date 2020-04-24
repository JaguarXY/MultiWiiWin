using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultiWiiWinGUI
{
    public partial class set_Shortcut_Key : Form
    {
        static Keys tmp_KD = Keys.None;
        public set_Shortcut_Key(int wp)
        {
            InitializeComponent();
            little_tip.Text = "设置所选投弹点 WP" + wp.ToString() + " 的快捷键";
        }
        private void keyDown(object sender, KeyEventArgs e)
        {
            StringBuilder keyValue = new StringBuilder();
            keyValue.Length = 0;
            keyValue.Append("");
            if (e.Modifiers != 0)
            {
                if (e.Control)
                    keyValue.Append("Ctrl +");
                if (e.Alt)
                    keyValue.Append("Alt + ");
                if (e.Shift)
                    keyValue.Append("Shift + ");
            }
            if ((e.KeyValue >= 33 && e.KeyValue <= 40) ||
              (e.KeyValue >= 65 && e.KeyValue <= 90) ||   //a-z/A-Z
              (e.KeyValue >= 112 && e.KeyValue <= 123))   //F1-F12
            {
                keyValue.Append(e.KeyCode);
            }
            else if ((e.KeyValue >= 48 && e.KeyValue <= 57))  //0-9
            {
                keyValue.Append(e.KeyCode.ToString().Substring(1));
            }
            tmp_KD = e.KeyData;
            this.ActiveControl.Text = "";
            this.ActiveControl.Text = keyValue.ToString();
        }

        private void keyUp(object sender, KeyEventArgs e)
        {
            string str = this.ActiveControl.Text.TrimEnd();
            int len = str.Length;
            if (len >= 1 && str.Substring(str.Length - 1) == "+")
            {
                this.ActiveControl.Text = "";
            }
            this.little_tip.Text = textBox1.Text;
        }
        public Keys KeyData
        {
            set { tmp_KD = value; }
            get { return tmp_KD; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tmp_KD != Keys.None)
                this.Hide();
            else
                textBox1.Text = "出错！请重试";
        }
    }
}
