using System.Linq.Expressions;
using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories;

public class ProductRepository(ApplicationDbContext context) : IProductRepository
{
    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await context.Products.ToListAsync();
    }

    public async Task<IEnumerable<Product?>> GetProductsByCondition(Expression<Func<Product, bool>> condition)
    {
        return await context.Products.Where(condition).ToListAsync();
    }

    public async Task<Product?> GetProductByCondition(Expression<Func<Product, bool>> condition)
    {
        return await context.Products.FirstOrDefaultAsync(condition);
    }

    public async Task<Product?> AddProduct(Product product)
    {
        await context.Products.AddAsync(product);
        var affectedRowsCount = await context.SaveChangesAsync();
        return affectedRowsCount > 0 ? product: null;
    }

    public async Task<Product?> UpdateProduct(Product product)
    {
        var foundedProduct = await context.Products
            .FirstOrDefaultAsync(temp => temp.ProductId == product.ProductId);
        if(foundedProduct == null) return null;
        foundedProduct.ProductName = product.ProductName;
        foundedProduct.UnitPrice = product.UnitPrice;
        foundedProduct.QuantityInStock = product.QuantityInStock;
        foundedProduct.Category = product.Category;
        var affectedRowsCount = await context.SaveChangesAsync();
        return affectedRowsCount > 0 ? foundedProduct : null;
    }

    public async Task<bool> DeleteProduct(Guid productId)
    {
        var foundedProduct = await context.Products
            .FirstOrDefaultAsync(product => product.ProductId == productId);
        if(foundedProduct == null) return false;
        context.Products.Remove(foundedProduct);
        var affectedRowsCount = await context.SaveChangesAsync();
        return affectedRowsCount > 0;
    }
}