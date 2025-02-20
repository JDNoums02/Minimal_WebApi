using System.Runtime.CompilerServices;
using System.Security.Cryptography.Xml;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using TP4;
using TP4.Models;
using TP4.Services;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddSingleton<IMemoryDb, MemoryDb>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString)
);

//pour resoudre le problème de référence cyclique
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
);

// Register the new services
builder.Services.AddScoped<TrajetsService>();
builder.Services.AddScoped<ArretsService>();

// Add services to the container. Required for MinimalAPIs
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

// Ajouter les routes ici

// app.Map...

app.MapGet(
    "/trajets",
    (TrajetsService services) =>
    {
        return Results.Ok(services.GetAllTrajets());
    }
);

app.MapGet(
    "/trajets/{idTrajet:int}",
    (int idTrajet, bool? includearrets, TrajetsService services) =>
    {
        if (services.GetTrajetById(idTrajet, false) != null)
        {
            if (includearrets != null)
            {
                return Results.Ok(services.GetTrajetById(idTrajet, includearrets));
            }
            else
            {
                return Results.Ok(services.GetTrajetById(idTrajet, false));
            }
        }

        return Results.NotFound();
    }
);

app.MapPost(
    "/trajets",
    (Trajet trajet, TrajetsService services) =>
    {
        if (trajet != null && !String.IsNullOrWhiteSpace(trajet.Nom))
        {
            var newTrajet = services.CreateTrajet(trajet);
            return Results.Created(
                $"https:/localhost:13806/ {trajet.Id}",
                services.GetTrajetById(newTrajet.Id, false)
            );
        }
        return Results.BadRequest();
    }
);
app.MapPost(
    "/trajets/{id:int}/arrets",
    (int id, List<Arret> arrets, TrajetsService services) =>
    {
        Trajet trajet = services.GetTrajetById(id, true);
        if (trajet != null)
        {
            services.AddArretsToTrajet(id, arrets);
            //if(!String.IsNullOrEmpty(trajet.Nom))
            //{
            //    return Results.BadRequest(trajet);
            //}
            return Results.Ok(trajet);
        }
        return Results.NotFound();
    }
);

app.MapGet(
    "/trajets/{idTrajet:int}/arrets",
    (int idTrajet, TrajetsService services) =>
    {
        Trajet trajet = services.GetTrajetById(idTrajet, true);

        if (trajet != null && trajet.PointsArret != null)
        {
            return Results.Ok(services.GetArretsForTrajet(trajet.Id));
        }
        return Results.NotFound();
    }
);

app.MapDelete(
    "/trajets/{id:int}",
    (int id, TrajetsService services) =>
    {
        if (services.GetTrajetById(id, true) != null)
        {
            services.DeleteTrajet(id);
            return Results.NoContent();
        }
        return Results.BadRequest();
    }
);

app.MapGet(
    "/arrets/{id:int}",
    (int id, ArretsService services) =>
    {
        if (services.GetArretById(id) != null)
        {
            return Results.Ok(services.GetArretById(id));
        }
        return Results.NotFound();
    }
);

app.MapDelete(
    "/arrets/{id:int}",
    (int id, ArretsService services) =>
    {
        if (services.GetArretById(id) != null)
        {
            services.DeleteArret(id);
            return Results.NoContent();
        }
        return Results.NotFound();
    }
);

app.Run();
