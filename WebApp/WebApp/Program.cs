using WebApp.Models;
using WebApp.Controllers;
using Microsoft.EntityFrameworkCore;


namespace WebApp 
{
    public class Program 
    {
        public static void Main(string[] args) 
        {
            List<Client> partsList = new List<Client>();

            Handler<Client> partsHandler = new Handler<Client>("FileClients.json");
            /*
            partsList.Add(new Client(100, "Vadim Korneev", "123123", new Mentor( 1, "Mathematics", "Thsiporkova K.A.")));
            partsList.Add(new Client(101, "Vadim Korneev", "123123", new Mentor(1, "Mathematics", "Thsiporkova K.A.")));
            */
            partsHandler.Update(partsList);
            partsHandler.OutputJsonContents();


            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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