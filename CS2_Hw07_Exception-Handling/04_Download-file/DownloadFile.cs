/*
 * Problem 4. Download file
 *
 * Write a program that downloads a file from Internet (e.g. Ninja image) and stores it the current directory.
 * Find in Google how to download files in C#.
 * Be sure to catch all exceptions and to free any used resources in the finally block.
 */
using System;
using System.Net;

class DownloadFile
{
    static void Main()
    {
        string webURI = "http://telerikacademy.com/Content/Images/news-img01.png";
        string fileName = webURI.Substring(webURI.LastIndexOf('/') + 1);
        if (string.IsNullOrEmpty(fileName))
        {
            fileName = "file_from_web";
        }
        WebClient webClient = new WebClient();
        try
        {
            // Create a new WebClient instance.
            
            Console.WriteLine("Downloading file '{0}' from '{1}'", fileName, webURI);
            // Download the Web resource and save it into the current filesystem folder.
            webClient.DownloadFile(webURI, fileName);
            Console.WriteLine("File '{0}' finished downloading from '{1}'", fileName, webURI);
            string localURI = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            string localPath = new Uri(localURI).LocalPath;
            string localDir = System.IO.Path.GetDirectoryName(localPath);
            Console.WriteLine("File saved in: '{0}'", localDir);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("The specified URI address has no value");
        }
        catch (WebException)
        {
            Console.WriteLine("The specified URI address is invalid OR The file does not exist OR An error occurred while downloading data");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("The method has been called simultaneously on multiple threads");
        }
        finally
        {
            webClient.Dispose();
        }
    }
}