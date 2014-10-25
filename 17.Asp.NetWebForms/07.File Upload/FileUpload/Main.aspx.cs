using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FileUpload
{
    public partial class Main : System.Web.UI.Page
    {
        private const int MAX_FILE_SIZE = 1024000;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void Upload(object sender, EventArgs e)
        {
            if (this.FileUploadZip.HasFile)
            {
                try
                {
                    var postedFile = this.FileUploadZip.PostedFile;
                    if (postedFile.ContentType == "application/zip" ||
                        postedFile.ContentType == "application/octet-stream")
                    {
                        if (postedFile.ContentLength <= MAX_FILE_SIZE)
                        {
                            SaveTextFilesContent(postedFile);
                            this.LabelFeedback.Text = "Text files content has been successfully saved to the database!";
                        }
                        else
                        {
                            this.LabelFeedback.Text = "File is too big to be handled!";
                        }
                    }
                    else
                    {
                        this.LabelFeedback.Text = "Only zip archives are accepted!";
                    }
                }
                catch (Exception ex)
                {
                    this.LabelFeedback.Text = ex.Message;
                }
            }
        }

        private void SaveTextFilesContent(HttpPostedFile postedFile)
        {
            var fileStream = postedFile.InputStream;
            var zip = new ZipArchive(fileStream);
            var files = zip.Entries;
            foreach (var file in files)
            {
                if (file.FullName.EndsWith(".txt"))
                {
                    ReadAndSaveTextContent(file);
                }
            }
        }

        private void ReadAndSaveTextContent(ZipArchiveEntry file)
        {
            var textFileContentAsStream = file.Open();
            var fileName = Path.GetFileNameWithoutExtension(file.FullName);
            var streamReader = new StreamReader(textFileContentAsStream);
            using (streamReader)
            {
                var textFileContentAsString = streamReader.ReadToEnd();
                SaveToDatabase(fileName, textFileContentAsString);                
            }
        }

        private void SaveToDatabase(string fileName, string textFileContentAsString)
        {
            var db = new FileStorageEntities();
            var fileEntry = new File();
            fileEntry.Name = fileName;
            fileEntry.Content = textFileContentAsString;
            db.Files.Add(fileEntry);
            db.SaveChanges();
        }
    }
}