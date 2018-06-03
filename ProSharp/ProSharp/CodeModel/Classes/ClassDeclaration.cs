using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.ProSharp0_8.CodeModel.Methods;

namespace NeuroSystem.ProSharp0_8.CodeModel.Classes
{
    public class ClassDeclaration : Node
    {
        public ClassDeclaration()
        {
            Methods = new List<MethodDeclaration>();
            Properties = new List<PropertyDeclaration>();
        }

        public string Name { get; set; }
        public List<MethodDeclaration> Methods { get; set; }
        public List<PropertyDeclaration> Properties { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("class " + Name);
            sb.AppendLine("{");

            foreach (var propertyDeclaration in Properties)
            {
                propertyDeclaration.RenderAsText(1, sb);
            }

            foreach (var methodDeclaration in Methods)
            {
                methodDeclaration.RenderAsText(1, sb);
            }

            return sb.ToString();
        }
    }
}
