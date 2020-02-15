public abstract class Building 
{
    public int Level { get; protected set; }
    public bool Upgrading { get; set; }

    public abstract void LevelUp();

    public Resources UpgradePrice()
    {
        var price = 100 + Level + 1 / 0.985;

        return new Resources(price, 0, price);
    }
}
