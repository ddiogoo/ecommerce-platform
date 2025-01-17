namespace BusinessLogicLayer.Dto;

public record ProductResponse(
    Guid ProductId,
    string ProductName, 
    EnumCategoryOptions Category, 
    double? UnitPrice, 
    int? QuantityInStock)
{
    public ProductResponse() : 
        this(Guid.Empty, string.Empty, default, null, null) { }
}