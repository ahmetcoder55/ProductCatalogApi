namespace Entities.Concrete.DTOs
{
    public record ProductDto(
        
        int ProductId, 
        int CategoryId, 
        string CategoryName, 
        string ProductName, 
        string Description, 
        string Content, 
        DateTime CreatedAte
    )
    {
        public ProductDto() : this(0, 0, string.Empty, string.Empty, string.Empty, string.Empty, DateTime.Now) 
        { 
        }
    };
}