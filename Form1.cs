using DocumentFormat.OpenXml.Math;

namespace Russ_Tool
{
	public partial class Form1 : Form
	{
		private ExcelSys excelReader;
		public Form1()
		{
			InitializeComponent();
			excelReader = new ExcelSys();
		}



		public string BrowseExcelFile()
		{
			string filePath = null;

			// Create OpenFileDialog
			OpenFileDialog openFileDialog = new OpenFileDialog();

			// Set the file dialog properties
			openFileDialog.Filter = "Excel Files|*.xls;*.xlsx|All Files|*.*";
			openFileDialog.FilterIndex = 1;
			openFileDialog.RestoreDirectory = true;

			// Show the dialog and check if the user clicked OK
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				// Get the selected file path
				filePath = openFileDialog.FileName;
			}

			// Return the selected file path
			return filePath;
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void btnRawData_Click(object sender, EventArgs e)
		{
			BrowseExcelFile();
		}

		private void btnFilePath_Click(object sender, EventArgs e)
		{
			BrowseExcelFile();
		}
	}
}
