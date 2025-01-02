using Dapper;
using eCommerce.Core.Dto;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositories;

internal class UsersRepository(DapperDbContext dbContext) : IUsersRepository
{
    public async Task<ApplicationUser?> AddUserAsync(ApplicationUser user)
    {
        user.UserId = Guid.NewGuid();
        const string query = "INSERT INTO Users"
                             + "(\"userid\", \"email\", \"personname\", \"gender\", \"password\") " 
                             + "VALUES (@UserId, @Email, @PersonName, @Gender, @Password)";
        var rowsAffectedCount = await dbContext.DbConnection.ExecuteAsync(query, user);
        return rowsAffectedCount == 0 ? null : user;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPasswordAsync(string email, string password)
    {
        const string query = "SELECT * FROM users WHERE email=@Email AND password=@Password";
        return await dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, new
        {
            email, password
        });;
    }
}
