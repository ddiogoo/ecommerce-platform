using System.Linq.Expressions;
using BusinessLogicLayer.Dto;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.ServiceContracts;

public interface IProductsService
{
    Task<IEnumerable<ProductResponse>> GetProducts();
    Task<IEnumerable<ProductResponse?>> GetProductsByCondition(Expression<Func<Product, bool>> condition);
    Task<ProductResponse?> GetProductByCondition(Expression<Func<Product, bool>> condition);
    Task<ProductResponse?> AddProduct(ProductAddRequest request);
    Task<ProductResponse?> UpdateProduct(ProductUpdateRequest request);
    Task<bool> DeleteProduct(Guid productId);
}
