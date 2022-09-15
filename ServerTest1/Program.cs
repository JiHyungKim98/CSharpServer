using ServerTest1.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Swagger�� �����ڰ� REST �� ���񽺸� ����, ����, ����ȭ, �Һ��ϴ� ���� �����ִ�
// ���� ���� ���°��� ������ �޴� ���� �ҽ� ����Ʈ���� ������ ��ũ
builder.Services.AddSwaggerGen(); // Swagger generator
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IAccountService,AccountService>();
builder.Services.AddSingleton<IRankingService,RankingService>();

var app = builder.Build();

// middleware -> JSON document, Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
