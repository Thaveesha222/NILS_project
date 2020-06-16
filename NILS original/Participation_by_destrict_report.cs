using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NILS_original
{
    class Participation_by_destrict_report
    {
        /// <summary>
        /// FUNCTION FOR EXPORT TO EXCEL
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="worksheetName"></param>
        /// <param name="saveAsLocation"></param>
        /// <returns></returns>
        public bool WriteDataTableToExcel(System.Data.DataTable dataTable, string worksheetName, string saveAsLocation, string ReporType, string progtype, string user, int No_of_individual_participants,string type="program",string courseno=null,bool paymentreport=false)
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
                if (type == "program")
                {
                    excelSheet.Cells[5, 1] = "Program Type :" + progtype;
                }
                else if (type == "diploma")
                {
                    excelSheet.Cells[5, 1] = "Course name :" + General_methods.get_course_name_from_course_no(courseno);

                }
                else if (type == "all")
                {
                    excelSheet.Cells[5, 1] = "For all batches";

                }

                // loop through each row and add values to our sheet
                int rowcount = 6;

                foreach (DataRow datarow in dataTable.Rows)
                {
                    //adding one to rowcount
                    rowcount += 1;
                    for (int i = 1; i <= dataTable.Columns.Count; i++)
                    {
                        // on the first iteration we add the column headers
                        if (rowcount == 7)
                        {
                            excelSheet.Cells[6, i] = dataTable.Columns[i - 1].ColumnName;
                            excelSheet.Cells.Font.Color = System.Drawing.Color.Black;
                            excelSheet.Cells[6, i].Font.Bold = true;
                        }

                        excelSheet.Cells[rowcount, i] = datarow[i - 1].ToString();

                        //for alternate rows
                        if (rowcount > 7)
                        {
                            if (i == dataTable.Columns.Count)
                            {
                                if (rowcount % 4 == 0)
                                {
                                    excelCellrange = excelSheet.Range[excelSheet.Cells[rowcount, 1], excelSheet.Cells[rowcount, dataTable.Columns.Count]];
                                    //FormattingExcelCells(excelCellrange, "#CCCCFF", System.Drawing.Color.Black, false);
                                }

                            }
                        }

                    }

                }


               

                // now we resize the columns
                excelCellrange = excelSheet.Range[excelSheet.Cells[1, 1], excelSheet.Cells[rowcount, dataTable.Columns.Count]];
                excelCellrange.EntireColumn.AutoFit();
                Microsoft.Office.Interop.Excel.Borders border = excelCellrange.Borders;
                border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                border.Weight = 2d;


                excelCellrange = excelSheet.Range[excelSheet.Cells[1, 1], excelSheet.Cells[5, dataTable.Columns.Count+12]];
                FormattingExcelCells(excelCellrange, "#000099", System.Drawing.Color.White, true);
                excelSheet.Cells[1, 1].Font.Size = 20;
                if (paymentreport == false)
                {
                    if (type == "program")
                    {
                        Microsoft.Office.Interop.Excel.Range chartRange;

                        Microsoft.Office.Interop.Excel.ChartObjects xlCharts = (Microsoft.Office.Interop.Excel.ChartObjects)excelSheet.ChartObjects(Type.Missing);
                        Microsoft.Office.Interop.Excel.ChartObject myChart = (Microsoft.Office.Interop.Excel.ChartObject)xlCharts.Add(10, 80, 300, 250);
                        Microsoft.Office.Interop.Excel.Chart chartPage = myChart.Chart;

                        chartRange = excelSheet.Range[excelSheet.Cells[7, 1], excelSheet.Cells[rowcount, dataTable.Columns.Count]];
                        chartPage.SetSourceData(chartRange);
                        chartPage.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlColumnClustered;
                    }
                    else if (type == "diploma")
                    {
                        Microsoft.Office.Interop.Excel.Range chartRange;

                        Microsoft.Office.Interop.Excel.ChartObjects xlCharts = (Microsoft.Office.Interop.Excel.ChartObjects)excelSheet.ChartObjects(Type.Missing);
                        Microsoft.Office.Interop.Excel.ChartObject myChart = (Microsoft.Office.Interop.Excel.ChartObject)xlCharts.Add(10, 80, 300, 250);
                        Microsoft.Office.Interop.Excel.Chart chartPage = myChart.Chart;

                        chartRange = excelSheet.Range[excelSheet.Cells[7, 1], excelSheet.Cells[rowcount, 2]];
                        chartPage.SetSourceData(chartRange);
                        chartPage.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlColumnClustered;
                    }
                }
                else
                {

                }
               


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
