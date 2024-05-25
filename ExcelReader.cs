using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
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
		private int ShoeStart = 0;
		private int FLoatPosStart = 0;
		private double Floatlen = 0;
		private double ShoeLen = 0;
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
					//MessageBox.Show($"The file {filePath} does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
							var destCellA = wsDblchk.Cell(row + 2, "A");
							var destCellB = wsDblchk.Cell(row + 2, "B");
							var destCellE = wsDblchk.Cell(row + 2, "E");
							var destCellH = wsDblchk.Cell(row + 2, "H");
							int iValueA = row - 1;
							// Convert meters to feet
							//double? valueBInFeet = ConvertMetersToFeet(sourceCellB.GetString());
							//double? valueCInFeet = ConvertMetersToFeet(sourceCellC.GetString());

							double? valueBInFeet = ConvertStringToDouble(sourceCellB.GetString());
							double? valueCInFeet = ConvertStringToDouble(sourceCellC.GetString());
							destCellA.SetValue(iValueA);
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

							//Add H values
							wsDblchk.Cell(row + 2, 8).FormulaA1 = $"=ABS(B{row + 2}-E{row + 2})";
							wsDblchk.Cell(row + 2,9).FormulaA1 = "=IF(H4 < 0.02, \"Good\", \"Bad\")";

							
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


		public void InsertDataToCasingTally(string pRawDataPath, string pCTPath, string pfilePath, string pfileName, int pLastRow)
		{
			try
			{
				using (var wbRawData = new XLWorkbook(pRawDataPath))
				using (var wbDblChk = new XLWorkbook(pCTPath))
				{
					var wsRawDataSheet2 = wbRawData.Worksheet("Sheet1");
					var wsCT = wbDblChk.Worksheet("Casing Tally");
					bool stopper = false;

					//var lastRow = wsRawDataSheet2.LastRowUsed().RowNumber();
					pLastRow = pLastRow + 1;
					// Copy data row by row and merge cells per row
					for (int rawrow = 2; rawrow <= pLastRow; rawrow++)
					{
						try
						{
							int CTrow = rawrow + 2;
							var sourceCellB = wsRawDataSheet2.Cell(rawrow, "B");
							IXLCell destCellB = null;
							var destCellA = wsCT.Cell(CTrow, "A");
							IXLCell destRowNumCounter = null;
							IXLCell destShoeA = null;
							IXLCell destFloatA = null;
							IXLCell destShoeB= null;
							IXLCell destFloatB = null;
							IXLCell destFloatC4 = null;
							IXLCell destFloatC = null;
							//IXLCell sourceCellB = null;



							// Convert meters to feet
							double? valueBInFeet = 0;
						    string valueInC4 = "";
							string valueInC= "";
							int iValueA = rawrow-1; // Declare and initialize the variable
													//string valueA = iValueA.ToString();

							//~~~~~~~~~~~~~~~~~~Condition~~~~~~~SHOE = YES , FLOAT = YES~~~~~~~~~~~~~~~~~//
							if (ShoeStart !=0 && FLoatPosStart != 0)
							{
								if (rawrow==2) { destShoeA = wsCT.Cell(ShoeStart, "A"); destShoeA.SetValue("Shoe"); destShoeB = wsCT.Cell(ShoeStart, "B"); destShoeB.SetValue(ShoeLen); }
								if (iValueA == FLoatPosStart + 1) { stopper = true; }
								if (stopper == false)
								{ 
									destRowNumCounter = wsCT.Cell(ShoeStart + iValueA, "A"); destRowNumCounter.SetValue(iValueA); // Col A Data
									destCellB = wsCT.Cell(ShoeStart + iValueA, "B"); valueBInFeet = ConvertStringToDouble(sourceCellB.GetString()); destCellB.SetValue(valueBInFeet); // Col B Data
								}

								if (FLoatPosStart != 0 && iValueA == (ShoeStart + FLoatPosStart)) { destFloatA = wsCT.Cell(FLoatPosStart + ShoeStart + 1, "A"); destFloatA.SetValue("Float"); destFloatB = wsCT.Cell(FLoatPosStart + ShoeStart + 1, "B"); destFloatB.SetValue(Floatlen); }
								if (stopper == true) 
								{
									destRowNumCounter = wsCT.Cell(ShoeStart + iValueA + 1, "A"); destRowNumCounter.SetValue(iValueA);
									destCellB = wsCT.Cell(ShoeStart + iValueA + 1, "B"); valueBInFeet = ConvertStringToDouble(sourceCellB.GetString()); destCellB.SetValue(valueBInFeet); // Col B Data
																																															
								}
							}
							//~~~~~~~~~~~~~~~~~~Condition~~~~~~~SHOE = NO , FLOAT = NO~~~~~~~~~~~~~~~~~//

							if (ShoeStart == 0 && FLoatPosStart==0)
							{ 
								destRowNumCounter = wsCT.Cell(CTrow, "A"); destRowNumCounter.SetValue(iValueA);  // Col A Data
								destCellB = wsCT.Cell(CTrow, "B"); valueBInFeet = ConvertStringToDouble(sourceCellB.GetString()); destCellB.SetValue(valueBInFeet); // Col B Data
							}

							//~~~~~~~~~~~~~~~~~~Condition~~~~~~~SHOE = YES , FLOAT = NO~~~~~~~~~~~~~~~~~//
							if (ShoeStart != 0 && FLoatPosStart == 0) 
							{
								if (rawrow == 2) { destShoeA = wsCT.Cell(ShoeStart, "A"); destShoeA.SetValue("Shoe"); destShoeB = wsCT.Cell(ShoeStart, "B"); destShoeB.SetValue(ShoeLen); }
								destRowNumCounter = wsCT.Cell(ShoeStart + iValueA, "A"); destRowNumCounter.SetValue(iValueA);// Col A Data
								destCellB = wsCT.Cell(ShoeStart + iValueA, "B"); valueBInFeet = ConvertStringToDouble(sourceCellB.GetString()); destCellB.SetValue(valueBInFeet); // Col B Data;
							}

							//~~~~~~~~~~~~~~~~~~Condition~~~~~~~SHOE = NO , FLOAT = YES~~~~~~~~~~~~~~~~~//
							if (ShoeStart == 0 && FLoatPosStart != 0)
							{
								if (iValueA == FLoatPosStart + 1) { stopper = true; }
								if (stopper == false)
								{ 
									destRowNumCounter = wsCT.Cell(CTrow, "A"); destRowNumCounter.SetValue(iValueA); // Col A Data
									destCellB = wsCT.Cell(CTrow, "B"); valueBInFeet = ConvertStringToDouble(sourceCellB.GetString()); destCellB.SetValue(valueBInFeet); // Col B Data
								}
								if (FLoatPosStart != 0 && iValueA == (FLoatPosStart + 1)) { destFloatA = wsCT.Cell(CTrow, "A"); destFloatA.SetValue("Float"); destFloatB = wsCT.Cell(CTrow, "B"); destFloatB.SetValue(Floatlen); }
								if (stopper == true)
								{ 
									destRowNumCounter = wsCT.Cell(CTrow + 1, "A"); destRowNumCounter.SetValue(iValueA);  // Col A Data
									destCellB = wsCT.Cell(CTrow + 1, "B"); valueBInFeet = ConvertStringToDouble(sourceCellB.GetString()); destCellB.SetValue(valueBInFeet); // Col B Data
								}
							}
							if (CTrow == 4)
							{
								valueInC4 = wsCT.Cell("B4").Value.ToString();
								destFloatC4 = wsCT.Cell("C4");
								destFloatC4.SetValue(ConvertStringToDouble(valueInC4));
								wsCT.Cell(4, 5).FormulaA1 = "=F4-B4";
							}
							//if (CTrow!=4 )
							//{
							//	valueInC = wsCT.Cell($"B{CTrow}").Value.ToString();
							//	destFloatC = wsCT.Cell($"C{CTrow}");
							//	string CUpValue = wsCT.Cell($"C{CTrow - 1}").Value.ToString();
							//	destFloatC.SetValue(ConvertStringToDouble(valueInC) + ConvertStringToDouble(CUpValue));
							//}

						

						}



					
						catch (Exception ex)
						{
							MessageBox.Show($"Error processing row {rawrow}: {ex.Message}", "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}

					int pLastRow2 = wsCT.LastRowUsed().RowNumber();
					for (int CstartRow = 5; CstartRow <= pLastRow + 4; CstartRow++)
					{
						// Set the formula in column C for each row
						wsCT.Cell(CstartRow, 3).FormulaA1 = $"=SUM(B{CstartRow},C{CstartRow - 1})";
						wsCT.Cell(CstartRow, 5).FormulaA1 = $"=F{CstartRow}-B{CstartRow}";
						wsCT.Cell(CstartRow, 6).FormulaA1 = $"=E{CstartRow-1}";		
					}

					wsCT.Cell("F4").FormulaA1 = $"=SUM(B4:B{(pLastRow2 + 4).ToString()})";
					//wsCT.Cell("C4").FormulaA1 = $"=B4";
					//wsCT.Cell("C5").FormulaA1 = $"=SUM(B5+C4)";

					//wsCT.Rows(pLastRow + 5,1000).Delete();
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


		//public bool InsertDataToColmnA(IXLCell destCellA,int pLastRow, int currentRow)
		//{
		//	try
		//	{
		//		int iValueA = currentRow - 2; // Declare and initialize the variable
		//		string valueA = iValueA.ToString();
		//		if (currentRow == 2) 
		//		{ 
		//			if (ShoeStart != 0) { valueA = GetShoeVal(ShoeStart); destCellA.SetValue(valueA); } 
		//			if(currentRow == FLoatPosStart) { valueA = GetFloatVal(FLoatPosStart); destCellA.SetValue(valueA); } 
		//		}
		//		if (currentRow == FLoatPosStart) 
		//		{ 
		//		 if (currentRow > 2) { valueA = GetFloatVal(FLoatPosStart);  destCellA.SetValue(valueA); }
				 
		//		}
		//		if (currentRow > FLoatPosStart) { destCellA.SetValue(iValueA); }
		//		if (ShoeStart == 0 && FLoatPosStart == 0) { destCellA.SetValue(iValueA); }
				


		//			return true;
		//	}
		//	catch (Exception ex)
		//	{
		//		return false;
		//	}

		//}


		// ---------------------------------------------------------------
		public bool GetShoeFloatConditions(bool pShoeExist, bool pFloatExist, int pFLoatPos, double pShoeLen, double floatLen)
		{
			try
			{	
				//SHOE = YES , FLOAT = YES
				if (pShoeExist == true && pFloatExist==true) { ShoeStart = 4; FLoatPosStart = pFLoatPos; ShoeLen = pShoeLen; Floatlen = floatLen; }
				

				//SHOE = NO, FLOAT = YES
				if (pShoeExist == false & pFloatExist == true) { ShoeStart = 0; FLoatPosStart = pFLoatPos; ShoeLen = 0; Floatlen = floatLen; }

				//SHOE = YES, FLOAT = NO
				if (pShoeExist == true && pFloatExist == false) { ShoeStart = 4; FLoatPosStart = 0; ShoeLen = pShoeLen; Floatlen = 0; }

				//SHOE = NO , FLOAT = NO
				if (pShoeExist == false && pFloatExist == false) { ShoeStart = 0; FLoatPosStart = 0; ShoeLen = 0; Floatlen = 0; }

				return true;
			}
			catch (Exception ex)
			{
				return false;
			}

		}

			// ---------------------------------------------------------------

			public int ShoeStartingPoint(bool pShoeExist, bool pFloatExist, int pFLoatPos)
	     	{
			int ret_val = 4;
			FLoatPosStart = pFLoatPos;
			if (pShoeExist == true) { ret_val = 4; ShoeStart = ret_val; }
			else
			{
				ShoeStart = 0;
				if (pFloatExist == true)
				{
					//ShoeStart = pFLoatPos;
					return ShoeStart;


				}
				else { ret_val = 0;  return ret_val;  }
			}
			
			return ret_val;
		    }

		//--------------//--------------//--------------//--------------//--------------//--------------
		public string GetShoeVal(int ShoeStart)
		{
			if (ShoeStart == 0) { return ""; }
			return "Shoe";
		}

		public string GetFloatVal(int FloatStart)
		{
			if (FloatStart == 0) { return ""; }
			return "Float";
		}
		//--------------//--------------//--------------//--------------//--------------

		public double ConvertStringToDouble(string input)
		{
			try
			{
				if (string.IsNullOrEmpty(input))
				{
					return 0;
				}

				return double.Parse(input);
			}
			catch
			{
				return 0;
			}
		}
		//--------------//--------------//--------------//--------------//--------------

	}
}
