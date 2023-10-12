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

    public IEnumerable<IDrug> UpdateDrugList()
    {
        for (var i = 0; i < _drugs.Count; i++)
        {
            _drugs[i].UpdateDrug();
        }

        return _drugs;
    }
}