using Bogus;
using Microsoft.EntityFrameworkCore;

namespace Library.WebAPI.Persistence;

public static class SeedDataExtensions
{
    public static async Task<IApplicationBuilder> SeedTestDataAsync(
        this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        await using var dbContext = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();

        if (await dbContext.Authors.AnyAsync()) return app;

        dbContext.Authors.AddRange(GetAuthorsByBooks());
        await dbContext.SaveChangesAsync();

        return app;
    }

    private static IEnumerable<Author> GetAuthorsByBooks()
    {
        var faker = new Faker();

        var data = new List<Author>();

        for (var i = 0; i < 10; i++)
        {
            var author = new Author()
            {
                Name = faker.Name.FullName(),
                Books = new List<Book>()
            };

            for (var j = 0; j < 10; j++)
            {
                author.Books.Add(new()
                {
                    Title = faker.Lorem.Sentence(5),
                    PublishedYear = faker.Date.PastDateOnly(20).Year
                });
            }

            data.Add(author);
        }

        return data;
    }
}