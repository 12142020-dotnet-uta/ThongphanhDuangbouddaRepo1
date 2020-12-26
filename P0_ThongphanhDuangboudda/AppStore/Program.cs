using System;
using AppStore.DAL;
using AppStore.Models;

namespace AppStore
{
    class Program
    {
         //enter program
        static void Main(string[] args)
        {
    
            Login login = new Login();
            Menu menu = new Menu();
            Customer customer = new Customer();
            CustomerDAL cusDAL = new CustomerDAL();
            AddStore addStore = new AddStore();
            AddProduct product = new AddProduct();

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
                login.AdminLogin();

            }else{
                customer = login.CustomerLogin(customer);
            }

            
            do{
                Customer returnCustomer = cusDAL.IsExist(customer);
                if(returnCustomer != null){
                    customer = returnCustomer;
                    Console.WriteLine("Welcome back : " + customer.FirstName);
                    Console.WriteLine(cusDAL.geProductSuggestion(customer));

                }else{
                    repo.AddCustomer(customer);
                    Console.WriteLine("Welcome new customer: " + customer.CustomerId + " Name:  " + customer.FirstName);
                    Console.WriteLine("No Suggested Products yet ...");
                }
              
                do{
                    int storeNumer = 0;
                    bool num = false;
                    //curent login as a customer 
                    Console.WriteLine("You entered Troll stores");
                    Console.WriteLine("Here are available stores :");
                     Console.WriteLine("Store# \tStoreName \tStoreAddress");
                    //viewStore();
                    Console.WriteLine(menu.viewStore());
                   
                    bool inCorrectStoreNumber = true;
                    bool foundStore = true;
                     //get store
                    do{
                        Console.WriteLine("Enter Store#");
                        enter = Console.ReadLine().Trim();
                        num = Int32.TryParse(enter, out storeNumer);
                        if(num){
                            foundStore = addStore.SearchForStore(storeNumer);
                            if(foundStore){
                                Console.WriteLine("Store found");
                                inCorrectStoreNumber = false;
                            }else{
                                Console.WriteLine("Store not found");
                            }
                            
                        }else{
                            inCorrectStoreNumber = true;
                        }

                    }while(inCorrectStoreNumber);
                   
                    //viewProduct();
                    Console.WriteLine("Produc tNumber \tName \t\tPDescription \tCategory \tPrice \t\tQuantity \t\tStoreID \n");
                    Console.WriteLine(product.viewProduct(storeNumer));

                    //selectProduct item;
                    //selectQuantity();
                    //Options checkout()// or logout


                    Console.WriteLine("Continue to shop as " + customer.FirstName);
                    Console.WriteLine("Press 'y' or 'Y' to continue: ");
                    enter = Console.ReadLine().Trim();
                }while(logIn);
                //if logout
                //promp(leave program/ or new customer)  =>exi
                
                //do get a customer 
                //customer = login.CustomerLogin(customer);
                //back to do while.
              

            }while(conntinueToShop);
        }
    }

}
