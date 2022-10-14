using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Blu.Net4
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            // 多语言
            var _resourceMnager = new ComponentResourceManager(this.GetType());
            this.Text = _resourceMnager.GetString("$this.Text");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}