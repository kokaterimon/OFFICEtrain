
namespace Vista
{
    using Datos;
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Excel = Microsoft.Office.Interop.Excel;
    using Word = Microsoft.Office.Interop.Word;
    using Preguntas;

    public partial class FormQuestionsPanel : Form
    {
        #region atributes
        Screen screen = Screen.PrimaryScreen;
        int[] arrayOrdenPreguntas;
        int contadorDeAvance;
        Excel.Application ObjExcel;
        //Excel.Worksheet wsheet;
        Excel.Workbook wbook;
        int examenIdExamen;
        #endregion

        public FormQuestionsPanel()
        {
            InitializeComponent();
        }
        #region Events

        private void FormQuestionsPanel_Load(object sender, EventArgs e)
        {
            examenIdExamen = FormMain.idExamenActual;
            CargarArrayOrdenPreguntas();
            //contadorDeAvance=0;
            ObtenerContadorDeAvance();
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
            GuardarAvance();
            ComprobarCorrectoIncorrecto();
            //wbook.Close();
            ObjExcel.Quit();
            MostrarPreguntaYEjercicio();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
           // wbook.Close();
            ObjExcel.Quit();
            int numeroDePregunta = FormStartExam.arrayOrdenDePreguntas[contadorDeAvance-1]; // - 1
            AbrirEjercicioExcel(numeroDePregunta);
        }
        #endregion

