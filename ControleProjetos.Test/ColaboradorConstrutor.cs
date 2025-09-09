using Bogus;
using ControleProjetos.Colaboradores;
using ControleProjetos.Diretorias;

namespace ControleProjetos.Test
{   //Testes estão sendo feitos no construtor (o que está sendo testado) - nome da classe
    public class ColaboradorConstrutor
    {
        [Fact]
        public void RetornaColaboradorValidoQuandoDadosValidos() //O que deve retornar em determinada situação - nome do método
        {
            //Arrange
            string nome = "Miguel Ferraz Modesto Sampaio Pinto";
            Diretoria diretoria = new Diretoria("DEE/STE");
            Colaborador colaborador = new Colaborador(nome, diretoria);

            //Act
            var validacao = true;
            string departamento = "DEE/STI";

            //Assert
            Assert.Equal(validacao, colaborador.ehValido(departamento));
        }


        [Theory] //Permite testar varios cenarios
        [InlineData("Miguel Ferraz Modesto Sampaio Pinto",
            "DEE/STE", true)]
        [InlineData("Andre Camargo Brandao",
            "DGC/STI", true)]
        public void RetornaEhValidoDeAcordoComDadosDeEntradaFaker(string nome, string nomeDaDiretoria, bool validou) //O que deve retornar em determinada situação - nome do método
        {
            //Arrange
            var faker = new Faker<string>().CustomInstantiator(f =>
                {
                    string nomeDaDiretoriaAleatorio = f.Name.FirstName();
                    return nomeDaDiretoriaAleatorio;
                });

            var fakerDiretoria = new Faker<Diretoria>().CustomInstantiator(f =>
            
                new Diretoria(
                    faker.Generate()
                    ));
            Console.WriteLine(nomeDaDiretoria);



            Diretoria diretoria = fakerDiretoria;
            Colaborador colaborador = new Colaborador(nome, diretoria);

            //Act
           

            //Assert
            Assert.Equal(validou, colaborador.ehValido(diretoria.Nome));
        }
        [Fact(DisplayName = "Validando ..")]
        public void RetornaColaboradorValidoQuandoDadosValidosFaker() //O que deve retornar em determinada situação - nome do método
        {
            //Arrange
            var nomeFaker = new Faker<string>().CustomInstantiator(f =>
            {
                string nomeFakeaAleatorio = f.Name.FirstName();
                return nomeFakeaAleatorio;
            });

            var faker = new Faker<string>().CustomInstantiator(f =>
            {
                string nomeDaDiretoriaAleatorio = f.Name.FirstName();
                return nomeDaDiretoriaAleatorio;
            });


            var fakerDiretoria = new Faker<Diretoria>().CustomInstantiator(f =>

                new Diretoria(
                    faker.Generate()
                    ));
            Diretoria diretoria = fakerDiretoria;
            Colaborador colaborador = new Colaborador(nomeFaker, diretoria);

            //Act
            var validacao = true;
            string departamento = nomeFaker;

            //Assert
            Assert.Equal(validacao, colaborador.ehValido(departamento));



        }
    }
}