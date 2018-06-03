using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.ProSharp0_8.CodeModel.Methods.Elements.Expressions
{
    public class AssignmentExpression : Expression
    {
        public Expression Left { get; internal set; }
        public Expression Right { get; internal set; }
    }
}
