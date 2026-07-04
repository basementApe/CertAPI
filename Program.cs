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


app.MapGet("/api/completelist", (ICertificateRepo repo) => 
{
    return repo.LoadCerts();
});

// app.MapPost("/api/cert", (Certificate certificate, ICertificateRepo repo) =>
// {
//     repo.SaveCert(certificate);
//     return Results.Created("/api/cert", certificate);
// });
app.MapPost("/api/cert", async (HttpRequest request, ICertificateRepo repo) =>
{
    var form = await request.ReadFormAsync();
    var file = form.Files["file"];
    if (file == null)
        return Results.BadRequest("No file uploaded.");

    var storedFileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
    var path = Path.Combine("Uploads", storedFileName);

    using var stream = File.Create(path);
    await file.CopyToAsync(stream);

    var certificate = new Certificate(form["type"]!, form["number"]!, form["notifiedBody"]!, DateOnly.Parse(form["issueDate"]!), DateOnly.Parse(form["expiryDate"]!), storedFileName);

    repo.SaveCert(certificate);

    return Results.Created("/api/cert", certificate);
});

app.MapGet("/api/searchtype", (string type, CertManager manager) =>
{
    return manager.GetByType(type);
});

app.MapGet("/api/searchnumber", (string number, CertManager manager) =>
{
    return manager.GetByNumber(number);
});

app.UseStaticFiles();   // enable html
app.Run();
