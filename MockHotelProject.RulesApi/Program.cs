using MediatR;
using Microsoft.EntityFrameworkCore;
using MockHotelProject.DataLayer;
using MockHotelProject.DataLayer.DependencyInjection;
using MockHotelProject.DataLayer.Models;
using MockHotelProject.DataLayer.QueryObjects;
using MockHotelProject.Mediator;
using MockHotelProject.Mediator.RoomTypeRequest;
using MockHotelProject.Mediator.RulesRequest;

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

app.MapGet("/getAllRules", (IMediator _mediator) =>
{
    return _mediator.Send(new RulesSelectRequest(0,0,0));
});

app.MapGet("/getRulesById", (IMediator _mediator, int idRule) =>
{
    return _mediator.Send(new RulesSelectRequest(idRule, 0, 0));
});

app.MapGet("/getRulesByIdAccomodation", (IMediator _mediator, int idAccomodation) =>
{
    return _mediator.Send(new RulesSelectRequest(0, idAccomodation, 0));
});

app.MapGet("/getRulesByPercentage", (IMediator _mediator, int percentage) =>
{
    return _mediator.Send(new RulesSelectRequest(0, 0, percentage));
});

app.MapPost("/insertNewRule", (IMediator _mediator, Rules rule) =>
{
    return _mediator.Send(new RulesInsertRequest(rule));
});

app.MapPut("/updateRule", (IMediator _mediator, Rules rule) =>
{
    return _mediator.Send(new RulesUpdateRequest(rule));
});
app.MapDelete("/deleteRule", (IMediator _mediator, int idRule) =>
{
    return _mediator.Send(new RulesDeleteRequest(idRule));
});
app.Run();

