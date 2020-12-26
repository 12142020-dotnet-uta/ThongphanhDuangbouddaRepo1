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
                      
                        
                        

                    
                        /*
                        //enter product
                        Console.WriteLine("Please enter product name: ");
                        bool invalidInput = true;
                        enter ="";
                        //get product name
                        do{
                            enter = Console.ReadLine().Trim();
                            if(enter.Length == 0){
                                Console.WriteLine("Please re-enter product name : ");
                            }else{
                                invalidInput = false;
                                productName = enter;
                            }

                        }while(invalidInput);
                        invalidInput = true;
                        //get product Description
                        Console.WriteLine("Please enter product description: ");
                        do{
                            enter = Console.ReadLine().Trim();
                            if(enter.Length == 0){
                                Console.WriteLine("Please re-enter Product Description: ");
                            }else{
                                productDes = enter;
                                invalidInput = false;
                            }


                        }while(invalidInput);
                        invalidInput = true;
                        //get product category
                        Console.WriteLine("Please enter: \n\t1. for Electorinc \n\t2. For Grocery \n\t3. For Clothing");
                        do{
                            bool numberTrue = true;
                            int select = 0;
                            enter = Console.ReadLine().Trim();
                            numberTrue = Int32.TryParse(enter, out select);
                            if(numberTrue == true && select < 4 && select > 0){
                                productCategory = categories[select - 1];
                                invalidInput = false;
                            }else{
                                invalidInput = true;
                            }
                            Console.WriteLine("Please re-enter a number: ");
                        }while(invalidInput);
                        invalidInput = true;
                        //get product price
                        Console.WriteLine("Enter Price: ");
                        do{
                            bool realMoney = true;
                            enter = Console.ReadLine().Trim();
                            realMoney = Decimal.TryParse(enter, out price);
                            if(realMoney == true){
                                Console.WriteLine("You entered:  $" + price);
                                invalidInput = false;
                            }else{
                                Console.WriteLine("Please re-enter price: ");
                            }

                        }while(invalidInput);
                        
                      
                        //getStoreID //read store
                        using(var db = new AppStoreContext()){
                            var stores = db.Stores;
                            foreach(var store in stores){
                                Console.WriteLine("StoreId: " + store.StoreId);
                            }

                        }
                        
                        //add product 
                        */

                    }
                    admin = false;

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