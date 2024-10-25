using System.Diagnostics;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Scriban;

namespace SourceGenerator.DynamicSorting;

[Generator]
public class SortingRequestGenerator : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext context)
    {
    }
    
    public void Execute(GeneratorExecutionContext context)
    {
        File.AppendAllText(@"C:s\SourceGeneratorLog.txt", "Source generator executed.\n");
        
        if (context.SyntaxContextReceiver is not SortablePayloadSyntaxReceiver receiver)
        {
            return;
        }
        
        var path = Path.Combine(Directory.GetCurrentDirectory(), "Templates");
        var templatePath = Path.Combine(path, "Payload.sbn");
        using var reader = new StreamReader(templatePath);
        var template = Template.Parse(reader.ReadToEnd());
        foreach (var candidate in receiver.Candidates)
        {
            var data = new
            {
                className = candidate.ClassName,
                namespaceName = candidate.Namespace,
                dataType = candidate.SortableType
            };

            var sourceCode = template.Render(data);
            // write the generated source to a file
            if (sourceCode is not null)
            {
                using var writer = new StreamWriter(Path.Combine(path, $"{candidate.ClassName}.t.cs"));
                writer.Write(sourceCode);
                
                context.AddSource($"{candidate.ClassName}.g.cs", SourceText.From(sourceCode, Encoding.UTF8));
            }
        }
    }
}