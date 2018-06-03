using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.ProSharp0_8.CodeModel.Methods.Elements.Statements
{
    public class Block : Statement
    {
        public Block()
        {
            Statements = new List<Statement>();
        }

        public List<Statement> Statements { get; set; }

        public override void RenderAsText(int level, StringBuilder sb)
        {
            renderLevel(level, sb);
            sb.AppendLine("{");

            foreach (var statement in Statements)
            {
                statement.RenderAsText(level+1, sb);
            }

            renderLevel(level, sb);
            sb.AppendLine("}");
        }

        
    }
}
