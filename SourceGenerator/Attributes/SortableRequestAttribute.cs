namespace SourceGenerator.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class SortableRequestAttribute : Attribute
{
    public Type DataType { get; }
    
    public SortableRequestAttribute(Type dataType)
    {
        DataType = dataType;
    }
}