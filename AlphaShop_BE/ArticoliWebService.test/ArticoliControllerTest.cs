using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticoliWebService.Controllers;
using ArticoliWebService.Dtos;
using ArticoliWebService.Services;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace ArticoliWebService.test
{
    public class ArticoliControllerTest
    {
        [Fact]
        public  async Task TestGetArticoloByCode()
        {
            string CodArt = "000992601";

             // Arrange
            var dbContext = DbContextMocker.alphaShopDbContext();
            var controller = new ArticoliController(new ArticoliRepository(dbContext));

            // Act
            var response = await controller.GetArticoloByCode(CodArt) as ObjectResult;
            var value = response.Value as ArticoliDto;

            dbContext.Dispose();

             // Assert
            Assert.Equal(200, response.StatusCode);
            Assert.NotNull(value);
            Assert.Equal(CodArt, value.CodArt);
        }

        [Fact]
        public async Task TestErrGetArticoloByCode()
        {
            string CodArt = "0009926010";

            // Arrange
            var dbContext = DbContextMocker.alphaShopDbContext();
            var controller = new ArticoliController(new ArticoliRepository(dbContext));

            // Act
            var response = await controller.GetArticoloByCode(CodArt) as ObjectResult;
            var value = response.Value as ArticoliDto;

            dbContext.Dispose();

            // Assert
            Assert.Equal(404, response.StatusCode);
            Assert.Null(value);
            Assert.Equal("Non è stato trovato l'articolo con il codice '0009926010'", response.Value);
        }

        [Fact]
        public async Task TestSelArticoliByDescrizione()
        {
            string Descrizione = "ACQUA ROCCHETTA";

            // Arrange
            var dbContext = DbContextMocker.alphaShopDbContext();
            var controller = new ArticoliController(new ArticoliRepository(dbContext));

             // Act
            var response = await controller.GetArticoliByDesc(Descrizione) as ObjectResult;
            var value = response.Value as ICollection<ArticoliDto>;

            dbContext.Dispose();

            // Assert
            Assert.Equal(200, response.StatusCode);
            Assert.NotNull(value);
            Assert.Equal(3, value.Count);
            Assert.Equal("002001201", value.FirstOrDefault().CodArt);
        }

        [Fact]
        public async Task TestErrSelArticoliByDescrizione()
        {
            string Descrizione = "Pippo";

             // Arrange
            var dbContext = DbContextMocker.alphaShopDbContext();
            var controller = new ArticoliController(new ArticoliRepository(dbContext));

             // Act
            var response = await controller.GetArticoliByDesc(Descrizione) as ObjectResult;
            var value = response.Value as ICollection<ArticoliDto>;

            dbContext.Dispose();

            Assert.Equal(404, response.StatusCode);
            Assert.Null(value);
            Assert.Equal("Non è stato trovato alcun articolo con il filtro 'Pippo'", response.Value);

        }

        [Fact]
        public async Task TestSelArticoloByEan()
        {
            string Ean = "80582533";

            // Arrange
            var dbContext = DbContextMocker.alphaShopDbContext();
            var controller = new ArticoliController(new ArticoliRepository(dbContext));

            // Act
            var response = await controller.GetArticoloByEan(Ean) as ObjectResult;
            var value = response.Value as ArticoliDto;

            dbContext.Dispose();

            // Assert
            Assert.Equal(200, response.StatusCode);
            Assert.NotNull(value);
            Assert.Equal("000974302", value.CodArt);

        }

        [Fact]
        public async Task TestErrSelArticoloByEan()
        {
            string Ean = "80582533A";

            // Arrange
            var dbContext = DbContextMocker.alphaShopDbContext();
            var controller = new ArticoliController(new ArticoliRepository(dbContext));

            // Act
            var response = await controller.GetArticoloByEan(Ean) as ObjectResult;
            var value = response.Value as ArticoliDto;

            dbContext.Dispose();

             // Assert
            Assert.Equal(404, response.StatusCode);
            Assert.Null(value);
            Assert.Equal("Non è stato trovato l'articolo con il barcode '80582533A'", response.Value);
        }
    }
}