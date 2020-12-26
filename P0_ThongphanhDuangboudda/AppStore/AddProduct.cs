using System;
using AppStore.DAL;
using AppStore.Models;

namespace AppStore
{
    public class AddProduct
    {
        public void getClassName(){
            Console.WriteLine("it  is AddProduct");
        }
        
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
        
    }
}