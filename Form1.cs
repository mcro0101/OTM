using DocumentFormat.OpenXml.Math;
using Report_Generator;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

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
        public string pFloatType = "";
        public double pShoeLen = 0;
        public double pFloatLen = 0;
        public int pFloatPos = 0;
        public string pFilename = "";
        public string pFileDest = "";
        public string SelectedTemplate = "";
        public int SelectedReport = 0; //0 For Double Check, 1 for Casing Tally
        public bool shoeExist = false;
        public bool floatExist = false;
        public int tempJointVal = 0;
        private FrmFileSave frmFileSaver;





        public Form1()
        {
            InitializeComponent();
            classInit = new Initializer();
            //frmFileSaver = _frmFileSaver;

            this.AutoScrollPosition = new Point(0, 0);
            this.Resize += new EventHandler(Form1_Resize);


        }

        public void InitializeControls()
        {
            if (classInit.cIniConfig.EnableGenerate == false)
            { //btnGenerate.Enabled = false; btnGenerate.BackColor = Color.FromArgb(255, 0, 0); 
                MessageBox.Show("The filepath specified in the config.ini is invalid. Please ensure the correct path is specified before running the application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                foreach (Control control in this.Controls)
                {
                    control.Enabled = false;
                }
            }
            else { btnGenerate.Enabled = true; }
            dtpDates.Format = DateTimePickerFormat.Custom;
            dtpDates.CustomFormat = "MM-dd-yyyy";
            //txtDate.Text = classInit.cIniConfig.iDate;
            txtCD.Text = classInit.cIniConfig.iCasingDetails;
            txtWI.Text = classInit.cIniConfig.iWellInformation;
            txtRO1.Text = classInit.cIniConfig.iRunOperator1;
            txtRO2.Text = classInit.cIniConfig.iRunOperator2;
            //txtNumJoint.Text = classInit.cIniConfig.iNumberOfJoints;
            txtShoeType.Text = classInit.cIniConfig.iShoeType;
            txtShoeLen.Text = classInit.cIniConfig.iShoeLength;
            txtFloatLen.Text = classInit.cIniConfig.iFloatLength;
            txtFloatType.Text = classInit.cIniConfig.iFloatType;
            txtFloatPos.Text = classInit.cIniConfig.iFloatPosition;
            classInit.cData.dDoubleChecke = classInit.cIniConfig.iDoubleCheckTemplatePath;
            classInit.cData.dCasingTallySF = classInit.cIniConfig.iCasingTallyTemplatePath;
            //txtFileName.Text = classInit.cIniConfig.iFileName;
            //txtRawData.Text = classInit.cIniConfig.iRawFile;
            txtRawData.Text = "";
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
            string f_WI = txtWI.Text;
            string f_CD = txtCD.Text;
            string nowDate = DateTime.Now.ToString("MM-dd-yy");
            //nowDate = nowDate.Replace("-", "");
            string dtDate = dtpDates.Value.ToString("MM-dd-yy");


            if (rdoDblChk.Checked == true)
            {
                txtFileName.Text = f_WI + " " + f_CD + " " + "Double Check Tally " + dtDate;
            }
            else if (rdoCT.Checked == true)
            {
                txtFileName.Text = f_WI + " " + f_CD + " " + "Casing Tally " + dtDate;
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
            classInit.cData.dFloatType = pFloatType;
            classInit.cData.dShoeLength = pShoeLen;
            classInit.cData.dFloatLength = pFloatLen;
            classInit.cData.dFloatPosition = pFloatPos;
        }
        public void InitiliazeConst()
        {
            //pDate = txtDate.Text;
            pDate = dtpDates.Text;
            pCD = txtCD.Text;
            pWI = txtWI.Text;
            pRO1 = txtRO1.Text;
            pRO2 = txtRO2.Text;
            pNumJoints = txtNumJoint.Text;
            pRawDataPath = txtRawData.Text;
            pShoeType = txtShoeType.Text;
            pFloatType = txtFloatType.Text;
            pShoeLen = classInit.cxlReader.ConvertStringToDouble(txtShoeLen.Text);
            pFloatLen = classInit.cxlReader.ConvertStringToDouble(txtFloatLen.Text);
            if (string.IsNullOrEmpty(txtFloatPos.Text) == false) { pFloatPos = int.Parse(txtFloatPos.Text); }
            else { pFloatPos = 0; }
            pFilename = txtFileName.Text;
            pFileDest = txtFilePathDest.Text;
            InitializeShoeFloat();
        }

        private void InitializeShoeFloat()
        {
            if (rdoShoeNo.Checked == true) { shoeExist = false; } else { shoeExist = true; }
            if (rdoShoeYes.Checked == true) { shoeExist = true; } else { shoeExist = false; }
            if (rdoFloatNo.Checked == true) { floatExist = false; } else { floatExist = true; }
            if (rdoFloatYes.Checked == true) { floatExist = true; } else { floatExist = false; }
        }

        private void Initialize()
        {
            classInit.cIniConfig.ReadConfig();

            InitializeControls();

            //classInit.cFileSaveForm.Show();
            //if (frmFileSaver.activateForm == false)
            //{this.Enabled = false;} else{this.Enabled = true;}

            //if (frmFileSaver.closeForm == true) { this.Close(); }
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
            //classInit.cLoadingScreen.Show();
            int RawMaxRows = classInit.cxlReader.GetMaxRowsInWorkbook(txtRawData.Text);
            txtNumJoint.Text = RawMaxRows.ToString();
            tempJointVal = RawMaxRows;
            //classInit.cLoadingScreen.StopLoading();
        }

        private void btnFilePath_Click(object sender, EventArgs e)
        {
            string cListedpath = classInit.cIniConfig.iFileDestination;
            txtFilePathDest.Text = classInit.cFileManager.BrowseFolder(cListedpath);
        }

        //private void UpdateConfigVal()
        //{
        //	// Update string values directly
        //	classInit.cData.dDate = txtDate.Text;
        //	classInit.cData.dCasingDetails = txtCD.Text;
        //	classInit.cData.dWellInformation = txtWI.Text;
        //	classInit.cData.dRunOperator1 = txtRO1.Text;
        //	classInit.cData.dRunOperator2 = txtRO2.Text;
        //	classInit.cData.dNumberOfJoints = txtNumJoint.Text;
        //	classInit.cData.dShoeType = txtShoeType.Text;

        //	// Parse and update double values with error handling
        //	if (double.TryParse(txtShoeLen.Text, out double shoeLength)){classInit.cData.dShoeLength = shoeLength;}
        //	else {classInit.cData.dShoeLength = 0;}
        //	if (double.TryParse(txtFloatLen.Text, out double floatLength)){classInit.cData.dFloatLength = floatLength;}
        //	else {classInit.cData.dFloatLength = 0;}
        //	// Parse and update int values with error handling
        //	if (int.TryParse(txtFloatPos.Text, out int floatPosition)){classInit.cData.dFloatPosition = floatPosition;}
        //	else {classInit.cData.dFloatPosition = 0;}
        //	// Save the updated configuration values
        //	classInit.cIniConfig.UpdateConfigValues();
        //}


        private void btnGenerate_Click(object sender, EventArgs e)
        {
            InitiliazeConst();
            StoreData();
            //classInit.cIniConfig.UpdateConfigValues(); 
            string pPath = pFileDest;
            string valReport = GetSelectedReport();
            if (string.IsNullOrEmpty(pRawDataPath)) { MessageBox.Show("Raw data input file not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }


            // Show loading screen


            if (pPath != "")
            {
                //classInit.cxlReader.ReadDataFromExcel(pPath, "Sheet1");
                string newFileDest = pFileDest + "\\" + pFilename + ".xlsx";
                classInit.cFileManager.CheckAndDeleteFile(newFileDest);
                classInit.cFileManager.CopyFile(valReport, newFileDest);
                classInit.cxlReader.ReplaceTextInExcel(newFileDest, pFilename, classInit.cData.InsertDictionary());
                if (SelectedReport == 0)
                {

                    classInit.cxlReader.InsertDataToDoubleCheck(pRawDataPath, newFileDest, newFileDest, pFilename, int.Parse(pNumJoints));
                    //classInit.cLoadingScreen.StopLoading();
                }
                if (SelectedReport == 1)
                {
                    if (checkMaxRowsCorrect() == false) { MessageBox.Show($"The number of joints cannot exceed {tempJointVal}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; };
                    if (string.IsNullOrEmpty(pNumJoints) || int.Parse(pNumJoints) == 0) { MessageBox.Show("Invalid Number of Joints", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    if (floatExist == true) { if (pFloatPos == 0) { MessageBox.Show("Invalid Float Position", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; } }
                    //classInit.cLoadingScreen.Show();
                    classInit.cxlReader.GetShoeFloatConditions(shoeExist, floatExist, pFloatPos, pShoeLen, pFloatLen);
                    classInit.cxlReader.InsertDataToCasingTally(pRawDataPath, newFileDest, newFileDest, pFilename, int.Parse(pNumJoints), pShoeType, pFloatType);
                    //classInit.cLoadingScreen.StopLoading();
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


        private void OnlyAllowNumeric(object sender, KeyPressEventArgs e)
        {
            // Allow control characters (backspace, delete, etc.)
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Allow digits only
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            // Get the current text in the TextBox
            string currentText = (sender as TextBox).Text;

            // Calculate the new value if the key is pressed
            string newText = currentText + e.KeyChar;

            // Check if the new value exceeds 1 million
            if (int.TryParse(newText, out int result) && result > 1000000)
            {
                e.Handled = true;
                MessageBox.Show("Number is too large", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool checkMaxRowsCorrect()
        {
            if (int.Parse(txtNumJoint.Text) <= tempJointVal) { return true; }
            return false;
        }
        public static void PreventSpecialCharacters(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a control key or a valid character (letters, digits, underscore, or dash)
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '_' && e.KeyChar != '-' && e.KeyChar != ' ' && e.KeyChar != '.' && e.KeyChar != '#')
            {
                string pInch = "inch";
                string pM = e.KeyChar.ToString();

                // Check if the pressed key is a slash "/"
                if (e.KeyChar == '/')
                {
                    // Show a message box indicating that slash is not allowed and suggest using "-"
                    MessageBox.Show($"Slash is not allowed. Use '-' (dash) instead. \nExample: instead of 1/2, use: 1-2, or .5 ", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else if (e.KeyChar == '"')
                {
                    // Show a message box indicating that the inch symbol is not allowed and suggest using inch symbol instead
                    MessageBox.Show($"Inch symbol is not allowed. Use '{pInch}' instead. \nExample: 7 inch, etc.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    // Show a message box indicating that other special characters are not allowed
                    MessageBox.Show($"Special characters are not allowed.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

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
                txtShoeLen.Enabled = false;
                txtShoeType.Enabled = false;

            }
            if (rdoShoeYes.Checked == true)
            {
                //txtShoeLen.Enabled = true;
                //txtShoeType.Enabled = true;
                txtShoeLen.Text = classInit.cIniConfig.iShoeLength;
                txtShoeType.Text = classInit.cIniConfig.iShoeType;
                txtShoeLen.Enabled = true;
                txtShoeType.Enabled = true;

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
                txtFloatLen.Enabled = false;
                txtFloatType.Enabled = false;
                txtFloatPos.Enabled = false;


            }
            if (rdoFloatYes.Checked == true)
            {
                //txtFloatLen.Enabled = true;
                //txtFloatType.Enabled = true;
                //txtFloatPos.Enabled = true;
                txtFloatLen.Text = classInit.cIniConfig.iFloatLength;
                txtFloatType.Text = classInit.cIniConfig.iFloatType;
                txtFloatPos.Text = classInit.cIniConfig.iFloatPosition;
                txtFloatLen.Enabled = true;
                txtFloatType.Enabled = true;
                txtFloatPos.Enabled = true;

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
            OnlyAllowNumeric(sender, e);
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
            OnlyAllowNumeric(sender, e);
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

        private void txtCD_TextChanged(object sender, EventArgs e)
        {
            SetFileName();
        }

        private void txtWI_TextChanged(object sender, EventArgs e)
        {
            SetFileName();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {

            SetFileName();
        }

        private void dtpDate_DataContextChanged(object sender, EventArgs e)
        {
            SetFileName();

        }

        private void txtCD_KeyPress(object sender, KeyPressEventArgs e)
        {
            PreventSpecialCharacters(sender, e);
        }

        private void txtWI_KeyPress(object sender, KeyPressEventArgs e)
        {
            PreventSpecialCharacters(sender, e);
        }

        private bool isMovedDown = false; // Track if the group boxes have already been moved down




        private void Form1_Resize(object sender, EventArgs e)
        {
         
          
            int formWidth = this.ClientSize.Width;


            int btn1Hgt = button1.Height;
           // int btnGenHgt = btnGenerate.Height;

            if (formWidth < 500 && !isMovedDown)
            {
                DummyPan.Hide();
                DummyPanGen.Hide();
        
                // Move panel1 down by the height of button1 plus an additional 5 units
                panel1.Location = new Point(panel1.Location.X, Dummy1.Bottom + (btn1Hgt + 5));              
                button1.Location = new Point(Dummy1.Left, button1.Location.Y);
                btnGenerate.Location = new Point(DummyPan.Left, panel1.Bottom);
                isMovedDown = true;
            }
            else if (formWidth >= 500 && isMovedDown)
            {
                DummyPan.Hide();
               
                button1.Location = new Point(panel1.Right, button1.Location.Y);
                btnGenerate.Location = new Point(panel1.Right, DummyPanGen.Bottom);
                panel1.Location = new Point(panel1.Location.X, Dummy1.Bottom);

                isMovedDown = false;
            }

        }
    }
}
