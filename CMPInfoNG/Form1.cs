using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Reflection;
using System.Collections.Specialized;

namespace CMPInfoNG
{
    public partial class CMPInfoNG : Form
    {
        public CMPInfoNG()
        {
            InitializeComponent();
            SetPosition();
            Starter();
        }


        private void Starter()
        {
            NameValueCollection sAll;
            sAll = ConfigurationManager.AppSettings;

            TableLayoutPanel panel = new TableLayoutPanel();
            panel.ColumnCount = 1;
            panel.RowCount = sAll.Count;
            panel.Dock = DockStyle.Top;
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            this.Controls.Add(panel);


            Type testType = typeof(Methods);


            foreach (string s in sAll.AllKeys)
            {


                MethodInfo toInvoke = testType.GetMethod(sAll.Get(s), BindingFlags.Static | BindingFlags.NonPublic);
                object obj = toInvoke.Invoke(null, null);

                panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / panel.RowCount));


                panel.Controls.Add(new Label() { Text = s + " : " + obj, AutoSize = true, Font = new Font("Arial", 10, FontStyle.Bold) });





            }

        }

            private void SetPosition()
        {
            this.StartPosition = FormStartPosition.Manual;
            foreach (var scrn in Screen.AllScreens)
            {
                if (scrn.Bounds.Contains(this.Location))
                {
                    this.Location = new Point(scrn.Bounds.Right - this.Width, scrn.Bounds.Top);
                    return;
                }
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

   


 }

