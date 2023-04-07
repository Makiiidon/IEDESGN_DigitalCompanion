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
            liquid.color = foam + foam;
        }
        else if (potion == Enums.Potions.Erosion)
        {
            body.sprite = ingredientHandler.GetBodySprite(1);
            liquid.sprite = ingredientHandler.GetLiquidSprite(1);
            liquid.color = foam + dust;
        }
        else if (potion == Enums.Potions.Vapor)
        {
            body.sprite = ingredientHandler.GetBodySprite(2);
            liquid.sprite = ingredientHandler.GetLiquidSprite(2);
            liquid.color = foam + spark;
        }
        else if (potion == Enums.Potions.Sludge)
        {
            body.sprite = ingredientHandler.GetBodySprite(3);
            liquid.sprite = ingredientHandler.GetLiquidSprite(3);
            liquid.color = foam + essence;
        }
        else if (potion == Enums.Potions.Crystal)
        {
            body.sprite = ingredientHandler.GetBodySprite(0);
            liquid.sprite = ingredientHandler.GetLiquidSprite(0);
            liquid.color = dust + dust;
        }
        else if (potion == Enums.Potions.Magma)
        {
            body.sprite = ingredientHandler.GetBodySprite(1);
            liquid.sprite = ingredientHandler.GetLiquidSprite(1);
            liquid.color = dust + spark;
        }
        else if (potion == Enums.Potions.Obsidian)
        {
            body.sprite = ingredientHandler.GetBodySprite(2);
            liquid.sprite = ingredientHandler.GetLiquidSprite(2);
            liquid.color = dust + essence;
        }
        else if (potion == Enums.Potions.BlueFire)
        {
            body.sprite = ingredientHandler.GetBodySprite(3);
            liquid.sprite = ingredientHandler.GetLiquidSprite(3);
            liquid.color = spark + spark;
        }
        else if (potion == Enums.Potions.Star)
        {
            body.sprite = ingredientHandler.GetBodySprite(0);
            liquid.sprite = ingredientHandler.GetLiquidSprite(0);
            liquid.color = spark + essence;
        }
        else if (potion == Enums.Potions.Void)
        {
            body.sprite = ingredientHandler.GetBodySprite(1);
            liquid.sprite = ingredientHandler.GetLiquidSprite(1);
            liquid.color = essence + essence;
        }

        name.SetText(potion.ToString());
    }
}
