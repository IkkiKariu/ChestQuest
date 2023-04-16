using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp1
{ 
    internal class Program
    {
        // Подразумевается, что состояние "closed" это закрытый незаблокрованный сундук, если состояние "locked",
        // то , разумеется, сундук был предвариетьно закрыт...
        enum chestStates
        {
            locked,
            closed,
            opened
        }
        static void Main(string[] args)
        {
            chestStates state = chestStates.locked;

            string action;

            while (true)
            {
                Console.WriteLine($"Now chest state is {state}!");
                Console.WriteLine("Enter command \"open\" \"close\" \"lock\" or \"unlock\" to change state:");

                action = Console.ReadLine().ToLower().Replace(" ", "");
                Console.WriteLine();

                switch (action)
                {
                    case "open":
                        Open(ref state);
                        break;
                    case "close":
                        Close(ref state);
                        break;
                    case "lock":
                        Lock(ref state);
                        break;
                    case "unlock":
                        Unlock(ref state);
                        break;
                    default:
                        Console.WriteLine("Сделаем вид, что я не видел этого позора...");
                        Console.WriteLine();
                        break;
                }
            }
        }

        static void Lock(ref chestStates state)
        {
            if(state == chestStates.closed) 
            { 
                state = chestStates.locked;
            }else { Console.WriteLine("In this condition you cannot lock the chest!"); }
        }

        static void Unlock(ref chestStates state)
        {
            if(state == chestStates.locked)
            {
                state = chestStates.closed;
            }else { Console.WriteLine("In this condition you cannot unlock the chest!"); }
        }

        static void Close(ref chestStates state)
        {
            if(state == chestStates.opened)
            {
                state = chestStates.closed;
            }else { Console.WriteLine("In this condition you cannot close the chest!"); }
        }

        static void Open(ref chestStates state)
        {
            if(state == chestStates.closed)
            {
                state = chestStates.opened;
            }else { Console.WriteLine("In this condition you cannot open the chest!"); }
        }
    }
}
