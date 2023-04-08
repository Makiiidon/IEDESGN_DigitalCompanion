using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PotionUI : MonoBehaviour
{
    [SerializeField] TMP_Text name;
    [SerializeField] Image body;
    [SerializeField] Image liquid;
    [SerializeField] Enums.Potions potionType;
    IngredientHandler ingredientHandler;
    // Start is called before the first frame update
    void Awake()
    {
        ingredientHandler = IngredientHandler.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(Enums.Potions potion)
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

        if (potion == Enums.Potions.Foam)
        {
            body.sprite = ingredientHandler.GetBodySprite(0);
            liquid.sprite = ingredientHandler.GetLiquidSprite(0);
            liquid.color = foam;
        }
        else if (potion == Enums.Potions.Dust)
        {
            body.sprite = ingredientHandler.GetBodySprite(1);
            liquid.sprite = ingredientHandler.GetLiquidSprite(1);
            liquid.color = dust;
        }
        else if (potion == Enums.Potions.Spark)
        {
            body.sprite = ingredientHandler.GetBodySprite(2);
            liquid.sprite = ingredientHandler.GetLiquidSprite(2);
            liquid.color = spark;
        }
        else if (potion == Enums.Potions.Essence)
        {
            body.sprite = ingredientHandler.GetBodySprite(3);
            liquid.sprite = ingredientHandler.GetLiquidSprite(3);
            liquid.color = essence;
        }
        else if (potion == Enums.Potions.Float)
        {
            body.sprite = ingredientHandler.GetBodySprite(0);
            liquid.sprite = ingredientHandler.GetLiquidSprite(0);
            liquid.color = floatColor;
        }
        else if (potion == Enums.Potions.Erosion)
        {
            body.sprite = ingredientHandler.GetBodySprite(1);
            liquid.sprite = ingredientHandler.GetLiquidSprite(1);
            liquid.color = erosion;
        }
        else if (potion == Enums.Potions.Vapor)
        {
            body.sprite = ingredientHandler.GetBodySprite(2);
            liquid.sprite = ingredientHandler.GetLiquidSprite(2);
            liquid.color = vapor;
        }
        else if (potion == Enums.Potions.Sludge)
        {
            body.sprite = ingredientHandler.GetBodySprite(3);
            liquid.sprite = ingredientHandler.GetLiquidSprite(3);
            liquid.color = sludge;
        }
        else if (potion == Enums.Potions.Crystal)
        {
            body.sprite = ingredientHandler.GetBodySprite(0);
            liquid.sprite = ingredientHandler.GetLiquidSprite(0);
            liquid.color = crystal;
        }
        else if (potion == Enums.Potions.Magma)
        {
            body.sprite = ingredientHandler.GetBodySprite(1);
            liquid.sprite = ingredientHandler.GetLiquidSprite(1);
            liquid.color = magma;
        }
        else if (potion == Enums.Potions.Obsidian)
        {
            body.sprite = ingredientHandler.GetBodySprite(2);
            liquid.sprite = ingredientHandler.GetLiquidSprite(2);
            liquid.color = obsidian;
        }
        else if (potion == Enums.Potions.BlueFire)
        {
            body.sprite = ingredientHandler.GetBodySprite(3);
            liquid.sprite = ingredientHandler.GetLiquidSprite(3);
            liquid.color = blueFire;
        }
        else if (potion == Enums.Potions.Star)
        {
            body.sprite = ingredientHandler.GetBodySprite(0);
            liquid.sprite = ingredientHandler.GetLiquidSprite(0);
            liquid.color = star;
        }
        else if (potion == Enums.Potions.Void)
        {
            body.sprite = ingredientHandler.GetBodySprite(1);
            liquid.sprite = ingredientHandler.GetLiquidSprite(1);
            liquid.color = voidColor;
        }

        name.SetText(potion.ToString());
    }
}
