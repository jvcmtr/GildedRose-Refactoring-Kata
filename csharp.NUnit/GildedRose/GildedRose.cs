using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    IList<IItem> Items;

    public GildedRose(IList<IItem> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            Items[i].UpdateItem();
        }
    }
}


