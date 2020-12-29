using System;
using System.Collections.Generic;
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
            OrderHistoryUI orderHistoryUI = new OrderHistoryUI();
            AddProductDAL productDAL = new AddProductDAL();
           
            CustomerDAL cusDAL = new CustomerDAL();
            AddStore addStore = new AddStore();
            AddProduct product = new AddProduct();
            List<Product> listProducts = new List<Product>();
           

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
               // customer = login.CustomerLogin(customer);
            }

            
            do{
                logIn = true;
                Customer customer = new Customer();
                List<Product> cart = new List<Product>();
                customer = login.CustomerLogin(customer); 
                // getUserName()
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
                int storeNumber = 0;
                // do while Login
                do{
                   
                   // bool num = false;
                    //curent login as a customer 
                    Console.WriteLine("You entered Troll stores");
                    Console.WriteLine("Here are available stores :");
                     Console.WriteLine("Store# \tStoreName \tStoreAddress");
                    //viewStore();
                    Console.WriteLine(menu.viewStore());
                    //getStore()
                    bool found_A_Store = true;
                    do{
                        storeNumber = addStore.getNumber();
                        found_A_Store = addStore.SearchForStore(storeNumber);
                        if(!found_A_Store){Console.WriteLine("Invalid Store Number");}
                    
                    }while(!found_A_Store);

                   
                    //viewProduct();
                    //getList of products
                    listProducts = productDAL.getListOfProducts(storeNumber);
                    foreach(var p in listProducts){
                        Console.WriteLine("got product list " + p.Price);
                    }
                    Console.WriteLine("Produc tNumber \tName \t\tPDescription \tCategory \tPrice \t\tQuantity \t\tStoreID \n");
                    Console.WriteLine(product.viewProduct(storeNumber));

                    //selectProduct item;
                    int itemNumber = 0;
                    bool correctItemNumber = true;
                    Product foundProduct;
                    // add product to cart
                    bool available = false;
                    int quantity = 0;
                    bool checkOut = false;
                    do{
                        bool addToCart = false;
                        correctItemNumber = false;
                        itemNumber = product.GetItemNumber();

                            //check if match
                        foundProduct =  product.SearchForProducts(itemNumber);
                        if(foundProduct != null){
                            Console.WriteLine("You selected item# " + itemNumber);
                            //get valid quantity
                            bool validQuantity = false;
                            do{
                                quantity = product.getQuantity();
                                available= productDAL.CheckProductAvailabilty(storeNumber,quantity);
                                if(available){
                                    //add item to cart
                                    Console.WriteLine("The item has been added to cart");
                                    foundProduct.Quantity = quantity;
                                    correctItemNumber = true;
                                    cart.Add(foundProduct);
                                    addToCart = true;
                                    validQuantity = true;
                                }else{
                                    Console.WriteLine("Please enter amount less then available quantity");
                                }

                            }while(!validQuantity);
                                
                        }else{
                            Console.WriteLine("Product not found");
                            
                        }
                        if(addToCart){
                            Console.WriteLine(menu.ViewCart(cart));
                            Console.WriteLine("Continue to shop as ===> " + customer.FirstName);
                            Console.WriteLine("Press 'y' or 'Y' to continue; else to checkout, L or l to logout");
                            enter = Console.ReadLine().Trim();
                            if(enter.Length == 0){
                                 correctItemNumber = true;
                            } else if(enter[0] == 'Y' || enter[0] == 'y'){
                                correctItemNumber = false;
                            }else if(enter[0] == 'L' || enter[0] == 'l'){
                                logIn = false;
                            }else{
                                checkOut = true;
                            }
                        }

                    }while(!correctItemNumber);
                    if(checkOut){
                        cusDAL.Checkout(cart, storeNumber, customer.CustomerId);
                      //  Console.WriteLine("==================================Order Histories==================================================");
                       // Console.WriteLine("Item Name \t Quantity \t Price \t     At store# ");
                       // Console.WriteLine( orderHistoryUI.GetGeneralOrderHistory(customer.CustomerId));
                        checkOut = false;
                    }
                    if(logIn){
                        //view history
                    Console.WriteLine("==================================Order Histories==================================================");
                    Console.WriteLine("Item Name \t Quantity \t Price \t     At store# ");
                    Console.WriteLine( orderHistoryUI.GetGeneralOrderHistory(customer.CustomerId));
                     
                    bool options = true;
                    //view specific store
                    
                        Console.WriteLine("Enter Y or y to view order history for specific store, C or c to continue shoping, else  to logout");
                        enter = Console.ReadLine().Trim();
                        if(enter.Length == 0){
                            logIn = false;
                        } else if(enter[0] == 'Y' || enter[0] == 'y'){
                            bool viewingAStore = true;
                            do{
                                 int num = addStore.getNumber();
                                 bool found = addStore.SearchForStore(num);
                                 if(found){
                                    Console.WriteLine("==================================Order Histories For Stroe # {0}  ==================================================", num);
                                    Console.WriteLine("Item Name \t Quantity \t Price \t     At store# ");
                                    Console.WriteLine(orderHistoryUI.GetSpecificStoreOrderHistory(customer.CustomerId, num)); 
                                    Console.WriteLine("Continue to view Other stores ?");
                                    string str = Console.ReadLine().Trim();
                                    if(str.Length == 0){
                                        viewingAStore = false;
                                    }else if(str[0] == 'Y' || str[0] =='y'){
                                        viewingAStore = true;
                                    }else{
                                        viewingAStore = false;
                                    }
                                 }else{Console.WriteLine("Invalid, Please re-enter storeNumber");}

                            }while(viewingAStore);
                                
                        }else if(enter[0] == 'C' || enter[0] =='c'){
                            logIn = true;

                        }else { logIn = false;}

                    }

                    if(logIn){
                    
                        Console.WriteLine("Continue to shop: Press y or Y; enter any thing else to logout");
                        enter = Console.ReadLine().Trim();
                         if(enter.Length == 0){
                            logIn = false;
                         }else if(enter[0] == 'Y' || enter[0] == 'y'){
                            logIn = true;
                         }else{
                            logIn = false;
                        }

                    }

                }while(logIn); //logout

                Console.WriteLine("You are logged out");
                Console.WriteLine("Press Y or y to constinue to shop, else exit program");
                enter = Console.ReadLine().Trim();
                if(enter.Length == 0){
                    conntinueToShop = false;
                } else if(enter[0] == 'Y' || enter[0] == 'y'){
                    conntinueToShop = true;
                }else { conntinueToShop = false;}
               

            }while(conntinueToShop);
        }

        
    public static string GetAnswer(){
        string str = "";
        return str;

    }
    }

}
