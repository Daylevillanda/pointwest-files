namespace CoffeeMakerDemo
{
    public class CoffeeMaker
    {

        private int espressoStock = 0;
        private int milkStock = 0;
        private int iceStock = 0;

        public Coffee MakeCoffee(CoffeeType type)
        {
            Coffee coffee = new Coffee();

            if (type.Equals(CoffeeType.AMERICANO))
            {
                UseIngredient(IngredientType.ESPRESSO, 4, coffee);
                UseIngredient(IngredientType.MILK, 0, coffee);
                UseIngredient(IngredientType.ICE, 0, coffee);
            }
            else if (type.Equals(CoffeeType.LATTE))
            {
                UseIngredient(IngredientType.ESPRESSO, 2, coffee);
                UseIngredient(IngredientType.MILK, 2, coffee);
                UseIngredient(IngredientType.ICE, 0, coffee);
            }
            else if (type.Equals(CoffeeType.CARAMEL_MACCHIATO))
            {
                UseIngredient(IngredientType.ESPRESSO, 2, coffee);
                UseIngredient(IngredientType.MILK, 2, coffee);
                UseIngredient(IngredientType.ICE, 0, coffee);
                AddSweetener(Sweetener.SYRUP, coffee);
                AddSweetener(Sweetener.CARAMEL, coffee);
            }
            return coffee;
        }

        public void UseIngredient(IngredientType type, int quantity, Coffee coffee)
        {
            if (type.Equals(IngredientType.ESPRESSO))
            {
                ValidateEnoughStock(this.espressoStock, quantity);
                this.espressoStock -= quantity;
                coffee.SetEspressoShots(quantity);
            }
            else if (type.Equals(IngredientType.ICE))
            {
                ValidateEnoughStock(this.iceStock, quantity);
                this.iceStock -= quantity;
                coffee.SetCupsOfIce(quantity);
            }
            else if (type.Equals(IngredientType.MILK))
            {
                ValidateEnoughStock(this.milkStock, quantity);
                this.milkStock -= quantity;
                coffee.SetCupsOfMilk(quantity);
            }
        }

        public void AddSweetener(Sweetener type, Coffee coffee)
        {
            if (coffee.GetSweetenerList() == null)
            {
                List<Sweetener> sweetenerList = new List<Sweetener>();
                coffee.SetSweetenerList(sweetenerList);
            }
            coffee.GetSweetenerList().Add(type);
        }

        public void AddEspressoStock(int espressoShots)
        {
            RequirePositive(espressoShots);
            espressoStock += espressoShots;
        }

        public void AddMilkStock(int cupsOfMilk)
        {
            RequirePositive(cupsOfMilk);
            milkStock += cupsOfMilk;
        }

        public void AddIceStock(int cupsOfIce)
        {
            RequirePositive(cupsOfIce);
            iceStock += cupsOfIce;
        }

        private void RequirePositive(int value)
        {
            if (value < 1)
            {
                throw new NullReferenceException();
            }
        }

        private void ValidateEnoughStock(int stock, int neededQuantity)
        {
            if (stock < neededQuantity)
            {
                throw new NullReferenceException("Not Enough Stock");
            }
        }

        public int GetEspressoStock()
        {
            return espressoStock;
        }

        public int GetMilkStock()
        {
            return milkStock;
        }

        public int GetIceStock()
        {
            return iceStock;
        }
    }
}