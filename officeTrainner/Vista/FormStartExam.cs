namespace Vista
{
    using System;
    using System.Windows.Forms;

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
            
            FormQuestionsPanel formQuestionsPanel = new FormQuestionsPanel();

            formQuestionsPanel.StartPosition = FormStartPosition.Manual;
            formQuestionsPanel.Left = 0;
            formQuestionsPanel.Top = Height - 180;
            formQuestionsPanel.Width = Width;
            formQuestionsPanel.ShowDialog();

            
        }
    }
}
