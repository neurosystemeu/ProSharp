using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.ProSharp0_8.CodeModel
{
    /// <summary>
    /// Bazowy węzeł do wszystkich elementów
    /// </summary>
    public class Node
    {
        public virtual void RenderAsText(int level, StringBuilder sb)
        {
            
        }

        protected void renderLevel(int level, StringBuilder sb)
        {
            for (int i = 0; i < level; i++)
            {
                sb.Append(" ");
            }
        }
    }
}
