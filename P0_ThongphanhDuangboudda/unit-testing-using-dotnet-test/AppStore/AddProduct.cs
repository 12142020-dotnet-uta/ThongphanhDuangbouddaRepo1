using System;
using AppStore.DAL;
using AppStore.Models;
using System.Linq;

namespace AppStore
{
    public class AddProduct
    {
        public void getClassName(){
            Console.WriteLine("it  is AddProduct");
        }
        /*
        * PURPOSE : View product by store ID
        *
        * RETURN : String of products available
        *
        *F*/
        public string viewProduct(int storeID){
            string str ="";
            using(var db = new AppStoreContext()){
                var product = db.Products
                    .Where(x => x.StoreId == storeID).ToList();
                foreach(var item in product){
                    str = str + item.ProductID + "\t\t" + item.ProductName + "\t\t" + item.ProductDescription + "\t\t" + item.Category + "\t\t" + item.Price + "\t\t" + item.Quantity + "\t\t" + item.StoreId + "\n";
                }
        
            }

            return str;
        }
        /*
        * PURPOSE : Add procuts to database
        *
        * RETURN : String of order history by cheapest
        *
        *F*/
        public void AddNewProduct(){
            Product product = new Product();
            string[] categories = {"Electronic","Grocery","Clothing"};
            string productName = "0";
            string productDes = "";
            string productCategory = "";
            decimal price = 0;
            int quantity = 100;
            product.Quantity = quantity;
            string enter = "";


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
                    product.ProductName = productName;
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
                    product.ProductDescription = productDes;
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
                    product.Category = productCategory;
                    invalidInput = false;
                }else{
                    Console.WriteLine("Please re-enter a number: ");
                    invalidInput = true;
                }
                   
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
                        product.Price = price;
                        invalidInput = false;
                    }else{
                        Console.WriteLine("Please re-enter price: ");
                    }

                }while(invalidInput);

                        
            //add product 
            AddProductDAL productDAL = new AddProductDAL();
            productDAL.AddProduct(product);


        }
        /*
        * PURPOSE : Search for product by ID
        *
        * RETURN : Product object match by ID
        *
        *F*/
        public Product SearchForProducts(int id){
            
            using(var db = new AppStoreContext()){
                var product = db.Products
                .Where(p =>p.ProductID == id)
                .FirstOrDefault();
                if(product != null){
                    return product;
                }
            }

            return null;
        }
        /*
        * PURPOSE : get item number from user
        *
        * RETURN : integer
        *
        *F*/
        public int GetItemNumber(){
            bool correctItemNumber = true;
            string enter = "";
            int itemNumber = 0;
            do{
                Console.Write("Enter the product number you want to purchase : ");
                enter = Console.ReadLine().Trim();
                correctItemNumber = Int32.TryParse(enter, out itemNumber);

            }while(!correctItemNumber);
           
           return itemNumber;

        }
        /*
        * PURPOSE : get quantity from user
        *
        * RETURN : integer
        *
        *F*/
        public int getQuantity(){
            bool correctItemNumber = true;
            string enter = "";
            int itemNumber = 0;
            do{
                Console.Write("Enter Quantity you want to purchase : ");
                enter = Console.ReadLine().Trim();
                correctItemNumber = Int32.TryParse(enter, out itemNumber);

            }while(!correctItemNumber);
           
           return itemNumber;

        }
        
    }
}