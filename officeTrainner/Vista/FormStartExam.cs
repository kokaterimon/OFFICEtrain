﻿namespace Vista
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Datos;

    public partial class FormStartExam : Form
    {
        #region Atributes
        public static int NUMERO_DE_PREGUNTAS = 35;
        string ExamenSeleccionado;
        //****************************************************
        public static bool Random;
        public static bool Cronometro;
        public static bool Guardar;
        //****************************************************
        public static int[] ArrayOrdenDePreguntas;
        //int[] arrayDeAleatorios = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        #endregion

        public FormStartExam()
        {
            InitializeComponent();
        }

        #region Events
        private void BtnComenzarExamen_Click(object sender, EventArgs e)
        {
            GuardarParametros();
            ArrayOrdenDePreguntas = ObteneOrdenDePreguntas(Random);

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
            ExamenSeleccionado = "Power Point";
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            ExamenSeleccionado = "Excel";
        }
        #endregion

        #region Methods
        private void GuardarParametros()
        {
            Random = ChbOrdenPregAle.Checked;
            Cronometro = ChbCronometro.Checked;
            Guardar = ChbGuardarResultados.Checked;
        }

        private int[] ObteneOrdenDePreguntas(bool aleatorio) //true = aleatorio; false = no aleatorio
        {
            int[] arrayDeAleatorios = new int[] {0, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0};
            if (!aleatorio)
            {
                arrayDeAleatorios = new int[] {1, 2,  3,  4,  5,  6,  7,  8,  9,  10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50};
            }
            else
            { 
                //Pondremos 5 patrones de números aleatorios hasta el 50. Para preguntas adicionales aumentar los números
                Random r = new Random();
                int rInt = 5;
                switch (rInt)
                {
                    case 1:
                        arrayDeAleatorios = new int[] { 2, 33, 24, 34, 43, 25, 41, 30, 18, 28, 7, 27, 47, 31, 6, 8, 45, 40, 42, 49, 46, 36, 19, 22, 3, 4, 50, 17, 44, 11, 20, 29, 26, 35, 39, 32, 21, 5, 10, 16, 13, 37, 14, 12, 38, 1, 23, 9, 48, 15 };
                        break;
                    case 2:
                        arrayDeAleatorios = new int[] { 15, 20, 33, 45, 11, 26, 17, 6, 9, 37, 27, 25, 8, 4, 47, 36, 14, 39, 42, 22, 49, 24, 29, 7, 5, 34, 31, 28, 38, 3, 41, 2, 21, 35, 13, 23, 40, 19, 50, 18, 10, 1, 12, 32, 46, 44, 43, 16, 48, 30 };
                        break;
                    case 3:
                        arrayDeAleatorios = new int[] { 36, 31, 20, 29, 19, 18, 22, 9, 14, 24, 25, 5, 15, 23, 41, 12, 8, 4, 32, 6, 47, 26, 1, 43, 10, 38, 28, 50, 40, 11, 7, 35, 3, 48, 30, 46, 27, 33, 45, 21, 13, 49, 44, 42, 17, 2, 16, 39, 37, 34 };
                        break;
                    case 4:
                        arrayDeAleatorios = new int[] { 5, 14, 41, 17, 13, 4, 15, 28, 25, 29, 40, 37, 48, 12, 9, 10, 22, 42, 47, 19, 31, 34, 18, 43, 2, 35, 33, 16, 30, 46, 20, 8, 23, 39, 36, 27, 21, 32, 44, 1, 6, 7, 49, 3, 38, 11, 50, 26, 24, 45 };
                        break;
                    case 5:
                        arrayDeAleatorios = new int[] { 19, 41, 15, 33, 8, 7, 21, 5, 14, 49, 17, 31, 46, 20, 22, 27, 40, 11, 39, 37, 38, 48, 36, 25, 18, 3, 6, 32, 42, 28, 26, 34, 29, 9, 30, 24, 43, 12, 10, 1, 4, 44, 45, 47, 13, 2, 35, 23, 50, 16 };
                        break;
                }
            }
            return arrayDeAleatorios;

        }

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
