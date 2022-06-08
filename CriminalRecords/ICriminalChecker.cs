namespace CriminalRecords;

public interface ICriminalChecker
{
    public Task<bool> IsCriminalStatusCorrect(int passportNumber, bool criminalRecord);
}
