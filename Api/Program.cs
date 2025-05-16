using LCB_Clone_Backend;
using LCB_Clone_Backend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// NOTE: getting connection string from config
string connectionString = builder.Configuration.GetConnectionString("Default")
    ?? throw new InvalidOperationException("Connection string Default not found");

// NOTE: Register SqlDataAccess for database operations
builder.Services.AddScoped<SqlDataAccess>(_ =>
    new SqlDataAccess(connectionString)
);

// Register DbContext with dependency injection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString)); // Or your preferred database provider

// NOTE: Register services required for controllers
builder.Services.AddScoped<AmendmentData>();
builder.Services.AddScoped<AgendaData>();
builder.Services.AddScoped<BillData>();
builder.Services.AddScoped<BudgetData>();
builder.Services.AddScoped<CommitteData>();
builder.Services.AddScoped<ExhibitData>();
builder.Services.AddScoped<HearingRoomMeetingData>();
builder.Services.AddScoped<LegislativeMeetingData>();
builder.Services.AddScoped<LegislatorData>();
builder.Services.AddScoped<StaffMemberData>();

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers(); // Map controller routes

app.Run();
