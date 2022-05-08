using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamSlovar
{
    class CountryDictionary
    {
        public Dictionary<string, string> English_Russian;
        public CountryDictionary()
        {
            English_Russian = new Dictionary<string, string>();
        }
        public bool Translate(string country, bool direction)
        {
            if (direction == false)
            {
                if (English_Russian.ContainsKey(country) == false)
                {
                    Console.WriteLine("Ключ не найден.");
                    return false;
                }
                Console.WriteLine("\n{0,16} - {1}", country, English_Russian[country]);
            }
            else
            {
                if (English_Russian.ContainsValue(country) == false)
                {
                    Console.WriteLine("Значение не найдено.");
                    return false;
                }
                Console.WriteLine("\n{0,16} - {1}", country, English_Russian.FirstOrDefault(x => x.Value == country).Key);
            }
            return true;
        }
        public void PrintDictionary(Dictionary<string, string> glossary)
        {
            Console.WriteLine();
            foreach (KeyValuePair<string, string> kvp in glossary)
            {
                Console.WriteLine("{0, 16} - {1}", kvp.Key, kvp.Value);
            }
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CountryDictionary book = new CountryDictionary();
            try
            {
                book.English_Russian.Add("Ukraine", "Украина");
                book.English_Russian.Add("France", "Франция");
                book.English_Russian.Add("USA", "США");
                book.English_Russian.Add("China", "Китай");
                book.English_Russian.Add("Japan", "Япония");
                book.English_Russian.Add("China", "Китай");
                book.English_Russian.Add("China", "Китай");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("\n\nАргумент уже существует.", e.Message);
            }
            finally
            {
                Dictionary<string, string> Russian_to_English = book.English_Russian.ToDictionary(x => x.Value, x => x.Key);
                book.PrintDictionary(book.English_Russian);
                book.PrintDictionary(Russian_to_English);
            }
            Console.WriteLine("\nВ каком направлении вы хотели бы перевести?");
            Console.WriteLine(" (0) Eng -> Rus     или     (1) Rus -> Eng.");
            Console.WriteLine("Выбери перевод \"0\" или \"1\":");
            string dir = Console.ReadLine();
            if (dir == "0")
                dir = "false";
            else if (dir == "1")
                dir = "true";
            bool direction;
            bool res = bool.TryParse(dir, out direction);
            if (res == true)
            {
                do
                {
                    if (direction == false)
                        Console.WriteLine("Напиши мне название страны на Английском языке.");
                    else
                        Console.WriteLine("Напиши мне название страны на русском языке.");
                    string country = Console.ReadLine();
                    book.Translate(country, direction);
                    Console.WriteLine("\nПродолжить? 0-Нет, любая другая клавиша - Да.");
                    string cont = Console.ReadLine();
                    if (cont == "0")
                        break;
                } while (true);
            }
            else
            {
                Console.WriteLine("Направление не правильное.");
            }
        }
    }
}