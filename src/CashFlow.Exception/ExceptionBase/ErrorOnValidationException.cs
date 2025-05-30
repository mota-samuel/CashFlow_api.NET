namespace CashFlow.Exception.ExceptionBase;
public class ErrorOnValidationException : CashFlowException
{
    public ErrorOnValidationException(List<string> errorsMessages)
    {
        Errors = errorsMessages;
    }

    public List<string> Errors { get; set; }
}
