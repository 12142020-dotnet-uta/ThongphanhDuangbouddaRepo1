using System;
using AppStore.DAL;


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
                AddStore addStore = new AddStore();
                Store newStore = addStore.AddNewStore();  
                repo.AddStore(newStore);
            }


            /*
            Console.WriteLine("enum iD " + (int)StoreNames.StoreName.Sacramento );
            string storeq = (StoreNames.StoreName.Sacramento.ToString("g"));
            //store.StoreId = (int)StoreNames.StoreName.Redwood;
            store.StoreName = StoreNames.StoreName.Redwood.ToString("g");
            store.City =   StoreNames.StoreName.Redwood.ToString("g");
            store.State = "Ca";
            store.Address = "5588 10th RedWood";
        
            repo.AddStore(store);
            */
            //add product to inventory; add all or add to single store.

            firstName  = getFirstName();
            lastName = getFirstName();

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
