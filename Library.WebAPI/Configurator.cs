using Library.WebAPI.Authors.Abstractions;
using Library.WebAPI.Authors.Repositories;
using Library.WebAPI.Books.Abstractions;
using Library.WebAPI.Books.Repositories;
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

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(Configurator).Assembly);
        });

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
        app.ApplyMigrations();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapControllers();

        return app;
    }

    public static IApplicationBuilder ApplyMigrations(
        this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        using var dbContext = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();

        dbContext.Database.Migrate();

        return app;
    }
}