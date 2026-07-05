using CertAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICertRepo, JsonCertRepo>();     // Change to SQL or something later

// builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGet("/api/completelist", (ICertRepo repo) => 
{
    return repo.LoadCerts();
});

// app.MapPost("/api/cert", (Certification certification, ICertRepo repo) =>
// {
//     repo.SaveCert(certification);
//     return Results.Created("/api/cert", certification);
// });
app.MapPost("/api/cert", async (HttpRequest request, ICertRepo repo) =>
{
    var form = await request.ReadFormAsync();
    var file = form.Files["file"];
    if (file == null)
        return Results.BadRequest("No file uploaded.");

    var storedFileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
    var path = Path.Combine("Uploads", storedFileName);

    using var stream = File.Create(path);
    await file.CopyToAsync(stream);

    var certification = new Certification(form["type"]!, form["number"]!, form["notifiedBody"]!, DateOnly.Parse(form["issueDate"]!), DateOnly.Parse(form["expiryDate"]!), storedFileName);

    repo.SaveCert(certification);

    return Results.Created("/api/cert", certification);
});

app.MapGet("/api/cert/{number}/download", (string number, ICertRepo repo) =>
{
    var cert = repo.LoadCerts().FirstOrDefault(c => c.Number == number);

    if (cert == null)
        return Results.NotFound("Certification not found");

    var path = Path.Combine("Uploads", cert.StoredFileName);

    if (!File.Exists(path))
        return Results.NotFound("File missing on server");

    var fileBytes = File.ReadAllBytes(path);

    return Results.File(fileBytes, "application/pdf", cert.Number + ".pdf");
});

app.MapGet("/api/searchtype", (string type, ICertRepo repo) =>
{
    return repo.LoadCerts().Where(c => c.Type.Contains(type, StringComparison.OrdinalIgnoreCase)).ToList();
});

app.MapGet("/api/searchnumber", (string number, ICertRepo repo) =>
{
    return repo.LoadCerts().Where(c => c.Number == number).ToList();
});


app.UseStaticFiles();   // enable html
app.Run();
