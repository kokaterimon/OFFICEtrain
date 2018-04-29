
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

            int WidthScreen = screen.Bounds.Width;
            int HeightScreen = screen.Bounds.Height;

            //Creamos un objeto que trabaje con la dll
            //object ObjMiss = System.Reflection.Missing.Value;
            Excel.Application ObjExcel = new Excel.Application();
            string ruta = Application.StartupPath + @"\Documentos\Excel\pregunta1\Pregunta1Ejercicio.xlsx";
            ObjExcel.Visible = true;

            //La razón entre la resolución del office y la pantalla es: 811/1080=office/screen
            int newHeightScreen = HeightScreen - HeightScreen * 200/1080;

            ObjExcel.Workbooks.Open(ruta);
            ObjExcel.ActiveWindow.Height = 811*newHeightScreen/1080;
            ObjExcel.ActiveWindow.Width = WidthScreen;
            ObjExcel.ActiveWindow.Left = 0;
            ObjExcel.ActiveWindow.Top = 0;
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            //Application.Exit();
        }
    }
}
