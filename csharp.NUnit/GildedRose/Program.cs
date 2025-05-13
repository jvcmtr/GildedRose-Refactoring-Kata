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

        IList<Item> items = new List<Item>
        {
            new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
            new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
            new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 15,
                Quality = 20
            },
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 10,
                Quality = 49
            },
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 5,
                Quality = 49
            },
            // this conjured item does not work properly yet
            new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
        };

        var app = new GildedRose(items);

        int days = 2;
        if (args.Length > 0)
        {
            days = int.Parse(args[0]) + 1;
        }

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

}