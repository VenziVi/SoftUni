namespace _01.Microsystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Microsystems : IMicrosystem
    {
        private Dictionary<int, Computer> compByNumber;
        private Dictionary<Brand, List<Computer>> compByBrand;
        private Dictionary<double, List<Computer>> compByScreen;
        private Dictionary<string, List<Computer>> compByColor;

        public Microsystems()
        {
            this.compByNumber = new Dictionary<int, Computer>();
            this.compByBrand = new Dictionary<Brand, List<Computer>>();
            this.compByScreen = new Dictionary<double, List<Computer>>();
            this.compByColor = new Dictionary<string, List<Computer>>();
        }

        public void CreateComputer(Computer computer)
        {
            if (this.compByNumber.ContainsKey(computer.Number))
                throw new ArgumentException();

            if (!this.compByBrand.ContainsKey(computer.Brand))
                this.compByBrand[computer.Brand] = new List<Computer>();
            this.compByBrand[computer.Brand].Add(computer);

            if (!this.compByScreen.ContainsKey(computer.ScreenSize))
                this.compByScreen[computer.ScreenSize] = new List<Computer>();
            this.compByScreen[computer.ScreenSize].Add(computer);

            if (!this.compByColor.ContainsKey(computer.Color))
                this.compByColor[computer.Color] = new List<Computer>();
            this.compByColor[computer.Color].Add(computer);

            this.compByNumber[computer.Number] = computer;
        }

        public bool Contains(int number)
        {
            return this.compByNumber.ContainsKey(number);
        }

        public int Count()
        {
            return this.compByNumber.Count;
        }

        public Computer GetComputer(int number)
        {
            if (!this.compByNumber.ContainsKey(number))
                throw new ArgumentException();

            return this.compByNumber[number];
        }

        public void Remove(int number)
        {
            if (!this.compByNumber.ContainsKey(number))
                throw new ArgumentException();

            var currComp = this.compByNumber[number];
            var screenSize = currComp.ScreenSize;
            var color = currComp.Color;

            this.compByNumber.Remove(number);
            this.compByScreen.Remove(screenSize);
            this.compByColor.Remove(color);
        }

        public void RemoveWithBrand(Brand brand)
        {
            if (!this.compByBrand.ContainsKey(brand))
                throw new ArgumentException();

            var currCopmuters = this.compByBrand[brand];

            foreach (var comp in currCopmuters)
            {
                this.Remove(comp.Number);
            }

        }

        public void UpgradeRam(int ram, int number)
        {
            var currComp = this.GetComputer(number);

            if (currComp.RAM < ram)
            {
                currComp.RAM = ram;
            }    
        }

        public IEnumerable<Computer> GetAllFromBrand(Brand brand)
        {
            if (!this.compByBrand.ContainsKey(brand))
                return new List<Computer>();

            return this.compByBrand[brand].ToList().OrderByDescending(c => c.Price);
        }

        public IEnumerable<Computer> GetAllWithScreenSize(double screenSize)
        {
            if (!this.compByScreen.ContainsKey(screenSize))
                return new List<Computer>();

            return this.compByScreen[screenSize].ToList().OrderByDescending(c => c.Number);
        }

        public IEnumerable<Computer> GetAllWithColor(string color)
        {
            if (!this.compByColor.ContainsKey(color))
                return new List<Computer>();

            return this.compByColor[color].ToList().OrderByDescending(c => c.Price);
        }

        public IEnumerable<Computer> GetInRangePrice(double minPrice, double maxPrice)
        {
            return this.compByNumber
                .Values
                .Where(c => c.Price >= minPrice && c.Price <= maxPrice)
                .OrderByDescending(c => c.Price);
        }
    }
}
