namespace GildedRoseKata;

public interface IItem : IItemUpdater
{ 
    public string Name { get; set; }
    public int SellIn { get; set; }
    public int Quality {get; set;}
}

