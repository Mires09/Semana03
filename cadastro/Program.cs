var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://0.0.0.0:8000");

var app = builder.Build();

app.MapGet("/", () => "API funcinando ...");

//Rotas
app.MapGet("/for", () => {
    for(int i=0; i<=10; i++){
        Console.WriteLine(i);
    }
});

app.MapGet("/while", () => {
    int i=0;
    while(i<=10){
	    Console.WriteLine(i);
        i++;
    }
});

app.Run();