using System;

namespace StringManipulationChallenge
{
    class Animal
{
    public void Eat() => System.Console.WriteLine("Eating.");

    public override string ToString() => "I am an animal.";
}
 
class Reptile : Animal { }
class Mammal : Animal { }
    public class Program
    {
           static void Test(Animal a)
    {
        // System.InvalidCastException at run time
        // Unable to cast object of type 'Mammal' to type 'Reptile'
        Reptile r = (Reptile)a;
    }
        static void Main(string[] args)
        {

                  //  Test(new Animal());

                  Reptile r = new Reptile();
                  Animal a = r;
                  Reptile newr = (Reptile)a;
                  Animal animal = new Animal();
                  Animal newAnimal = new Animal();

                  if(typeof(Animal) == animal.GetType()){
                      Console.WriteLine ("THese types are equal");
                  }

                  ///newr = (Reptile)animal; runtime exception

                  Console.WriteLine("Type of " + animal.GetType());


        // Keep the console window open in debug mode.
        Console.WriteLine("Press any key to exit.");
        Console.Read();
            Console.WriteLine(" this code is run");
            double d = 1234.7;
            int x = 0;
                x =(int)d;
            Console.WriteLine("this is a 1234.7 : " + x);
            x = 11;
            int y = 2;
            
            d = (double)x/2; // +(double)(x%2)/2;
            Console.WriteLine("d = " + d);

            string userInputString; //this will hold your users message
            int elementNum;         //this will hold the element number within the messsage that your user indicates
            char char1;             //this will hold the char value that your user wants to search for in the message.
            string fName;           //this will hold the users first name
            string lName;           //this will hold the users last name
            string userFullName;    //this will hold the users full name;
            
            //
            //
            //implement the required code here and within the methods below.
            //
            //


        }

        // This method has one string parameter. 
        // It will:
        // 1) change the string to all upper case, 
        // 2) print the result to the console and 
        // 3) return the new string.
        public static string StringToUpper(string x){
            throw new NotImplementedException("StringToUpper method not implemented.");
        }

        // This method has one string parameter. 
        // It will:
        // 1) change the string to all lower case, 
        // 2) print the result to the console and 
        // 3) return the new string.        
        public static string StringToLower(string x){
            throw new NotImplementedException("StringToUpper method not implemented.");

        }
        
        // This method has one string parameter. 
        // It will:
        // 1) trim the whitespace from before and after the string, 
        // 2) print the result to the console and 
        // 3) return the new string.
        public static string StringTrim(string x){
            throw new NotImplementedException("StringTrim method not implemented.");

        }
        
        // This method has two parameters, one string and one integer. 
        // It will:
        // 1) get the substring based on the integer received, 
        // 2) print the result to the console and 
        // 3) return the new string.
        public static string StringSubstring(string x, int elementNum){
            throw new NotImplementedException("StringSubstring method not implemented.");

        }

        // This method has two parameters, one string and one char.
        // It will:
        // 1) search the string parameter for the char parameter
        // 2) return the index of the char.
        public static int SearchChar(string userInputString, char x){
            throw new NotImplementedException("SearchChar method not implemented.");
        }

        // This method has two string parameters.
        // It will:
        // 1) concatenate the two strings with a space between them.
        // 2) return the new string.
        public static string ConcatNames(string fName, string lName){
            throw new NotImplementedException("ConcatNames method not implemented.");
        }



    }//end of program
}
