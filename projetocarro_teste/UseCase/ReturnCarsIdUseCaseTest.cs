using FluentAssertions;
using Moq;
using projetoCarro.Borders.Interfaces;
using projetoCarro.DTO.ReturnCarById;
using projetoCarro.Models;
using projetoCarro.UseCase;
using projetocarro_teste.Builder;
using System;
using Xunit;

namespace projetocarro_teste.UseCase
{
    public class ReturnCarsIdUseCaseTest
    {
        private readonly Mock<IRepositoriesCars> _repositoriescars;
        private readonly ReturnCarsIdUseCase _returnCarsIdUse;

        public ReturnCarsIdUseCaseTest()
        {
            _repositoriescars = new Mock<IRepositoriesCars>();
            _returnCarsIdUse = new ReturnCarsIdUseCase(_repositoriescars.Object);
        }

        [Fact]
        public void Cars_ReturnCarsId_WhenReturn_Sucess()
        {
            //Arrange
            //Criar as variaveis
            var number = 1;
            var request = new ReturnCarsIdRequestBuilder(number).Build();
            var response = new ReturnCarIdResponse();
            var cars = new Cars();
            response.msg = "Carro encontrado com Sucesso";

            _repositoriescars.Setup(repositorio => repositorio.GetById(request.id)).Returns(cars);

            //Act
            //Chamar acçoes

            var result = _returnCarsIdUse.Execute(request);


        }

        [Fact]
        public void Cars_ReturnCarsId_WhenReturn_Failed()
        {
            //Arrange
            //Criar as variaveis
            var number = 0;
            var request = new ReturnCarsIdRequestBuilder(number).Build();
            var response = new ReturnCarIdResponse();
            response.msg = "Id não encontrado :(";
            //Act
            //Chamar ações

            var result = _returnCarsIdUse.Execute(request);

            response.Should().BeEquivalentTo(result);

        }

        [Fact]
        public void Cars_ReturnCarsId_WhenReturn_Exception()
        {
            //Arrange
            //Criar as variaveis
            var number = 0;
            var request = new ReturnCarsIdRequestBuilder(number).Build();
            var response = new ReturnCarIdResponse();
            response.msg = "Falha ao procurar o carro :(";
            //Act
            //Chamar ações
            _repositoriescars.Setup(repositorio => repositorio.GetById(request.id)).Throws(new Exception());

            var result = _returnCarsIdUse.Execute(request);

            response.Should().BeEquivalentTo(result);

        }
    }
}
