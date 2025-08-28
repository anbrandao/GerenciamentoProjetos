using ControleProjetos.Models;

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

            //Assert
            Assert.Equal(validacao, colaborador.ehValido(validacao));
        }


        [Theory] //Permite testar varios cenarios
        [InlineData("Miguel Ferraz Modesto Sampaio Pinto",
            "DEE/STE",true)]
        [InlineData("Andre Camargo Brandao",
            "DGC/STI", true)]
        public void RetornaEhValidoDeAcordoComDadosDeEntrada(string nome, string nomeDaDiretoria, bool validou) //O que deve retornar em determinada situação - nome do método
        {
            //Arrange
            Diretoria diretoria= new Diretoria(nomeDaDiretoria);
            Colaborador colaborador = new Colaborador(nome, diretoria);

            //Act
           

            //Assert
            Assert.Equal(validou, colaborador.ehValido(validou));
        }
    }
}