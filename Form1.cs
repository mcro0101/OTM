using DocumentFormat.OpenXml.Math;

namespace Russ_Tool
{
	public partial class Form1 : Form
	{
		private Initializer classInit;
		public string pDate = "";
		public string pCD = "";
		public string pWI = "";
		public string pRO1 = "";
		public string pRO2 = "";
		public string pNumJoints = "";
		public string pRawDataPath = "";
		public string pShoeType = "";
		public string pShoeLen = "";
		public string pFloatLen = "";
		public string pFloatPos = "";
		public string pFilename = "";
		public string pFileDest = "";
		public string SelectedTemplate = "";
		public int SelectedReport = 0; //0 For Double Check, 1 for Casing Tally
		public Form1()
		{
			InitializeComponent();
			classInit = new Initializer();
		}

		public void InitializeControls()
		{
			txtDate.Text = classInit.cIniConfig.iDate;
			txtCD.Text = classInit.cIniConfig.iCasingDetails;
			txtWI.Text = classInit.cIniConfig.iWellInformatio;
			txtRO1.Text = classInit.cIniConfig.iRunOperator1;
			txtRO2.Text = classInit.cIniConfig.iRunOperator2;
			txtNumJoint.Text = classInit.cIniConfig.iNumberOfJoints;
			txtShoeType.Text = classInit.cIniConfig.iShoeType;
			txtShoeLen.Text = classInit.cIniConfig.iShoeLength;
			txtFloatLen.Text = classInit.cIniConfig.iFloatLength;
			txtFloatType.Text = classInit.cIniConfig.iFloatType;
			txtFloatPos.Text = classInit.cIniConfig.iFloatPosition;
			//txtFileName.Text = classInit.cIniConfig.iFileName;
			txtRawData.Text = classInit.cIniConfig.iRawFile;
			txtFilePathDest.Text = classInit.cIniConfig.iFileDestination;
			rdoDblChk.Checked = true;
			//rdoFloatNo.Checked = true;
			//rdoShoeNo.Checked = true;
			rdoFloatYes.Checked = true;
			rdoShoeYes.Checked = true;
			if (string.IsNullOrEmpty(txtRawData.Text) == false)
			{ txtNumJoint.Text = classInit.cxlReader.GetMaxRowsInWorkbook(txtRawData.Text).ToString(); }

			SetFileName();

		}
		private void SetFileName()
		{
			string nowDate = DateTime.Now.ToString("MM-dd-yy");
			nowDate = nowDate.Replace("-", "");
			if (rdoDblChk.Checked == true)
			{
				txtFileName.Text = "DoubleCheck_" + nowDate;
			}
			else if (rdoCT.Checked == true)
			{
				txtFileName.Text = "CasingTally_" + nowDate;
			}
			else
			{
				txtFileName.Text = "";
			}


		}

		public void StoreData()
		{
			classInit.cData.dDate = pDate;
			classInit.cData.dCasingDetails = pCD;
			classInit.cData.dWellInformation = pWI;
			classInit.cData.dRunOperator1 = pRO1;
			classInit.cData.dRunOperator2 = pRO2;
			classInit.cData.dNumberOfJoints = pNumJoints;
			classInit.cData.dShoeType = pShoeType;
			classInit.cData.dShoeLength = pShoeType;
			classInit.cData.dFloatLength = pFloatLen;
			classInit.cData.dFloatPosition = pFloatPos;
		}
		public void InitiliazeConst()
		{
			classInit.cData.dDoubleChecke = "C:\\TEMP\\Templates\\OTM Double Check (Feet) 400 Joints Long Version.xlsx";
			classInit.cData.dCasingTallySF = "C:\\TEMP\\Templates\\OTM Casing Tally Template 400 Joint SHOE and FLOAT Version.xlsx";
			//classInit.cData.dCasingTallyNSNF = "C:\\TEMP\\Templates\\OTM Casing Tally Template 400 Joint NO SHOE NO FLOAT Version.xltx";
			pDate = txtDate.Text;
			pCD = txtCD.Text;
			pWI = txtWI.Text;
			pRO1 = txtRO1.Text;
			pRO2 = txtRO2.Text;
			pNumJoints = txtNumJoint.Text;
			pRawDataPath = txtRawData.Text;
			pShoeType = txtShoeType.Text;
			pShoeLen = txtShoeLen.Text;
			pFloatLen = txtFloatLen.Text;
			pFloatPos = txtFloatPos.Text;
			pFilename = txtFileName.Text;
			pFileDest = txtFilePathDest.Text;

		}

		private void Initialize()
		{
			classInit.cIniConfig.ReadConfig();
			InitializeControls();
		}
		private string GetSelectedReport()
		{
			if (rdoDblChk.Checked == true) { SelectedTemplate = classInit.cData.dDoubleChecke; SelectedReport = 0; }
			if (rdoCT.Checked == true) { SelectedTemplate = classInit.cData.dCasingTallySF; SelectedReport = 1; }
			return SelectedTemplate;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Initialize();
		}

		private void btnRawData_Click(object sender, EventArgs e)
		{
			txtRawData.Text = classInit.cxlReader.BrowseExcelFile();

			int RawMaxRows = classInit.cxlReader.GetMaxRowsInWorkbook(txtRawData.Text);
			txtNumJoint.Text = RawMaxRows.ToString();
		}

