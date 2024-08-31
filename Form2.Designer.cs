namespace Report_Generator
{
	partial class FrmFileSave
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			btnBrowse = new Button();
			label2 = new Label();
			txtFilePathDest = new TextBox();
			btnSave = new Button();
			btnCancel = new Button();
			label1 = new Label();
			SuspendLayout();
			// 
			// btnBrowse
			// 
			btnBrowse.Location = new Point(375, 40);
			btnBrowse.Name = "btnBrowse";
			btnBrowse.Size = new Size(75, 23);
			btnBrowse.TabIndex = 31;
			btnBrowse.Text = "Browse...";
			btnBrowse.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(3, 46);
			label2.Name = "label2";
			label2.Size = new Size(56, 15);
			label2.TabIndex = 30;
			label2.Text = "Location:";
			// 
			// txtFilePathDest
			// 
			txtFilePathDest.Location = new Point(63, 40);
			txtFilePathDest.Name = "txtFilePathDest";
			txtFilePathDest.ReadOnly = true;
			txtFilePathDest.Size = new Size(304, 23);
			txtFilePathDest.TabIndex = 29;
			// 
			// btnSave
			// 
			btnSave.Location = new Point(292, 79);
			btnSave.Name = "btnSave";
			btnSave.Size = new Size(75, 23);
			btnSave.TabIndex = 32;
			btnSave.Text = "Save";
			btnSave.UseVisualStyleBackColor = true;
			btnSave.Click += btnSave_Click;
			// 
			// btnCancel
			// 
			btnCancel.Location = new Point(375, 79);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 23);
			btnCancel.TabIndex = 33;
			btnCancel.Text = "Cancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += btnCancel_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(144, 11);
			label1.Name = "label1";
			label1.Size = new Size(165, 15);
			label1.TabIndex = 34;
			label1.Text = "Choose Output Folder to Save";
			// 
			// FrmFileSave
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(455, 115);
			Controls.Add(label1);
			Controls.Add(btnCancel);
			Controls.Add(btnSave);
			Controls.Add(btnBrowse);
			Controls.Add(label2);
			Controls.Add(txtFilePathDest);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Name = "FrmFileSave";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "File Location";
			TopMost = true;
			Load += FrmFileSave_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btnBrowse;
		private Label label2;
		private TextBox txtFilePathDest;
		private Button btnSave;
		private Button btnCancel;
		private Label label1;
	}
}