using System;
using System.Linq;


namespace BadCredit
{
    class Program
    {
        public enum CardType
        {
            Visa,
            Amex,
            Master,
            Invalid
        }

        public static CardType GetCardType(string cardNumber)
        {
            if (IsNumber(cardNumber) && GetCheckSum(cardNumber))
            {
                if ((cardNumber.StartsWith("34") || cardNumber.StartsWith("37")) && cardNumber.Length == 15)
                {
                    return CardType.Amex;
                }
                if ((cardNumber.StartsWith("51") ||
                   cardNumber.StartsWith("52") ||
                   cardNumber.StartsWith("53") ||
                   cardNumber.StartsWith("54") ||
                   cardNumber.StartsWith("55")) && cardNumber.Length == 16)
                {
                    return CardType.Master;
                }
                if ((cardNumber.StartsWith("4")) &&
                    (cardNumber.Length == 16 || cardNumber.Length == 13))
                {
                    return CardType.Visa;
                }

            }
            return CardType.Invalid;
        }

        public static bool IsNumber(string number)
        {
            long result;
            return long.TryParse(number, out result);
        }

        public static bool GetCheckSum(string cardNubmer)
        {
            int sum = 0;
            bool helper = false;
            for (int i = cardNubmer.Length - 1; i >= 0; i--)
            {
                char[] helperArray = cardNubmer.ToArray();
                int n = int.Parse(helperArray[i].ToString()); 

                if (helper)
                {
                    n *= 2;

                    if (n > 9)
                    {
                        n = (n / 10) + (n % 10) ;
                    }
                }
                sum += n;
                helper = !helper;
            }
            Console.WriteLine(sum);
            return (sum % 10 == 0);
        }

            static void Main(string[] args)
        {
            Console.Write("Please enter credit card number: ");
            string cardNumber = Console.ReadLine();
            CardType cardType = GetCardType(cardNumber);
            Console.Write("Your card is ");
            switch (cardType)
            {
                case CardType.Invalid:
                    Console.Write("Invalid");
                    break;
                case CardType.Amex:
                    Console.Write("AMEX");
                    break;
                case CardType.Master:
                    Console.Write("MasterCard");
                    break;
                case CardType.Visa:
                    Console.Write("Visa");
                    break;
            }
        }

    }
}