		private void btnFilePath_Click(object sender, EventArgs e)
		{
			txtFilePathDest.Text = classInit.cFileManager.BrowseFolder();
		}

		private void btnGenerate_Click(object sender, EventArgs e)
		{
			InitiliazeConst();
			StoreData();
			string pPath = pFileDest;
			string valReport = GetSelectedReport();
		
			if (pPath != "")
			{
				//classInit.cxlReader.ReadDataFromExcel(pPath, "Sheet1");
				string newFileDest = pFileDest + "\\" + pFilename + ".xlsx";
				classInit.cFileManager.CopyFile(valReport, newFileDest);
				classInit.cxlReader.ReplaceTextInExcel(newFileDest, pFilename, classInit.cData.InsertDictionary());
				if (SelectedReport == 0)
				{
					classInit.cxlReader.InsertDataToDoubleCheck(pRawDataPath, newFileDest, newFileDest, pFilename, int.Parse(pNumJoints));
				}
				if (SelectedReport == 1)
				{
					//CT
					classInit.cxlReader.InsertDataToCasingTally(pRawDataPath, newFileDest, newFileDest, pFilename, int.Parse(pNumJoints));
				}

			}
		}


		private void OnlyAllowNumericAndDecimal(object sender, KeyPressEventArgs e)
		{
			// Allow control characters (backspace, delete, etc.)
			if (char.IsControl(e.KeyChar))
			{
				return;
			}

			// Allow digits and one decimal point
			if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
			{
				e.Handled = true;
			}

			// Ensure only one decimal point is allowed
			if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
			{
				e.Handled = true;
			}
		}
		public static void PreventSpecialCharacters(object sender, KeyPressEventArgs e)
		{
			// Check if the pressed key is a control key or a valid character
			if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '_')
			{
				// Cancel the key press event
				e.Handled = true;
			}
		}

		public void DisabledControlsShoe()
		{
			if (rdoShoeNo.Checked == true)
			{
				//txtShoeLen.Enabled = false;
				//txtShoeType.Enabled = false;
				txtShoeLen.Text = "";
				txtShoeType.Text = "";			
				rdoFloatNo.Checked = true;
			}
			if(rdoShoeYes.Checked == true)
			{
				//txtShoeLen.Enabled = true;
				//txtShoeType.Enabled = true;
				txtShoeLen.Text = classInit.cIniConfig.iShoeLength;
				txtShoeType.Text = classInit.cIniConfig.iShoeType;
				rdoFloatYes.Checked = true;
			}

		}

		public void DisabledControlsFloat()
		{


			if (rdoFloatNo.Checked == true)
			{
				//txtFloatLen.Enabled = false;
				//txtFloatType.Enabled = false;
				//txtFloatPos.Enabled = false;
				txtFloatLen.Text = "";
				txtFloatType.Text = "";
				txtFloatPos.Text = "";
				rdoShoeNo.Checked = true;
			}
			if (rdoFloatYes.Checked == true)
			{
				//txtFloatLen.Enabled = true;
				//txtFloatType.Enabled = true;
				//txtFloatPos.Enabled = true;
				txtFloatLen.Text = classInit.cIniConfig.iFloatLength;
				txtFloatType.Text = classInit.cIniConfig.iFloatType;
				txtFloatPos.Text = classInit.cIniConfig.iFloatPosition;
				rdoShoeYes.Checked = true;
			}

		}


private static bool IsAllowedSpecialCharacter(char c)
		{
			// Define the set of allowed special characters
			char[] allowedSpecialCharacters = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '-', '=', '[', ']', '{', '}', '\\', '|', ';', ':', '\'', '"', ',', '.', '<', '>', '/', '?' };

			// Check if the character is in the set of allowed special characters
			return Array.IndexOf(allowedSpecialCharacters, c) != -1;
		}
		private void txtNumJoint_KeyPress(object sender, KeyPressEventArgs e)
		{
			OnlyAllowNumericAndDecimal(sender, e);
		}

		private void txtShoeLen_KeyPress(object sender, KeyPressEventArgs e)
		{
			OnlyAllowNumericAndDecimal(sender, e);
		}

		private void txtFloatLen_KeyPress(object sender, KeyPressEventArgs e)
		{
			OnlyAllowNumericAndDecimal(sender, e);
		}

		private void txtFloatPos_KeyPress(object sender, KeyPressEventArgs e)
		{
			OnlyAllowNumericAndDecimal(sender, e);
		}

		private void txtRawData_TextChanged(object sender, EventArgs e)
		{

		}

		private void txtFileName_KeyPress(object sender, KeyPressEventArgs e)
		{
			PreventSpecialCharacters(sender, e);
		}

		private void rdoShoeNo_CheckedChanged(object sender, EventArgs e)
		{
			DisabledControlsShoe();
		}

		private void rdoFloatNo_CheckedChanged(object sender, EventArgs e)
		{
			DisabledControlsFloat();
		}

		private void rdoFloatYes_CheckedChanged(object sender, EventArgs e)
		{
			DisabledControlsFloat();
		}

		private void rdoShoeYes_CheckedChanged(object sender, EventArgs e)
		{
			DisabledControlsShoe();
		}

		private void rdoCT_CheckedChanged(object sender, EventArgs e)
		{
			SetFileName();
		}

		private void rdoDblChk_CheckedChanged(object sender, EventArgs e)
		{
			SetFileName();
		}
	}
}
