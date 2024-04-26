using System;
namespace Lab2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(1251);
            Console.WriteLine("Виберіть тип конвертації:");
            Console.WriteLine("1 - десяткове число у двійкове прямим кодом");
            Console.WriteLine("2 - десяткове число у двійкове зворотнім кодом");
            Console.WriteLine("3 - десяткове число у двійкове додатковим кодом");

            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine("Введіть десяткове число:");
            double decimalNumber = double.Parse(Console.ReadLine());
            string binaryRepresentation;
            switch (choice)
            {
                case 1:
                    binaryRepresentation = DecimalToBinary(decimalNumber);
                    break;
                case 2:
                    binaryRepresentation = DecimalToBinaryReverse(decimalNumber);
                    break;
                case 3:
                    binaryRepresentation =
                   DecimalToBinaryOnes(decimalNumber);
                    break;
                default:
                    Console.WriteLine("Виберіть 1, 2 чи 3.");
                    return;
            }
            Console.WriteLine("Двійкове представлення числа " + decimalNumber + ": " + binaryRepresentation);
            Console.ReadLine();
        }
        // Переведення десяткового числа у двійкове прямим кодом
        static string DecimalToBinary(double decimalNumber)
        {
            int integerPart = (int)decimalNumber;
            double fractionalPart = decimalNumber - integerPart;
            string binaryIntegerPart = Convert.ToString(integerPart, 2);
            string binaryFractionalPart = "";
            while (fractionalPart > 0 && binaryFractionalPart.Length < 8 - binaryIntegerPart.Length - 1) // Обмеження на 8 знаків
            {
                fractionalPart *= 2;
                int bit = (int)fractionalPart;
                binaryFractionalPart += bit;
                fractionalPart -= bit;
            }
            return binaryIntegerPart + "." + binaryFractionalPart;
        }
        // Перетворення десяткового числа у двійкове зворотнім кодом
        static string DecimalToBinaryReverse(double decimalNumber)
        {           
            string binary = DecimalToBinary(decimalNumber);
            char[] reversedBinary = binary.ToCharArray();
            Array.Reverse(reversedBinary);
            return new string(reversedBinary).PadRight(8,'0'); // Обмежуємо до 8 знаків нулями
        }

        // Перетворення десяткового числа у двійкове додатковим кодом 
        static string DecimalToBinaryOnes(double decimalNumber)
        {            
            string binary = DecimalToBinary(decimalNumber);
            char[] binaryArray = binary.ToCharArray();
            binaryArray[binaryArray.Length - 1] = '1'; // Змінюємо останній елемент на 1
            return new string(binaryArray);
        }
        
    }
}
