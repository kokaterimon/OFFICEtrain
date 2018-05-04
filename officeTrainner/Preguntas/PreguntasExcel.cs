//using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Datos;


namespace Preguntas
{

    public class PreguntasExcel
    {
        /****Excel guardado temporal****/
        Excel.Application ObjExcelAlumno;
        Excel.Worksheet wsheetAlumno;
        Excel.Workbook wbookAlumno;
        /****Excel ejercicio resuelto****/
        Excel.Application ObjExcelResuelto;
        Excel.Worksheet wsheetResuelto;
        Excel.Workbook wbookResuelto;
        int idExamen;
        /***** *********/
        string p1 = "NO EXISTE";
        string p2 = "NO EXISTE";
        string p3 = "NO EXISTE";
        string p4 = "NO EXISTE";
        string p5 = "NO EXISTE";

        public void Pregunta(int numeroDePregunta, int examenIdExamen)
        {
            idExamen = examenIdExamen;
            AbrirExcels(numeroDePregunta);

            switch (numeroDePregunta)
                {
                case 1: Pregunta1(); break;
                case 2: Pregunta2(); break;
                case 3: Pregunta3(); break;
                case 4: Pregunta4(); break;
                case 5: Pregunta5(); break;
                case 6: Pregunta6(); break;
                case 7: Pregunta7(); break;
                case 8: Pregunta8(); break;
                case 9: Pregunta9(); break;
                case 10: Pregunta10(); break;
                case 11: Pregunta11(); break;
                case 12: Pregunta12(); break;
                case 13: Pregunta13(); break;
                case 14: Pregunta14(); break;
                case 15: Pregunta15(); break;
                case 16: Pregunta16(); break;
                case 17: Pregunta17(); break;
                case 18: Pregunta18(); break;
                case 19: Pregunta19(); break;
                case 20: Pregunta20(); break;
                case 21: Pregunta21(); break;
                case 22: Pregunta22(); break;
                case 23: Pregunta23(); break;
                case 24: Pregunta24(); break;
                case 25: Pregunta25(); break;
                case 26: Pregunta26(); break;
                case 27: Pregunta27(); break;
                case 28: Pregunta28(); break;
                case 29: Pregunta29(); break;
                case 30: Pregunta30(); break;
                case 31: Pregunta31(); break;
                case 32: Pregunta32(); break;
                case 33: Pregunta33(); break;
                case 34: Pregunta34(); break;
                case 35: Pregunta35(); break;
                case 36: Pregunta36(); break;
                case 37: Pregunta37(); break;
                case 38: Pregunta38(); break;
                case 39: Pregunta39(); break;
                case 40: Pregunta40(); break;
                case 41: Pregunta41(); break;
                case 42: Pregunta42(); break;
                case 43: Pregunta43(); break;
                case 44: Pregunta44(); break;
                case 45: Pregunta45(); break;
                case 46: Pregunta46(); break;
                case 47: Pregunta47(); break;
                case 48: Pregunta48(); break;
                case 49: Pregunta49(); break;
                case 50: Pregunta50(); break;



            }
                 
        }

        private void AbrirExcels(int numeroDePregunta)
        {
            ObjExcelAlumno = new Excel.Application()
            {
                Visible = false
            };
            string ruta = Application.StartupPath + @"\Documentos\Temp\Ejercicio.xlsx";
            wbookAlumno = ObjExcelAlumno.Workbooks.Open(ruta);
            wsheetAlumno = (Excel.Worksheet)wbookAlumno.ActiveSheet;

            ObjExcelResuelto = new Excel.Application()
            {
                Visible = false
            };
            string rutaResuelto = Application.StartupPath + @"\Documentos\Excel\Pregunta "+ numeroDePregunta+@"\Pregunta "+ numeroDePregunta+@" Resuelta.xlsx";
            wbookResuelto = ObjExcelResuelto.Workbooks.Open(rutaResuelto);
            wsheetResuelto = (Excel.Worksheet)wbookResuelto.ActiveSheet;
        }

        private void CerrarExcels()
        {
            wbookAlumno.Close();
            wbookResuelto.Close();
            ObjExcelAlumno.Quit();
            ObjExcelResuelto.Quit();
        }

