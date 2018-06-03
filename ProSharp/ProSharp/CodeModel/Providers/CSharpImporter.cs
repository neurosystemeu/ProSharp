using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NeuroSystem.ProSharp0_8.CodeModel.Classes;
using NeuroSystem.ProSharp0_8.CodeModel.Methods;
using NeuroSystem.ProSharp0_8.CodeModel.Methods.Elements.Expressions;
using NeuroSystem.ProSharp0_8.CodeModel.Methods.Elements.Statements;
using NeuroSystem.ProSharp0_8.CodeModel.Methods.Elements.Variables;
using NeuroSystem.ProSharp0_8.CodeModel.Modules;
using NeuroSystem.ProSharp0_8.Runtime.Types;

namespace NeuroSystem.ProSharp0_8.CodeModel.Providers
{
    public class CSharpImporter : CodeImporterBase
    {
        
        public ModuleDeclaration Import(Microsoft.CodeAnalysis.CSharp.Syntax.CompilationUnitSyntax compilationUnit)
        {
            var module = new ModuleDeclaration();

            convertComputationUnit(compilationUnit, module);
            
            return module;
        }

        private void convertComputationUnit(CompilationUnitSyntax compilationUnit, ModuleDeclaration module)
        {
            foreach (var memberDeclarationSyntax in compilationUnit.Members)
            {
                converMemberDeclaration(memberDeclarationSyntax, module);
            }
        }

        private void converMemberDeclaration(MemberDeclarationSyntax memberDeclarationSyntax,
            ModuleDeclaration module)
        {
            if (memberDeclarationSyntax is ClassDeclarationSyntax classDeclarationSyntax)
            {
                convertClassDeclaration(classDeclarationSyntax, module);
            } 
        }

        private void convertClassDeclaration(ClassDeclarationSyntax classDeclarationSyntax, ModuleDeclaration module)
        {
            var classDeclaration = new ClassDeclaration();
            module.Clases.Add(classDeclaration);

            foreach (var memberDeclarationSyntax in classDeclarationSyntax.Members)
            {
                if (memberDeclarationSyntax is PropertyDeclarationSyntax propertyDeclaration)
                {
                    convertPropertyDeclaration(propertyDeclaration, classDeclaration);
                }

                if (memberDeclarationSyntax is MethodDeclarationSyntax method)
                {
                    convertMethodDeclaration(method, classDeclaration);
                }
            }
            
        }

        private void convertPropertyDeclaration(PropertyDeclarationSyntax propertyDeclaration, ClassDeclaration classDeclaration)
        {
            var pd = new PropertyDeclaration();

            pd.Name = propertyDeclaration.Identifier.ToString();
            pd.TypeReference = getTypeReference(propertyDeclaration.Type);

            classDeclaration.Properties.Add(pd);
        }

        private void convertMethodDeclaration(MethodDeclarationSyntax methodDeclaration,
            ClassDeclaration classDeclaration)
        {
            var method = new MethodDeclaration();
            method.Name = methodDeclaration.Identifier.Text;

            foreach (var parameter in methodDeclaration.ParameterList.Parameters)
            {
                convertMethodParameter(parameter, method);
            }

            convertMethodBody(methodDeclaration.Body, method);
            classDeclaration.Methods.Add(method);
        }

        private void convertMethodBody(BlockSyntax body, MethodDeclaration method)
        {
            var b = new Block();
            foreach (var statementSyntax in body.Statements)
            {
                convertStatment(statementSyntax, b);
            }

            method.Statement = b;
        }

        private void convertStatment(StatementSyntax statementSyntax, Block b)
        {
            //statementSyntax
            switch (statementSyntax)
            {
                case ReturnStatementSyntax returnStatement:
                    var ret = new ReturnStatement();
                    ret.Expression = convertExpression(returnStatement.Expression);
                    b.Statements.Add(ret);
                    return;
                case LocalDeclarationStatementSyntax localDeclarationStatementSyntax:
                    convertLocalVariableDeclaration(localDeclarationStatementSyntax, b);
                    return;
                case ExpressionStatementSyntax expressionStatementSyntax:
                    var es = new ExpressionStatement();
                    es.Expression = convertExpression(expressionStatementSyntax.Expression);
                    b.Statements.Add(es);
                    return;
                case ForStatementSyntax forStatementSyntax:
                    var f = new ForStatement();
                    foreach (var dec in forStatementSyntax.Declaration.Variables)
                    {
                        var vd = new VariableDeclaration();
                        vd.Name = dec.Identifier.ToString();
                        vd.Initialize = convertVariableInicializer(dec.Initializer);
                        f.Variables.Add(vd);
                    }

                    f.Condition = convertExpression(forStatementSyntax.Condition);
                    foreach (var expressionSyntax in forStatementSyntax.Incrementors)
                    {
                        f.Incrementors.Add(convertExpression(expressionSyntax));
                    }

                    f.Statement = new Block();
                    convertStatment(forStatementSyntax.Statement, f.Statement);
                    return;
                case BlockSyntax blockSyntax:
                    var bl = new Block();
                    b.Statements.Add(bl);
                    foreach (var bs in blockSyntax.Statements)
                    {
                        convertStatment(bs, bl);
                    }
                    
                    return;
            }

            return;
        }

