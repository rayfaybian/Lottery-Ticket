using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace LotteryTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            //Aufgabe Lottery
            //Erstelle eine Klasse LotteryTicket.
            //Diese soll eine 6 - stellige Zahl speichern können.
            //In der Main Methode sollst du nun eine 6 - stellige
            //Zufallszahl generieren und als LotteryTicket speichern.
            //Der Nutzer soll nun selbst mehrere 6 - stellige Zahlen
            //eingeben können und du sollst ausgeben, wie viele der Ziffern
            //richtig waren(Selbe Ziffer an selber Stelle). Wenn er
            //alle 6 richtig geraten hat oder aufgegeben hat,
            //sollst du die richtige Zahl ausgeben.

            LotteryTicket ticket = new LotteryTicket();
            //Console.WriteLine(ticket.number);

            Console.WriteLine(" ----------------------------------------\n" +
                             "|      Willkommen beim Lottospiel        |\n" +
                              " ----------------------------------------\n");

            bool isPlaying = true;
            bool gameLost = false;
            string input = string.Empty;
            int counter = 1;
            while (isPlaying)
            {
                Console.WriteLine("\n -------------------------\n" +
                                  "|    Was willst du tun?   |\n" +
                                  "|         1) Raten        |\n" +
                                  "|       2) Aufgeben       |\n" +
                                  " -------------------------\n");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        string playerNumber = getPlayerNumber(counter);
                        counter++;


                        gameLost = getResult(CheckNumber(ticket, playerNumber), ticket, playerNumber);

                        {
                            if (!gameLost)
                            {
                                isPlaying = AskPlayer(ticket);
                                counter = 1;
                            }
                        }
                        break;

                    case "2":
                        Console.WriteLine("\nNa schön du Loser.\nHier ist die Lösung:\n\n" +
                            " --------------\n" +
                            "|    " + ticket.number + "    |\n" +
                            " --------------\n");
                        isPlaying = false;
                        break;
                    default:
                        Console.WriteLine("Bitte wähle zwischen 1 und 2");
                        break;
                }
            }
        }

        public static String getPlayerNumber(int counter)
        {
            bool inputOk = false;
            Console.WriteLine("Errate die 6 Lottozahlen auf dem Ticket.");
            Console.WriteLine("\nTippe eine 6-stellige Zahl ein.\n");
            Console.WriteLine(" ----------------------\n" +
                              "|      " + counter + ". Versuch      |\n" +
                              " ----------------------\n");
            string number = "";
            while (!inputOk)
            {
                number = Console.ReadLine();
                if (number.Length < 6)
                {
                    Console.WriteLine("Bitte tippe genau 6 Ziffern ein");
                }
                else
                {
                    inputOk = true;
                }
            }

            return number;
        }

        public static String CheckNumber(LotteryTicket ticket, String number)
        {
            char[] correctNumbers = new char[6];

            char[] ticketArray = ticket.number.ToCharArray();
            char[] playerArray = number.ToCharArray();


            for (int i = 0; i < ticketArray.Count(); i++)
            {
                if (ticketArray[i].Equals(playerArray[i]))
                {
                    correctNumbers[i] = ticketArray[i];
                }
                else
                {
                    correctNumbers[i] = '_';
                }
            }
            string solvedDigits = new string(correctNumbers);
            return solvedDigits;
        }

        public static bool getResult(string solvedDigits, LotteryTicket ticket, string number)
        {
            bool isCorrect;
            if (solvedDigits.Equals(ticket.number))
            {
                isCorrect = true;
            }
            else
            {
                isCorrect = false;
            }

            bool gameLost = false;
            switch (isCorrect)
            {
                case true:
                    Console.WriteLine("Gewonnen! Du hast die korrekten Lottozahlen erraten\n\n" +
             " --------------\n" +
             "|    Lösung    |\n" +
                            "|    " + ticket.number + "    |\n" +
                            " --------------\n");
                    gameLost = false;
                    break;
                case false:

                    if (!solvedDigits.Equals("______"))
                    {

                        Console.WriteLine("Leider falsch\nDu hast aber mindestens eine Zahl korrekt erraten:\n\n" + solvedDigits + "\n\n");
                    }
                    else
                    {
                        Console.WriteLine("Leider nein. " + number + " ist nicht die gesuchte Zahlenfolge.");
                    }
                    gameLost = true;
                    break;
            }
            return gameLost;
        }

        public static bool AskPlayer(LotteryTicket ticket)
        {
            bool playAgain = false;
            bool playerDecided = false;
            string input = "";

            while (!playerDecided)
            {
                Console.WriteLine("Willst du noch eine Runde spielen? y/n");
                input = Console.ReadLine();
                switch (input)
                {
                    case "y":
                        Console.WriteLine("Großartig, dann los.");
                        ticket.CreateNewNumber();
                        playAgain = true;
                        playerDecided = true;
                        break;

                    case "n":
                        Console.WriteLine("Schade, dann bis zum nächsten mal.");
                        playAgain = false;
                        playerDecided = true;
                        break;

                    default:
                        Console.WriteLine("Nope, kein Plan was du mir damit sagen willst Bro.");
                        break;
                }
            }
            return playAgain;
        }
    }
}
