using DocumentFormat.OpenXml.Spreadsheet;
using SharpConfig;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Configuration = SharpConfig.Configuration;

namespace Russ_Tool
{
	public class IniConfig
	{
		
		public string iDate = "";
		public string iCasingDetails = "";
		public string iWellInformation = "";
		public string iRunOperator1 = "";
		public string iRunOperator2 = "";
		//public string iNumberOfJoints = "";
		public string iShoeType = "";
		public string iShoeLength = "";
		public string iFloatLength = "";
		public string iFloatType = "";
		public string iFloatPosition = "";
		public string iFileName = "";
		//public string iRawFile = "";
		public string iFileDestination = "";
		public string iDoubleCheckTemplatePath = "";
		public string iCasingTallyTemplatePath = "";



		public bool EnableGenerate = true;
		private string configFileName = "Config.ini";

		public bool CheckConfigExist()
		{

			string exeFilePath = Application.ExecutablePath;
			string getFolder = Path.GetDirectoryName(exeFilePath);
			string cTempFolder = "";
			try
			{
				string[] files = Directory.GetFiles(getFolder);
				foreach (string file in files)
				{
					string pFilename = Path.GetFileName(file).ToUpper();
					if (pFilename == configFileName.ToUpper())
					{
						return true;
					}
				}

			}
			catch (Exception ex) { EnableGenerate = false;  return false; }
			EnableGenerate = false;
			return false;
		}

		//---------------------------------------------


		public bool ReadConfig()
		{
			if (CheckConfigExist())
			{
				Configuration cfg = new Configuration();
				cfg = SharpConfig.Configuration.LoadFromFile(configFileName);
				var DefVal = cfg["DefaultValue"];
				iDate = DefVal["Date"].StringValue;
				iCasingDetails = DefVal["CasingDetails"].StringValue;
				iWellInformation = DefVal["WellInformatio"].StringValue;
				iRunOperator1 = DefVal["RunOperator1"].StringValue;
				iRunOperator2 = DefVal["RunOperator2"].StringValue;
				//iNumberOfJoints = DefVal["NumberOfJoints"].StringValue;
				iShoeType = DefVal["ShoeType"].StringValue;
				iShoeLength = DefVal["ShoeLength"].StringValue;
				iFloatLength = DefVal["FloatLength"].StringValue;
				iFloatPosition = DefVal["FloatPosition"].StringValue;
				iFileName = DefVal["FileName"].StringValue;
				//iRawFile = DefVal["RawFile"].StringValue;
				iFileDestination = DefVal["FileDestination"].StringValue;
				iFloatType = DefVal["FloatType"].StringValue;
				iDoubleCheckTemplatePath = DefVal["DoubleCheckTemplatePath"].StringValue;
				iCasingTallyTemplatePath = DefVal["CasingTallyTemplatePath"].StringValue;
				if (string.IsNullOrEmpty(iDoubleCheckTemplatePath) || string.IsNullOrEmpty(iCasingTallyTemplatePath)) { EnableGenerate = false; }
				else {  EnableGenerate = true; }

			}
			else { return false; }
			return true;
		}

		//public bool UpdateConfigValues()
		//{
		//	try
		//	{
		//		Form1 mMain = new Form1();
		//		// Load the existing configuration file
		//		Configuration cfg = SharpConfig.Configuration.LoadFromFile(configFileName);

		//		// Get the section where your values are stored
		//		var DefVal = cfg["DefaultValue"];


		//		// Update the values with the current properties
		//		DefVal["Date"].StringValue = Main.CL
		//		DefVal["CasingDetails"].StringValue = mMain.pCD;
		//		DefVal["WellInformatio"].StringValue = mMain.pWI;
		//		DefVal["RunOperator1"].StringValue = mMain.pRO1;
		//		DefVal["RunOperator2"].StringValue = mMain.pRO2;
		//		//DefVal["NumberOfJoints"].StringValue = iNumberOfJoints;
		//		DefVal["ShoeType"].StringValue = mMain.pShoeType;
		//		DefVal["ShoeLength"].StringValue = mMain.pShoeLen.ToString();
		//		DefVal["FloatLength"].StringValue = mMain.pFloatLen.ToString();
		//		DefVal["FloatPosition"].StringValue = mMain.pFloatPos.ToString();
		//		DefVal["FileName"].StringValue = iFileName;
		//		//DefVal["RawFile"].StringValue = iRawFile;
		//		DefVal["FileDestination"].StringValue = iFileDestination;
		//		DefVal["FloatType"].StringValue = iFloatType;
		//		DefVal["DoubleCheckTemplatePath"].StringValue = iDoubleCheckTemplatePath;
		//		DefVal["CasingTallyTemplatePath"].StringValue = iCasingTallyTemplatePath;

		//		// Save the updated configuration back to the file
		//		cfg.SaveToFile(configFileName);

		//		return true;
		//	}
		//	catch (Exception ex)
		//	{
		//		// Handle exceptions if necessary
		//		return false;
		//	}
		//}


	}
}
