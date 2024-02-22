using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddAzureKeyVault(
        new Uri(builder.Configuration["VaultUrl"]), 
        new DefaultAzureCredential(new DefaultAzureCredentialOptions
        {
            ManagedIdentityClientId = builder.Configuration["client_id"],
            TenantId = builder.Configuration["tenant_id"]
        })
    );
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
