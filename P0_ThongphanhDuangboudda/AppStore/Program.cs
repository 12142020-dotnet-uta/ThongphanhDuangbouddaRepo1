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
            Test tes = new Test();
            tes.isTest();
            Login login = new Login();
            Menu nenu = new Menu();
            Customer customer = new Customer();
            CustomerDAL cusDAL = new CustomerDAL();

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
                }else{
                    repo.AddCustomer(customer);
                    Console.WriteLine("Welcome new customer: " + customer.CustomerId + " Name:  " + customer.FirstName);
                }
              
                do{
                    //curent login customer 
                    Console.WriteLine("You entered Troll stores");

                    logIn = false;
                }while(logIn);
                //is new customer 
                // yes call login 
                // checking 
                //x to  quiz

            }while(conntinueToShop);
        }
    }

}
