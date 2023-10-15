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

            case "Dafalgan":
                HandleDafalgan();
                break;

            default:
                HandleUnknownDrug();
                break;
        }
    }

    private void HandleHerbalTea()
    {
        // Herbal Tea: Benefit increases over time, but up to a maximum of 50
        if (Benefit < 50)
        {
            if (ExpiresIn > 0)
                Benefit++;
            else
                Benefit += 2;

            if (Benefit > 50)
                Benefit = 50;
        }

        ExpiresIn--; // Decrease expiresIn
    }

    private void HandleFervex()
    {
        // Fervex: Benefit rate increases as expiration date approaches, up to a maximum of 50
        if (ExpiresIn > 0 && Benefit <= 50)
        {
            if (ExpiresIn > 10)
                Benefit += 1;
            else if (ExpiresIn <= 10 && ExpiresIn > 5)
                Benefit += 2;
            else if (ExpiresIn <= 5)
                Benefit += 3;

            if (Benefit > 50)
                Benefit = 50;
        }
        else
        {
            // Benefit drops to 0 after expiration
            Benefit = 0;
        }

        ExpiresIn--; // Decrease expiresIn
    }

    private void HandleDafalgan()
    {
        // Dafalgan: Benefit decreases over time at twice the regular rate, but not below 0
        if (Benefit > 0)
        {
            if (ExpiresIn > 0)
                Benefit -= 2;
            else
                Benefit -= 4;

            if (Benefit < 0)
                Benefit = 0;
        }

        ExpiresIn--; // Decrease expiresIn
    }

    private void HandleUnknownDrug()
    {
        // For unknown drugs: Benefit decreases over time, but not below 0
        if (Benefit > 0)
        {
            if (ExpiresIn > 0)
                Benefit--;
            else
                Benefit -= 2;

            if (Benefit < 0)
                Benefit = 0;
        }

        ExpiresIn--; // Decrease expiresIn
    }
}