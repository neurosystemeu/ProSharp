using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.ProSharp0_8.CodeModel.Classes;

namespace NeuroSystem.ProSharp0_8.CodeModel.Modules
{
    public class ModuleDeclaration : Node
    {
        public ModuleDeclaration()
        {
            Clases = new List<ClassDeclaration>();
        }

        public List<ClassDeclaration> Clases { get; set; }
    }
}
