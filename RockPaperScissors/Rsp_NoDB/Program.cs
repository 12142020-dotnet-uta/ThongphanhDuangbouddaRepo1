using System;

namespace Rsp_NoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            bool result = true;
            bool parsResult = false;
            int userInputInt = 0;
            
            do{

                string userInput = Console.ReadLine();
            //bool result = false;
                //int userResponse = int.Parse(userInput);
                parsResult = int.TryParse(userInput,out userInputInt);
                if(parsResult == false){
                    Console.WriteLine("Please Enter a number");
                    continue;
                }
                if(userInputInt > 3 || userInputInt < 1){
                    Console.WriteLine("Input is out of range");
                    continue;
                }
                result = false;

            }while(result);

            Console.WriteLine("Congratulation you enter : " + userInputInt);
        }
    }
}
