using System;
using System.Net;

namespace AnalizatorTekstow
{
    class Program
    {
        static void Main(string[] args)
        {
            string _url = "";// string with hardcoded url adress of the file
            string _path = "";//string with path to where save the file
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
                    using (WebClient myClient = new WebClient())
                    {
                        myClient.DownloadFile(url, @path);
                    }
                    return "Pobieranie pliku rozpoczęte.";
                }
                else
                {
                    return "Adres url i/albo ścieżka są puste. Pobieranie nieudane.";
                }
              
            }
        }
    }
}