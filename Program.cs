using System;
using System.Net;
using System.IO;

namespace AnalizatorTekstow
{
    class Program
    {
        static void Main(string[] args)
        {
            string folderPath = @"C:\Users\studentwsb\Desktop\Analizator-tekstow-master\"; //string with folder path to where save all file
            string _url = "https://s3.zylowski.net/public/input/3.txt"; // string with hardcoded url adress of the file
            string plik = "";
            string _path = folderPath + plik; //string with path to where save the file
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
                if (menuOption == 6)
                {
                    letterAmount(_path);
                    numberLettersGenerator(_path);
                }
                if (menuOption == 7)
                {
                    saveStatisctic(_path);
                }
                if (menuOption == 8)
                {
                    ExitMethod(folderPath);
                }
            }

            //metod downloading file from url, and saving it in the directory path
            string Downloader(string url, string path)
            {
                while (true)
                {
                    Console.WriteLine("\nChcesz pobrać plik z internetu[T] czy z komputera[N]\n");
                    string trueFalse = Console.ReadLine();
                    if (trueFalse == "T")
                    {
                        if (string.IsNullOrEmpty(url) && string.IsNullOrEmpty(path))
                        {
                            return "\nAdres url i/albo ścieżka są puste. Pobieranie nieudane.";
                        }
                        else
                        {
                            using (WebClient myClient = new WebClient())
                            {
                                plik = "zadanie.txt";
                                _path = folderPath + plik;
                                myClient.DownloadFile(url, _path);
                            }
                            return "\nPlik został pobrany.";
                        }
                    }
                    if (trueFalse == "N")
                    {
                        Console.WriteLine("\nPodaj nazwe pliku z komputera.");
                        plik = Console.ReadLine();
                        _path = folderPath + plik;
                        if (!File.Exists(_path))
                        {
                            return "\nNazwa pliku jest nie poprawna.";
                        }
                        else
                        {
                            return "\nNazwa pliku jest poprawna.";
                        }

                    }
                }
            }

            //counting letters in file 
            string LettersCounter(string path)
            {
                if (File.Exists(path))
                {

                    int numbervovels = 0;
                    int numberconsonant = 0;

                    using (StreamReader reader = new StreamReader(path))
                    {
                        string tekst = File.ReadAllText(path);

                        foreach (char letter in tekst)
                        {
                            if (letter == 'A' || letter == 'a' || letter == 'E' || letter == 'e' || letter == 'O' || letter == 'o' || letter == 'U'
                                    || letter == 'u' || letter == 'Y' || letter == 'y' || letter == 'I' || letter == 'i')
                            {
                                numbervovels++;
                            }

                            else
                            {
                                numberconsonant++;
                            }


                        }
                    }
                    return "\nLiczba samogłosek: " + numbervovels.ToString() + "\nLiczba społgłosek: " + numberconsonant.ToString();
                }
                else
                {
                    return "\nBłąd, plik nie istnieje! Wykonaj najpierw punkt 1.";
                }
            }

            //counting words in file 
            string WordsCounter(string path)
            {
                if (File.Exists(path))
                {
                    int wordsCount = 0;
                    int words;
                    using (StreamReader reader = new StreamReader(path))
                    {
                        string tekst = File.ReadAllText(path);
                        char[] rozdzielacze = new char[] { ' ', '\n', '\r' };

                        words = tekst.Split(rozdzielacze, StringSplitOptions.RemoveEmptyEntries).Length;
                        string[] character = tekst.Split(rozdzielacze, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < words; i++)
                        {

                            if (character[i].Length > 1)
                            {
                                wordsCount += 1;
                            }
                        }
                    }
                    return "\nLiczba wyrazów: " + wordsCount.ToString();
                }
                else
                {
                    return "\nBłąd, plik nie istnieje! Wykonaj najpierw punkt 1.";
                }
            }

            //counting Punctuation Marks in file 
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
                    return "\nLiczba znaków interpunkcyjnych: " + PunctuationMarksCounter.ToString();
                }
                else
                {
                    return "\nBłąd, plik nie istnieje! Wykonaj najpierw punkt 1.";
                }
            }

            //counting Sentences in file 
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
                    return "\nLiczba zdań: " + SentencesCounter.ToString();
                }
                else
                {
                    return "\nBłąd, plik nie istnieje! Wykonaj najpierw punkt 1.";
                }
            }

            //function to generate number of letters to the file
            string letterAmount(string path)
            {
                if (File.Exists(path))
                {
                    int[] arrayOfLetters = new int[(int)char.MaxValue];
                    using (StreamReader reader = new StreamReader(path))
                    {
                        string tekst = File.ReadAllText(path);

                        foreach (char letter in tekst)
                        {
                            if (letter >= 'A' && letter <= 'z')
                            {
                                arrayOfLetters[(int)letter]++;
                            }
                        }

                        string numberLetters = "";

                        for (char letter = 'A'; letter <= 'z'; letter++)
                        {
                            if (Char.IsLetter(letter))
                            {
                                numberLetters += ((char)letter + " : " + arrayOfLetters[letter] + "\n");
                            }
                        }
                        return numberLetters;
                    }
                }
                else
                {
                    return "\nBłąd, plik nie istnieje! Wykonaj najpierw punkt 1.";
                }
            }

            //generate number of letters to the file
            void numberLettersGenerator(string path)
            {
                if (File.Exists(path))
                {
                    System.IO.File.WriteAllText(folderPath + "cyfry.txt", letterAmount(_path));
                    Console.WriteLine("\nIlosc poszczególnych liter została wygenerowana do cyfry.txt");
                }
                else
                {
                    Console.WriteLine("\nBłąd, plik nie istnieje! Wykonaj najpierw punkt 1.");
                }
            }

            //save statistic to the file
            void saveStatisctic(string path)
            {
                if (File.Exists(path))
                {
                    System.IO.File.WriteAllText(folderPath + "statystyki.txt", LettersCounter(_path) + Environment.NewLine + WordsCounter(_path) + Environment.NewLine + PunctuationMarksCounter(_path) + Environment.NewLine + SentencesCounter(_path));
                    Console.WriteLine("\nStatystyki zostały zapisane do pliku.");
                }
                else
                {
                    Console.WriteLine("\nBłąd, plik nie istnieje! Wykonaj najpierw punkt 1.");
                }
            }

            //Exid method with deleting files
            void ExitMethod(string path)
            {
                if(File.Exists(path + "statystyki.txt"))
                {
                    File.Delete(path + "statystyki.txt");
                }
                if (File.Exists(path + "zadanie.txt"))
                {
                    File.Delete(path + "zadanie.txt");
                }
                Environment.Exit(0);
            }
        }
    }
}