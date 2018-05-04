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
        Excel.Application ObjExcel;
        Excel.Worksheet wsheet;
        Excel.Workbook wbook;
        /****Excel ejercicio resuelto****/
        Excel.Application ObjExcelResuelto;
        Excel.Worksheet wsheetResuelto;
        Excel.Workbook wbookResuelto;

        public void Pregunta01(int examenIdExamen)
        {
            string p1 = "NO EXISTE";
            string p2 = "NO EXISTE";

            ObjExcel = new Excel.Application()
            {
                Visible = false
            };
            string ruta =  Application.StartupPath + @"\Documentos\Temp\Ejercicio.xlsx";
            wbook = ObjExcel.Workbooks.Open(ruta);
            wsheet = (Excel.Worksheet)wbook.ActiveSheet;

            ObjExcelResuelto = new Excel.Application()
            {
                Visible = false
            };
            string rutaResuelto = Application.StartupPath + @"\Documentos\Excel\Pregunta 1\Pregunta 1 Resuelta.xlsx";
            wbookResuelto = ObjExcelResuelto.Workbooks.Open(rutaResuelto);
            wsheetResuelto = (Excel.Worksheet)wbookResuelto.ActiveSheet;


            // string temp1 = wsheet.ListObjects.get_Item("Tabla1").TableStyle;
            //var temp2 = wsheetResuelto.ListObjects.get_Item("Tabla2").TableStyle;

            //wsheet.ListObjects.get_Item("MyTableStyletest").TableStyle ="TableStyleMedium16";

            Excel.TableStyle temp1 = wsheet.ListObjects.get_Item("Tabla1").TableStyle;
            Excel.TableStyle temp2 = wsheetResuelto.ListObjects.get_Item("Tabla2").TableStyle;


            //if (wsheet.ListObjects.get_Item("Tabla1").TableStyle == wsheetResuelto.ListObjects.get_Item("Tabla2").TableStyle)

            if (temp1.Name == temp2.Name)
              {
                  p1 = "CORRECTO";
              }
              else
              {
                  p1 = "INCORRECTO";
              }

              if (wsheet.ListObjects.get_Item("Tabla1").ShowTableStyleRowStripes == false)
              {
                  p2 = "CORRECTO";
              }
              else
              {
                  p2 = "INCORRECTO";
              }

            PuntajePregunta puntajePregunta = new PuntajePregunta
            {                
                sp1 = p1,
                sp2 = p2,
                sp3 = "NO EXISTE",
                sp4 = "NO EXISTE",
                sp5 = "NO EXISTE",
                ExamenIdExamen = examenIdExamen
            };

            using (ModelContainer conexion = new ModelContainer())
            {
                conexion.PuntajePreguntas.Add(puntajePregunta);
                conexion.SaveChanges();
            }

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
    }
}
