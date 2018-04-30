namespace Vista
{
    using System;
    using System.Windows.Forms;
    using Datos;

    public partial class FormStartExam : Form
    {
        public FormStartExam()
        {
            InitializeComponent();
        }

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
                    MessageBox.Show("Estudiante registrado");
                }
            }


            formQuestionsPanel.ShowDialog();

            
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
    }
}
