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
    );
}