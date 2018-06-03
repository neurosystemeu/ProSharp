using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.ProSharp0_8.Runtime.Types;

namespace NeuroSystem.ProSharp0_8.CodeModel.Methods.Elements.Expressions
{
    public class LiteralExpression : Expression
    {
        public TypeReference LiteType { get; set; }
        public object LiteralValue { get; set; }
    }
}
