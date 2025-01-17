using System.Linq.Expressions;
using BusinessLogicLayer.Dto;
using BusinessLogicLayer.ServiceContracts;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryContracts;

namespace BusinessLogicLayer.Services;

public class ProductsService : IProductsService
{
    private readonly IProductRepository _productRepository;

    public ProductsService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }


    public Task<IEnumerable<ProductResponse>> GetProducts()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProductResponse?>> GetProductsByCondition(Expression<Func<Product, bool>> condition)
    {
        throw new NotImplementedException();
    }

    public Task<ProductResponse?> GetProductByCondition(Expression<Func<Product, bool>> condition)
    {
        throw new NotImplementedException();
    }

    public Task<ProductResponse?> AddProduct(ProductAddRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ProductResponse?> UpdateProduct(ProductUpdateRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteProduct(Guid productId)
    {
        throw new NotImplementedException();
    }
}
