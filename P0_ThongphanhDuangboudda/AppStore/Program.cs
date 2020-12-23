using System;

namespace AppStore
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu nenu = new Menu();
            string firstName = "";
            string lastName = "";
            string enter = "";
            bool conntinueToShop = false;

            Console.WriteLine("\n\n========= Welcome To  Rose Clothing Stroes ======== \n");
            Console.WriteLine("Please enter any key to enter; X to  Exit");
            enter = Console.ReadLine().Trim();
            if(enter.Length == 0) enter = "yes";
           // Console.WriteLine("lent of enter  " + enter.Length);
            if(enter[0] == 'X' || enter[0] == 'x' || enter.Length == 0){
                Environment.Exit(0);
            }

            do{
                bool correctFirstName = false;
                //get first name 
                Console.WriteLine("Please enter first name: ");
                do{
                   
                    firstName = Console.ReadLine().Trim();
                    if(firstName.Length == 0 ){
                        Console.WriteLine("Please re-enter your first name: ");
                    }else{
                        correctFirstName = true;
                    }
                }while(!correctFirstName);
                //get last name 
                Console.WriteLine("Please enter last name: ");
                bool incorrectLastName = true;
                do{
                    lastName = Console.ReadLine().Trim();
                    if(lastName.Length == 0){
                        Console.WriteLine("Please re-enter your last name: ");
                    }else{
                        incorrectLastName = false;
                    }

                }while(incorrectLastName);

            }while(conntinueToShop);

            

            


        }
    }

}
