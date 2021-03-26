using System;

namespace PizzaCalories
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] pizzaInput = Console.ReadLine().Split();
            string[] doughInput = Console.ReadLine().Split();

            try
            {
                var flour = doughInput[1];
                var baking = doughInput[2];
                var doughWeight = int.Parse(doughInput[3]);

                Dough dough = new Dough(flour, baking, doughWeight);

                Pizza pizza = new Pizza(pizzaInput[1], dough);


                while (true)
                {
                    string toppingInput = Console.ReadLine();

                    if (toppingInput == "END")
                    {
                        break;
                    }

                    string[] type = toppingInput.Split();
                    var toppingName = type[1];
                    var toppingWeight = int.Parse(type[2]);

                    Topping topping = new Topping(toppingName, toppingWeight);

                    pizza.AddTopping(topping);
                }

                Console.WriteLine($"{pizza.Name} - {pizza.PizzaCalories:f2} Calories.");
            }
            catch (Exception ex)
                when(ex is ArgumentException || ex is InvalidOperationException)
            {
                Console.WriteLine(ex.Message);
            }







            //string[] input = Console.ReadLine().Split();
            //string flourType = input[1];
            //string baking = input[2];
            //int weight = int.Parse(input[3]);

            //try
            //{
            //    Dough dough = new Dough(flourType, baking, weight);
            //    Console.WriteLine(dough.DoughCalories());
            //}
            //catch (ArgumentException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //var toppingInput = Console.ReadLine().Split();
            //var name = toppingInput[1];
            //var toppingweight = int.Parse(toppingInput[2]);

            //try
            //{
            //    Topping topping = new Topping(name, toppingweight);
            //    Console.WriteLine(topping.ToppingCalories);
            //}
            //catch (ArgumentException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }
    }
}
