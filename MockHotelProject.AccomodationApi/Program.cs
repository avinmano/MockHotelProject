using Microsoft.EntityFrameworkCore;
using MockHotelProject.DataLayer;
using MediatR;
using MockHotelProject.DataLayer.DependencyInjection;
using MockHotelProject.Mediator;
using MockHotelProject.DataLayer.QueryObjects;
using Microsoft.AspNetCore.Mvc;
using MockHotelProject.DataLayer.Models;
using MockHotelProject.Mediator.AccomodationRequest;
using System.Net;
using MockHotelProject.AccomodationApi.Models;

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

app.UseExceptionHandler(error =>
{
    error.Run(async httpContext =>
    {
        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        //CAN ADD LOGGING OF EXCEPTIONS HERE
    });
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/getAllAccomodations", (IMediator _mediator) =>
{
    return _mediator.Send(new AccomodationSelectRequest(new AccomodationQueryParameters()));
});

app.MapGet("/getAllAccomodationsByName", (IMediator _mediator, [FromQuery] string name) =>
{
    return _mediator.Send(new AccomodationSelectRequest(new AccomodationQueryParameters { Name = name }));
});

app.MapGet("/getAllAccomodationsByNameLikeCondition", (IMediator _mediator, [FromQuery] string name) =>
{
    return _mediator.Send(new AccomodationSelectRequest(new AccomodationQueryParameters { NameLike = name }));
});

app.MapGet("/getAllAccomodationsByAddress", (IMediator _mediator, [FromQuery] string address) =>
{
    return _mediator.Send(new AccomodationSelectRequest(new AccomodationQueryParameters { Address = address }));
});

app.MapGet("/getAllAccomodationsByCity", (IMediator _mediator, [FromQuery] string city) =>
{
    return _mediator.Send(new AccomodationSelectRequest(new AccomodationQueryParameters { City = city }));
});

app.MapGet("/getAllAccomodationsByCountry", (IMediator _mediator, [FromQuery] string country) =>
{
    return _mediator.Send(new AccomodationSelectRequest(new AccomodationQueryParameters { Country = country }));
});

app.MapPost("/insertAccomodation", (IMediator _mediator, [FromBody] InsertModel accomodation) =>
{
    var returnObj = _mediator.Send(new AccomodationInsertRequest( 
        new Accomodations 
        { 
            Name = accomodation.Name,
            Address = accomodation.Address,
            City = accomodation.City,
            Country = accomodation.Country,
        }));
    return returnObj.Result != null ? Results.Ok() : Results.StatusCode(500);
});

app.MapPut("/updateAccomodation", (IMediator _mediator, [FromBody] Accomodations accomodation) =>
{
    var returnObj = _mediator.Send(new AccomodationUpdateRequest(accomodation));
    return returnObj.Result != null ? Results.Ok() : Results.StatusCode(500);
});

app.MapDelete("/deleteAccomodation", (IMediator _mediator, [FromQuery] int id) =>
{
    var returnNumber = _mediator.Send(new AccomodationDeleteRequest(id));
    return returnNumber.Result == 1 ? Results.Ok() : Results.NotFound();
});

app.Run();

