using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly List<IComputer> computers;
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;

        public Controller()
        {
            computers = new List<IComputer>();
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }


        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            IComputer currComp = computers.FirstOrDefault(c => c.Id == computerId);

            if (!computers.Contains(currComp))
            {
                throw new ArgumentException(string.Format(Common.Constants.ExceptionMessages.NotExistingComputerId));
            }

            var currComponent = components.FirstOrDefault(c => c.Id == id);

            if (currComponent != null)
            {
                throw new ArgumentException(string.Format(Common.Constants.ExceptionMessages.ExistingComponentId));
            }

            IComponent component = null;

            if (componentType == nameof(CentralProcessingUnit))
            {
                component = new CentralProcessingUnit(id, manufacturer,model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(Motherboard))
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(PowerSupply))
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(RandomAccessMemory))
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(SolidStateDrive))
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(VideoCard))
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException(string.Format(Common.Constants.ExceptionMessages.InvalidComponentType));
            }

            currComp.AddComponent(component);
            components.Add(component);
            return string.Format(Common.Constants.SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer computer = computers.FirstOrDefault(c => c.Id == id);

            if (computer != null)
            {
                throw new ArgumentException(string.Format(Common.Constants.ExceptionMessages.ExistingComputerId));
            }

            IComputer comp = null;

            if (computerType == "Laptop")
            {
                comp = new Laptop(id, manufacturer, model, price);
            }
            else if (computerType == "DesktopComputer")
            {
                comp = new DesktopComputer(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException(string.Format(Common.Constants.ExceptionMessages.InvalidComputerType));
            }

            computers.Add(comp);
            return string.Format(Common.Constants.SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            IComputer currComp = computers.FirstOrDefault(c => c.Id == computerId);

            if (!computers.Contains(currComp))
            {
                throw new ArgumentException(string.Format(Common.Constants.ExceptionMessages.NotExistingComputerId));
            }

            var currPeripherial = peripherals.FirstOrDefault(p => p.Id == id);
            if (currPeripherial != null)
            {
                throw new ArgumentException(string.Format(Common.Constants.ExceptionMessages.ExistingPeripheralId));
            }

            IPeripheral peripheral = null;

            if (peripheralType == nameof(Headset))
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == nameof(Keyboard))
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == nameof(Monitor))
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == nameof(Mouse))
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException(string.Format(Common.Constants.ExceptionMessages.InvalidPeripheralType));
            }

            currComp.AddPeripheral(peripheral);
            peripherals.Add(peripheral);
            return string.Format(Common.Constants.SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            IComputer currComp = null;

            foreach (var computer in computers.OrderByDescending(c => c.OverallPerformance))
            {
                if (computer.Price > budget)
                {
                    continue;
                }
                else
                {
                    currComp = computer;
                    break;
                }
            }


            computers.Remove(currComp);
            return currComp.ToString();
            //throw new NotImplementedException();
            //computers.OrderByDescending(c => c.OverallPerformance);
            //computers.OrderByDescending(c => c.Price);
            //IComputer currComp = computers.FirstOrDefault(c => c.Price <= budget);

            //if (currComp == null)
            //{
            //    throw new ArgumentException(string.Format(Common.Constants.ExceptionMessages.CanNotBuyComputer, budget));
            //}

            //computers.Remove(currComp);
            //return currComp.ToString();
        }

        public string BuyComputer(int id)
        {
            IComputer currComp = computers.FirstOrDefault(c => c.Id == id);

            if (!computers.Contains(currComp))
            {
                throw new ArgumentException(string.Format(Common.Constants.ExceptionMessages.NotExistingComputerId));
            }

            computers.Remove(currComp);
            return currComp.ToString();
        }

        public string GetComputerData(int id)
        {
            IComputer currComp = computers.FirstOrDefault(c => c.Id == id);

            if (!computers.Contains(currComp))
            {
                throw new ArgumentException(string.Format(Common.Constants.ExceptionMessages.NotExistingComputerId));
            }

            return currComp.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IComputer currComp = computers.FirstOrDefault(c => c.Id == computerId);

            if (!computers.Contains(currComp))
            {
                throw new ArgumentException(string.Format(Common.Constants.ExceptionMessages.NotExistingComputerId));
            }

            var component = currComp.Components.FirstOrDefault(c => c.GetType().Name == componentType);

            if (component == null)
            {
                throw new ArgumentException(string.Format(Common.Constants.ExceptionMessages.NotExistingComponent, componentType, currComp.GetType().Name, computerId));
            }
            var id = component.Id;
            currComp.RemoveComponent(componentType);
            components.Remove(component);
            return string.Format(Common.Constants.SuccessMessages.RemovedComponent, componentType, id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IComputer currComp = computers.FirstOrDefault(c => c.Id == computerId);

            if (!computers.Contains(currComp))
            {
                throw new ArgumentException(string.Format(Common.Constants.ExceptionMessages.NotExistingComputerId));
            }

            var peripherial = currComp.Peripherals.FirstOrDefault(c => c.GetType().Name == peripheralType);

            if (peripherial == null)
            {
                throw new ArgumentException(string.Format(Common.Constants.ExceptionMessages.NotExistingPeripheral, peripheralType, currComp.GetType().Name, computerId));
            }
            var id = peripherial.Id;
            currComp.RemovePeripheral(peripheralType);
            peripherals.Remove(peripherial);
            return string.Format(Common.Constants.SuccessMessages.RemovedPeripheral, peripheralType, id);
        }

    }
}
