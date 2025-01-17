namespace BusinessLogicLayer.Dto;

public record ProductUpdateRequest(
    string ProductName, 
    EnumCategoryOptions Category, 
    double? UnitPrice, 
    int? QuantityInStock)
{
    public ProductUpdateRequest() : 
        this(string.Empty, default, null, null) { }
}
