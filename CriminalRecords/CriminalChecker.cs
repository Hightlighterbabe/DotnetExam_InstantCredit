namespace CriminalRecords;

public class CriminalChecker : ICriminalChecker
{
    public async Task<bool> IsCriminalStatusCorrect(int passportNumber, bool criminalRecord)
    {
        return (passportNumber == 123123) == criminalRecord;
    }
}
