using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.ProSharp0_8.Runtime.Types
{
    public enum TypeKind
    {
        UserType,
        Int,
        Double,
        String
    }

    public class TypeReference
    {
        public string Name { get; set; }
        public string Namespace { get; set; }
        public TypeKind Kind { get; set; }

        internal static TypeReference Parse(string name)
        {
            var tr = new TypeReference();
            tr.Name = name;
            switch (name)
            {
                case "int":
                    tr.Kind = TypeKind.Int;
                    break;
                case "double":
                    tr.Kind = TypeKind.Double;
                    break;
                case "string":
                    tr.Kind = TypeKind.String;
                    break;
            }

            return tr;
        }
    }
}
