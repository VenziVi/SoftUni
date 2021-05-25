namespace AquaShop
{
    using System;
    using System.Globalization;
    using System.Threading;
    using AquaShop.Core;
    using AquaShop.Core.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
            //Don't forget to comment out the commented code lines in the Engine class!
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
