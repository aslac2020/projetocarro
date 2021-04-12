using FluentAssertions;
using Moq;
using projetoCarro.Borders.Adapter;
using projetoCarro.Borders.Interfaces;
using projetoCarro.DTO.AddCars;
using projetoCarro.Models;
using projetoCarro.UserCase;
using projetocarro_teste.Builder;
using System;
using Xunit;

namespace projetocarro_teste.UseCase
{

    public class AddCarsUseCaseTest
    {
        private readonly Mock<IRepositoriesCars> _repositoriescars;
        private readonly Mock<IAddCarsAdapter> __addcarsadapter;
        private readonly AddCarsUseCase _usercase;

        public AddCarsUseCaseTest()
        {
            _repositoriescars = new Mock<IRepositoriesCars>();
            __addcarsadapter = new Mock<IAddCarsAdapter>();
            _usercase = new
            AddCarsUseCase(_repositoriescars.Object, __addcarsadapter.Object);
        }

        [Fact]
        public void Cars_AddCars_WhenReturn_Sucess()
        {

            var request = new AddCarsRequestBuilder().Build();
            var response = new AddCarsResponse();
            var cars = new Cars();
            cars.id = 1;
            response.msg = "Adicionado com Sucesso";
            response.id = cars.id;

            _repositoriescars.Setup(repositorio => repositorio.Add(cars)).Returns(cars.id);
            __addcarsadapter.Setup(adapter => adapter.converterRequestCars(request)).Returns(cars);

            var result = _usercase.Execute(request);

            response.Should().BeEquivalentTo(result);


        }

        [Fact]
        public void Cars_AddCars_WhenReturn_Failed()
        {

            var request = new AddCarsRequestBuilder().withModelLength(2).Build();
            var response = new AddCarsResponse();
            response.msg = "Erro ao adicionar o carro";

            var result = _usercase.Execute(request);

            response.Should().BeEquivalentTo(result);
        }

        [Fact]
        public void Cars_AddCars_WhenReturn_Exception()
        {

            var request = new AddCarsRequestBuilder().Build();
            var response = new AddCarsResponse();
            var cars = new Cars();
            cars.id = 1;
            response.msg = "Erro ao adicionar o carro";

            _repositoriescars.Setup(repositorio => repositorio.Add(cars)).Returns(cars.id);
            __addcarsadapter.Setup(adapter => adapter.converterRequestCars(request)).Throws(new Exception());

            var result = _usercase.Execute(request);

            response.Should().BeEquivalentTo(result);


        }
    }
}
