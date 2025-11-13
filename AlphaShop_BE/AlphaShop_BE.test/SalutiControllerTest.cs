using AlphaShop_BE.Controllers;
using Xunit;

namespace AlphaShop_BE.test
{
    public class SalutiControllerTest
    {
        SalutiController salutiController;

        public SalutiControllerTest()
        {
            salutiController = new SalutiController();
        }

        [Fact]
        public void TestGetSalui()
        {
            var retVal = salutiController.getSaluto();
            var testVal = "\"Ciao sono il tuo nuovo controller in c#\"";

            Assert.Equal(testVal, retVal);  
        }

        [Fact]
        public void TestGetSaluiConNome()
        {
            var Nome = "Mario";
            var retVal = salutiController.getSaluti(Nome);
            var testVal = string.Format("\"Saluti {0} dalla tua api in c#\"", Nome);
            Assert.Equal(testVal, retVal);
        }
    }
}

