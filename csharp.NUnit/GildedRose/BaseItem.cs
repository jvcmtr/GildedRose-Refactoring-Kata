namespace GildedRoseKata;

public abstract class BaseItem
{
    public static readonly int MAX_QUALITY = 50; 
    public static readonly int MIN_QUALITY = 0;
     
    public virtual string Name { get; set; }
    public virtual int SellIn { get; set; }
    
    private int _quality; 
    public virtual int Quality { 
        get => _quality; 
        set => _quality = 
            value > MAX_QUALITY? MAX_QUALITY
            : value < MIN_QUALITY? MIN_QUALITY
            : value;
    }
}


