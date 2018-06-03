using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.ProSharp0_8.CodeModel.Methods.Elements.Expressions;
using NeuroSystem.ProSharp0_8.Runtime.Types;

namespace NeuroSystem.ProSharp0_8.CodeModel.Methods
{
    /// <summary>
    /// Parametr metody
    /// </summary>
    public class MethodParameter : Node
    {
        public TypeReference ParameterTypeReference { get; set; }
        public string Name { get; set; }
        public Expression Expression { get; set; }

        public override void RenderAsText(int level, StringBuilder sb)
        {
            sb.Append(Name);
        }
    }
}
