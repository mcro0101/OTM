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
		//-------------------------------------------
		//public void ReplaceTextInExcel(string filePath, string fileName, Dictionary<string, string> replacements)
		//{
		//	try
		//	{
		//		// Check if the file exists
		//		if (!File.Exists(filePath))
		//		{
		//			MessageBox.Show($"The file {filePath} does not exist.");
		//			return;
		//		}

		//		// Open the Excel file
		//		using (var workbook = new XLWorkbook(filePath))
		//		{
		//			var worksheet = workbook.Worksheets.Add("Sample Sheet");
		//			worksheet.Cell("B2").Value = "Hello World!"; //date
		//			worksheet.Cell("D2").Value = "Hello World!"; //Well Info
		//			//worksheet.Cell("D2").FormulaA1 = "=MID(A1, 7, 5)"; //for using formula



		//			// Save the changes to the workbook
		//			workbook.Save();
		//		}

		//		string pathDir = Path.GetDirectoryName(filePath);
		//		MessageBox.Show($"{fileName} updated successfully.\nLocated at: {pathDir}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
		//	}
		//	catch (IOException ex)
		//	{
		//		MessageBox.Show($"An IO exception occurred: {ex.Message}");
		//	}
		//	catch (UnauthorizedAccessException ex)
		//	{
		//		MessageBox.Show($"Access to the file is denied: {ex.Message}");
		//	}
		//	catch (Exception ex)
		//	{
		//		MessageBox.Show($"An unexpected error occurred: {ex.Message}");
		//	}
		//}





		// ---------------------------------------



		public void ReplaceTextInExcel(string filePath, string fileName, Dictionary<string, string> replacements)
		{
			try
			{
				// Check if the file exists
				if (!File.Exists(filePath))
				{
					MessageBox.Show($"The file {filePath} does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				// Open the Excel file
				using (var workbook = new XLWorkbook(filePath))
				{
					// Iterate through each worksheet in the workbook
					foreach (var worksheet in workbook.Worksheets)
					{
						// Iterate through each cell in the worksheet
						foreach (var cell in worksheet.CellsUsed())
						{
							try
							{
								if (cell.HasFormula)
								{
									// If the cell contains a formula, get the formula as text
									string formula = cell.FormulaA1;
									bool replaced = false;

									foreach (var replacement in replacements)
									{
										if (formula.Contains(replacement.Key, StringComparison.OrdinalIgnoreCase))
										{
											// Replace the text in the formula
											formula = formula.Replace(replacement.Key, replacement.Value, StringComparison.OrdinalIgnoreCase);
											replaced = true;
										}
									}

									if (replaced)
									{
										// Set the new formula
										cell.FormulaA1 = formula;
									}
								}
								else
								{
									// If the cell does not contain a formula, get the cell's value as a string
									string cellValue = cell.GetString();

									if (replacements.TryGetValue(cellValue, out string newValue))
									{
										// Replace the cell's value with the corresponding value from the replacements dictionary
										cell.Value = newValue;
									}
								}
							}
							catch (Exception ex)
							{
								MessageBox.Show($"An error occurred while processing cell {cell.Address}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
								continue;
							}
						}
					}

					// Save the changes to the workbook
					workbook.Save();
				}

				//string pathDir = Path.GetDirectoryName(filePath);
				//MessageBox.Show($"{fileName} updated successfully.\nLocated at: {pathDir}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (IOException ex)
			{
				MessageBox.Show($"An IO exception occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (UnauthorizedAccessException ex)
			{
				MessageBox.Show($"Access to the file is denied: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}



		// ---------------------------------------------------------------

		public int GetMaxRowsInWorkbook(string filePath)
		{
			try
			{
				// Check if the file exists
				if (!File.Exists(filePath))
				{
					MessageBox.Show($"The file {filePath} does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return 0;
				}

				// Open the Excel file
				using (var workbook = new XLWorkbook(filePath))
				{
					int maxRows = 0;

					// Iterate through each worksheet in the workbook
					foreach (var worksheet in workbook.Worksheets)
					{
						// Get the last used row in the worksheet
						var lastRow = worksheet.LastRowUsed()?.RowNumber() ?? 0;
						if (lastRow > maxRows)
						{
							maxRows = lastRow - 1;
						}
					}

					return maxRows;
				}
			}
			catch (IOException ex)
			{
				MessageBox.Show($"An IO exception occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return 0;
			}
			catch (UnauthorizedAccessException ex)
			{
				MessageBox.Show($"Access to the file is denied: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return 0;
			}
			catch (Exception ex)
			{
				MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return 0;
			}
		}

		// ---------------------------------------------------------------

		public void InsertDataToDoubleCheck(string pRawDataPath, string pDoubleCheckPath, string pfilePath, string pfileName, int pLastRow)
		{
			try
			{
				using (var wbRawData = new XLWorkbook(pRawDataPath))
				using (var wbDblChk = new XLWorkbook(pDoubleCheckPath))
				{
					var wsDblchk = wbDblChk.Worksheet("Double Check Tally");
					var wsRawDataSheet2 = wbRawData.Worksheet("Sheet1");

					//var lastRow = wsRawDataSheet2.LastRowUsed().RowNumber();
					pLastRow = pLastRow + 1;
					// Copy data row by row and merge cells per row
					for (int row = 2; row <= pLastRow; row++)
					{
						try
						{
							var sourceCellB = wsRawDataSheet2.Cell(row, "B");
							var sourceCellC = wsRawDataSheet2.Cell(row, "C");
							var destCellB = wsDblchk.Cell(row + 2, "B");
							var destCellE = wsDblchk.Cell(row + 2, "E");

							// Convert meters to feet
							double? valueBInFeet = ConvertMetersToFeet(sourceCellB.GetString());
							double? valueCInFeet = ConvertMetersToFeet(sourceCellC.GetString());

							// Copy converted data if conversion is successful
							if (valueBInFeet.HasValue)
							{
								destCellB.SetValue(valueBInFeet.Value);
							}
							else
							{
								destCellB.Clear(); // Clear cell if conversion fails
							}

							if (valueCInFeet.HasValue)
							{
								destCellE.SetValue(valueCInFeet.Value);
							}
							else
							{
								destCellE.Clear(); // Clear cell if conversion fails
							}

							// Merge cells
							wsDblchk.Range(destCellB, destCellB.CellRight(2)).Merge();
							wsDblchk.Range(destCellE, destCellE.CellRight(2)).Merge();
						}
						catch (Exception ex)
						{
							MessageBox.Show($"Error processing row {row}: {ex.Message}", "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}

					try
					{
						wbDblChk.Save();
						// Display success message
						string pathDir = Path.GetDirectoryName(pfilePath);
						MessageBox.Show($"{pfileName} updated successfully.\nLocated at: {Path.Combine(pathDir, pfileName)}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					catch (Exception ex)
					{
						MessageBox.Show($"Error saving the file: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}


		// ---------------------------------------------------------------

		public double? ConvertMetersToFeet(string input)
		{
			try
			{
				// Attempt to parse the input string to a double
				if (double.TryParse(input, out double meters))
				{
					// Convert meters to feet (1 meter = 3.28084 feet)
					double feet = meters * 3.28084;
					// Return the result
					return feet;
				}
				else
				{
					// Return null if input is not a number
					return null;
				}
			}
			catch (Exception ex)
			{
				// Log the exception (optional) and return null
				Console.WriteLine($"An error occurred: {ex.Message}");
				return null;
			}
		}


		// ---------------------------------------------------------------

	}
}
