using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ennerbot
{
    [Serializable]
    public class SerializableMacro
    {
        /// <summary>
        /// Deserializes the stream into a SerializableMacro object
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static SerializableMacro Deserialize(Stream stream)
        {
            return (new Serializer()).Deserialize<SerializableMacro>(stream);
        }

        /// <summary>
        /// Serializes the SerializableMacro object into string
        /// </summary>
        /// <param name="macro"></param>
        /// <returns></returns>
        public static string Serialize(SerializableMacro macro)
        {
            return (new Serializer()).Serialize(macro);
        }

        public SerializableMacro()
        {
        }

        public SerializableMacro(IMacroRoutine routine, IEnumerable<IMacroMethod> register)
        {
            this.Repetitions = routine.Repetitions;
            this.Actions = routine.Actions.Select(a => (BaseAction) a).ToList();

            this.Register = new List<SerializableMethod>();
            foreach (var method in register)
            {
                this.Register.Add(new SerializableMethod(method.Name, method.Actions.Select(a => (BaseAction) a).ToList()));
            }
        }

        public List<SerializableMethod> Register { get; set; }  

        public List<BaseAction> Actions { get; set; }

        public int Repetitions { get; set; }
    }
}
