namespace Russ_Tool
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			label1 = new Label();
			btnGenerate = new Button();
			rdoCT = new RadioButton();
			rdoDblChk = new RadioButton();
			txtDate = new TextBox();
			txtCD = new TextBox();
			txtWI = new TextBox();
			txtRO1 = new TextBox();
			txtRO2 = new TextBox();
			label3 = new Label();
			label4 = new Label();
			label5 = new Label();
			groupBox1 = new GroupBox();
			label12 = new Label();
			txtNumJoint = new TextBox();
			label11 = new Label();
			groupBox2 = new GroupBox();
			label7 = new Label();
			txtFloatLen = new TextBox();
			label19 = new Label();
			rdoFloatNo = new RadioButton();
			rdoFloatYes = new RadioButton();
			rdoShoeNo = new RadioButton();
			label13 = new Label();
			rdoShoeYes = new RadioButton();
			label14 = new Label();
			txtFloatPos = new TextBox();
			label15 = new Label();
			label16 = new Label();
			txtShoeType = new TextBox();
			txtShoeLen = new TextBox();
			txtFloatType = new TextBox();
			label17 = new Label();
			label18 = new Label();
			button1 = new Button();
			txtFilePathDest = new TextBox();
			txtFileName = new TextBox();
			label2 = new Label();
			label6 = new Label();
			groupBox3 = new GroupBox();
			btnFilePathDest = new Button();
			btnImportRaw = new Button();
			txtRawData = new TextBox();
			groupBox4 = new GroupBox();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox3.SuspendLayout();
			groupBox4.SuspendLayout();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(19, 92);
			label1.Name = "label1";
			label1.Size = new Size(99, 15);
			label1.TabIndex = 1;
			label1.Text = "Well Information:";
			// 
			// btnGenerate
			// 
			btnGenerate.Font = new Font("Segoe UI", 13F);
			btnGenerate.Location = new Point(429, 563);
			btnGenerate.Name = "btnGenerate";
			btnGenerate.Size = new Size(117, 95);
			btnGenerate.TabIndex = 5;
			btnGenerate.Text = "Generate";
			btnGenerate.UseVisualStyleBackColor = true;
			btnGenerate.Click += btnGenerate_Click;
			// 
			// rdoCT
			// 
			rdoCT.AutoSize = true;
			rdoCT.Location = new Point(169, 41);
			rdoCT.Name = "rdoCT";
			rdoCT.Size = new Size(99, 19);
			rdoCT.TabIndex = 6;
			rdoCT.TabStop = true;
			rdoCT.Text = "Double Check";
			rdoCT.UseVisualStyleBackColor = true;
			// 
			// rdoDblChk
			// 
			rdoDblChk.AutoSize = true;
			rdoDblChk.Location = new Point(284, 41);
			rdoDblChk.Name = "rdoDblChk";
			rdoDblChk.Size = new Size(87, 19);
			rdoDblChk.TabIndex = 7;
			rdoDblChk.TabStop = true;
			rdoDblChk.Text = "Casing Tally";
			rdoDblChk.UseVisualStyleBackColor = true;
			// 
			// txtDate
			// 
			txtDate.Location = new Point(123, 31);
			txtDate.Name = "txtDate";
			txtDate.Size = new Size(180, 23);
			txtDate.TabIndex = 8;
			// 
			// txtCD
			// 
			txtCD.Location = new Point(123, 60);
			txtCD.Name = "txtCD";
			txtCD.Size = new Size(180, 23);
			txtCD.TabIndex = 9;
			// 
			// txtWI
			// 
			txtWI.Location = new Point(123, 89);
			txtWI.Name = "txtWI";
			txtWI.Size = new Size(180, 23);
			txtWI.TabIndex = 10;
			// 
			// txtRO1
			// 
			txtRO1.Location = new Point(123, 118);
			txtRO1.Name = "txtRO1";
			txtRO1.Size = new Size(180, 23);
			txtRO1.TabIndex = 11;
			// 
			// txtRO2
			// 
			txtRO2.Location = new Point(123, 147);
			txtRO2.Name = "txtRO2";
			txtRO2.Size = new Size(180, 23);
			txtRO2.TabIndex = 12;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(19, 121);
			label3.Name = "label3";
			label3.Size = new Size(97, 15);
			label3.TabIndex = 13;
			label3.Text = "Run #1 Operator:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(19, 63);
			label4.Name = "label4";
			label4.Size = new Size(84, 15);
			label4.TabIndex = 14;
			label4.Text = "Casing Details:";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(19, 34);
			label5.Name = "label5";
			label5.Size = new Size(34, 15);
			label5.TabIndex = 15;
			label5.Text = "Date:";
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(label12);
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(txtNumJoint);
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(label11);
			groupBox1.Controls.Add(txtDate);
			groupBox1.Controls.Add(txtCD);
			groupBox1.Controls.Add(txtWI);
			groupBox1.Controls.Add(txtRO1);
			groupBox1.Controls.Add(txtRO2);
			groupBox1.Controls.Add(label3);
			groupBox1.Controls.Add(label4);
			groupBox1.ForeColor = SystemColors.ActiveCaptionText;
			groupBox1.Location = new Point(12, 4);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(378, 225);
			groupBox1.TabIndex = 21;
			groupBox1.TabStop = false;
			groupBox1.Text = "Job Details";
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.Location = new Point(19, 179);
			label12.Name = "label12";
			label12.Size = new Size(98, 15);
			label12.TabIndex = 24;
			label12.Text = "Number of Joints";
			// 
			// txtNumJoint
			// 
			txtNumJoint.Location = new Point(123, 176);
			txtNumJoint.Name = "txtNumJoint";
			txtNumJoint.Size = new Size(180, 23);
			txtNumJoint.TabIndex = 23;
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Location = new Point(19, 150);
			label11.Name = "label11";
			label11.Size = new Size(97, 15);
			label11.TabIndex = 22;
			label11.Text = "Run #2 Operator:";
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(label7);
			groupBox2.Controls.Add(txtFloatLen);
			groupBox2.Controls.Add(label19);
			groupBox2.Controls.Add(rdoFloatNo);
			groupBox2.Controls.Add(rdoFloatYes);
			groupBox2.Controls.Add(rdoShoeNo);
			groupBox2.Controls.Add(label13);
			groupBox2.Controls.Add(rdoShoeYes);
			groupBox2.Controls.Add(label14);
			groupBox2.Controls.Add(txtFloatPos);
			groupBox2.Controls.Add(label15);
			groupBox2.Controls.Add(label16);
			groupBox2.Controls.Add(txtShoeType);
			groupBox2.Controls.Add(txtShoeLen);
			groupBox2.Controls.Add(txtFloatType);
			groupBox2.Controls.Add(label17);
			groupBox2.Controls.Add(label18);
			groupBox2.ForeColor = SystemColors.ActiveCaptionText;
			groupBox2.Location = new Point(13, 291);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(378, 252);
			groupBox2.TabIndex = 22;
			groupBox2.TabStop = false;
			groupBox2.Text = "Float Equipment";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(18, 149);
			label7.Name = "label7";
			label7.Size = new Size(76, 15);
			label7.TabIndex = 29;
			label7.Text = "Float Length:";
			// 
			// txtFloatLen
			// 
			txtFloatLen.Location = new Point(122, 146);
			txtFloatLen.Name = "txtFloatLen";
			txtFloatLen.Size = new Size(180, 23);
			txtFloatLen.TabIndex = 28;
			// 
			// label19
			// 
			label19.AutoSize = true;
			label19.Location = new Point(4, 225);
			label19.Name = "label19";
			label19.Size = new Size(119, 15);
			label19.TabIndex = 27;
			label19.Text = "(After  Joint Number)";
			// 
			// rdoFloatNo
			// 
			rdoFloatNo.AutoSize = true;
			rdoFloatNo.Location = new Point(227, 120);
			rdoFloatNo.Name = "rdoFloatNo";
			rdoFloatNo.Size = new Size(41, 19);
			rdoFloatNo.TabIndex = 26;
			rdoFloatNo.TabStop = true;
			rdoFloatNo.Text = "No";
			rdoFloatNo.UseVisualStyleBackColor = true;
			// 
			// rdoFloatYes
			// 
			rdoFloatYes.AutoSize = true;
			rdoFloatYes.Location = new Point(147, 120);
			rdoFloatYes.Name = "rdoFloatYes";
			rdoFloatYes.Size = new Size(42, 19);
			rdoFloatYes.TabIndex = 25;
			rdoFloatYes.TabStop = true;
			rdoFloatYes.Text = "Yes";
			rdoFloatYes.UseVisualStyleBackColor = true;
			// 
			// rdoShoeNo
			// 
			rdoShoeNo.AutoSize = true;
			rdoShoeNo.Location = new Point(227, 29);
			rdoShoeNo.Name = "rdoShoeNo";
			rdoShoeNo.Size = new Size(41, 19);
			rdoShoeNo.TabIndex = 24;
			rdoShoeNo.TabStop = true;
			rdoShoeNo.Text = "No";
			rdoShoeNo.UseVisualStyleBackColor = true;
			// 
			// label13
			// 
			label13.AutoSize = true;
			label13.Location = new Point(18, 207);
			label13.Name = "label13";
			label13.Size = new Size(82, 15);
			label13.TabIndex = 24;
			label13.Text = "Float Position:";
			// 
			// rdoShoeYes
			// 
			rdoShoeYes.AutoSize = true;
			rdoShoeYes.Location = new Point(147, 29);
			rdoShoeYes.Name = "rdoShoeYes";
			rdoShoeYes.Size = new Size(42, 19);
			rdoShoeYes.TabIndex = 23;
			rdoShoeYes.TabStop = true;
			rdoShoeYes.Text = "Yes";
			rdoShoeYes.UseVisualStyleBackColor = true;
			// 
			// label14
			// 
			label14.AutoSize = true;
			label14.Location = new Point(18, 33);
			label14.Name = "label14";
			label14.Size = new Size(36, 15);
			label14.TabIndex = 15;
			label14.Text = "Shoe:";
			// 
			// txtFloatPos
			// 
			txtFloatPos.Location = new Point(122, 211);
			txtFloatPos.Name = "txtFloatPos";
			txtFloatPos.Size = new Size(180, 23);
			txtFloatPos.TabIndex = 23;
			// 
			// label15
			// 
			label15.AutoSize = true;
			label15.Location = new Point(18, 91);
			label15.Name = "label15";
			label15.Size = new Size(76, 15);
			label15.TabIndex = 1;
			label15.Text = "Shoe Length:";
			// 
			// label16
			// 
			label16.AutoSize = true;
			label16.Location = new Point(20, 178);
			label16.Name = "label16";
			label16.Size = new Size(60, 15);
			label16.TabIndex = 22;
			label16.Text = "Float Type";
			// 
			// txtShoeType
			// 
			txtShoeType.Location = new Point(122, 54);
			txtShoeType.Name = "txtShoeType";
			txtShoeType.Size = new Size(180, 23);
			txtShoeType.TabIndex = 9;
			// 
			// txtShoeLen
			// 
			txtShoeLen.Location = new Point(122, 88);
			txtShoeLen.Name = "txtShoeLen";
			txtShoeLen.Size = new Size(180, 23);
			txtShoeLen.TabIndex = 10;
			// 
			// txtFloatType
			// 
			txtFloatType.Location = new Point(122, 175);
			txtFloatType.Name = "txtFloatType";
			txtFloatType.Size = new Size(180, 23);
			txtFloatType.TabIndex = 12;
			// 
			// label17
			// 
			label17.AutoSize = true;
			label17.Location = new Point(20, 120);
			label17.Name = "label17";
			label17.Size = new Size(36, 15);
			label17.TabIndex = 13;
			label17.Text = "Float:";
			// 
			// label18
			// 
			label18.AutoSize = true;
			label18.Location = new Point(18, 62);
			label18.Name = "label18";
			label18.Size = new Size(63, 15);
			label18.TabIndex = 14;
			label18.Text = "Shoe Type:";
			// 
			// button1
			// 
			button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
			button1.BackgroundImageLayout = ImageLayout.Stretch;
			button1.FlatAppearance.BorderColor = Color.LightGray;
			button1.FlatStyle = FlatStyle.Flat;
			button1.ImageAlign = ContentAlignment.MiddleRight;
			button1.Location = new Point(398, 12);
			button1.Name = "button1";
			button1.Size = new Size(169, 142);
			button1.TabIndex = 23;
			button1.UseVisualStyleBackColor = true;
			// 
			// txtFilePathDest
			// 
			txtFilePathDest.Location = new Point(21, 90);
			txtFilePathDest.Name = "txtFilePathDest";
			txtFilePathDest.ReadOnly = true;
			txtFilePathDest.Size = new Size(280, 23);
			txtFilePathDest.TabIndex = 25;
			// 
			// txtFileName
			// 
			txtFileName.Location = new Point(21, 40);
			txtFileName.Name = "txtFileName";
			txtFileName.Size = new Size(118, 23);
			txtFileName.TabIndex = 24;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(6, 69);
			label2.Name = "label2";
			label2.Size = new Size(167, 15);
			label2.TabIndex = 26;
			label2.Text = "File Path Destination Location:";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(6, 19);
			label6.Name = "label6";
			label6.Size = new Size(63, 15);
			label6.TabIndex = 27;
			label6.Text = "File Name:";
			// 
			// groupBox3
			// 
			groupBox3.Controls.Add(btnFilePathDest);
			groupBox3.Controls.Add(label6);
			groupBox3.Controls.Add(label2);
			groupBox3.Controls.Add(txtFileName);
			groupBox3.Controls.Add(txtFilePathDest);
			groupBox3.Controls.Add(rdoDblChk);
			groupBox3.Controls.Add(rdoCT);
			groupBox3.ForeColor = SystemColors.ActiveCaptionText;
			groupBox3.Location = new Point(13, 545);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new Size(377, 121);
			groupBox3.TabIndex = 28;
			groupBox3.TabStop = false;
			groupBox3.Text = "Save File";
			// 
			// btnFilePathDest
			// 
			btnFilePathDest.Location = new Point(297, 90);
			btnFilePathDest.Name = "btnFilePathDest";
			btnFilePathDest.Size = new Size(75, 23);
			btnFilePathDest.TabIndex = 28;
			btnFilePathDest.Text = "Open...";
			btnFilePathDest.UseVisualStyleBackColor = true;
			btnFilePathDest.Click += btnFilePath_Click;
			// 
			// btnImportRaw
			// 
			btnImportRaw.FlatAppearance.BorderColor = Color.Black;
			btnImportRaw.Location = new Point(297, 22);
			btnImportRaw.Name = "btnImportRaw";
			btnImportRaw.Size = new Size(75, 23);
			btnImportRaw.TabIndex = 30;
			btnImportRaw.Text = "Open...";
			btnImportRaw.UseVisualStyleBackColor = true;
			btnImportRaw.Click += btnRawData_Click;
			// 
			// txtRawData
			// 
			txtRawData.Location = new Point(21, 22);
			txtRawData.Name = "txtRawData";
			txtRawData.ReadOnly = true;
			txtRawData.Size = new Size(280, 23);
			txtRawData.TabIndex = 29;
			// 
			// groupBox4
			// 
			groupBox4.Controls.Add(txtRawData);
			groupBox4.Controls.Add(btnImportRaw);
			groupBox4.Location = new Point(12, 232);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new Size(378, 56);
			groupBox4.TabIndex = 32;
			groupBox4.TabStop = false;
			groupBox4.Text = "Raw Data Input file:";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(243, 243, 243);
			ClientSize = new Size(576, 677);
			Controls.Add(groupBox4);
			Controls.Add(groupBox3);
			Controls.Add(button1);
			Controls.Add(groupBox2);
			Controls.Add(groupBox1);
			Controls.Add(btnGenerate);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "Form1";
			Text = "OTM Report Generator";
			Load += Form1_Load;
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			groupBox4.ResumeLayout(false);
			groupBox4.PerformLayout();
			ResumeLayout(false);
		}

		#endregion
		private Label label1;
		private Button btnGenerate;
		private RadioButton rdoCT;
		private RadioButton rdoDblChk;
		private TextBox txtDate;
		private TextBox txtCD;
		private TextBox txtWI;
		private TextBox txtRO1;
		private TextBox txtRO2;
		private Label label3;
		private Label label4;
		private Label label5;
		private GroupBox groupBox1;
		private Label label12;
		private TextBox txtNumJoint;
		private Label label11;
		private GroupBox groupBox2;
		private Label label19;
		private RadioButton rdoFloatNo;
		private RadioButton rdoFloatYes;
		private RadioButton rdoShoeNo;
		private Label label13;
		private RadioButton rdoShoeYes;
		private Label label14;
		private TextBox txtFloatPos;
		private Label label15;
		private Label label16;
		private TextBox txtShoeType;
		private TextBox txtShoeLen;
		private TextBox txtFloatType;
		private Label label17;
		private Label label18;
		private Button button1;
		private TextBox txtFilePathDest;
		private TextBox txtFileName;
		private Label label2;
		private Label label6;
		private GroupBox groupBox3;
		private Button btnFilePathDest;
		private Button btnImportRaw;
		private TextBox txtRawData;
		private GroupBox groupBox4;
		private Label label7;
		private TextBox txtFloatLen;
	}
}
