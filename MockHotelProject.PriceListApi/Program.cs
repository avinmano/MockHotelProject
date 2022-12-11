using MediatR;
using Microsoft.EntityFrameworkCore;
using MockHotelProject.DataLayer.DependencyInjection;
using MockHotelProject.DataLayer;
using MockHotelProject.Mediator;
using MockHotelProject.DataLayer.QueryObjects;
using MockHotelProject.Mediator.RoomTypeRequest;
using MockHotelProject.Mediator.PriceListRequest;
using MockHotelProject.DataLayer.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection"));
});
builder.Services.AddMediatR(typeof(MediatRAssemblyEntry).Assembly);
builder.Services.RegisterDataLayerDependencies(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/getAllPriceList", (IMediator _mediator) =>
{
    return _mediator.Send(new PriceListSelectRequest(new PriceListQueryParameters()));
});

app.MapGet("/getPriceListById", (IMediator _mediator, int id) =>
{
    return _mediator.Send(new PriceListSelectRequest(new PriceListQueryParameters() { Id = id }));
});

app.MapGet("/getPriceListRoomTypeId", (IMediator _mediator, int idRoomType) =>
{
    return _mediator.Send(new PriceListSelectRequest(new PriceListQueryParameters() { IdRoomType = idRoomType }));
});

app.MapGet("/getPriceListByPrice", (IMediator _mediator, decimal price) =>
{
    return _mediator.Send(new PriceListSelectRequest(new PriceListQueryParameters() { Price = price }));
});

app.MapGet("/getPriceListByPriceRange", (IMediator _mediator, decimal minPrice, decimal maxPrice) =>
{
    return _mediator.Send(new PriceListSelectRequest(new PriceListQueryParameters() { MinPrice = minPrice, MaxPrice = maxPrice }));
});

app.MapPost("/insertPrice", (IMediator _mediator, PriceList price) =>
{
    var returbObj = _mediator.Send(new PriceListInsertRequest(price));
    return returbObj.Result != null ? Results.Ok() : Results.Problem();
});

app.MapPut("/updatePrice", (IMediator _mediator, PriceList price) =>
{
    var returnObj = _mediator.Send(new PriceListInsertRequest(price));
    return returnObj.Result != null ? Results.Ok() : Results.Problem();
});
app.MapDelete("/deletePriceList", (IMediator _mediator, int idPriceList) =>
{
    var returnNum = _mediator.Send(new PriceListDeleteRequest(idPriceList));
    return returnNum.Result == 1 ? Results.Ok() : Results.NotFound();
});

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}