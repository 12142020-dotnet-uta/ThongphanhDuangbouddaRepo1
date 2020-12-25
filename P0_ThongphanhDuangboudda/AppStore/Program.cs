using System;
using AppStore.DAL;
using AppStore.Models;



namespace AppStore
{
    class Program
    {
       
      
        public static string getFirstName(){
            string firstName = "default";
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
            return  firstName;
        }
        public static string getLastName(){
            string lastName = "";
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
            return lastName;
        }




        //enter program
        static void Main(string[] args)
        {
            Test tes = new Test();
            tes.isTest();
            Menu nenu = new Menu();
            Customer customer = new Customer();
            CustomerDAL cusDAL = new CustomerDAL();
            string firstName = "";
            string lastName = "";
            string enter = "";
            bool logIn = true;
            bool conntinueToShop = false;
            Store store = new Store();
            RepositoryLayer repo = new RepositoryLayer();

            Console.WriteLine("\n\n========= Welcome To Troll Stores ======== \n");
            Console.WriteLine("Please press any key to enter; X to  Exit  OR  a or A for Admin");
            enter = Console.ReadLine().Trim();
            if(enter.Length == 0) enter = "yes";
           // Console.WriteLine("lent of enter  " + enter.Length);
            if(enter[0] == 'X' || enter[0] == 'x' || enter.Length == 0){
                Environment.Exit(0);
            }


            // Amin loggin
            if(enter[0] == 'A' || enter[0] == 'a'){
            //Add store
                bool admin = true;
                do{
                    Console.WriteLine("Press y or Y to add store:  press any key to add products: x or X to exit or space");
                    enter = Console.ReadLine();
                    if(enter[0] == 'X' || enter[0] == 'x' || enter.Length == 0){
                     Environment.Exit(0);
                    }else if(enter[0] == 'Y' || enter[0] == 'y'){
                        AddStore addStore = new AddStore();
                        Store newStore = addStore.AddNewStore();  
                        Console.WriteLine("Added Store");
                        // repo.AddStore(newStore);
                       // Environment.Exit(0);
                    }else{
                        //add product 
                        //getStoreID //read store


                    }

                }while(admin);


            }else{
                //Customer loop
                firstName  = getFirstName();
                lastName = getFirstName();
                customer.FirstName = firstName;
                customer.LastName = lastName;
                cusDAL.IsExist(customer);
                //repo.AddCustomer(customer);
            }

            

            //
            do{
                // Check if the user is an existing user; if not, assign as a new user; ===> RepositoryLayer();
                //customers select a store
                do{

                    logIn = false;
                }while(logIn);

            }while(conntinueToShop);
        }
    }

}
