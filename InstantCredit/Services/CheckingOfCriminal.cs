using CriminalRecords;
using InstantCredit.Models;

namespace InstantCredit.Services;

public class CheckingOfCriminal
{
    private readonly ICriminalChecker _criminalStatusChecker;

    public CheckingOfCriminal(ICriminalChecker criminalStatusChecker) =>
        _criminalStatusChecker = criminalStatusChecker;

    public async Task<bool> IsCriminalStatusCorrect(FormModel formModel) =>
        await _criminalStatusChecker.IsCriminalStatusCorrect(
            formModel.PassportNumber.Value,
            formModel.CriminalRecord.Value);
}
