using CertAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICertificateRepo, JsonCertificateRepo>();     // Change to SQL or something later

// builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGet("/api/test", (ICertificateRepo repo) => 
{
    return repo.LoadCerts();
});

app.MapPost("/api/cert", (Certificate certificate, ICertificateRepo repo) =>
{
    repo.SaveCerts(certificate);
    return Results.Created("/api/test", certificate);
});

app.UseStaticFiles();   // enable html
app.Run();
