using FluentAssertions;
using Moq;
using projetoCarro.Borders.Interfaces;
using projetoCarro.DTO.ReturnListCars;
using projetoCarro.Models;
using projetoCarro.UseCase;
using projetocarro_teste.Builder;
using System;
using System.Collections.Generic;
using Xunit;

namespace projetocarro_teste.UseCase
{
    public class ReturnListCarsUseCaseTest
    {

        private readonly Mock<IRepositoriesCars> _repositoriescars;
        private readonly ReturnListCarsUseCase _returnListCars;

        public ReturnListCarsUseCaseTest()
        {
            _repositoriescars = new Mock<IRepositoriesCars>();
            _returnListCars = new ReturnListCarsUseCase(_repositoriescars.Object);
        }

        [Fact]
        public void Cars_ReturnListCars_WhenReturn_Sucess()
        {

            var request = new ReturnListCarsRequestBuilder().Build();
            var response = new ReturnListCarsResponse();
            var cars = new List<Cars>();
            var list = new Cars
            {
                id = 9,
                Model = "Fusca",
                Cor = "Azul",
                Brands = "Volks",
                NumberDoors = 2,
                Year = 1984,
                TypeRate = "Gasolina"
            };

            cars.Add(list);

            response.msg = "Lista de Carro encontrado com Sucesso";

            _repositoriescars.Setup(repositorio => repositorio.GetListCars()).Returns(cars);

            var result = _returnListCars.Execute();

        }

        [Fact]
        public void Cars_ReturnListCars_WhenReturn_Failed()
        {
            var request = new ReturnListCarsRequestBuilder().Build();
            var response = new ReturnListCarsResponse();
            response.msg = "Nenhuma lista para ser mostrada :(";
            var cars = new List<Cars>();

            _repositoriescars.Setup(repositorio => repositorio.GetListCars()).Returns(cars);

            var result = _returnListCars.Execute();

        }

        [Fact]
        public void Cars_ReturnListCars_WhenReturn_Exception()
        {

            var request = new ReturnListCarsRequestBuilder().Build();
            var response = new ReturnListCarsResponse();
            response.msg = "Problema ao carregar a lista :(";
            var cars = new List<Cars>();

            _repositoriescars.Setup(repositorio => repositorio.GetListCars()).Throws(new Exception());

            var result = _returnListCars.Execute();

        }

    }
}
