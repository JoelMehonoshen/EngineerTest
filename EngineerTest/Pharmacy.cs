namespace EngineerTest;

public class Pharmacy : IPharmacy
{
    private readonly List<Drug> _drugs = new();

    public IDrug AddDrug(string name, int expiresIn, int benefit)
    {
        var drug = new Drug(name, expiresIn, benefit);
        _drugs.Add(drug);
        return drug;
    }

    public IEnumerable<IDrug> UpdateBenefitValue()
    {
        for (var i = 0; i < _drugs.Count; i++)
        {
            _drugs[i].updateDrug();
        }

        return _drugs;
    }
}