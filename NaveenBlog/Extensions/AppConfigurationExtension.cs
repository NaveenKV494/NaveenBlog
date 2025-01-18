using Microsoft.EntityFrameworkCore;
using NaveenBlog.Data.DBContext;
using NaveenBlog.Data.Repositories.Abstractions;
using NaveenBlog.Data.Repositories.Implementations;
using NaveenBlog.Service.Abstractions;
using NaveenBlog.Service.Implementations;

namespace NaveenBlog.Extensions
{
    public static class AppConfigurationExtension
    {
        public static IServiceCollection ConfigureAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BlogDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }

        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            #region Writings alias Posts
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPostService, PostService>();
            #endregion

            #region Book Reviews
            services.AddScoped<IBookReviewRepository, BookReviewRepository>();
            services.AddScoped<IBookReviewService, BookReviewService>();
            #endregion

            #region Book Recoms
            services.AddScoped<IBookRecomRepository, BookRecomRepository>();
            services.AddScoped<IBookRecomService, BookRecomService>();
            #endregion



            return services;
        }

        public static IServiceCollection ConfigureCutomCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowBlazorClient", builder =>
                {
                    builder.AllowAnyOrigin()  // Blazor WASM URL
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });
            return services;
        }
    }


}
