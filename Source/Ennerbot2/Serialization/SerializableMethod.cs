using System.Collections.Generic;

namespace Ennerbot
{
    public class SerializableMethod
    {
        public SerializableMethod() { }

        public SerializableMethod(string name, List<BaseAction> actions)
        {
            this.Name = name;
            this.Actions = actions;
        }

        public string Name { get; set; }

        public List<BaseAction> Actions { get; set; } 
    }
}
