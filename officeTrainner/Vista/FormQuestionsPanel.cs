
namespace Vista
{
    using System;
    using System.Windows.Forms;
    using Excel = Microsoft.Office.Interop.Excel;
    public partial class FormQuestionsPanel : Form
    {
        public FormQuestionsPanel()
        {
            InitializeComponent();
        }

        private void FormQuestionsPanel_Load(object sender, EventArgs e)
        {
            Screen screen = Screen.PrimaryScreen;

            int Width = screen.Bounds.Width;
            int Height = screen.Bounds.Height;

            //Creamos un objeto que trabaje con la dll
            //object ObjMiss = System.Reflection.Missing.Value;
            Excel.Application ObjExcel = new Excel.Application();
            string ruta = Application.StartupPath + @"\Documentos\Excel\pregunta1\Pregunta1Ejercicio.xlsx";
            ObjExcel.Visible = true;
            int newHeight = Height - 180;

            ObjExcel.Workbooks.Open(ruta);
            ObjExcel.ActiveWindow.Height = 500;
            ObjExcel.ActiveWindow.Width = Width;
            ObjExcel.ActiveWindow.Left = 0;
            ObjExcel.ActiveWindow.Top = 0;
        }
    }
}
