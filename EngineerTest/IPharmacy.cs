namespace EngineerTest;

public interface IPharmacy
{
    IEnumerable<IDrug> UpdateDrugList();
    IDrug AddDrug(string name, int expiresIn, int benefit);
}