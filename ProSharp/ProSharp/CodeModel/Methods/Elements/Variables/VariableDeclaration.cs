using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.ProSharp0_8.CodeModel.Methods.Elements.Variables
{
    public class VariableDeclaration : Node
    {
        public string Name { get; internal set; }
        public VariableInitializer Initialize { get; internal set; }
    }
}
