namespace CashFlow.Communication.Responses;
public class ResponseErrorJson
{
    public List<string> ErrorMessagem { get; set; } = [];

    public ResponseErrorJson(string erroMessage)
    {
        ErrorMessagem = new List<string> { erroMessage };
    }

    public ResponseErrorJson(List<string> errorsMessages)
    {
        ErrorMessagem = errorsMessages;
    }
}
