using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using NeuroSystem.ProSharp0_8.CodeModel.Providers;

namespace ProSharp.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var ttt = CSharpSyntaxTree.ParseText("this.TestowaFunkcja(this.Ala * 2, 2)");

            var ttt = CSharpSyntaxTree.ParseText(@"
public class Pracownik
    {
        public string Nazwisko { get; set; }
        public string Imie { get; set; }
        public int RokUrodzenia { get; set; }
        public int RozmiarButa { get; set; }

        public string GenerujRaport()
        {
            var ret = Imie + ' ' + Nazwisko + ' : ';
            int i = 1;
            i = i + RozmiarButa + RokUrodzenia;

            var d = 1.4 * RozmiarButa + i;

            for (int j = i; j < RozmiarButa; j++)
            {
                ret += j;
            }

            return ret;
        }
    }".Replace("'","\""));

            var root = ttt.GetRoot() as Microsoft.CodeAnalysis.CSharp.Syntax.CompilationUnitSyntax;

            var importer = new CSharpImporter();
            var com = importer.Import(root);
            //var md = root.Members[0] as Microsoft.CodeAnalysis.CSharp.Syntax.MethodDeclarationSyntax;
            
        }

        public int Ala => 4;

        public int TestowaFunkcja(int i, int j)
        {
            return i + j * 2;
        }
    }
}
