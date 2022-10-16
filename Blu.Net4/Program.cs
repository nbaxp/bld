using Blu.Net4.Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace Blu.Net4
{
    internal static class Program
    {
        public static Font Font { get; private set; }

        [STAThread]
        private static void Main()
        {
            using (var db = new SqliteDbContext())
            {
                db.Settings.Add(new Data.Entities.Setting());
                db.SaveChanges();
            }
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(Path.Combine(Directory.GetCurrentDirectory(), "MSYH.TTC"));
            Font = new Font(pfc.Families[0], 12);
            //
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        public static void SetFont(Control control)
        {
            control.Font = Program.Font;
            foreach (Control item in control.Controls)
            {
                SetFont(item);
            }
        }

        public static void SetLanguage(ComponentResourceManager manager, ControlCollection controls)
        {
            foreach (Control item in controls)
            {
                manager.ApplyResources(item, item.Name);
                SetLanguage(manager, item.Controls);
                if (item is MenuStrip menuStrip)
                {
                    foreach (ToolStripItem menuItem in menuStrip.Items)
                    {
                        manager.ApplyResources(menuItem, menuItem.Name);
                        if (menuItem is ToolStripDropDownItem dropDownMenuItem)
                        {
                            foreach (ToolStripItem dropDownItem in dropDownMenuItem.DropDownItems)
                            {
                                manager.ApplyResources(dropDownItem, dropDownItem.Name);
                            }
                        }
                    }
                }
                else if (item is StatusStrip statusStrip)
                {
                    foreach (ToolStripItem menuItem in statusStrip.Items)
                    {
                        manager.ApplyResources(menuItem, menuItem.Name);
                        if (menuItem is ToolStripDropDownItem dropDownMenuItem)
                        {
                            foreach (ToolStripItem dropDownItem in dropDownMenuItem.DropDownItems)
                            {
                                manager.ApplyResources(dropDownItem, dropDownItem.Name);
                            }
                        }
                    }
                }
            }
        }
    }
}