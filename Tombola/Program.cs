using System;

namespace Tombola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto a Tombola!\n");
            char keepGoing; // variabile che mi permette di continuare a giocare se l'utente vuole
            do
            {
                //PROGRAMMA
                int[] userNumbers = new int[15]; // numeri utente

                Console.WriteLine("Inserisci 15 numeri compresi tra 1 e 90:");
                UserNumbers(ref userNumbers);
                
                int index = LevelChoice();
                switch (index)
                {
                    case 1: // facile
                        int[] gameNumbers1 = new int[70];
                        GameNumbers(ref gameNumbers1);
                        CheckIfWin(userNumbers, gameNumbers1);

                        break;
                    case 2: // medio
                        int[] gameNumbers2 = new int[40];
                        GameNumbers(ref gameNumbers2);
                        CheckIfWin(userNumbers, gameNumbers2);
                        break;
                    case 3: // difficile
                        int[] gameNumbers3 = new int[20];
                        GameNumbers(ref gameNumbers3);
                        CheckIfWin(userNumbers, gameNumbers3);
                        break;
                }
                // possibilità di rigiocare
                Console.WriteLine("\nVuoi rigiocare?\n(premi y se vuoi rigiocare, altrimenti premi un altro tasto)");
                keepGoing = Console.ReadKey().KeyChar;
                Console.WriteLine("\n");
            } while (keepGoing == 'y');
            
            //FINE PROGRAMMA



            //ROUNTINE

            void UserNumbers(ref int[] userNumbers) //l'utente sceglie i suoi 15 numeri
                {
                    for (int i = 0; i < userNumbers.Length; i++)
                    {
                        Console.Write("Inserisci numero " + (i+1) + ": ");
                        bool isOk = int.TryParse(Console.ReadLine(), out int temp);
                        while (!(isOk && temp > 0 && temp < 91 && Array.IndexOf(userNumbers, temp) == -1))
                        {
                            Console.WriteLine("Scelta non valida!");
                            Console.Write("Inserisci di nuovo il numero " + (i+1) + ": ");
                            isOk = int.TryParse(Console.ReadLine(), out temp);
                        }
                        userNumbers[i] = temp;
                    }

                }

                int LevelChoice() //l'utente sceglie la difficoltà del gioco
                {
                    Console.WriteLine("\nScegli la difficoltà del gioco:");
                    Console.WriteLine("1: facile (estrazione di 70 numeri)\n2: medio (estrazione di 40 numeri)\n3: difficile (estrazione di 20 numeri)");
                    Console.Write("Scelta: ");
                    bool isOk = int.TryParse(Console.ReadLine(), out int index);
                    while (!(isOk && index > 0 && index <= 3))
                    {
                        Console.WriteLine("Inserimento non valido!");
                        Console.WriteLine("1: facile (estrazione di 70 numeri)\n2: medio(estrazione di 40 numeri)\n3: difficile (estrazione di 20 numeri)");
                        Console.Write("Scelta: ");
                        isOk = int.TryParse(Console.ReadLine(), out index);
                    }
                    return index;
                }

                void GameNumbers(ref int[] gameNumbers) //estrazione numeri computer
                {
                    Random random = new Random();
                    for (int i = 0; i < gameNumbers.Length; i++)
                    {
                        int temp = random.Next(1, 90);
                        int found = Array.IndexOf(gameNumbers, temp);
                        while (found != -1)
                        {
                            temp = random.Next(1, 90);
                            found = Array.IndexOf(gameNumbers, temp);
                        }
                        gameNumbers[i] = temp;

                    }
                }

                void CheckIfWin(int[] userNumbers, int[] gameNumbers)
                {
                    int[] sameNumbers = new int[15]; //eventuali numeri comuni tra computer e utente
                    int counter = 0;
                    for (int i = 0; i < userNumbers.Length; i++)
                    {
                        for (int j = 0; j < gameNumbers.Length; j++)
                        {
                            if (userNumbers[i] == gameNumbers[j])
                            {
                                sameNumbers[counter] = userNumbers[i];
                                counter++;
                                break;
                            }

                        }
                    }
                    int k = 0;
                    while (sameNumbers[k] != 0)
                    {
                        k++;
                    } //quando esce dal while, in k c'è il numero di numeri uguali

                    if (k == 2)
                    {
                        Console.WriteLine("\nHai fatto ambo!");
                        Console.WriteLine("Numeri vincenti: " + sameNumbers[0] + " " + sameNumbers[1]);


                    }
                    else if (k == 3)
                    {
                        Console.WriteLine("\nHai fatto terna!");
                        Console.WriteLine("Numeri vincenti: " + sameNumbers[0] + " " + sameNumbers[1] + " " + sameNumbers[2]);
                    }
                    else if (k == 4)
                    {
                        Console.WriteLine("\nHai fatto quaterna!");
                        Console.WriteLine("Numeri vincenti: " + sameNumbers[0] + " " + sameNumbers[1] + " " + sameNumbers[2] + " " + sameNumbers[3]);

                    }
                    else if (k >= 5 && k <15)
                    {
                        Console.WriteLine("\nHai fatto cinquina!");
                        Console.Write("Numeri vincenti: ");
                        for (int s = 0; s < counter; s++)
                        {
                            Console.Write(sameNumbers[s] + " ");
                        }
                        
                    }
                    else if (k == 15)
                    {
                        Console.WriteLine("\nHai fatto tombola!");
                        for (int t = 0; t < sameNumbers.Length; t++)
                        {
                            Console.Write(sameNumbers[t] + " ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("hai perso...");
                        Console.WriteLine("counter " + k);


                    }
                }
                // FINE ROUNTINE


                
        }
    }
}
