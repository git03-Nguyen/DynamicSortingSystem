using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SourceGenerator.Attributes;

namespace SourceGenerator.DynamicSorting;

public class SortablePayloadSyntaxReceiver : ISyntaxContextReceiver
{
    public List<SortablePayloadInfo> Candidates { get; } = new ();

    public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
    {
        if (context.Node is ClassDeclarationSyntax { AttributeLists.Count: > 0 } classDeclaration)
        {
            var model = context.SemanticModel;
            var classSymbol = model.GetDeclaredSymbol(classDeclaration) as INamedTypeSymbol;
                
            foreach (var attributeData in classSymbol.GetAttributes())
            {
                if (attributeData.AttributeClass.ToDisplayString() == typeof(SortableRequestAttribute).FullName)
                {
                    if (attributeData.ConstructorArguments.FirstOrDefault().Value is INamedTypeSymbol typeArgument)
                    {
                        var classInfo = new SortablePayloadInfo
                        {
                            ClassName = classSymbol.Name,
                            Namespace = classSymbol.ContainingNamespace.ToDisplayString(),
                            SortableType = typeArgument.Name
                        };

                        Candidates.Add(classInfo);
                    }
                }
            }
        }
    }
}