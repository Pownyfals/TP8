var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var Title = new[]
{
	"The Shawshank Redemption", "The Godfather", "The Dark Knight"
};
var Director = new[]
{
	"Frank Darabont","Francis Ford Coppola", "Christoper Nolan"
};
List<string[]> Stars = new List<string[]>();
Stars.Add(new[] { "Tim Robbins","Morgam Freeman","Bob Gunton","William Sadler" });
Stars.Add(new[] { "Marlon Brando","Al Pacino","James Caan","Diane Keaton" });
Stars.Add(new[] { "Christian Bale, Heath Ledger","Heath Ledger","Aaron Eckhart","Michael Caine" });
var Description = new[]
{
	"Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
	"The aging patriarch of an organized crime dynasty in postwar New York City transfers control of his clandestine empire to his reluctant youngest son.",
	"When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice"
};
Stars.ToArray();


app.MapGet("/api/Movies", () =>
{
	var Movie = Enumerable.Range(1, 3).Select(index =>
	   new Movies
	   (
		   Title[index-1],
		   Director[index-1],
		   Stars[index-1],
		   Description[index-1]

	   ))
		.ToArray();
	return Movie;
})
.WithName("GetMovies");

app.Run();

internal record Movies (string? Title,string? Director, string[] Stars,string? Description)
{
}