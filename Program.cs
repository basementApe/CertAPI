using CertAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICertificateRepo, JsonCertificateRepo>();     // Change to SQL or something later
builder.Services.AddSingleton<CertManager>();

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
    repo.SaveCert(certificate);
    return Results.Created("/api/cert", certificate);
});

app.MapGet("/api/searchtype", (string type, CertManager manager) =>
{
    return manager.GetByType(type);
});

app.MapGet("/api/searchnumber", (int number, CertManager manager) =>
{
    return manager.GetByNumber(number);
});

app.UseStaticFiles();   // enable html
app.Run();
