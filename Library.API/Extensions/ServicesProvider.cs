using Library.Application.IServices;
using Library.Application.Services;
using Library.Domain.IRepositories;
using Library.Domain.Models;
using Library.Infrastructure.Repositories;

namespace Library.Extensions;

public static class ServicesProvider
{
    public static void ProvideServices(this IServiceCollection services)
    {
        #region Repositories
        
        services.AddTransient<ICrudRepository<Book,string>,BooksRepository>();
        
        #endregion

        #region Services

        services.AddScoped<IBooksService,BooksService>();

        #endregion
    }
}