        private void Pregunta1()
        {
            //string p1 = "NO EXISTE";
            //string p2 = "NO EXISTE";

            //ObjExcelAlumno = new Excel.Application()
            //{
            //    Visible = false
            //};
            //string ruta =  Application.StartupPath + @"\Documentos\Temp\Ejercicio.xlsx";
            //wbookAlumno = ObjExcelAlumno.Workbooks.Open(ruta);
            //wsheetAlumno = (Excel.Worksheet)wbookAlumno.ActiveSheet;

            //ObjExcelResuelto = new Excel.Application()
            //{
            //    Visible = false
            //};
            //string rutaResuelto = Application.StartupPath + @"\Documentos\Excel\Pregunta 1\Pregunta 1 Resuelta.xlsx";
            //wbookResuelto = ObjExcelResuelto.Workbooks.Open(rutaResuelto);
            //wsheetResuelto = (Excel.Worksheet)wbookResuelto.ActiveSheet;

            //AbrirExcels();

            if (wsheetAlumno.ListObjects.Count == 0)
            {
                p1 = "INCORRECTO";
                p2 = "INCORRECTO";
            }
            else
            {
                Excel.TableStyle tableStyleALumno = wsheetAlumno.ListObjects.get_Item("Tabla1").TableStyle;
                Excel.TableStyle tableStyleResuelto = wsheetResuelto.ListObjects.get_Item("Tabla2").TableStyle;

                Excel.Range rangeAlumno = wsheetAlumno.ListObjects.get_Item("Tabla1").Range;
                Excel.Range rangeResuelto = wsheetResuelto.ListObjects.get_Item("Tabla2").Range;

                if (tableStyleALumno.Name == tableStyleResuelto.Name && rangeAlumno.Column == rangeResuelto.Column && rangeAlumno.Row == rangeResuelto.Row && rangeAlumno.Count == rangeResuelto.Count)
                {
                    p1 = "CORRECTO";
                }
                else
                {
                    p1 = "INCORRECTO";
                }


                if (wsheetAlumno.ListObjects.get_Item("Tabla1").ShowTableStyleRowStripes == false)
                {
                    p2 = "CORRECTO";
                }
                else
                {
                    p2 = "INCORRECTO";
                }
            }
            


            PuntajePregunta puntajePregunta = new PuntajePregunta
            {                
                sp1 = p1,
                sp2 = p2,
                sp3 = "NO EXISTE",
                sp4 = "NO EXISTE",
                sp5 = "NO EXISTE",
                ExamenIdExamen = idExamen
            };

            using (ModelContainer conexion = new ModelContainer())
            {
                conexion.PuntajePreguntas.Add(puntajePregunta);
                conexion.SaveChanges();
            }
            //wbookAlumno.Close();
            //wbookResuelto.Close();
            //ObjExcelAlumno.Quit();
            //ObjExcelResuelto.Quit();
            CerrarExcels();

            //var range = wsheet.get_Range("A1:J325");
            //wsheet.ListObjects.AddEx(Excel.XlListObjectSourceType.xlSrcRange, range, Type.Missing, Microsoft.Office.Interop.Excel.XlYesNoGuess.xlYes, Type.Missing).Name = "MyTableStyle";

            //string nombreObjectList;
            //nombreObjectList = wsheet.ListObjects[1].Name; // Tabla1


            // wsheet.ListObjects.get_Item("MyTableStyle").TableStyle = "TableStyleMedium16";
            // wsheet.ListObjects.get_Item("MyTableStyle").ShowTableStyleRowStripes = false;
            // wsheet.ListObjects.get_Item("MyTableStyle").ShowTableStyleFirstColumn = true;
            //wbook.Save();
            // wbook.Close();
        }

