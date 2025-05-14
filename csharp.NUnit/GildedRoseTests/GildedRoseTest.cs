using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Test]
    public void ConjuredItem()
    {
        var initialQuality = 50;
        var initialSellin = 10;
        
        var defaultItem = new DefaultItem(){ Name = "default", SellIn = initialSellin, Quality = initialQuality };
        var conjuredItem = new ConjuredItem(){ Name = "conjured", SellIn = initialSellin, Quality = initialQuality } ;
        
        var items = new List<IItem> { defaultItem, conjuredItem};
        var app = new GildedRose(items);
        
        for (int i = 0; i < 10; i++){
            app.UpdateQuality();
        }

        var ratio = (initialQuality - conjuredItem.Quality) / (decimal) (initialQuality - defaultItem.Quality) ;
        Assert.That(ratio, Is.EqualTo(2));
    }

    [Test]
    public void Foo()
    {
        var items = new List<IItem> { new DefaultItem(){ Name = "foo", SellIn = 0, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Name, Is.EqualTo("foo"));
    }
}