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
            Console.WriteLine("This is The Official Batch Rock-Paper-Scissors Game");
            do{
                Console.WriteLine("Please choose Rock, Paper, or Scissors by typing 1, 2, or 3 and hitting enter.");
                Console.WriteLine("\t1. Rock \n\t2. Paper \n\t3. Scissors");

                string userInput = Console.ReadLine();
                //bool result = false;
                //int userResponse = int.Parse(userInput);
                parsResult = int.TryParse(userInput,out userInputInt);
                if(parsResult == false){
                    Console.WriteLine("Please Enter a number");
                    continue;
                }
                if(userInputInt > 3 || userInputInt < 1){
                    Console.WriteLine("Input is out of range, Please enter between 1 -3");
                    continue;
                }

              
            Console.WriteLine("Congratulation you enter : " + userInputInt);
            Random randomNumber = new Random(10);
            int computerChoice = randomNumber.Next(1,4);
            Console.WriteLine("The computer choice is ==> " + computerChoice);
            //check for winner
            if(userInputInt == computerChoice){ // if the players are tied
                Console.WriteLine("This game was a tie");
            }else if(userInputInt ==2 && computerChoice == 1){
                Console.WriteLine("Congrats, You (the user) WON!");
            
            }else if(userInputInt == 3 && computerChoice ==2){
                Console.WriteLine("Congrats, You (the user) WON!");

            }else if(userInputInt == 1 && computerChoice ==3){
                Console.WriteLine("Congrats, You (the user) WON!");

            }else{
                Console.WriteLine("Sorry. The computer WON!");

            }

              Console.WriteLine("Do you want to play again y/n");
              string ch = Console.ReadLine();
              char c = char.Parse(ch);
                if(c == 'y' || c =='Y'){
                    result = true;
                }else{
                    result = false;
                }
                

            }while(result);
        }
    }
}
