using FluentAssertions;
using Moq;
using projetoCarro.Borders.Interfaces;
using projetoCarro.Context;
using projetoCarro.DTO.DeleteCars;
using projetoCarro.Models;
using projetoCarro.Repositories;
using projetoCarro.UseCase;
using projetocarro_teste.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace projetocarro_teste.UseCase
{

    public class DeleteCarsUseCaseTest
    {
        private readonly Mock<IRepositoriesCars> _repositoriescars;
        private readonly DeleteCarsUseCase _usercase;

        public DeleteCarsUseCaseTest()
        {
            _repositoriescars = new Mock<IRepositoriesCars>();
            _usercase = new DeleteCarsUseCase(_repositoriescars.Object);
        }

        [Fact]
        public void Cars_DeleteCars_WhenReturn_Sucess()
        {
            //Arrange
            //Criar as variaveis
            var number = 1;
            var request = new DeleteCarsRequestBuilder(number).Build();
            var response = new DeleteCarsResponse();
            var cars = new Cars();
            response.msg = "Deletado com Sucesso";

            _repositoriescars.Setup(repositorio => repositorio.GetById(request.id)).Returns(cars);

            //Act
            //Chamar acçoes

            var result = _usercase.Execute(request);

            //Asserts
            //As regras dos testes que vamos utilizar
            response.Should().BeEquivalentTo(result);

        }

        [Fact]
        public void Cars_DeleteCars_WhenReturn_Failed()
        {
            //Arrange
            //Criar as variaveis
            var number = 0;
            var request = new DeleteCarsRequestBuilder(number).Build();
            var response = new DeleteCarsResponse();
            response.msg = "Não encontrado o id :( ";
            //Act
            //Chamar acçoes

            var result = _usercase.Execute(request);

            //Asserts
            //As regras dos testes que vamos utilizar
            response.Should().BeEquivalentTo(result);
        }

        [Fact]
        public void Cars_DeleteCars_WhenReturn_Exception()
        {
            //Arrange
            //Criar as variaveis
            var number = 0;
            var request = new DeleteCarsRequestBuilder(number).Build();
            var response = new DeleteCarsResponse();
            response.msg = "Falha ao deletar o carro :(";
            //Act
            //Chamar acçoes

            _repositoriescars.Setup(repositorio => repositorio.GetById(request.id)).Throws(new Exception());

            var result = _usercase.Execute(request);

            //Asserts
            //As regras dos testes que vamos utilizar
            response.Should().BeEquivalentTo(result);
        }

    }
}
