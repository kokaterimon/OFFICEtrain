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

            //BR: el monitor actual es de 1080 X 1920
            int WidthScreen = screen.Bounds.Width;
            int HeightScreen = screen.Bounds.Height;

            FormQuestionsPanel formQuestionsPanel = new FormQuestionsPanel();

            formQuestionsPanel.StartPosition = FormStartPosition.Manual;
            formQuestionsPanel.Left = 0;
            //formQuestionsPanel.Top = Height - 180; //BR: No tomaremos una medida fija, sino que será proporcional a la resolución de ptantalla
            formQuestionsPanel.Top = HeightScreen - HeightScreen * 180/1080;
            formQuestionsPanel.Width = WidthScreen;
            formQuestionsPanel.Height = HeightScreen * 180 / 1080;
            formQuestionsPanel.ShowDialog();

            
        }
    }
}
