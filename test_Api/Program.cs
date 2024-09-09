using test_Api.Service.PayFormMellat;
using test_Api.Service.PayFromMeli;
using test_Api.Service.PayFromZarinPal;
using test_Api.Strategy;

namespace test_Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IPaymentFactory, PaymentFactory>();
            builder.Services.AddScoped<IPaymentStrategy, PayFromMeli>();
            builder.Services.AddScoped<IPaymentStrategy, PayFromMellat>();
            builder.Services.AddScoped<IPaymentStrategy, PayFromZarinPal>();
            //  builder.Services.AddScoped<IPaymentStrategy>();

            builder.Services.AddHttpClient("zinbal", httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://rickandmortyapi.com/api/");
            });




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
