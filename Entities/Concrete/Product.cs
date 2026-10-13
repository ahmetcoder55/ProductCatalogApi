using Entities.Abstract;

namespace Entities.Concrete
{
   public class Product:IEntity
    { 
        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAte { get; set; }=DateTime.Now;

        public Category Category { get; set; }


        
    }   
}