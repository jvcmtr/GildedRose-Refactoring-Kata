namespace GildedRoseKata {
    public class PassItem : BaseItem, IItem
    {
        public void UpdateItem()
        {
            var deltaQ = 1;

            if(SellIn < 0) deltaQ = 0;
            else if(SellIn == 0) deltaQ = Quality * (-1);
            else if(SellIn <= 5) deltaQ = +3;
            else if(SellIn <= 10) deltaQ = +2;

            Quality += deltaQ;
            SellIn -=1;
        }
    }
}
