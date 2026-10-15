namespace Entities.Concrete.DTOs
{
    public record ProductUpdateDto(
        int ProductId, 
        int CategoryId, 
        string ProductName, 
        string Description, 
        string Content
    );
}