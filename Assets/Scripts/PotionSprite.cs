using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PotionSprite : MonoBehaviour
{
    IngredientHandler ingredientHandler;
    Mixing mixing;
    [SerializeField] Image body;
    [SerializeField] Image liquid;
    [SerializeField] TMP_Text name;
    [SerializeField] int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        ingredientHandler = IngredientHandler.Instance;
        mixing = Mixing.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSprite()
    {
        Color foam = ingredientHandler.GetColor(0);
        Color dust = ingredientHandler.GetColor(1);
        Color spark = ingredientHandler.GetColor(2);
        Color essence = ingredientHandler.GetColor(3);
        Color floatColor = ingredientHandler.GetColor(4);
        Color erosion = ingredientHandler.GetColor(5);
        Color vapor = ingredientHandler.GetColor(6);
        Color sludge = ingredientHandler.GetColor(7);
        Color crystal = ingredientHandler.GetColor(8);
        Color magma = ingredientHandler.GetColor(9);
        Color obsidian = ingredientHandler.GetColor(10);
        Color blueFire = ingredientHandler.GetColor(11);
        Color star = ingredientHandler.GetColor(12);
        Color voidColor = ingredientHandler.GetColor(13);

        if (mixing.GetPotionsToMixList()[index] == Enums.Potions.Foam)
        {
            body.sprite = ingredientHandler.GetBodySprite(0);
            liquid.sprite = ingredientHandler.GetLiquidSprite(0);
            liquid.color = foam;
        }
        else if (mixing.GetPotionsToMixList()[index] == Enums.Potions.Dust)
        {
            body.sprite = ingredientHandler.GetBodySprite(1);
            liquid.sprite = ingredientHandler.GetLiquidSprite(1);
            liquid.color = dust;
        }
        else if (mixing.GetPotionsToMixList()[index] == Enums.Potions.Spark)
        {
            body.sprite = ingredientHandler.GetBodySprite(2);
            liquid.sprite = ingredientHandler.GetLiquidSprite(2);
            liquid.color = spark;
        }
        else if (mixing.GetPotionsToMixList()[index] == Enums.Potions.Essence)
        {
            body.sprite = ingredientHandler.GetBodySprite(3);
            liquid.sprite = ingredientHandler.GetLiquidSprite(3);
            liquid.color = essence;
        }
        else if (mixing.GetPotionsToMixList()[index] == Enums.Potions.Float)
        {
            body.sprite = ingredientHandler.GetBodySprite(0);
            liquid.sprite = ingredientHandler.GetLiquidSprite(0);
            liquid.color = floatColor;
        }
        else if (mixing.GetPotionsToMixList()[index] == Enums.Potions.Erosion)
        {
            body.sprite = ingredientHandler.GetBodySprite(1);
            liquid.sprite = ingredientHandler.GetLiquidSprite(1);
            liquid.color = erosion;
        }
        else if (mixing.GetPotionsToMixList()[index] == Enums.Potions.Vapor)
        {
            body.sprite = ingredientHandler.GetBodySprite(2);
            liquid.sprite = ingredientHandler.GetLiquidSprite(2);
            liquid.color = vapor;
        }
        else if (mixing.GetPotionsToMixList()[index] == Enums.Potions.Sludge)
        {
            body.sprite = ingredientHandler.GetBodySprite(3);
            liquid.sprite = ingredientHandler.GetLiquidSprite(3);
            liquid.color = sludge;
        }
        else if (mixing.GetPotionsToMixList()[index] == Enums.Potions.Crystal)
        {
            body.sprite = ingredientHandler.GetBodySprite(0);
            liquid.sprite = ingredientHandler.GetLiquidSprite(0);
            liquid.color = crystal;
        }
        else if (mixing.GetPotionsToMixList()[index] == Enums.Potions.Magma)
        {
            body.sprite = ingredientHandler.GetBodySprite(1);
            liquid.sprite = ingredientHandler.GetLiquidSprite(1);
            liquid.color = magma;
        }
        else if (mixing.GetPotionsToMixList()[index] == Enums.Potions.Obsidian)
        {
            body.sprite = ingredientHandler.GetBodySprite(2);
            liquid.sprite = ingredientHandler.GetLiquidSprite(2);
            liquid.color = obsidian;
        }
        else if (mixing.GetPotionsToMixList()[index] == Enums.Potions.BlueFire)
        {
            body.sprite = ingredientHandler.GetBodySprite(3);
            liquid.sprite = ingredientHandler.GetLiquidSprite(3);
            liquid.color = blueFire;
        }
        else if (mixing.GetPotionsToMixList()[index] == Enums.Potions.Star)
        {
            body.sprite = ingredientHandler.GetBodySprite(0);
            liquid.sprite = ingredientHandler.GetLiquidSprite(0);
            liquid.color = star;
        }
        else if (mixing.GetPotionsToMixList()[index] == Enums.Potions.Void)
        {
            body.sprite = ingredientHandler.GetBodySprite(1);
            liquid.sprite = ingredientHandler.GetLiquidSprite(1);
            liquid.color = voidColor;
        }
        name.SetText(mixing.GetPotionsToMixList()[index].ToString());

    }
}
