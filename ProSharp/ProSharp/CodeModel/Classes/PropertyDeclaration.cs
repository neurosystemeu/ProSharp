using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.ProSharp0_8.Runtime.Types;

namespace NeuroSystem.ProSharp0_8.CodeModel.Classes
{
    public class PropertyDeclaration : Node
    {
        public string Name { get; internal set; }
        public TypeReference TypeReference { get; internal set; }

        public override void RenderAsText(int level, StringBuilder sb)
        {
            base.renderLevel(level, sb);
            sb.AppendLine("public " + TypeReference.Name + " " + Name + " { get; set; }");
        }
    }
}
