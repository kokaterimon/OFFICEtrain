
namespace Vista
{
    using Datos;
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Excel = Microsoft.Office.Interop.Excel;
    using Word = Microsoft.Office.Interop.Word;

    public partial class FormQuestionsPanel : Form
    {
        #region atributes
        Screen screen = Screen.PrimaryScreen;
        int contadorDeAvance;
        Excel.Application ObjExcel;
        #endregion

        public FormQuestionsPanel()
        {
            InitializeComponent();
        }
        #region Events

        private void FormQuestionsPanel_Load(object sender, EventArgs e)
        {
            contadorDeAvance=0;
            MostrarPreguntaYEjercicio();

        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            //Application.Exit();
        }

        private void BtNext_Click(object sender, EventArgs e)
        {
            
            //FormStartExam.NUMERO_DE_PREGUNTAS;
           int examenIdExamen = ObtenerUltimoIdExamen();
            using (ModelContainer conexion = new ModelContainer())
            {
               
                var examen = conexion.Examenes
                    .Where(p => p.IdExamen == examenIdExamen).
                    FirstOrDefault();
                if (examen == null)
                {
                    MessageBox.Show("No es posible actualizar un examen no registrado");
                }
                else
                {
                    examen.avance = contadorDeAvance;
                    conexion.SaveChanges();                    
                }
            }
            
            ObjExcel.Quit();

            MostrarPreguntaYEjercicio();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            ObjExcel.Quit();
            int numeroDePregunta = FormStartExam.arrayOrdenDePreguntas[contadorDeAvance-1]; // - 1
            AbrirEjercicioExcel(numeroDePregunta);
        }
        #endregion

        #region Methods
        private int ObtenerUltimoIdExamen()
        {
            using (ModelContainer conexion = new ModelContainer())
            {
                int id = conexion.Examenes.Max(u => u.IdExamen);
                return id;
            }
        }
        private void MostrarPreguntaYEjercicio()
        {
            int numeroDePregunta = FormStartExam.arrayOrdenDePreguntas[contadorDeAvance];
            if (!AbrirEjercicioExcel(numeroDePregunta))
            {
                contadorDeAvance++;
                MostrarPreguntaYEjercicio();                
            }
            else
            {
                MostrarPregunta(numeroDePregunta);
                contadorDeAvance++;
            }
           
        }

        private bool AbrirEjercicioExcel(int numeroDePregunta)
        {
            int WidthScreen = screen.Bounds.Width;
            int HeightScreen = screen.Bounds.Height;
            int newHeightScreen = HeightScreen - HeightScreen * 200 / 1080;            
            ObjExcel = new Excel.Application();
            string ruta = Application.StartupPath + @"\Documentos\Excel\pregunta "+ numeroDePregunta + @"\Pregunta "+ numeroDePregunta + @" Ejercicio.xlsx";
            if (System.IO.File.Exists(ruta))
            {
                ObjExcel.Visible = true;
                ObjExcel.Workbooks.Open(ruta);
                ObjExcel.ActiveWindow.Height = 811 * newHeightScreen / 1080;
                ObjExcel.ActiveWindow.Width = WidthScreen;
                ObjExcel.ActiveWindow.Left = 0;
                ObjExcel.ActiveWindow.Top = 0;
            }
            else
            {
                return false;
            }
            return true;
        }

        private void MostrarPregunta(int numeroDePregunta)
        {            
            //object ObjMiss = System.Reflection.Missing.Value;
            Word.Application ObjWord = new Word.Application();
            //Document doc = new Document();

            //object fileName = path;
            string ruta = Application.StartupPath + @"\Documentos\Excel\pregunta " + numeroDePregunta + @"\Pregunta " + numeroDePregunta + @".docx";
            object fileName = ruta;
            // Define an object to pass to the API for missing parameters
            object missing = System.Type.Missing;
            Word.Document ObjDoc = ObjWord.Documents.Open(ref fileName,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing);

            String read = string.Empty;           
            foreach (Word.Range tmpRange in ObjDoc.StoryRanges)
            {
                TxtQuestion.Text = tmpRange.Text;
            }
            ObjDoc.Close();
            ObjWord.Quit();            
        }
        #endregion

    }
}
