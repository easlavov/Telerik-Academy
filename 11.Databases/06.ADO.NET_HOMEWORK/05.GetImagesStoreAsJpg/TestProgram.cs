//Write a program that retrieves the images for all 
//categories in the Northwind database and stores 
//them as JPG files in the file system.
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Drawing.Imaging;
using System.Drawing;
using System.Collections.Generic;
using System.IO;

class TestProgram
{
    static void Main()
    {
        string northwindConnectionString = "Server=.\\SQLEXPRESS; " +
                                  "Database=Northwind; Integrated Security=true";
        var images = GetImagesFromDb(northwindConnectionString, "Categories", "Picture");
        string savePath = @"C:\NorthwindPictures\";
        Console.WriteLine("Images will be saved in " + savePath);
        Console.WriteLine("Press any key to start:");
        Console.ReadKey();
        SaveImages(images, savePath);
        Console.WriteLine("Images saved successfully!");
    }

    private static IEnumerable<Image> GetImagesFromDb(string connectionString, string table, string column)
    {
        IList<Image> images = new List<Image>();
        SqlConnection dbCon = new SqlConnection(connectionString);
        dbCon.Open();        
        using (dbCon)
        {
            var imgRetrieveCmd = new SqlCommand(
                "select " + column + " from " + table,
                dbCon);
            var reader = imgRetrieveCmd.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    //var imageArray = (byte[])reader["Picture"];
                    var rawData = (byte [])reader["Picture"];
                    //string fileName = reader["CategoryName"].ToString().Replace('/', '_') + ".jpg";
                    int len = rawData.Length;
                    int header = 78;
                    byte[] imgData = new byte[len - header];
                    Array.Copy(rawData, 78, imgData, 0, len - header);

                    var stream = new MemoryStream(imgData);
                    var image = Image.FromStream(stream);
                    images.Add(image);
                }
            }
        }

        return images as IEnumerable<Image>;
    }

    private static void SaveImages(IEnumerable<Image> images, string savePath)
    {
        int imageNumberCounter = 1;
        Directory.CreateDirectory(savePath);
        foreach (var image in images)
        {
            string fileName = savePath + "Image" + imageNumberCounter + ".jpeg";
            image.Save(new FileStream(fileName, FileMode.Create), ImageFormat.Jpeg);
            imageNumberCounter++;
        }
    }
}