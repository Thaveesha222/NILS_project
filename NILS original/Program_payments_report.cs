using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NILS_original
{
    class Program_payments_report
    {
        /// <summary>
        /// FUNCTION FOR EXPORT TO EXCEL
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="worksheetName"></param>
        /// <param name="saveAsLocation"></param>
        /// <returns></returns>
        public bool WriteDataTableToExcel(DataTable dataTable1, DataTable dataTable2, string worksheetName, string saveAsLocation, string ReporType, string progtype, string user,string progtitle)
        {
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook excelworkBook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;
            Microsoft.Office.Interop.Excel.Range excelCellrange;

            try
            {
                // Start Excel and get Application object.
                excel = new Microsoft.Office.Interop.Excel.Application();

                // for making Excel visible
                excel.Visible = true;
                excel.DisplayAlerts = true;

                // Creation a new Workbook
                excelworkBook = excel.Workbooks.Add(Type.Missing);

                // Workk sheet
                excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
                excelSheet.Name = worksheetName;


                excelSheet.Cells[1, 1] = "Report Name - " + ReporType;
                excelSheet.Cells[2, 1] = "Date of Report Generation : " + General_methods.get_current_date();
                excelSheet.Cells[3, 1] = "Time of Report Generation :" + General_methods.get_current_time();
                excelSheet.Cells[4, 1] = "Report Created By :" + user;
                excelSheet.Cells[5, 1] = "Program Type :" + progtype;
                excelSheet.Cells[6, 1] = "Program Title :" + progtitle;
                excelSheet.Cells[7, 1] = "All Payments by Company Participants";



                // loop through each row and add values to our sheet
                int rowcount = 8;

                foreach (DataRow datarow in dataTable1.Rows)
                {
                    //adding one to rowcount
                    rowcount += 1;
                    for (int i = 1; i <= dataTable1.Columns.Count; i++)
                    {
                        // on the first iteration we add the column headers
                        if (rowcount == 9)
                        {
                            excelSheet.Cells[8, i] = dataTable1.Columns[i - 1].ColumnName;
                            excelSheet.Cells.Font.Color = System.Drawing.Color.Black;
                            excelSheet.Cells[8, i].Font.Bold = true;

                        }

                        excelSheet.Cells[rowcount, i] = datarow[i - 1].ToString();

                        //for alternate rows
                        if (rowcount > 9)
                        {
                            if (i == dataTable1.Columns.Count)
                            {
                                if (rowcount % 4 == 0)
                                {
                                    excelCellrange = excelSheet.Range[excelSheet.Cells[rowcount, 1], excelSheet.Cells[rowcount, dataTable1.Columns.Count]];
                                    FormattingExcelCells(excelCellrange, "#CCCCFF", System.Drawing.Color.Black, false);
                                }

                            }
                        }

                    }

                }

                // now we resize the columns
                excelCellrange = excelSheet.Range[excelSheet.Cells[1, 1], excelSheet.Cells[rowcount, dataTable1.Columns.Count]];
                excelCellrange.EntireColumn.AutoFit();
                Microsoft.Office.Interop.Excel.Borders border = excelCellrange.Borders;
                border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                border.Weight = 2d;




                int newrowcount = rowcount + 5;
                int y = newrowcount;
                excelSheet.Cells[newrowcount - 1, 1] = " All Payments by Individual Participants";
                int x = newrowcount;
                //newrowcount =2;

                foreach (DataRow datarow in dataTable2.Rows)
                {
                    //adding one to rowcount
                    newrowcount += 1;
                    for (int i = 1; i <= dataTable2.Columns.Count; i++)
                    {
                        // on the first iteration we add the column headers
                        if (newrowcount == x + 1)
                        {
                            excelSheet.Cells[x, i] = dataTable2.Columns[i - 1].ColumnName;
                            excelSheet.Cells.Font.Color = System.Drawing.Color.Black;
                            excelSheet.Cells[x, i].Font.Bold = true;


                        }

                        excelSheet.Cells[newrowcount, i] = datarow[i - 1].ToString();

                        //for alternate rows
                        if (newrowcount > x + 1)
                        {
                            if (i == dataTable2.Columns.Count)
                            {
                                if (newrowcount % 4 == 0)
                                {
                                    excelCellrange = excelSheet.Range[excelSheet.Cells[newrowcount, 1], excelSheet.Cells[newrowcount, dataTable2.Columns.Count]];
                                    FormattingExcelCells(excelCellrange, "#CCCCFF", System.Drawing.Color.Black, false);
                                }

                            }
                        }

                    }
                    

                }
                excelCellrange = excelSheet.Range[excelSheet.Cells[x, 1], excelSheet.Cells[newrowcount, dataTable2.Columns.Count]];
                excelCellrange.EntireColumn.AutoFit();
                Microsoft.Office.Interop.Excel.Borders border2 = excelCellrange.Borders;
                border2.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                border2.Weight = 2d;

                excelCellrange = excelSheet.Range[excelSheet.Cells[1, 1], excelSheet.Cells[6, dataTable1.Columns.Count]];
                FormattingExcelCells(excelCellrange, "#000099", System.Drawing.Color.White, true);
                excelSheet.Cells[1, 1].Font.Size = 20;
                excelSheet.Cells[7, 1].Font.Color = System.Drawing.Color.Red;
                excelSheet.Cells[7, 1].Font.Bold = true;

                excelSheet.Cells[y - 1, 1].Font.Color = System.Drawing.Color.Red;
                excelSheet.Cells[y - 1, 1].Font.Bold = true;



                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                excelSheet = null;
                excelCellrange = null;
                excelworkBook = null;
            }


        }
        /// <summary>
        /// //////////
        /// </summary>
        //var application = new Application();

        ////////////////////////////
        /// <summary>
        /// FUNCTION FOR FORMATTING EXCEL CELLS
        /// </summary>
        /// <param name="range"></param>
        /// <param name="HTMLcolorCode"></param>
        /// <param name="fontColor"></param>
        /// <param name="IsFontbool"></param>
        public void FormattingExcelCells(Microsoft.Office.Interop.Excel.Range range, string HTMLcolorCode, System.Drawing.Color fontColor, bool IsFontbool)
        {
            range.Interior.Color = System.Drawing.ColorTranslator.FromHtml(HTMLcolorCode);
            range.Font.Color = System.Drawing.ColorTranslator.ToOle(fontColor);
            if (IsFontbool == true)
            {
                range.Font.Bold = IsFontbool;
            }
        }
    }
}
