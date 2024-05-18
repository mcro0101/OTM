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
		public string pRawDate = "";
		public string pShoeType = "";
		public string pShoeLen = "";
		public string pFloatLen = "";
		public string pFloatPos = "";
		public string pFilename = "";
		public string pFileDest = "";
		private ExcelSys excelReader;
		public Form1()
		{
			InitializeComponent();
			excelReader = new ExcelSys();
			classInit = new Initializer();
		}

		public void InitializeTextBoxValues()
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
			txtFileName.Text = classInit.cIniConfig.iFileName;
			txtRawData.Text = classInit.cIniConfig.iRawFile;
			txtFilePathDest.Text = classInit.cIniConfig.iFileDestination;
			rdoDblChk.Checked = true;
			rdoFloatNo.Checked = true;
			rdoShoeNo.Checked = true;

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
			classInit.cData.dCasingTallyNSNF = "C:\\TEMP\\Templates\\OTM Casing Tally Template 400 Joint NO SHOE NO FLOAT Version.xltx";
			classInit.cData.dCasingTallySF = "C:\\TEMP\\Templates\\OTM Casing Tally Template 400 Joint SHOE and FLOAT Version.xltx";
			pDate = txtDate.Text;
			pCD = txtCD.Text;
			pWI = txtWI.Text;
			pRO1 = txtRO1.Text;
			pRO2 = txtRO2.Text;
			pNumJoints = txtNumJoint.Text;
			pRawDate = txtRawData.Text;
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
			InitializeTextBoxValues();


		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Initialize();
		}

		private void btnRawData_Click(object sender, EventArgs e)
		{
			txtRawData.Text = classInit.cxlReader.BrowseExcelFile();
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
			if (pPath != "")
			{
				//classInit.cxlReader.ReadDataFromExcel(pPath, "Sheet1");
				string newFileDest = pFileDest + "\\" + pFilename + ".xlsx";
				classInit.cFileManager.CopyFile(classInit.cData.dDoubleChecke, newFileDest);
				classInit.cxlReader.ReplaceTextInExcel(newFileDest, pFilename, classInit.cData.InsertDictionary());
			}
		}
	}
}
