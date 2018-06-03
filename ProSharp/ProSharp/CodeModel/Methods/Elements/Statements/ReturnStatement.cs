using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.ProSharp0_8.CodeModel.Methods.Elements.Expressions;

namespace NeuroSystem.ProSharp0_8.CodeModel.Methods.Elements.Statements
{
    public class ReturnStatement : Statement
    {
        public Expression Expression { get; internal set; }
    }
}
