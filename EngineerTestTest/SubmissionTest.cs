using EngineerTest;
using Xunit;

namespace EngineerTestTest;

public class SubmissionTest
{
    private readonly Pharmacy _pharmacy;

    public SubmissionTest()
    {
        _pharmacy = new Pharmacy();
    }
    
    [Fact]
    public void TestShouldDecreaseBenefitAndExpiresIn()
    {
        _pharmacy.AddDrug("test", 2, 3);
        Assert.Equal(new[] { new Drug("test", 1, 2)}, 
            _pharmacy.UpdateBenefitValue());
    }
    
    [Fact]
    public void TestShouldDecreaseBenefitTwiceAsFastOnceExpired()
    {
        _pharmacy.AddDrug("test", -1, 3);
        Assert.Equal(new[] { new Drug("test", -2, 1)}, 
            _pharmacy.UpdateBenefitValue());
    }
    
    [Fact]
    public void TestBenefitShouldNeverBeNegative()
    {
        _pharmacy.AddDrug("test", 1, 0);
        Assert.Equal(new[] { new Drug("test", 0, 0)}, 
            _pharmacy.UpdateBenefitValue());
    }

    [Fact]
    public void TestHerbalTeaIncreasedBenefit()
    {
        _pharmacy.AddDrug("Herbal Tea", 1, 0);
        Assert.Equal(new[] { new Drug("Herbal Tea", 0, 1)}, 
            _pharmacy.UpdateBenefitValue());
    }

    [Fact]
    public void TestHerbalTeaIncreasedBenefitDoubledWhenExpired()
    {
        _pharmacy.AddDrug("Herbal Tea", -1, 0);
        Assert.Equal(new[] { new Drug("Herbal Tea", -2, 2)}, 
            _pharmacy.UpdateBenefitValue());
    }

    [Fact]
    public void TestHerbalTeaIncreasedBenefitMax50()
    {
        _pharmacy.AddDrug("Herbal Tea", 1, 50);
        Assert.Equal(new[] { new Drug("Herbal Tea", 0, 50)}, 
            _pharmacy.UpdateBenefitValue());
    }

    [Fact]
    public void TestMagicPillNeverChanges()
    {
        _pharmacy.AddDrug("Magic Pill", 1, 10);
        Assert.Equal(new[] { new Drug("Magic Pill", 1, 10)}, 
            _pharmacy.UpdateBenefitValue());
    }
    
    [Fact]
    public void TestFervexIncreasedBenefitGreaterThan10()
    {
        _pharmacy.AddDrug("Fervex", 11, 2);
        Assert.Equal(new[] { new Drug("Fervex", 10, 3)}, 
            _pharmacy.UpdateBenefitValue());
    }

    [Fact]
    public void TestFervexIncreasedBenefitDoubledWhen10DaysOrLess()
    {
        _pharmacy.AddDrug("Fervex", 10, 0);
        Assert.Equal(new[] { new Drug("Fervex", 9, 2)}, 
            _pharmacy.UpdateBenefitValue());
        Assert.Equal(new[] { new Drug("Fervex", 8, 4)}, 
            _pharmacy.UpdateBenefitValue());
        Assert.Equal(new[] { new Drug("Fervex", 7, 6)}, 
            _pharmacy.UpdateBenefitValue());
        Assert.Equal(new[] { new Drug("Fervex", 6, 8)}, 
            _pharmacy.UpdateBenefitValue());
        Assert.Equal(new[] { new Drug("Fervex", 5, 10)}, 
            _pharmacy.UpdateBenefitValue());
    }
    
    [Fact]
    public void TestFervexBenefitZeroAfterExpires()
    {
        _pharmacy.AddDrug("Fervex", -1, 30);
        Assert.Equal(new[] { new Drug("Fervex", -2, 0)}, 
            _pharmacy.UpdateBenefitValue());
    }

    [Fact]
    public void TestFervexIncreasedBenefitTrippledWhen5DaysOrLess()
    {
        _pharmacy.AddDrug("Fervex", 5, 0);
        Assert.Equal(new[] { new Drug("Fervex", 4, 3)}, 
            _pharmacy.UpdateBenefitValue());
        Assert.Equal(new[] { new Drug("Fervex", 3, 6)}, 
            _pharmacy.UpdateBenefitValue());
        Assert.Equal(new[] { new Drug("Fervex", 2, 9)}, 
            _pharmacy.UpdateBenefitValue());
        Assert.Equal(new[] { new Drug("Fervex", 1, 12)}, 
            _pharmacy.UpdateBenefitValue());
        Assert.Equal(new[] { new Drug("Fervex", 0, 15)}, 
            _pharmacy.UpdateBenefitValue());
    }

    [Fact]
    public void TestFervexIncreasedBenefitMax50()
    {
        _pharmacy.AddDrug("Fervex", 1, 50);
        Assert.Equal(new[] { new Drug("Fervex", 0, 50)}, 
            _pharmacy.UpdateBenefitValue());
    }

    [Fact]
    public void TestDafalganDoubleDecreasedBenefit()
    {
        _pharmacy.AddDrug("Dafalgan", 10, 50);
        Assert.Equal(new[] { new Drug("Dafalgan", 9, 48)}, 
            _pharmacy.UpdateBenefitValue());
        Assert.Equal(new[] { new Drug("Dafalgan", 8, 46)}, 
            _pharmacy.UpdateBenefitValue());
        Assert.Equal(new[] { new Drug("Dafalgan", 7, 44)}, 
            _pharmacy.UpdateBenefitValue());
    }

    [Fact]
    public void TestDafalganFourTimesDecreasedBenefitAfterExpiration()
    {
        _pharmacy.AddDrug("Dafalgan", 10, 50);
        Assert.Equal(new[] { new Drug("Dafalgan", 9, 48)}, 
            _pharmacy.UpdateBenefitValue());
        Assert.Equal(new[] { new Drug("Dafalgan", 8, 46)}, 
            _pharmacy.UpdateBenefitValue());
        Assert.Equal(new[] { new Drug("Dafalgan", 7, 44)}, 
            _pharmacy.UpdateBenefitValue());
    }

    

}