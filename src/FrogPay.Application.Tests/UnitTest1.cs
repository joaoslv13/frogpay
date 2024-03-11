namespace FrogPay.Application.Tests
{
    public class Tests
    {
        private IPessoaService _pessoaService;

        [SetUp]
        public void Setup()
        {
            var connectionString = "Host=localhost;Port=5432;Database=frog;Username=username;Password=password;";

            var serviceProvider = new ServiceCollection()
                .AddTransient<IPessoaService, PessoaService>()
                .AddTransient<IPessoaRepository, PessoaRepository>()
                .AddAutoMapper(typeof(PessoaMapper))
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddDbContext<AppDbContext>(opt => opt.UseNpgsql(connectionString))
                .AddScoped<INotificationHandler, NotificationHandler>()
                .BuildServiceProvider();

            _pessoaService = serviceProvider.GetRequiredService<IPessoaService>();
        }

        [Test]
        public async Task GetAllTest()
        {
            var pageNumber = 1;
            var pageSize = 10;

            try
            {
                var resultado = await _pessoaService.GetAllAsync(pageNumber, pageSize, CancellationToken.None);

                Assert.IsNotNull(resultado);
                Assert.AreEqual(1, resultado.PageNumber);
                Assert.AreEqual(10, resultado.PageSize);
            }
            catch (Exception ex)
            {
                Assert.Fail($"O teste falhou com a seguinte exceção: {ex}");
            }
        }

        [Test]
        public async Task UpdateTest()
        {
            //TESTE FORCANDO O ERRO DE ALTERAR O CPF DE UM USUARIO

            var pessoaRequest = new PessoaRequest("Joao Testes", "28104559885", new DateOnly(2013, 02, 11));
            var pessoaId = new Guid("6ffbcdae-9f25-41fa-8404-2d58ee118495".ToUpper());
            try
            {
                var resultado = await _pessoaService.UpdateAsync(pessoaId, pessoaRequest, CancellationToken.None);

                Assert.IsNull(resultado);
                //Assert.AreEqual(resultado?.Id,pessoaId);
            }
            catch
            {
                Assert.Fail($"Alterou o CPF no UPDATE");
            }
        }
    }

}