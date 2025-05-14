namespace GildedRoseKata {
    public class ConjuredItem : BaseItem, IItem
    {
        public void UpdateItem()
        {
            SellIn -= 1;
            Quality -= SellIn < 0? 4 : 2;
        }
    }
}

