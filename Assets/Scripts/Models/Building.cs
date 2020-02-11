public abstract class Building 
{
    public int Level { get; internal set; }
    public bool Upgrading { get; internal set; }

    public abstract void LevelUp();
    public abstract void Upgrade();

    //public Resourсes UpgradePrice()
    //{
    //}
}
