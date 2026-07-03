using System.Text.Json;
using CertAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICertificateRepo, JsonCertificateRepo>();     // Change to SQL or something later

// builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    // app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Get sends to frontend, Post receives from frontend
app.MapGet("/api/test", (ICertificateRepo repo) => 
{
    // if (!File.Exists(filename)) return Array.Empty<Certificate>();
    // var json = File.ReadAllText(filename);
    // return JsonSerializer.Deserialize<Certificate[]>(json);
    return repo.LoadCerts();
});

app.MapPost("/api/cert", (Certificate certificate, ICertificateRepo repo) =>
{
    // var certs = new List<Certificate>();
    // if (File.Exists(filename))
    // {
    //     var json1 = File.ReadAllText(filename);
    //     var certsArray = JsonSerializer.Deserialize<Certificate[]>(json1);
    //     certs.AddRange(certsArray);
    // }
    // certs.Add(certificate);
    // var json2 = JsonSerializer.Serialize(certs);
    // File.WriteAllText(filename, json2);
    repo.SaveCerts(certificate);
    return Results.Created("/api/test", certificate);
});

app.UseStaticFiles();   // enable html
app.Run();
