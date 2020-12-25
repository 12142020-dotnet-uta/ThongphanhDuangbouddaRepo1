using System.ComponentModel.DataAnnotations;
namespace AppStore.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        // List<OrderHistory> OrderHistories = new List<OrderHistory();

       // public int StoreID {get; set;}
    }
}