        #region Methods
        private void ComprobarCorrectoIncorrecto()
        {
            //Guardar el exel. ObjExcel
            string ruta = Application.StartupPath + @"\Documentos\Temp\Ejercicio.xlsx";

            if (System.IO.File.Exists(ruta))
            {
                System.IO.File.Delete(ruta);
            }
            
            wbook.SaveAs(ruta, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
            false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            wbook.Close();

            //comparar cambio en los archivos ejercicio y respuesta
            int numeroDePregunta = arrayOrdenPreguntas[contadorDeAvance-1];
            PreguntasExcel preguntasExcel = new PreguntasExcel();
            preguntasExcel.Pregunta(numeroDePregunta, examenIdExamen);

            //borrar documentos temporales 

        }
        private void GuardarAvance()
        {
            
            using (ModelContainer conexion = new ModelContainer())
            {
                var examen = conexion.Examenes
                    .Where(p => p.IdExamen == examenIdExamen).
                    FirstOrDefault();
                examen.avance = contadorDeAvance;
                conexion.SaveChanges();
            }
        }
        private void ObtenerContadorDeAvance()
        {
           using (ModelContainer conexion = new ModelContainer())
            {
                var examen = conexion.Examenes
                    .Where(p => p.IdExamen == examenIdExamen).
                    FirstOrDefault();
                contadorDeAvance = examen.avance;
            }

        }
        private void MostrarPreguntaYEjercicio()
        {          
            
            
            //int numeroDePregunta = FormStartExam.arrayOrdenDePreguntas[contadorDeAvance];
            int numeroDePregunta = arrayOrdenPreguntas[contadorDeAvance];

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
                wbook = ObjExcel.Workbooks.Open(ruta);
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
     
        private void CargarArrayOrdenPreguntas()
        {

            arrayOrdenPreguntas = new int[FormMain.NUMERO_DE_PREGUNTAS];

            int idExamen = FormMain.idExamenActual;
            using (ModelContainer conexion = new ModelContainer())
            {
                ArrayOrdenPreguntas arrayOrdenDePreguntasO = new ArrayOrdenPreguntas();

                arrayOrdenDePreguntasO = conexion.ArrayOrdenPreguntas.Where(p => p.ExamenIdExamen == idExamen).FirstOrDefault();

                arrayOrdenPreguntas[0] = arrayOrdenDePreguntasO.p01;
                arrayOrdenPreguntas[1] = arrayOrdenDePreguntasO.p02;
                arrayOrdenPreguntas[2] = arrayOrdenDePreguntasO.p03;
                arrayOrdenPreguntas[3] = arrayOrdenDePreguntasO.p04;
                arrayOrdenPreguntas[4] = arrayOrdenDePreguntasO.p05;
                arrayOrdenPreguntas[5] = arrayOrdenDePreguntasO.p06;
                arrayOrdenPreguntas[6] = arrayOrdenDePreguntasO.p07;
                arrayOrdenPreguntas[7] = arrayOrdenDePreguntasO.p08;
                arrayOrdenPreguntas[8] = arrayOrdenDePreguntasO.p09;
                arrayOrdenPreguntas[9] = arrayOrdenDePreguntasO.p10;
                arrayOrdenPreguntas[10] = arrayOrdenDePreguntasO.p11;
                arrayOrdenPreguntas[11] = arrayOrdenDePreguntasO.p12;
                arrayOrdenPreguntas[12] = arrayOrdenDePreguntasO.p13;
                arrayOrdenPreguntas[13] = arrayOrdenDePreguntasO.p14;
                arrayOrdenPreguntas[14] = arrayOrdenDePreguntasO.p15;
                arrayOrdenPreguntas[15] = arrayOrdenDePreguntasO.p16;
                arrayOrdenPreguntas[16] = arrayOrdenDePreguntasO.p17;
                arrayOrdenPreguntas[17] = arrayOrdenDePreguntasO.p18;
                arrayOrdenPreguntas[18] = arrayOrdenDePreguntasO.p19;
                arrayOrdenPreguntas[19] = arrayOrdenDePreguntasO.p20;
                arrayOrdenPreguntas[20] = arrayOrdenDePreguntasO.p21;
                arrayOrdenPreguntas[21] = arrayOrdenDePreguntasO.p22;
                arrayOrdenPreguntas[22] = arrayOrdenDePreguntasO.p23;
                arrayOrdenPreguntas[23] = arrayOrdenDePreguntasO.p24;
                arrayOrdenPreguntas[24] = arrayOrdenDePreguntasO.p25;
                arrayOrdenPreguntas[25] = arrayOrdenDePreguntasO.p26;
                arrayOrdenPreguntas[26] = arrayOrdenDePreguntasO.p27;
                arrayOrdenPreguntas[27] = arrayOrdenDePreguntasO.p28;
                arrayOrdenPreguntas[28] = arrayOrdenDePreguntasO.p29;
                arrayOrdenPreguntas[29] = arrayOrdenDePreguntasO.p30;
                arrayOrdenPreguntas[30] = arrayOrdenDePreguntasO.p31;
                arrayOrdenPreguntas[31] = arrayOrdenDePreguntasO.p32;
                arrayOrdenPreguntas[32] = arrayOrdenDePreguntasO.p33;
                arrayOrdenPreguntas[33] = arrayOrdenDePreguntasO.p34;
                arrayOrdenPreguntas[34] = arrayOrdenDePreguntasO.p35;
                arrayOrdenPreguntas[35] = arrayOrdenDePreguntasO.p36;
                arrayOrdenPreguntas[36] = arrayOrdenDePreguntasO.p37;
                arrayOrdenPreguntas[37] = arrayOrdenDePreguntasO.p38;
                arrayOrdenPreguntas[38] = arrayOrdenDePreguntasO.p39;
                arrayOrdenPreguntas[39] = arrayOrdenDePreguntasO.p40;
                arrayOrdenPreguntas[40] = arrayOrdenDePreguntasO.p41;
                arrayOrdenPreguntas[41] = arrayOrdenDePreguntasO.p42;
                arrayOrdenPreguntas[42] = arrayOrdenDePreguntasO.p43;
                arrayOrdenPreguntas[43] = arrayOrdenDePreguntasO.p44;
                arrayOrdenPreguntas[44] = arrayOrdenDePreguntasO.p45;
                arrayOrdenPreguntas[45] = arrayOrdenDePreguntasO.p46;
                arrayOrdenPreguntas[46] = arrayOrdenDePreguntasO.p47;
                arrayOrdenPreguntas[47] = arrayOrdenDePreguntasO.p48;
                arrayOrdenPreguntas[48] = arrayOrdenDePreguntasO.p49;
                arrayOrdenPreguntas[49] = arrayOrdenDePreguntasO.p50;

            }
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
