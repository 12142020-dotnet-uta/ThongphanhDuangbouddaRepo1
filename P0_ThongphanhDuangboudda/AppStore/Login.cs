using AppStore.Models;
using AppStore.DAL;
using System;
namespace AppStore
{
    public class Login
    {

        public Customer CustomerLogin(Customer cus){
            Customer customer = cus;
            string firtName = "";
            string lastName = "";
            firtName = getFirstName();
            lastName = getLastName();
            customer.FirstName = firtName;
            customer.LastName = lastName;

            return customer;
        }

        public void AdminLogin(){
                        //Add store
                AddProduct newP = new AddProduct();
                newP.getClassName();
                     
                string[] categories = {"Electronic","Grocery","Clothing"};
                string productName = "0";
                string productDes = "";
                string productCategory = "";
                decimal price = 0;
                int quantity = 100;

                string enter = "";
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
                        bool addingNewProduct = true;
                        do{
                            newP.AddNewProduct();
                            Console.WriteLine("Continue to add Product? y/Y");
                            enter = Console.ReadLine().Trim();
                            if(enter[0] == 'Y' || enter[0] == 'y'){
                                newP.AddNewProduct();
                            }else{
                                addingNewProduct = false;
                            }
                        }while(addingNewProduct);

                    }

                    Console.WriteLine("Continue as admin? y/n");
                    Console.ReadLine().Trim();
                    if(enter[0] == 'Y' || enter[0] == 'y'){
                        admin = true;
                    }else{
                        admin = false;
                    }

                }while(admin);


        }

        
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
        
    }
}