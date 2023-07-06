## Configuração base do projeto

[Documentação do ****xUnit.net****](https://xunit.net/docs/comparisons)

[SDK Versão 2.2](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-2.2.207-windows-x64-installer)

[Chrome Driver](https://chromedriver.chromium.org/downloads): Necessário para navegação com o navegador Chrome. Checar a versão que possui o Chrome instalado e baixar o exe.

![Untitled](https://github.com/jojosuelobo/Selenium.demo/assets/47835727/46d57ab8-8dc2-463f-a73f-4255078cdfa3)

![Untitled (1)](https://github.com/jojosuelobo/Selenium.demo/assets/47835727/a0968f86-17e8-4ef6-bfab-0c2f4724e6fd)

Logo após a instalação, adicionar o executável dentro da pasta \bin\Debug\net6.0\ do projeto.

![Untitled (2)](https://github.com/jojosuelobo/Selenium.demo/assets/47835727/f6e597bc-68a0-4f23-bb64-0d25960b230a)

O executável deve ser adicionado na pasta do projeto que será feito a codificação dos testes, neste caso, eu estou usando o projeto chamado **Alura.LeilaoOnline.Selenium.** Caso o nome dentro da pasta Debug\ seja diferente de “net6.0”, siga o processo normalmente, adicionando o executável dentro da pasta que for criada dentro de Debug\

## Principais conceitos

### Setup

Etapa executada antes da execução de cada teste individual. Nesta etapa são configurados as preparações necessárias para o ambiente de teste, como iniciar o navegador, abrir a página da web, fazer login, e outros. O objetivo do Setup é garantir que o ambiente esteja pronto para executar o teste. Um outro exemplo, poderia ser a criação do construtor base de um navegador do projeto.

```csharp
public class teste_1
{
		// Variável **driver** do tipo IWebDriver (Navegador web)
    private IWebDriver driver;
		// Caminho do executável ChromeDriver
		private PastaDoExecutavel = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

    // Setup
    public teste_1()
    {
				// Um novo navegador é atribuido a variável **driver**
        driver = new ChromeDriver(PastaDoExecutavel);
    }
}
```

### Tear Down

Executado após a conclusão de cada teste individual, classificado como um destrutor. Ações necessárias para encerrar o ambiente de teste, como fechar o navegador, limpar cookies, realizar logout, etc. O Tear Down é responsável por limpar qualquer estado residual deixado pelo teste.

```csharp
public void Dispose()
{
    driver.Quit();
}
```

### Class Fixture

Conjunto comum de Setup e Tear Down para todas as classes de teste em uma classe de teste. Recurso compartilhado por testes da mesma classe

### Collection Fixture

Recurso compartilhado por testes de várias classes

## [Fact]

Representa um caso de teste individual que não possui parâmetros. Ele é executado uma vez e é esperado que produza um resultado booleano (verdadeiro ou falso) indicando se o teste passou ou falhou.

```csharp
[Fact]
public void TestAddition()
{
    // Lógica de teste
    Assert.Equal(4, Calculator.Add(2, 2));
}
```

## [Theory]

Recebe parâmetros via `[InlineData]` e é executado várias vezes, uma vez para cada conjunto de dados fornecido. É útil quando você deseja testar o mesmo cenário com diferentes entradas.

```csharp
[Theory]
[InlineData(2, 3, 5)]
[InlineData(0, 0, 0)]
[InlineData(-2, 2, 0)]
public void TestAddition(int a, int b, int expectedResult)
{
    // Lógica de teste
    Assert.Equal(expectedResult, Calculator.Add(a, b));
}
```
