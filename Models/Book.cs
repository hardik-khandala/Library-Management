using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library_Management.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        
        public decimal Price { get; set; }  
        public int YearPublished {  get; set; }
        public int Stock {  get; set; }
    }
}
