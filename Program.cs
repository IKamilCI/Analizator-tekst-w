using System;
using System.Net;
using System.IO;

namespace AnalizatorTekstow
{
    class Program
    {
        static void Main(string[] args)
        {
            string _url = "https://s3.zylowski.net/public/input/3.txt";// string with hardcoded url adress of the file
            string _path = @"C:\Users\kamil\Desktop\szkola\Analizator-tekstow\zadanie.txt";//string with path to where save the file
            while (true)
            {
                Console.WriteLine("\n1. Pobierz plik z internetu.");
                Console.WriteLine("2. Zlicz liczbę liter w pobranym pliku.");
                Console.WriteLine("3. Zlicz liczbę wyrazów w pliku.");              
                Console.WriteLine("4. Zlicz liczbę znaków interpunkcyjnych w pliku.");
                Console.WriteLine("5. Zlicz liczbę zdań w pliku.");
                Console.WriteLine("6. Wygeneruj raport o użyciu liter(A - Z).");
                Console.WriteLine("7. Zapisz statystyki z punktów 2 - 5 do pliku statystyki.txt.");
                Console.WriteLine("8. Wyjście z programu.\n");
                int menuOption = Convert.ToInt32(Console.ReadLine());
                if (menuOption == 1)
                {
                    Console.WriteLine(Downloader(_url, _path));                                             
                }
                if (menuOption == 2)
                {
                    Console.WriteLine(LettersCounter(_path));
                }
                if (menuOption == 3)
                {
                    Console.WriteLine(WordsCounter(_path));
                }
                if (menuOption == 4)

                {
                    Console.WriteLine(PunctuationMarksCounter(_path));

                }
                if (menuOption == 5)
                {
                    Console.WriteLine(SentencesCounter(_path));
                }
                if (menuOption == 8)
                    break;
            }

            //metod downloading file from url, and saving it in the directory path
            string Downloader(string url, string path)
            {
                //checking if path and url are not empty to not couse exception
                if(string.IsNullOrEmpty(url)&&string.IsNullOrEmpty(path))
                {
                    return "\nAdres url i/albo ścieżka są puste. Pobieranie nieudane.";
                }
                else
                {                    
                    using (WebClient myClient = new WebClient())
                    {
                        myClient.DownloadFile(url, path);
                    }
                    return "\nPlik został pobrany.";
                }
              
            }

            //counting words in file 
            string LettersCounter(string path)
            {
                if (File.Exists(path))
                {
                    int lettersCount;
                    using (StreamReader reader = new StreamReader(path))
                    {
                        string tekst = File.ReadAllText(path);
                        lettersCount = tekst.Length;
                    }
                    return "\nLiczba liter: " + lettersCount.ToString();
                }
                else
                {
                    return "\nBłąd, plik nie istnieje!";
                }
            }

            //counting words in file 
            string WordsCounter(string path)
            {
                if (File.Exists(path))
                {
                    int wordsCount;
                    using (StreamReader reader = new StreamReader(path))
                    {
                        string tekst = File.ReadAllText(path);
                        char[] rozdzielacze = new char[] { ' ', '\n', '\r' };
                        wordsCount = tekst.Split(rozdzielacze, StringSplitOptions.RemoveEmptyEntries).Length;
                    }
                    return "\nLiczba wyrazów: "+wordsCount.ToString();
                }
                else
                {
                    return "\nBłąd, plik nie istnieje!";
                }
            }
            string PunctuationMarksCounter(string path)
            {
                if (File.Exists(path))
                {
                    int PunctuationMarksCounter;

                    using (StreamReader reader = new StreamReader(path))
                    {
                        string tekst = File.ReadAllText(path);
                        char[] separator = { '.', '?', '!', ',', ';', '-', '\'', '\'', ':' };

                        PunctuationMarksCounter = tekst.Split(separator, StringSplitOptions.RemoveEmptyEntries).Length;

                    }
                    return PunctuationMarksCounter.ToString();
                }
                else
                {
                    return "Błąd, plik nie istnieje!";
                }
            }
            string SentencesCounter(string path)
            {
                if (File.Exists(path))
                {
                    int SentencesCounter = 0;
                    using (StreamReader reader = new StreamReader(path))
                    {
                        string tekst = File.ReadAllText(path);
                        char[] separator = { '.', '?', '!' };
                        SentencesCounter = 0;
                        int Sentences = tekst.Split(separator, StringSplitOptions.RemoveEmptyEntries).Length;
                        string[] character = tekst.Split(separator, StringSplitOptions.RemoveEmptyEntries);

                        for (int i = 0; i < Sentences; i++)
                        {

                            if (character[i].Length >= 10)
                            {
                                SentencesCounter += 1;
                            }

                        }



                    }
                    return SentencesCounter.ToString();
                }
                else
                {
                    return "Błąd, plik nie istnieje!";
                }
            }
    }
}