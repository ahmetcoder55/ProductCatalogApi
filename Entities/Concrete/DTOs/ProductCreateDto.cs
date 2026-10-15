namespace Entities.Concrete.DTOs
{
    public record ProductCreateDto(
        int CategoryId, 
        string ProductName, 
        string Description, 
        string Content
    );
}