using System;
using System.Net;
using System.IO;

namespace AnalizatorTekstow
{
    class Program
    {
        static void Main(string[] args)
        {
            string _url = "https://s3.zylowski.net/public/input/1.txt";// string with hardcoded url adress of the file
            string _path = @"C:\\Users\\nazwa\\Desktop\\1.txt";//string with path to where save the file
            while (true)
            {
                Console.WriteLine("1. Pobierz plik z internetu.");
                Console.WriteLine("2. Zlicz liczbę liter w pobranym pliku.");
                Console.WriteLine("3. Zlicz liczbę wyrazów w pliku.");              
                Console.WriteLine("4. Zlicz liczbę znaków interpunkcyjnych w pliku.");
                Console.WriteLine("5. Zlicz liczbę zdań w pliku.");
                Console.WriteLine("6. Wygeneruj raport o użyciu liter(A - Z).");
                Console.WriteLine("7. Zapisz statystyki z punktów 2 - 5 do pliku statystyki.txt.");
                Console.WriteLine("8. Wyjście z programu.");
                int menuOption = Convert.ToInt32(Console.ReadLine());
                if (menuOption == 8)
                    break;
                if (menuOption == 3)
                {
                    Console.WriteLine(Counter(_path));
                }
                if (menuOption == 1)
                {
                    Console.WriteLine(Downloader(_url, _path));                                             
                }
            }

            //metod downloading file from url, and saving it in the directory path
            string Downloader(string url, string path)
            {
                //checking if path and url are not empty to not couse exception
                if(string.IsNullOrEmpty(url)&&string.IsNullOrEmpty(path))
                {
                    return "Adres url i/albo ścieżka są puste. Pobieranie nieudane.";
                }
                else
                {                    
                    using (WebClient myClient = new WebClient())
                    {
                        myClient.DownloadFile(url, path);
                    }
                    return "Pobieranie pliku rozpoczęte.";
                }
              
            }

            //counting words in file 
            string Counter(string path)
            {
                if (File.Exists(path))
                {
                    int count;
                    using (StreamReader reader = new StreamReader(path))
                    {
                        string tekst = File.ReadAllText(path);
                        char[] rozdzielacze = new char[] { ' ', '\n', '\r' };
                        count = tekst.Split(rozdzielacze, StringSplitOptions.RemoveEmptyEntries).Length;
                    }
                    return count.ToString();
                }
                else
                {
                    return "Błąd, plik nie istnieje!";
                }
            }
        }
    }
}