using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace Blu.Net4
{
    public partial class LeakJudgmentForm : Form
    {
        private ComponentResourceManager _resourceMnager;

        public LeakJudgmentForm()
        {
            InitializeComponent();
        }

        private void LeakJudgmentForm_Load(object sender, EventArgs e)
        {
            // 居中显示
            this.Left = (Screen.PrimaryScreen.WorkingArea.Size.Width - this.Width) / 2;
            this.Top = (Screen.PrimaryScreen.WorkingArea.Size.Height - this.Height) / 2;
            // 多语言
            this._resourceMnager = new ComponentResourceManager(this.GetType());
            this.Text = _resourceMnager.GetString("$this.Text");
            // 除第一个选择框外都禁用
            foreach (var item in this.panel1.Controls)
            {
                if (item is CheckBox checkBox)
                {
                    if (checkBox.Tag.ToString() != "1")
                    {
                        checkBox.Enabled = false;
                    }
                }
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                // 如果当前选择框被选中，则找到下一个选择框并启用
                var tag = int.Parse((sender as CheckBox).Tag.ToString()) + 1;
                foreach (var item in this.panel1.Controls)
                {
                    if (item is CheckBox checkBox)
                    {
                        if (checkBox.Tag.ToString() == tag.ToString() && !checkBox.Enabled)
                        {
                            checkBox.Enabled = true;
                        }
                    }
                }
                // 如果是最后一个选择框，弹出确认信息并关闭当前窗体
                if ((sender as CheckBox).Tag.ToString() == "8")
                {
                    MessageBox.Show(_resourceMnager.GetString("LeakMessage"));
                    this.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}