        private void Pregunta2()
        {
            ////Microsoft.Office.Interop.Excel.Worksheet sheet = workbook.Sheets[1];

            int maxCol = 13; // set maximum number of rows/columns to search
            int maxRow = 325;
            bool banderaSalirDelFor = false;
            string p1 = "NO EXISTE";


            //this is pretty slow, since it has to interact with 10,000 cells in Excel
            // just one example of how to access and set cell values       
            for (int col = 1; col <= maxCol; col++)
            {
                
                for (int row = 1; row <= maxRow; row++)
                {
                    if((wsheetAlumno.Cells[row, col] as Excel.Range).Value != (wsheetResuelto.Cells[row, col] as Excel.Range).Value)
                    {                       
                        banderaSalirDelFor = true;
                        p1 = "INCORRECTO";
                        break ;
                    }
                }
                if (banderaSalirDelFor)
                    break;
            }
            if(!banderaSalirDelFor)
            {               
                p1 = "CORRECTO";
            }

            PuntajePregunta puntajePregunta = new PuntajePregunta
            {
                sp1 = p1,
                sp2 = "NO EXISTE",
                sp3 = "NO EXISTE",
                sp4 = "NO EXISTE",
                sp5 = "NO EXISTE",
                ExamenIdExamen = idExamen
            };

            using (ModelContainer conexion = new ModelContainer())
            {
                conexion.PuntajePreguntas.Add(puntajePregunta);
                conexion.SaveChanges();
            }
            //wbookAlumno.Close();
            //wbookResuelto.Close();
            //ObjExcelAlumno.Quit();
            //ObjExcelResuelto.Quit();
            CerrarExcels();
        }
   
        private void Pregunta3()
        {
            var borrar = (wsheetAlumno.Cells[2, 13] as Excel.Range).Formula;
            if ((wsheetAlumno.Cells[2, 13] as Excel.Range).Formula != (wsheetResuelto.Cells[2, 13] as Excel.Range).Formula)
            {
                p1 = "INCORRECTO";
            }
            else
            {
                p1 = "CORRECTO";
            }

            PuntajePregunta puntajePregunta = new PuntajePregunta
            {
                sp1 = p1,
                sp2 = "NO EXISTE",
                sp3 = "NO EXISTE",
                sp4 = "NO EXISTE",
                sp5 = "NO EXISTE",
                ExamenIdExamen = idExamen
            };

            using (ModelContainer conexion = new ModelContainer())
            {
                conexion.PuntajePreguntas.Add(puntajePregunta);
                conexion.SaveChanges();
            }
            CerrarExcels();
        }
        private void Pregunta4()
        {
        }
        private void Pregunta5()
        {
        }
        private void Pregunta6()
        {
        }
        private void Pregunta7()
        {
        }
        private void Pregunta8()
        {
        }
        private void Pregunta9()
        {
        }
        private void Pregunta10()
        {
        }
        private void Pregunta11()
        {
        }
        private void Pregunta12()
        {
        }
        private void Pregunta13()
        {
        }
        private void Pregunta14()
        {
        }
        private void Pregunta15()
        {
        }
        private void Pregunta16()
        {
        }
        private void Pregunta17()
        {
        }
        private void Pregunta18()
        {
        }
        private void Pregunta19()
        {
        }

        private void Pregunta20()
        {
        }
        private void Pregunta21()
        {
        }
        private void Pregunta22()
        {
        }
        private void Pregunta23()
        {
        }
        private void Pregunta24()
        {
        }
        private void Pregunta25()
        {
        }
        private void Pregunta26()
        {
        }
        private void Pregunta27()
        {
        }
        private void Pregunta28()
        {
        }
        private void Pregunta29()
        {
        }
        private void Pregunta30()
        {
        }
        private void Pregunta31()
        {
        }
        private void Pregunta32()
        {
        }
        private void Pregunta33()
        {
        }
        private void Pregunta34()
        {
        }
        private void Pregunta35()
        {
        }
        private void Pregunta36()
        {
        }
        private void Pregunta37()
        {
        }
        private void Pregunta38()
        {
        }
        private void Pregunta39()
        {
        }
        private void Pregunta40()
        {
        }
        private void Pregunta41()
        {
        }
        private void Pregunta42()
        {
        }
        private void Pregunta43()
        {
        }
        private void Pregunta44()
        {
        }
        private void Pregunta45()
        {
        }
        private void Pregunta46()
        {
        }
        private void Pregunta47()
        {
        }
        private void Pregunta48()
        {
        }
        private void Pregunta49()
        {
        }
        private void Pregunta50()
        {
        }
    }
}


