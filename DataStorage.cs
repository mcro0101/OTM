using Russ_Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Russ_Tool
{
	public class DataStorage
	{
		private Form1 cMainForm;
		// Date
		public string dDate { get; set; }

		// Casing Details
		public string dCasingDetails { get; set; }

		// Well Information
		public string dWellInformation { get; set; }

		// Run #1 Operator
		public string dRunOperator1 { get; set; }

		// Run #2 Operator
		public string dRunOperator2 { get; set; }

		// Number of Joints
		public string dNumberOfJoints { get; set; }

		// Shoe Type
		public string dShoeType { get; set; }

		// Shoe Length
		public double dShoeLength { get; set; }

		// Float length
		public double dFloatLength { get; set; }

		// Float Position
		public int dFloatPosition { get; set; }

		// File Name of the File
		public string dFileName { get; set; }

		// File Input
		public string dRawFile { get; set; }

		// Filepath destination
		public string dFileDestination { get; set; }

		public string dDoubleChecke { get; set; }

		public string dCasingTallyNSNF { get; set; }

		public string dCasingTallySF { get; set; }
		//-----------------------------------FOR RAW FILE DATA----------------------------------------//

		//public void StoreData(string date, string casingDetails, string wellInformation, string runOperator1, string runOperator2, string numberOfJoints, string shoeType, string shoeLength, string floatLength, string floatPosition)
		//{
		//	dDate = date;
		//	dCasingDetails = casingDetails;
		//	dWellInformation = wellInformation;
		//	dRunOperator1 = runOperator1;
		//	dRunOperator2 = runOperator2;
		//	dNumberOfJoints = numberOfJoints;
		//	dShoeType = shoeType;
		//	dShoeLength = shoeLength;
		//	dFloatLength = floatLength;
		//	dFloatPosition = floatPosition;
		//}

		public Dictionary<string, string> InsertDictionary()
		{
			Dictionary<string, string> dataDictionary = new Dictionary<string, string>();

			try
			{
				// Add data to the dictionary
				dataDictionary.Add("{pdate}", dDate);
				dataDictionary.Add("{pWI}", dWellInformation);
				dataDictionary.Add("{pCD}", dCasingDetails);
				dataDictionary.Add("{pRO1}", dRunOperator1);
				dataDictionary.Add("{pRO2}", dRunOperator2);

				// Add more key-value pairs as needed
			}
			catch (Exception ex)
			{
				return null;
				// Handle or log the exception as required
			}

			return dataDictionary;
		}

	}
}
