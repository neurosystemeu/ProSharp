using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.ProSharp0_8.CodeModel.Methods.Elements.Expressions;
using NeuroSystem.ProSharp0_8.CodeModel.Methods.Elements.Variables;

namespace NeuroSystem.ProSharp0_8.CodeModel.Methods.Elements.Statements
{
    public class ForStatement : Statement
    {
        public ForStatement()
        {
            Variables = new List<VariableDeclaration>();
            Incrementors = new List<Expression>();
        }

        public List<VariableDeclaration> Variables { get; set; }
        public Expression Condition { get; internal set; }
        public List<Expression> Incrementors { get; internal set; }
        public Block Statement { get; internal set; }
    }
}
