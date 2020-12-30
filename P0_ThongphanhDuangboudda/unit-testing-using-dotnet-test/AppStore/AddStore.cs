using System;
using AppStore.Models;
using AppStore.DAL;
using System.Linq;

namespace AppStore
{
    
    public class AddStore
    {/*
           var found = db.Customers    
                .Where(x => x.FirstName == customer.FirstName && x.LastName == customer.LastName)
                .FirstOrDefault();
    */
        public int getNumber(){
            bool num = true;
            int storeNumber = 0;
            string enter = "";
            bool inCorrectStoreNumber = true;
             //get store
             do{
                inCorrectStoreNumber = true;
                Console.WriteLine("Enter Store#");
                enter = Console.ReadLine().Trim();
                num = Int32.TryParse(enter, out storeNumber);
                if(num){

                    inCorrectStoreNumber = false;
              
                }
            }while(inCorrectStoreNumber);
            //Console.WriteLine("Return Number " + storeNumber);
            return storeNumber;
        }
        public bool SearchForStore( int storeNumer){
           
            using(var db = new AppStoreContext()){
                var store = db.Stores
                    .Where(x => x.StoreId == storeNumer)
                    .FirstOrDefault();
                if(store != null){
                    return true;
                }

            }
            
            return false;
        }
        /*
        * PURPOSE : Add store to database
        *
        * RETURN : Return a store object
        *
        *F*/
        public Store AddNewStore(){
            Store newStore = new Store();
            bool enterCorrectly = false;
            string name = "";
            string location = "";
           // string city = "";
            //string state ="";
            Console.WriteLine("Store Name: ");
            do{
                name = Console.ReadLine().Trim();
                if(name.Length == 0){ 
                    Console.WriteLine("Invalid, Please re-enter Store Name: ");
                }else{
                    newStore.StoreName = name;
                    enterCorrectly = true;
                }
            }while(!enterCorrectly);

            enterCorrectly = false;
            Console.WriteLine("Store Address: ");
            do{
                location = Console.ReadLine().Trim();
                if(location.Length == 0){
                    Console.WriteLine("Invalid, Please re-enter address: ");
                }else{
                    newStore.Address = location;
                    enterCorrectly = true;
                }

            }while(!enterCorrectly);

            newStore.City = "Sacramento";
            newStore.State = "CA";
            return newStore;
        }
    }
}