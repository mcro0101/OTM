using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace Russ_Tool
{
	public class FileManager
	{
		public bool CheckFileExists(string filePath)
		{
			try
			{
				// Check if the file exists
				if (File.Exists(filePath))
				{
					return true;
				}
				else
				{
					Console.WriteLine("File does not exist: " + filePath);
					return false;
				}
			}
			catch (Exception ex)
			{
				// Handle any exceptions
				Console.WriteLine("Error checking file existence: " + ex.Message);
				return false;
			}
		}


		// ---------------------------------------------------------------

		public string BrowseFolder(string pPath)
		{
			string selectedFolder = null;

			try
			{
				using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
				{
					// Set the initial folder (optional)
					//folderBrowserDialog.SelectedPath = @"C:\TEMP\Templates\Output";
					folderBrowserDialog.SelectedPath = pPath;

					// Set the dialog to only allow folder selection
					folderBrowserDialog.Description = "Select a folder";
					folderBrowserDialog.ShowNewFolderButton = false;

					// Show the folder browser dialog and capture the result
					DialogResult result = folderBrowserDialog.ShowDialog();

					// Check if the user clicked OK
					if (result == DialogResult.OK)
					{
						// Get the selected folder path
						selectedFolder = folderBrowserDialog.SelectedPath;
					}
				}
			}
			catch (Exception ex)
			{
				// Handle the exception
				Console.WriteLine("Error while browsing for folder: " + ex.Message);
				// You can also show a message box or log the exception
			}

			return selectedFolder;
		}

		//-----------------------------------------


		public bool CopyFile(string pSource, string pFileDestion)
		{
			bool result = false;
			try
			{
				string DstFolderLoc = Path.GetDirectoryName(pFileDestion);
				CreateDirectory(DstFolderLoc);
				if (ValidateFileCopy(pSource, pFileDestion))
				{
					File.Copy(pSource, pFileDestion);
					result = true;
				}


			}
			catch (Exception ex)
			{
				result = false;
			}

			return result;
		}

		public bool CreateDirectory(string path)
		{
			bool result = false;
			try
			{
				Directory.CreateDirectory(path);
				result = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				result = false;
			}

			return result;
		}

		public bool ValidateFileCopy(string pSource, string pFileDestion)
		{
			bool result = false;
			try
			{
				if (CheckUserWriteAcceFile(pFileDestion))
				{
					result = true;
				}
				else { MessageBox.Show("Administrator Write Access Required : " + pFileDestion); result = false; }
				if (CheckUserReadAccessFile(pSource))
				{
					result = true;
				}
				else { MessageBox.Show("Administrator Read Access Required : " + pSource); result = false; }

			}
			catch (Exception ex) { MessageBox.Show(ex.Message); result = false; }

			return result;

		}

		public bool CheckUserWriteAcceFile(string DstFileLoc)
		{
			try
			{
				string tempFilePath = Path.Combine(Path.GetDirectoryName(DstFileLoc), Path.GetFileNameWithoutExtension(DstFileLoc) + ".tmp");
				using (FileStream stream = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write))
				{

				}
				File.Delete(tempFilePath);
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return false;
			}
		}

		public bool CheckUserReadAccessFile(string DstFileLoc)
		{
			try
			{
				using (FileStream stream = new FileStream(DstFileLoc, FileMode.OpenOrCreate, FileAccess.Read))
				{
					return true;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return false;
			}
		}



		/// ---------------
		/// 
		public  void CheckAndDeleteFile(string filePath)
		{
			try
			{
				if (File.Exists(filePath))
				{
					File.Delete(filePath);
				//	MessageBox.Show($"File deleted successfully: {filePath}", "File Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					return;
				}
			}
			catch (UnauthorizedAccessException ex)
			{
				return;
			}
			catch (IOException ex)
			{
				return;
			}
			catch (Exception ex)
			{
				return;
			}
		}

	}
}
