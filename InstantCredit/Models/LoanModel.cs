namespace InstantCredit.Models;

public class LoanModel
{
    public int? Score { get; init; }
    public bool Result { get; init; }
    public string Message { get; init; }
    public decimal? CreditRate { get; init; }
}