        private VariableInitializer convertVariableInicializer(EqualsValueClauseSyntax initializer)
        {
            var vi = new VariableInitializer();
            vi.Expression = convertExpression(initializer.Value);
            return vi;
        }

        private void convertLocalVariableDeclaration(LocalDeclarationStatementSyntax localDeclarationStatementSyntax, Block b)
        {
            foreach (var variableDeclaratorSyntax in localDeclarationStatementSyntax.Declaration.Variables)
            {
                var lv = new LocalVariableDeclaration();
                lv.Name = variableDeclaratorSyntax.Identifier.ToString();
                lv.TypeReference = getTypeReference(localDeclarationStatementSyntax.Declaration.Type);
                lv.InitializeExpression = convertExpression(variableDeclaratorSyntax.Initializer.Value);
                b.Statements.Add(lv);
            }
        }

        

        private Expression convertExpression(ExpressionSyntax expression)
        {
            switch (expression)
            {
                case BinaryExpressionSyntax binaryExpressionSyntax:
                    var be = new BinaryExpression();
                    be.Kind = convertBinaryExpressionKind(binaryExpressionSyntax.Kind());
                    be.Left = convertExpression(binaryExpressionSyntax.Left);
                    be.Right = convertExpression(binaryExpressionSyntax.Right);
                    return be;
                case IdentifierNameSyntax identifierNameSyntax:
                    var id = new IdentifierNameExpression();
                    id.Name = identifierNameSyntax.ToString();
                    return id;
                case LiteralExpressionSyntax literalExpressionSyntax:
                    var le = convertLiteralExpressionValue(literalExpressionSyntax);
                    return le;
                case AssignmentExpressionSyntax assignmentExpressionSyntax:
                    var ae = new AssignmentExpression();
                    ae.Left = convertExpression(assignmentExpressionSyntax.Left);
                    ae.Right = convertExpression(assignmentExpressionSyntax.Right);
                    return ae;
                case PostfixUnaryExpressionSyntax postfixUnaryExpressionSyntax:
                    var pe = new PostfixUnaryExpression();
                    pe.Expression = postfixUnaryExpressionSyntax.Operand;
                    return pe;

            }

            return null;
        }

        private LiteralExpression convertLiteralExpressionValue(LiteralExpressionSyntax literalExpressionSyntax)
        {
            var le = new LiteralExpression();
            var str = literalExpressionSyntax.ToString();

            int i;
            double d;

            if (int.TryParse(str, out i))
            {
                le.LiteralValue = i;
                le.LiteType = TypeReference.Parse("int");
            } else if (double.TryParse(str, out d))
            {
                le.LiteralValue = d;
                le.LiteType = TypeReference.Parse("double");
            }
            else
            {
                le.LiteralValue = str;
                le.LiteType = TypeReference.Parse("string");
            }


            return le;
        }

        private BinaryExpressionKind convertBinaryExpressionKind(SyntaxKind syntaxKind)
        {
            switch (syntaxKind)
            {
                case SyntaxKind.AddExpression:
                    return BinaryExpressionKind.AddExpression;
                case SyntaxKind.MultiplyExpression:
                    return BinaryExpressionKind.MultiplyExpression;
                case SyntaxKind.LessThanExpression:
                    return BinaryExpressionKind.LessThanExpression;
            }

            throw new NotImplementedException();
        }

        private void convertMethodParameter(ParameterSyntax parameter, MethodDeclaration method)
        {
            var p = new MethodParameter();
            p.Name = parameter.Identifier.ToString();
            p.ParameterTypeReference = getTypeReference(parameter.Type);
            p.Name = parameter.Identifier.ToString();
            method.Parameters.Add(p);
        }

        private TypeReference getTypeReference(TypeSyntax type)
        {
            return TypeReference.Parse(type.ToString());
        }
    }
}
