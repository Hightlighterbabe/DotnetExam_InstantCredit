namespace InstantCredit.Models;

public class FormModel
{
    public string Fio { get; init; }
    public int? PassportSeries { get; init; }
    public int? PassportNumber { get; init; }
    public string PassportGiven { get; init; }
    public DateTime? PassportGivenDate { get; init; }
    public string PassportRegistration { get; init; }
    public int? Age { get; init; }
    public bool? CriminalRecord { get; init; }
    public decimal? Sum { get; init; }
    public GoalEnum? Goal { get; init; }
    public EmploymentEnum? Employment { get; init; }
    public bool? OtherCredits { get; init; }
    public PledgeEnum? Pledge { get; init; }
    public int? AutoAge { get; init; }

    public enum GoalEnum
    {
        Consumer = 1,
        RealEstate = 2,
        OnLending = 3
    }

    public enum EmploymentEnum
    {
        Unemployed = 1,
        Ip = 2,
        Tk = 3,
        NonTk = 4,
        Pensioner = 5
    }

    public enum PledgeEnum
    {
        RealEstate = 1,
        Auto = 2,
        Guarantee = 3,
        NonPledge = 4
    }
}