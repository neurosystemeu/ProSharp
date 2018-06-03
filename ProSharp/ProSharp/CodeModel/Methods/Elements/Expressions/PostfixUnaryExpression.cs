using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace NeuroSystem.ProSharp0_8.CodeModel.Methods.Elements.Expressions
{
    public class PostfixUnaryExpression : Expression
    {
        public ExpressionSyntax Expression { get; internal set; }
    }
}
