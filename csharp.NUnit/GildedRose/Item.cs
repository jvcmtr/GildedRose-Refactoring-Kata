
namespace GildedRoseKata;

public class Item
{
    public static readonly int MAX_QUALITY = 50; 
    public static readonly int MIN_QUALITY = 0;
     
    public string Name { get; set; }
    public int SellIn { get; set; }
    
    private int _quality; 
    public int Quality { 
        get => _quality; 
        set => _quality = 
            value > MAX_QUALITY? MAX_QUALITY
            : value < MIN_QUALITY? MIN_QUALITY
            : value;
    }
}

