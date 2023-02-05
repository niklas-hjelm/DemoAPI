using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// Steg 1
app.MapGet("/", () => "Test");

// Steg 2
var myName = "Niklas";
app.MapGet("/myName", ()=>$"My name is:{myName}");

//Steg 3
app.MapGet("/yourName/{name}", (string name) => $"Your name is: {name}");

//Steg 4
var people = new Dictionary<Guid,Person>();
app.MapPost("/savePerson", (Person person) =>
{
    people.Add(Guid.NewGuid(),person);
    return Results.Ok();
});

app.MapGet("/getPerson/{id}", (Guid id) => people[id]);

app.MapGet("/getPeople", () => people);

//Steg 5
app.MapDelete("/removePerson/{id}", (Guid id) =>
{
    var exists = people.ContainsKey(id);

    //if (exists is null)
    //{
    //    return Results.NotFound();
    //}

    people.Remove(id);
    return Results.Ok();
});

app.MapPut("/updatePerson/{id}", (Guid id, Person person) =>
{
    var exists = people.ContainsKey(id);

    if (!exists)
    {
        return Results.NotFound();
    }

    people[id] = person;
    return Results.Ok();
});

//Steg 7
app.MapPatch("/changeAge/{id}/{newAge}", (Guid id, int newAge) =>
{
    var exists = people.ContainsKey(id);

    if (!exists)
    {
        return Results.NotFound();
    }

    people[id].Age = newAge;
    return Results.Ok();
});

app.MapPatch("/changeName/{id}/{newName}", (Guid id, string newName) =>
{
    var exists = people.ContainsKey(id);

    if (!exists)
    {
        return Results.NotFound();
    }

    people[id].Name = newName;
    return Results.Ok();
});

app.Run();

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
