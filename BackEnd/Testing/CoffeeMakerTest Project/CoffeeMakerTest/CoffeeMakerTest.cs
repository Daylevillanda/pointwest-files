using CoffeeMakerDemo;

namespace CoffeeMakerTest
{
    [TestClass]
    public class CoffeeMakerTest
    {
        CoffeeMaker coffeeMaker;

        [TestInitialize]
        public void SetUp()
        {
            coffeeMaker = new CoffeeMaker();
        }


        [TestMethod]
        public void MakeCoffee_WithFourEspresso_CanMakeHotAmericanoCoffee()
        {
            coffeeMaker.AddEspressoStock(4);

            //We test that the coffeeMaker "can" make Americano
            Coffee coffee = coffeeMaker.MakeCoffee(CoffeeType.AMERICANO);

            //Americano is Espresso with no Milk
            Assert.AreEqual(4, coffee.GetEspressoShots(), "Incorrect Espresso Amount");
            Assert.AreEqual(0, coffee.GetCupsOfMilk(), "Should have no Milk");
            //Hot coffee has no Ice
            Assert.AreEqual(0, coffee.GetCupsOfIce(), "Should have no Ice");
        }

        [TestMethod]
        public void MakeCoffee_WithTwoEspressoTwoMilk_CanMakeLatte()
        {
            coffeeMaker.AddEspressoStock(2);
            coffeeMaker.AddMilkStock(2);

            Coffee coffee = coffeeMaker.MakeCoffee(CoffeeType.LATTE);

            Assert.AreEqual(2, coffee.GetEspressoShots(), "Incorrect Espresso Shot Amount");
            Assert.AreEqual(2, coffee.GetCupsOfMilk(), "Incorrect number of cups of milk.");
            Assert.AreEqual(0, coffee.GetCupsOfIce(), "Incorrect number of ice.");
        }

        //Unable to make coffee when insufficient espresso stock
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]  //<-- Assert
        public void MakeCoffee_InsufficientEspressoStockForAmericano_ReturnsException()
        {
            //given
            coffeeMaker.AddEspressoStock(3);

            //when
            coffeeMaker.MakeCoffee(CoffeeType.AMERICANO);
        }

        //Espresso stocks get reduced when making coffee
        [TestMethod]
        public void MakeCoffee_MadeHotAmericanoCoffee_ReducesEspressoStock()
        {
            //given
            coffeeMaker.AddEspressoStock(4);

            //when
            Coffee coffee = coffeeMaker.MakeCoffee(CoffeeType.AMERICANO);

            //then
            Assert.AreEqual(0, coffeeMaker.GetEspressoStock(), "Stocks should be reduced");
        }

        [TestMethod]
        public void MakeCoffee_MadeCaramelCoffee_ContainsSyrupCaramelSweetener()
        {
            coffeeMaker.AddEspressoStock(2);
            coffeeMaker.AddMilkStock(2);

            Coffee coffee = coffeeMaker.MakeCoffee(CoffeeType.CARAMEL_MACCHIATO);

            Assert.AreEqual(2, coffee.GetEspressoShots(), "Incorrect Espresso Amount");
            Assert.AreEqual(2, coffee.GetCupsOfMilk(), "Should have no Milk");
            Assert.AreEqual(0, coffee.GetCupsOfIce(), "Should have no Ice");
            Assert.IsTrue(coffee.GetSweetenerList().Contains(Sweetener.SYRUP), "Missing Syrup in Sweetener List");
            Assert.IsTrue(coffee.GetSweetenerList().Contains(Sweetener.CARAMEL), "Missing CARAMEL in Sweetener List");
            Assert.IsFalse(coffee.GetSweetenerList().Contains(Sweetener.SUGAR));
            //can also use CollectionAssert
        }
    }
}

