using AppStore.Models;
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