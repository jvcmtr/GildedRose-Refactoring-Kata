using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        // Responsabilidade do metodo passa a ser mapear cada item para a sua função de update correspondente
        for (var i = 0; i < Items.Count; i++)
        {
            switch (GetItem(i).Name){
                case "Aged Brie":
                    UpdateAged(i);
                    break; 
                case "Backstage passes to a TAFKAL80ETC concert":
                    UpdatePass(i);
                    break; 
                case "Sulfuras, Hand of Ragnaros":
                    UpdateLegendary(i);
                    break; 
                default:
                    UpdateDefault(i);
                    break; 
            }

        }
    }

    // OS Metodos que seguem o padrão `UpdateAged`, `UpdateLegendary` e `UpdatePass` não fazem referencia ao nome dos 
    // items: 'Aged Brie' 'Sulfuras' e 'backstage pass' respectivamente porque intende-se que seu comportamento é derivado 
    // de caracteristicas do objeto em sí. Por exemplo: 
    // - um vinho poderia aumentar em qualidade conforme o tempo passa (assim como o brie). 
    // - Passagens de barco aumentariam de valor conforme se aproxima da data da viagem, mas uma vez que o barco partiu, a passagem perde o valor (assim como BackstagePass)
    // Além disso, no proprio enunciado do Kata que a causa de 'sulfras' não perder sua qualidade é o fato de ser um item lendario. 
    // Portanto, é de se esperar que outros itens lendarios possuam o mesmo comportamento.
    // '"Sulfuras", being a legendary item, never has to be sold or decreases in Quality'
    private void UpdateAged(int index){
        AddToSellIn(index);
        
        var bonus = GetItem(index).SellIn <0? 2 : 1;  
        AddToQuality(index, +bonus);
    }

    private void UpdateLegendary(int index){
        return;
    }

    private void UpdatePass(int index){
        var sellin = 0 + GetItem(index).SellIn;
        AddToSellIn(index);
        
        // Usando a tatica do 'Early Return' para manter as condicionais limpas
        if(sellin < 0) return;

        if(sellin == 0){
            SetQuality(index, 0);
            return;
        }
        if(sellin <= 5 ){
            AddToQuality(index, +3);
            return;
        }
        if(sellin <= 10 ){
            AddToQuality(index, +2);
            return;
        }

        AddToQuality(index, +1);
    }

    private void UpdateDefault(int index){
        AddToSellIn(index);

        var bonus = GetItem(index).SellIn <0? -2 : -1;  
        AddToQuality(index, +bonus);
    }



    // Aplicando os limites de qualidade em uma unica função
    private void AddToQuality(int index, int ammount = -1){
        var q = GetItem(index).Quality + ammount; 
        
        GetItem(index).Quality = Math.Clamp(q, 0, 50);
    }

    // Por mais que seja somente uma linha, isolar este comportamento (reduzir o sellIn) em um só lugar 
    // facilita futuras possiveis extenções deste código. Por exemplo: Caso queiramos que a propriedade SellIn não contabilize feriados. 
    private void AddToSellIn(int index, int ammount = -1){
        GetItem(index).SellIn += ammount;
    }

    // Isola o acesso a propriedade, mas ainda mantém os limites (<50 e >0) em uma unica função;
    private void SetQuality(int index, int value){
        var diference =  value - GetItem(index).Quality ; 
        AddToQuality(index, diference);
    }

    // Isolar o acesso a esta variavel permitiria mudar a implementação da lista e manter o encapsulamento.
    // Exemplo: Em uma refatoração futura poderiamos colocar a lista em uma outra classe ou até mesmo em um bd
    private Item GetItem(int index){
        return Items[index];
    }


}