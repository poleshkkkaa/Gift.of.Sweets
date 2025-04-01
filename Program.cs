using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace лаба4_2
{
    public class Chocolate : Sweet
    {
        public Chocolate(string name, double weight, double sugarContent) : base(name, weight, sugarContent) { }
    }

    public class Caramel : Sweet
    {
        public Caramel(string name, double weight, double sugarContent) : base(name, weight, sugarContent) { }
    }

    public class Jelly : Sweet
    {
        public Jelly(string name, double weight, double sugarContent) : base(name, weight, sugarContent) { }
    }

    public class Toffee : Sweet
    {
        public Toffee(string name, double weight, double sugarContent) : base(name, weight, sugarContent) { }
    }

    class Program
    {
        static void Main()
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            bool repeat = true;

            while (repeat)
            {
                var chocolate = new Chocolate("Цукерка Ромашка", 250, 65);
                var caramel = new Caramel("Карамелька Чупа-Чупс", 50, 60);
                var jelly = new Jelly("Желейки", 130, 40);
                var whiteChocolate = new Chocolate("Білий шоколад 'Мілка'", 150, 55);
                var toffee = new Toffee("Іриска", 100, 70);

                var giftBox = new Gift();
                giftBox.AddSweet(chocolate);
                giftBox.AddSweet(caramel);
                giftBox.AddSweet(jelly);
                giftBox.AddSweet(whiteChocolate);
                giftBox.AddSweet(toffee);

                Console.WriteLine("Цукерки, які є для подарунку:");
                giftBox.ShowSweets();

                double result = 0;
                bool validInput = false;

                while (!validInput)
                {
                    Console.Write("\nВведіть бажаний відсоток цукру для пошуку: ");
                    string input = Console.ReadLine();

                    if (input.EndsWith("%"))
                    {
                        input = input.Replace("%", "").Trim();
                        if (double.TryParse(input, out result) && result > 0)
                        {
                            validInput = true;
                            var bestFitsBySugar = giftBox.FindBestFitBySugarContent(result);
                            if (bestFitsBySugar.Any())
                            {
                                Console.WriteLine("\nЦукерки, які підходять під ваші параметри (вміст цукру):");
                                foreach (var sweet in bestFitsBySugar)
                                {
                                    Console.Write($"{sweet}; ");
                                }

                                double totalWeight = giftBox.TotalWeightForSelectedSweets(bestFitsBySugar);
                                Console.WriteLine($"\nЗагальна вага подарунка для цих цукерок: {totalWeight} г");

                                string filePath = @"C:\Users\Polina\Desktop\Gift.txt";

                                string resultText = "Цукерки, які підходять під ваші параметри (вміст цукру):\n";
                                foreach (var sweet in bestFitsBySugar)
                                {
                                    resultText += $"{sweet}; ";
                                }
                                resultText += $"\nЗагальна вага подарунка для цих цукерок: {totalWeight} г";

                                File.WriteAllText(filePath, resultText);

                                Console.WriteLine("\nРезультат збережено у файл на вашому робочому столі.");
                            }
                            else
                            {
                                Console.WriteLine("Жодна цукерка не підходить під ваш діапазон вмісту цукру.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Введено некоректний відсоток цукру. Будь ласка, введіть позитивне число.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Введено некоректне значення. введіть відсоток цукру.");
                    }
                }

                bool validAnswer = false;
                while (!validAnswer)
                {
                    Console.Write("\nХочете ще раз зібрати подарунок? (так/ні або yes/no): ");
                    string answer = Console.ReadLine().ToLower().Trim();

                    if (answer == "так" || answer == "yes")
                    {
                        validAnswer = true;
                        Console.Clear();
                    }
                    else if (answer == "ні" || answer == "no")
                    {
                        validAnswer = true;
                        repeat = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Невірний ввід. Введіть 'так' або 'ні', 'yes' або 'no'.");
                    }
                }
            }
        }
    }
}

