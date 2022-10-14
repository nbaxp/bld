using PdfiumViewer;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Blu.Net4
{
    public partial class HelpForm : Form
    {
        private string _path;

        public HelpForm(string path)
        {
            InitializeComponent();
            _path = path;
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {
            // 多语言
            var _resourceMnager = new ComponentResourceManager(this.GetType());
            this.Text = _resourceMnager.GetString("$this.Text");
            // 加载 pdf
            this.pdfViewer1.Document = PdfDocument.Load(this._path);
        }

        private void pdfViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}