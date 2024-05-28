using Report_Generator;
using Russ_Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Russ_Tool
{
	public class Initializer
	{

		public DataStorage cData { get; set; }
		public ExcelReader cxlReader { get; set; }
		public FileManager cFileManager { get; set; }
		public IniConfig cIniConfig { get; set; }

		public ProgressLoader cLoadingScreen { get; set; }
		public Initializer()
		{
			cData = new DataStorage();
			cxlReader = new ExcelReader();
			cFileManager = new FileManager();
			cIniConfig = new IniConfig();
			cLoadingScreen = new ProgressLoader();

		}
	}


}
