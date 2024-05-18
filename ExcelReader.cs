using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;//using Excel = Microsoft.Office.Interop.Excel;

namespace Russ_Tool
{
	public class ExcelReader
	{
		public List<List<string>> ReadDataFromExcel(string filePath, string sheetName)
		{
			List<List<string>> dataList = new List<List<string>>();

			try
			{
				// Open the workbook
				using (var workbook = new XLWorkbook(filePath))
				{
					// Get the specified worksheet
					var worksheet = workbook.Worksheet(sheetName);

					// Get the used range of the worksheet
					var usedRange = worksheet.RangeUsed();

					// Get the total number of rows and columns
					int rowCount = usedRange.RowCount();
					int colCount = usedRange.ColumnCount();

					// Iterate through each row
					for (int row = 1; row <= rowCount; row++)
					{
						List<string> rowData = new List<string>();
						// Iterate through each column in the row
						for (int col = 1; col <= colCount; col++)
						{
							// Get the cell value and add it to the list
							var cell = worksheet.Cell(row, col);
							rowData.Add(cell.GetString());
						}
						dataList.Add(rowData);
					}
				}
			}
			catch (Exception ex)
			{
				// Handle any exceptions
				Console.WriteLine("Error reading data from Excel file: " + ex.Message);
			}

			return dataList;
		}


		// -----------------------

		public string BrowseExcelFile()
		{
			string selectedFilePath = null;

			// Create OpenFileDialog
			OpenFileDialog openFileDialog = new OpenFileDialog();

			// Set the file filter to allow only Excel files
			openFileDialog.Filter = "Excel Files|*.xls;*.xlsx|All Files|*.*";

			// Display OpenFileDialog
			DialogResult result = openFileDialog.ShowDialog();

			// Check if the user selected a file
			if (result == DialogResult.OK)
			{
				// Get the selected file path
				selectedFilePath = openFileDialog.FileName;
			}

			return selectedFilePath;
		}

		// ---------------------------------------
		public void ReplaceTextInExcel(string filePath, string fileName, Dictionary<string, string> replacements)
		{
			try
			{
				// Open the workbook
				using (var workbook = new XLWorkbook(filePath))
				{
					// Check if there are sheets in the workbook
					if (workbook.Worksheets.Count == 0)
					{
						throw new Exception("Workbook is empty.");
					}

					// Get the first worksheet
					var worksheet = workbook.Worksheet(1);

					// Get the used range of the worksheet
					var range = worksheet.RangeUsed();

					// Check if there is data in the used range
					if (range == null)
					{
						throw new Exception("No data found in the worksheet.");
					}

					// Get the total number of rows and columns
					int rows = range.RowCount();
					int cols = range.ColumnCount();

					// Iterate through the replacements dictionary
					foreach (var replacement in replacements)
					{
						string searchText = replacement.Key;
						string replaceText = replacement.Value;

						// Iterate through each cell in the used range
						for (int i = 1; i <= rows; i++)
						{
							for (int j = 1; j <= cols; j++)
							{
								var cell = worksheet.Cell(i, j);
								if (!string.IsNullOrEmpty(cell.GetString()) && cell.GetString() == searchText)
								{
									cell.Value = replaceText;
								}
							}
						}
					}

					// Save the workbook
					workbook.Save();
				}

				// Display success message
				string pathDir = Path.GetDirectoryName(filePath);
				MessageBox.Show($"{fileName} created successfully.\nLocated at: {pathDir}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
				// Handle or log the exception as required
			}
		}
		// ---------------------------------------------------------------
		private static void ReleaseObject(object obj)
		{
			try
			{
				System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
				obj = null;
			}
			catch (System.Exception ex)
			{
				obj = null;
				throw ex;
			}
			finally
			{
				GC.Collect();
			}
		}

		// ---------------------------------------------------------------
	}
}
