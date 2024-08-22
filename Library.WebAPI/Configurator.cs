using Library.WebAPI.Authors;
using Library.WebAPI.Authors.Abstractions;
using Library.WebAPI.Books;
using Library.WebAPI.Books.Abstractions;
using Library.WebAPI.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Library.WebAPI;

public static class Configurator
{
    public static IServiceCollection AddServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddControllers();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        var connectionString = configuration.GetConnectionString("SqlServer");

        services.AddDbContext<LibraryDbContext>(options =>
        {
            options.UseSqlServer(connectionString)
                .AddInterceptors(new LibrarySaveChangesInterceptor());
        });

        services.AddScoped<ISaver>(sp =>
            sp.GetRequiredService<LibraryDbContext>());

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();

        return services;
    }

    public static WebApplication UseMiddlewares(
        this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapControllers();

        return app;
    }
}