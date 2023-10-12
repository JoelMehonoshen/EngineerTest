namespace EngineerTest;

public class Drug : IDrug
{
    public string Name { get; }
    public int ExpiresIn { get; set; }
    public int Benefit { get; set; }

    public Drug(string name, int expiresIn, int benefit)
    {
        Name = name;
        ExpiresIn = expiresIn;
        Benefit = benefit;
    }

    protected bool Equals(Drug other)
    {
        return Name == other.Name && ExpiresIn == other.ExpiresIn && Benefit == other.Benefit;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Drug)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, ExpiresIn, Benefit);
    }

    public void UpdateDrug()
    {
        switch (Name)
        {
            case "Magic Pill":
                // Magic Pill never expires nor decreases in Benefit
                break;

            case "Herbal Tea":
                HandleHerbalTea();
                break;

            case "Fervex":
                HandleFervex();
                break;
        }
    }

    private void HandleHerbalTea()
    {
        // Increase Benefit
        if (Benefit < 50)
        {
            if (ExpiresIn > 0)
                Benefit++;
            else { Benefit += 2; }
            if (Benefit > 50) { Benefit = 50; }
        }
        ExpiresIn--; // Decrease expiresIn
    }
    private void HandleFervex()
    {
        if (ExpiresIn > 0)
        {
            if (Benefit < 50)
            {
                if (ExpiresIn > 10)
                    Benefit += 1;
                else if (ExpiresIn <= 10 && ExpiresIn > 5)
                    Benefit += 2;
                else if (ExpiresIn <= 5)
                    Benefit += 3;
                if (Benefit > 50) {Benefit = 50; }
            }
            
        }
        // Benefit drops to 0 after expiration
        else Benefit = 0;
        // Decrease expiresIn
        ExpiresIn--; 
    }
}