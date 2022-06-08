using InstantCredit.Models;

namespace InstantCredit.Services;

public class ScoringOfCredit
{
    public int CountScore(FormModel form)
    {
        var score = 0;

        switch (form.Age)
        {
            case >= 21 and <= 28:
                switch (form.Sum)
                {
                    case < 1000000:
                        score += 12;
                        break;
                    case < 3000000:
                        score += 9;
                        break;
                    default:
                        score += 0;
                        break;
                }

                break;
            case >= 29 and <= 59:
                score += 14;
                break;
            case >= 60 and <= 72:
                score += form.Pledge is not FormModel.PledgeEnum.NonPledge ? 8 : 0;
                break;
            default:
                score += 0;
                break;
        }

        score += form.CriminalRecord.Value ? 0 : 15;

        switch (form.Employment)
        {
            case FormModel.EmploymentEnum.Unemployed:
                score += 0;
                break;
            case FormModel.EmploymentEnum.Ip:
                score += 12;
                break;
            case FormModel.EmploymentEnum.Tk:
                score += 14;
                break;
            case FormModel.EmploymentEnum.NonTk:
                score += 8;
                break;
            case FormModel.EmploymentEnum.Pensioner:
                score += form.Age < 70 ? 5 : 0;
                break;
        }

        switch (form.Goal)
        {
            case FormModel.GoalEnum.Consumer:
                score += 14;
                break;
            case FormModel.GoalEnum.RealEstate:
                score += 8;
                break;
            case FormModel.GoalEnum.OnLending:
                score += 12;
                break;
        }

        switch (form.Pledge)
        {
            case FormModel.PledgeEnum.RealEstate:
                score += 14;
                break;
            case FormModel.PledgeEnum.Auto:
                score += form.AutoAge < 3 ? 8 : 3;
                break;
            case FormModel.PledgeEnum.Guarantee:
                score += 12;
                break;
            case FormModel.PledgeEnum.NonPledge:
                score += 0;
                break;
        }

        if (!form.OtherCredits!.Value && form.Goal != FormModel.GoalEnum.OnLending) 
            score += 15;

        switch (form.Sum)
        {
            case <= 1000000:
                score += 12;
                break;
            case <= 5000000:
                score += 14;
                break;
            case <= 10000000:
                score += 8;
                break;
        }

        return score;
    }
}