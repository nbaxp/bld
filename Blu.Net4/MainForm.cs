using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Blu.Net4
{
    public partial class MainForm : Form
    {
        private List<CultureInfo> _locales = new List<CultureInfo> { new CultureInfo("zh-CN"), new CultureInfo("en") };
        private ComponentResourceManager _resourceMnager = new ComponentResourceManager(typeof(MainForm));

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Program.SetFont(this);
            Init();
        }

        /// <summary>
        /// 窗体初始化
        /// </summary>
        private void Init()
        {
            // 禁用缩放
            this.AutoScaleMode = AutoScaleMode.None;
            // 中英文切换初始化
            this.toolStripComboBox1.Items.AddRange(this._locales.Select(o => o.NativeName).ToArray());
            var configName = Thread.CurrentThread.CurrentUICulture.NativeName;
            this.toolStripComboBox1.SelectedIndex = this._locales.FindIndex(o => o.NativeName == configName);
            // 状态栏布局
            this.toolStripStatusLabel2.Alignment = ToolStripItemAlignment.Right;
        }

        /// <summary>
        /// 状态栏显示系统时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel2.Text = DateTime.Now.ToString("F", Thread.CurrentThread.CurrentCulture);
        }

        #region 帮助

        /// <summary>
        /// 打开关于窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        /// <summary>
        /// 打开帮助窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 帮助文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var file = Thread.CurrentThread.CurrentUICulture.Name == "zh-CN" ? "BLD_Help.pdf" : "BLD_Help_EN.pdf";
            var path = Path.Combine(Directory.GetCurrentDirectory(), file);
            new HelpForm(path).ShowDialog();
        }

        /// <summary>
        /// 退出应用程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion 帮助

        /// <summary>
        /// 中英文切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var nativeName = (sender as ToolStripComboBox).Text;
            var locale = this._locales.FirstOrDefault(o => o.NativeName == nativeName);
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = locale;
            this.Text = _resourceMnager.GetString("$this.Text");
            Program.SetLanguage(this._resourceMnager, this.Controls);
        }

        /// <summary>
        /// 打开泄漏分析窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 泄漏分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new LeakJudgmentForm().Show();
        }
    }
}