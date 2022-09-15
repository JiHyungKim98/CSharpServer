using ServerTest1.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Swagger은 개발자가 REST 웹 서비스를 설계, 빌드, 문서화, 소비하는 일을 도와주는
// 대형 도구 생태계의 지원을 받는 오픈 소스 소프트웨어 프레임 워크
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
