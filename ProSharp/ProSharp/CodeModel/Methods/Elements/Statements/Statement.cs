using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.ProSharp0_8.CodeModel.Methods.Elements.Statements
{
    public class Statement : MethodElement
    {
        public override void RenderAsText(int level, StringBuilder sb)
        {
            base.renderLevel(level, sb);
            sb.AppendLine(this.ToString());
        }
    }
}
