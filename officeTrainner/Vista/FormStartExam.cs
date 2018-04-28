using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class FormStartExam : Form
    {
        public FormStartExam()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Screen screen = Screen.PrimaryScreen;

            int Width = screen.Bounds.Width;
            int Height = screen.Bounds.Height;
            //MessageBox.Show(Convert.ToString(Height));
            FormQuestionsPanel form1 = new FormQuestionsPanel();

            form1.StartPosition = FormStartPosition.Manual;
            form1.Left = 0;
            form1.Top = Height - 180;
            form1.ShowDialog();
        }
    }
}
