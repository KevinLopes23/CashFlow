namespace CashFlow.Exception.ExpectionsBase;

public class ErrorOnValidationExpection : CashFlowException
{
 
    public List<string> Errors { get; set; }
    
    public ErrorOnValidationExpection(List<string> errorMessages)
    {
        Errors = errorMessages;
    }
}
