class DependencyConfiguration
{
    static void Configure(string[] args)
    {
        // Configuração do contêiner de injeção de dependência
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IService1, Service1>()
            .BuildServiceProvider();
            
       // Obtenção da instância do Consumer através da injeção de dependência
        var consumer = serviceProvider.GetService<Consumer>();

        // Chamada do método DoWork() no Consumer
        consumer.DoWork();
    }
}