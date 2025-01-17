namespace BusinessLogicLayer.Dto;

public record ProductAddRequest(
    string ProductName,
    EnumCategoryOptions Category,
    double? UnitPrice,
    int? QuantityInStock)
{
    public ProductAddRequest() : 
        this(string.Empty, default, null, null) { }
}
