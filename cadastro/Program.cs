var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://0.0.0.0:8000");

var app = builder.Build();

Funcionario[] funcionarios = new Funcionario[100];
int totalFuncionarios = 0;

app.MapGet("/", () => "API de funcionários em execução ...");

//Cadastrar funcionário
        app.MapGet("/funcionarios/{nome}/{idade}/{cargo}/{departamento}",
        (string nome, int idade, string cargo, string departamento) =>
    {
        // Verifica se o vetor está cheio
        if (totalFuncionarios >= funcionarios.Length)
            return Results.BadRequest("Limite de funcionários atingido!");
    
        Funcionario f = new Funcionario();
        f.SetNome(nome);
        f.SetIdade(idade);
        f.SetCargo(cargo);
        f.SetDepartamento(departamento);

        funcionarios[totalFuncionarios] = f;
        totalFuncionarios++;

        return Results.Ok(new
        {
            nome = f.GetNome(),
            idade = f.GetIdade(),
            cargo = f.GetCargo(),
            departamento = f.GetDepartamento()
        });
    });

        // GET - Listar todos os funcionários
        app.MapGet("/funcionarios", () =>
    {
        var lista = new List<object>();

        for (int i = 0; i < totalFuncionarios; i++)
    {
        var f = funcionarios[i];
        lista.Add(new
        {
            nome = f.GetNome(),
            idade = f.GetIdade(),
            cargo = f.GetCargo(),
            departamento = f.GetDepartamento()
        });
    }

    return Results.Ok(lista);
});

app.Run();