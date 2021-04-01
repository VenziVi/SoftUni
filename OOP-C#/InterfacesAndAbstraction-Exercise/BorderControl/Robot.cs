using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    class Robot : IRobot, IIdentifiable
    {
        public Robot(string Model, string id)
        {
            this.Model = Model;
            this.Id = id;
        }
        public string Model { get; private set; }

        public string Id { get; private set; }
    }
}
