using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.ProSharp0_8.CodeModel.Methods.Elements.Expressions;
using NeuroSystem.ProSharp0_8.CodeModel.Methods.Elements.Statements;
using NeuroSystem.ProSharp0_8.Runtime.Types;

namespace NeuroSystem.ProSharp0_8.CodeModel.Methods.Elements.Variables
{
    public class LocalVariableDeclaration : Statement
    {
        public string Name { get; internal set; }
        public Expression InitializeExpression { get; internal set; }
        public TypeReference TypeReference { get; internal set; }
    }
}
