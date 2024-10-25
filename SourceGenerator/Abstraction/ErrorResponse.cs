namespace SourceGenerator.Abstraction;

public class ErrorResponse
{
    public int Status { get; set; }
    public string StatusText { get; set; }
    public string ErrorMessage { get; set; }
    public string ErrorMessageCode { get; set; }
}