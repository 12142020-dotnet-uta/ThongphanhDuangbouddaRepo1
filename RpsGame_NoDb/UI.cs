using System;
namespace RpsGame_NoDb
{
    public class UI
    {
        public int LogInOptions(){
            int option = 0;
            bool enterIsNotCorrect = true;
            do{
                 Console.WriteLine("Select: \n\t1. For A New User. \n\t2. For An Existing User.");
                string choiceNumber = Console.ReadLine();
                char c = choiceNumber[0];
                 
            if(Char.IsNumber(c)){
                //Console.WriteLine("My optoin is " + Char.GetNumericValue(c));
                option = (int)Char.GetNumericValue(c);
                if(option == 1 || option == 2){
                    enterIsNotCorrect = false;
                }
               // Console.WriteLine("Please enter number 1 Or 2 ==> " + option);

            }
            if(enterIsNotCorrect)
            Console.WriteLine("Invalid!!\tPlease enter number 1 Or 2 ");
            
            }while(enterIsNotCorrect);

            return option;
        }

       public string getFirstName(){
            Console.WriteLine("Please Enter your First Name: ");
            string firstName = Console.ReadLine();

            return  firstName;
        }
            public string getLastName(){
            Console.WriteLine("Please Enter your First Name: ");
            string LastName = Console.ReadLine();

            return  LastName;
        }

        
    }
}