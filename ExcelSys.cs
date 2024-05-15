using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Russ_Tool
{
	
	public class ExcelSys
	{
		public List<List<string>> ReadExcelData(string filePath, string sheetName)
		{
			List<List<string>> data = new List<List<string>>();

			// Check if the file exists
			if (!File.Exists(filePath))
			{
				throw new FileNotFoundException("The specified file does not exist.");
			}

			// Open the workbook
			using (var workbook = new XLWorkbook(filePath))
			{
				// Get the specified worksheet
				var worksheet = workbook.Worksheet(sheetName);

				// Check if the worksheet exists
				if (worksheet == null) 
				{
					throw new ArgumentException($"Worksheet '{sheetName}' not found in the Excel file.");
				}

				// Iterate through rows and columns to collect data
				foreach (var row in worksheet.RowsUsed())
				{
					List<string> rowData = new List<string>();

					foreach (var cell in row.Cells())
					{
						rowData.Add(cell.Value.ToString() ?? "");
					}

					data.Add(rowData);
				}
			}

			return data;
		}

	}
}
