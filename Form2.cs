using Russ_Tool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Report_Generator
{
	public partial class FrmFileSave : Form
	{
	
		private Form1 _form1;
		public FrmFileSave(Form1 mainform)
		{
			InitializeComponent();
			_form1 = mainform;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			//closeForm = true;
			this.Close();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			//activateForm = true;
		}

		private void FrmFileSave_Load(object sender, EventArgs e)
		{
			//activateForm = false;
			//closeForm = false;
		}
	}
}
