using System;
using System.Collections.Generic;
using System.Text;
using GildedRoseKata.Utils;

namespace GildedRoseKata;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("OMGHAI!");


        IList<IItem> items = GetItems();
        int days = 2;
        string mode = "default";
        
        if (args.Length > 0)
        {
            days = int.Parse(args[0]) + 1;
        }

        if (args.Length > 1)
        {
            mode = args[1];
        }

        switch(mode){
            case "default":
                RunDefault(days, items);
                break;
            case "style":
                RunStylish(days, items);
                break;
            default:
                Console.WriteLine("### ERROR, '" + mode + "' is not a valid mode." );
                break;
        }        
    }

    public static void RunDefault(int days, IList<IItem> items ){
        var app = new GildedRose(items);

        for (var i = 0; i < days; i++)
        {
            Console.WriteLine("-------- day " + i + " --------");
            Console.WriteLine("name, sellIn, quality");
            for (var j = 0; j < items.Count; j++)
            {
                Console.WriteLine(items[j].Name + ", " + items[j].SellIn + ", " + items[j].Quality);
            }
            Console.WriteLine("");
            app.UpdateQuality();
        }
    }

    public static void RunStylish(int days, IList<IItem> items ){
        var app = new GildedRose(items);

        var str = new StringBuilder();
        for (var i = 0; i < days; i++)
        {
            var table = new Table<string>();
            for (var j = 0; j < items.Count; j++)
            {
                table[j.ToString(), "__Name__"] = items[j].Name; 
                table[j.ToString(), "__Sell_in__"] = items[j].SellIn.ToString(); 
                table[j.ToString(), "__Quality__"] = items[j].Quality.ToString();
            }
            
            str.AppendLine("                       ░▒█ DAY " + i + " █▒░  \n");
            str.Append(table.GetFormated(" |  ", ' ', Alignment.ALIGN_LEFT));
            var dayInfo = ConsoleViewUtils.Boxed(str.ToString());
            Console.WriteLine( dayInfo );

            Console.WriteLine("");
            app.UpdateQuality();
            str.Clear();
        }
    }

    public static List<IItem> GetItems(){
        return new List<IItem>
        {
            new DefaultItem {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
            new AgedItem  {Name = "Aged Brie", SellIn = 2, Quality = 0},
            new DefaultItem {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
            new LegendaryItem {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
            new LegendaryItem {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
            new PassItem
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 15,
                Quality = 20
            },
            new PassItem
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 10,
                Quality = 49
            },
            new PassItem
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 5,
                Quality = 49
            },
            new ConjuredItem {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
        };
    }

}