namespace GildedRoseKata {
    public class DefaultItem : BaseItem, IItem
    {
        public void UpdateItem()
        {
            SellIn -= 1;
            Quality -= SellIn < 0? 2 : 1;
        }
    }
}

