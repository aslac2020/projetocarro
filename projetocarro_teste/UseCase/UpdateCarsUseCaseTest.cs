using FluentAssertions;
using Moq;
using projetoCarro.Borders.Adapter;
using projetoCarro.Borders.Interfaces;
using projetoCarro.DTO.UpdateCars;
using projetoCarro.Models;
using projetoCarro.UseCase;
using projetocarro_teste.Builder;
using System;
using Xunit;

namespace projetocarro_teste.UseCase
{
    public class UpdateCarsUseCaseTest
    {
        private readonly Mock<IRepositoriesCars> _repositoriescars;
        private readonly Mock<IUpdateCarsAdapter> _updateCars;
        private readonly UpdateCarsUseCase _usercase;

        public UpdateCarsUseCaseTest()
        {
            _repositoriescars = new Mock<IRepositoriesCars>();
            _updateCars = new Mock<IUpdateCarsAdapter>();
            _usercase = new UpdateCarsUseCase(_repositoriescars.Object, _updateCars.Object);
        }

        [Fact]
        public void Cars_UpdateCars_WhenReturn_Sucess()
        {

            var number = 1;
            var request = new UpdateCarsRequestBuilder(number).Build();
            var response = new UpdateCarsResponse();
            var cars = new Cars();
            cars.id = 1;
            request.id = cars.id;
            response.msg = "Carro atualizado Sucesso";
            response.id = cars.id;

            _repositoriescars.Setup(repositorio => repositorio.GetById(cars.id)).Returns(cars);
            _updateCars.Setup(adapter => adapter.converterRequestCars(request)).Returns(cars);

            var result = _usercase.Execute(request, cars.id);

            response.Should().BeEquivalentTo(result);

        }

        [Fact]
        public void Cars_UpdateCars_WhenReturn_Failed()
        {

            var number = 0;
            var request = new UpdateCarsRequestBuilder(number).Build();
            var response = new UpdateCarsResponse();
            response.msg = "Erro ao atualizar o carro";

            var result = _usercase.Execute(request, request.id);

            response.Should().BeEquivalentTo(result);

        }

        [Fact]
        public void Cars_UpdateCars_WhenReturn_Exception()
        {

            var number = 0;
            var request = new UpdateCarsRequestBuilder(number).Build();
            var response = new UpdateCarsResponse();
            response.msg = "Erro ao atualizar o carro";

            _repositoriescars.Setup(repositorio => repositorio.GetById(request.id)).Throws(new Exception());

            var result = _usercase.Execute(request, request.id);

            response.Should().BeEquivalentTo(result);

        }


    }
}
