using MediatR;
using Microsoft.EntityFrameworkCore;
using MockHotelProject.DataLayer;
using MockHotelProject.DataLayer.DependencyInjection;
using MockHotelProject.DataLayer.Models;
using MockHotelProject.DataLayer.QueryObjects;
using MockHotelProject.Mediator;
using MockHotelProject.Mediator.RoomTypeRequest;
using MockHotelProject.RoomTypeApi.Models;
using System.Net;

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

app.MapGet("/getAllRoomTypes", (IMediator _mediator) =>
{
    return _mediator.Send(new RoomTypeSelectRequest(new RoomTypeQueryParameters()));
});

app.MapGet("/getRoomTypeById", (IMediator _mediator, int id) =>
{
    return _mediator.Send(new RoomTypeSelectRequest(new RoomTypeQueryParameters() { Id = id }));
});

app.MapGet("/getRoomTypesByDescription", (IMediator _mediator, string roomTypeDesc) =>
{
    return _mediator.Send(new RoomTypeSelectRequest(new RoomTypeQueryParameters() { RoomTypeDesc = roomTypeDesc }));
});

app.MapGet("/getRoomTypesByAccomodation", (IMediator _mediator, int idAccomodation) =>
{
    return _mediator.Send(new RoomTypeSelectRequest(new RoomTypeQueryParameters() { IdAccomodation = idAccomodation }));
});

app.MapPost("/insertRoomTypes", (IMediator _mediator, InsertModel roomType) =>
{
    var returnObj = _mediator.Send(new RoomTypeInsertRequest(
        new RoomType
        {
            AccomodationId = roomType.AccomodationId,
            RoomTypeDesc = roomType.RoomTypeDesc,
            Heirarchy = roomType.Heirarchy,
        }));
    return returnObj.Result != null ? Results.Ok() : Results.StatusCode(500);
});

app.MapPut("/updateRoomTypes", (IMediator _mediator, RoomType roomType) =>
{
    var returnObj = _mediator.Send(new RoomTypeUpdateRequest(roomType));
    return returnObj.Result != null ? Results.Ok() : Results.StatusCode(500);
});
app.MapDelete("/deleteRoomTypes", (IMediator _mediator, int idRoomType) =>
{
    var returnNum = _mediator.Send(new RoomTypeDeleteRequest(idRoomType));
    return returnNum.Result == 1 ? Results.Ok() : Results.NotFound();
});

app.Run();