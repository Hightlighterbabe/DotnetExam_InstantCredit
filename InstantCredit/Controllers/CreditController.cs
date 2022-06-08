using Microsoft.AspNetCore.Mvc;
using InstantCredit.Models;
using InstantCredit.Services;

namespace InstantCredit.Controllers;

[ApiController]
[Route("[controller]")]
public class CreditController : ControllerBase
{
    private readonly CheckingOfCriminal _checkingOfCriminal;
    private readonly ScoringOfCredit _scoringOfCredit;
    private readonly RateCredit _rateCredit;

    public CreditController(CheckingOfCriminal checkingOfCriminal, ScoringOfCredit scoringOfCredit,
        RateCredit rateCredit)
    {
        _checkingOfCriminal = checkingOfCriminal;
        _scoringOfCredit = scoringOfCredit;
        _rateCredit = rateCredit;
    }

    [HttpPost]
    public async Task<IActionResult> Submit([FromBody]FormModel questionnaire)
    {
        var criminalStatusIsCorrect = await _checkingOfCriminal.IsCriminalStatusCorrect(questionnaire);
        if (!criminalStatusIsCorrect)
            return new JsonResult(new LoanModel
            {
                Score = null,
                Result = false,
                Message = "Статус судимости не соответствует действительности",
                CreditRate = null
            });
        
        var score = _scoringOfCredit.CountScore(questionnaire);
        
        if (score < 80)
            return new JsonResult(new LoanModel
            {
                Score = score,
                Result = false,
                Message = "Кредит не будет выдан, так как набрано 80 или менее очков",
                CreditRate = null
            });
        
        var creditRate = _rateCredit.CalculateCreditRate(score);
        return new JsonResult(new LoanModel
        {
            Score = score,
            Result = true,
            Message = "Кредит будет выдан, так как набрано более 80 очков",
            CreditRate = creditRate
        });
    }
}
