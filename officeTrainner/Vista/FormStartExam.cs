namespace Vista
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Datos;   

    public partial class FormStartExam : Form
    {
        #region Atributes
        public const int NUMERO_DE_PREGUNTAS = 35;
        string ExamenSeleccionado; 
        #endregion

        public FormStartExam()
        {
            InitializeComponent();
        }

        #region Events
        private void BtnComenzarExamen_Click(object sender, EventArgs e)
        {
            Screen screen = Screen.PrimaryScreen;

            //BR: el monitor actual es de 1080 X 1920
            int WidthScreen = screen.Bounds.Width;
            int HeightScreen = screen.Bounds.Height;

            FormQuestionsPanel formQuestionsPanel = new FormQuestionsPanel
            {
                StartPosition = FormStartPosition.Manual,
                Left = 0,
                //formQuestionsPanel.Top = Height - 180; //BR: No tomaremos una medida fija, sino que será proporcional a la resolución de ptantalla
                Top = HeightScreen - HeightScreen * 200 / 1080,
                Width = WidthScreen,
                Height = HeightScreen * 200 / 1080
            };
            //Llenamos los respectivos campos de la base de datos antes de abrir la siguiente ventana
            if (CampoValidos())
            {
                Alumno alumno = new Alumno
                {
                    Nombres = TxtFirstName.Text,
                    Apellidos = TxtLastName.Text
                };
                using (ModelContainer conexion = new ModelContainer())
                {
                    conexion.Alumnos.Add(alumno);
                    conexion.SaveChanges();
                }

                DateTime today = DateTime.Today;
                Examen examen = new Examen
                {
                    //NombreExamen = ExamenSeleccionado,
                    NombreExamen = "Word",
                    fecha = today,
                    Avance = 0,
                    AlumnoIdAlumno = ObtenerUltimoIdAlumno(),
                    NumeroDePreguntas = ObtenerNumeroDePreguntas()
                };
                using (ModelContainer conexion = new ModelContainer())
                {
                    conexion.Examenes.Add(examen);
                    conexion.SaveChanges();
                }

                DetalleExamen detalleExamen = new DetalleExamen
                {
                    //los tres estados de esta tabla son: CORRECTO, INCORRECTO, NO RESUELTO (indica que el alumno todavía no llegó a esta pregunta)
                    //Inicializaremos las 35 preguntas
                    Pregunta1 = "NO RESUELTO",
                    Pregunta2 = "NO RESUELTO",
                    Pregunta3 = "NO RESUELTO",
                    Pregunta4 = "NO RESUELTO",
                    Pregunta5 = "NO RESUELTO",
                    Pregunta6 = "NO RESUELTO",
                    Pregunta7 = "NO RESUELTO",
                    Pregunta8 = "NO RESUELTO",
                    Pregunta9 = "NO RESUELTO",
                    Pregunta10 = "NO RESUELTO",
                    Pregunta11 = "NO RESUELTO",
                    Pregunta12 = "NO RESUELTO",
                    Pregunta13 = "NO RESUELTO",
                    Pregunta14 = "NO RESUELTO",
                    Pregunta15 = "NO RESUELTO",
                    Pregunta16 = "NO RESUELTO",
                    Pregunta17 = "NO RESUELTO",
                    Pregunta18 = "NO RESUELTO",
                    Pregunta19 = "NO RESUELTO",
                    Pregunta20 = "NO RESUELTO",
                    Pregunta21 = "NO RESUELTO",
                    Pregunta22 = "NO RESUELTO",
                    Pregunta23 = "NO RESUELTO",
                    Pregunta24 = "NO RESUELTO",
                    Pregunta25 = "NO RESUELTO",
                    Pregunta26 = "NO RESUELTO",
                    Pregunta27 = "NO RESUELTO",
                    Pregunta28 = "NO RESUELTO",
                    Pregunta29 = "NO RESUELTO",
                    Pregunta30 = "NO RESUELTO",
                    Pregunta31 = "NO RESUELTO",
                    Pregunta32 = "NO RESUELTO",
                    Pregunta33 = "NO RESUELTO",
                    Pregunta34 = "NO RESUELTO",
                    Pregunta35 = "NO RESUELTO",
                    ExamenIdExamen = ObtenerUltimoIdExamen()
                };

                using (ModelContainer conexion = new ModelContainer())
                {
                    conexion.DetalleExamenes.Add(detalleExamen);
                    conexion.SaveChanges();
                }

            }
            formQuestionsPanel.Show();
        }

        private void BtnWord_Click(object sender, EventArgs e)
        {
            ExamenSeleccionado = "Word";
        }

        private void BtnPowerPoint_Click(object sender, EventArgs e)
        {
            ExamenSeleccionado = "Powe Point";
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            ExamenSeleccionado = "Excel";
        } 
        #endregion

        #region Methods
        private int ObtenerNumeroDePreguntas()
        {
            var num = NUMERO_DE_PREGUNTAS;
            return num;
        }
        private bool CampoValidos()
        {
            if (string.IsNullOrEmpty(this.TxtFirstName.Text))
            {
                MessageBox.Show("Ingrese su Nombre");
                return false;
            }
            if (string.IsNullOrEmpty(this.TxtLastName.Text))
            {
                MessageBox.Show("Ingrese su Apellido");
                return false;
            }
            return true;
        }
        private int ObtenerUltimoIdExamen()
        {
            using (ModelContainer conexion = new ModelContainer())
            {
                int id = conexion.Examenes.Max(u => u.IdExamen);
                return id;
            }
        }

        private int ObtenerUltimoIdAlumno()
        {
            using (ModelContainer conexion = new ModelContainer())
            {
                int id = conexion.Alumnos.Max(u => u.IdAlumno);
                return id;
            }
        }

        private int ObtenerUltimoIdDetalleExamen()
        {
            using (ModelContainer conexion = new ModelContainer())
            {
                int id = conexion.DetalleExamenes.Max(u => u.IdDetalleExamen);
                return id;
            }
        }
        #endregion
    }
}
