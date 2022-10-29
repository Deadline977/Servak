using MainService;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

MainServiceClass mainServiceClass = new MainServiceClass();
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/clients", () =>
{
    List<Client> users = mainServiceClass.getAllUsers();
    return mainServiceClass.serializeObject(users);
});
app.MapPost("/clientEdit", (Client user) =>
{
    string result = mainServiceClass.editUser(user);
    return JsonSerializer.Serialize(new Messenger(result));
});
app.MapPost("/clientDelete", (Client user) =>
{
    string result = mainServiceClass.deleteUser(user);
    return JsonSerializer.Serialize(new Messenger(result));
});
app.MapPost("/clients", (Client user) =>
{
    string result = mainServiceClass.addNewUser(user);
    return JsonSerializer.Serialize(new Messenger(result));
});
app.Run();

