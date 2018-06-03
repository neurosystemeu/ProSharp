using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.ProSharp0_8.CodeModel.Methods.Elements.Statements;
using NeuroSystem.ProSharp0_8.Runtime.Types;

namespace NeuroSystem.ProSharp0_8.CodeModel.Methods
{
    public class MethodDeclaration : Node
    {
        public MethodDeclaration()
        {
            Parameters = new List<MethodParameter>();
        }

        public TypeReference ReturnTypeReference { get; set; }
        public string Name { get; internal set; }

        public List<MethodParameter> Parameters { get; set; }
        public Block Statement { get; internal set; }

        public override void RenderAsText(int level, StringBuilder sb)
        {
            base.renderLevel(level, sb);
            sb.Append("public " + ReturnTypeReference?.Name + " " + Name);
            foreach (var methodParameter in Parameters)
            {
                methodParameter.RenderAsText(0, sb);
            }

            sb.AppendLine(")");

            Statement.RenderAsText(level+1, sb);
        }
    }
}
