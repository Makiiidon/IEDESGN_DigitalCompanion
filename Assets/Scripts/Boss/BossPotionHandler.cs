using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossPotionHandler : MonoBehaviour
{
    [SerializeField] GameObject PotionMenuUI;
    [SerializeField] GameObject ButtonPrefab;
    [SerializeField] Transform PotionHolder;

    [SerializeField] GameObject PlayerCountUI;

    [SerializeField] GameObject UseButton;
    BossBehaviour bossBehaviour;
    Enums.Potions equipped = Enums.Potions.None;

    IngredientHandler ingredientHandler;

    [SerializeField] Image body;
    [SerializeField] Image liquid;
    [SerializeField] TMP_Text name;

    [SerializeField] GameObject ScoreUI;

    [SerializeField] TMP_Text player1Txt;
    [SerializeField] TMP_Text player2Txt;
    [SerializeField] TMP_Text player3Txt;
    [SerializeField] TMP_Text player4Txt;
    [SerializeField] TMP_Text player5Txt;
    [SerializeField] TMP_Text player6Txt;

    [SerializeField] TMP_Text TurnTxt;

    [SerializeField] List<int> playerScores;
    int currentPlayer = 0;

    bool isOpened = false, isScoresOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        bossBehaviour = FindAnyObjectByType<BossBehaviour>();
        ingredientHandler = IngredientHandler.Instance;
        PotionMenuUI.SetActive(false);
        PlayerCountUI.SetActive(true);
        ScoreUI.SetActive(false);
    }

    private void Update()
    {
        if (equipped == Enums.Potions.None)
        {
            UseButton.SetActive(false);
        }
        else
        {
            UseButton.SetActive(true);
            ChangeSprite();
        }

        if (isScoresOpened)
        {
            player1Txt.SetText(playerScores[0].ToString());
            player2Txt.SetText(playerScores[1].ToString());
            if (playerScores.Count >= 3)
            {
                player3Txt.SetText(playerScores[2].ToString());
                if (playerScores.Count >= 4)
                {
                    player4Txt.SetText(playerScores[3].ToString());
                    if (playerScores.Count >= 5)
                    {
                        player5Txt.SetText(playerScores[4].ToString());
                    }
                    if (playerScores.Count >= 6)
                    {
                        player6Txt.SetText(playerScores[5].ToString());
                    }
                }
            }
        }
        TurnTxt.SetText($"Player {currentPlayer + 1}'s turn!");

    }

    public void InputNumberOfPlayers(int numberOfPlayers)
    {
        for (int i = 0; i < numberOfPlayers; i++)
        {
            playerScores.Add(0);
        }
        PlayerCountUI.SetActive(false);
    }

    public void SetEquippedPotion(string potionStr)
    {
        Enums.Potions potion = Enums.Potions.None;

        if (potionStr == "Foam")
        {
            potion = Enums.Potions.Foam;
        }
        else if (potionStr == "Dust")
        {
            potion = Enums.Potions.Dust;
        }
        else if (potionStr == "Spark")
        {
            potion = Enums.Potions.Spark;
        }
        else if (potionStr == "Essence")
        {
            potion = Enums.Potions.Essence;
        }
        else if (potionStr == "Float")
        {
            potion = Enums.Potions.Float;
        }
        else if (potionStr == "Erosion")
        {
            potion = Enums.Potions.Erosion;
        }
        else if (potionStr == "Vapor")
        {
            potion = Enums.Potions.Vapor;
        }
        else if (potionStr == "Sludge")
        {
            potion = Enums.Potions.Sludge;
        }
        else if (potionStr == "Magma")
        {
            potion = Enums.Potions.Magma;
        }
        else if (potionStr == "Crystal")
        {
            potion = Enums.Potions.Crystal;
        }
        else if (potionStr == "Obsidian")
        {
            potion = Enums.Potions.Obsidian;
        }
        else if (potionStr == "BlueFire")
        {
            potion = Enums.Potions.BlueFire;
        }
        else if (potionStr == "Star")
        {
            potion = Enums.Potions.Star;
        }
        else if (potionStr == "Void")
        {
            potion = Enums.Potions.Void;
        }
        equipped = potion;
    }

    public void UsePotion()
    {
        if (equipped != Enums.Potions.None)
        {
            Debug.Log((currentPlayer + 1) + "'s Turn");

            playerScores[currentPlayer] += bossBehaviour.DamageBoss(equipped);
            equipped = Enums.Potions.None;
            if (currentPlayer < playerScores.Count - 1)
            {
                currentPlayer++;
            }
            else
            {
                currentPlayer = 0;
            }
        }
        
    }

    public void OpenPotionMenu()
    {
        if (isOpened)
        {
            PotionMenuUI.SetActive(false);
            isOpened = false;

        }
        else
        {
            PotionMenuUI.SetActive(true);
            isOpened = true;
        }
        
    }

    public void OpenScores()
    {
        if (isScoresOpened)
        {
            ScoreUI.SetActive(false);
            isScoresOpened = false;

        }
        else
        {
            ScoreUI.SetActive(true);

            isScoresOpened = true;
        }
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

        if (equipped == Enums.Potions.Foam)
        {
            body.sprite = ingredientHandler.GetBodySprite(0);
            liquid.sprite = ingredientHandler.GetLiquidSprite(0);
            liquid.color = foam;
        }
        else if (equipped == Enums.Potions.Dust)
        {
            body.sprite = ingredientHandler.GetBodySprite(1);
            liquid.sprite = ingredientHandler.GetLiquidSprite(1);
            liquid.color = dust;
        }
        else if (equipped == Enums.Potions.Spark)
        {
            body.sprite = ingredientHandler.GetBodySprite(2);
            liquid.sprite = ingredientHandler.GetLiquidSprite(2);
            liquid.color = spark;
        }
        else if (equipped == Enums.Potions.Essence)
        {
            body.sprite = ingredientHandler.GetBodySprite(3);
            liquid.sprite = ingredientHandler.GetLiquidSprite(3);
            liquid.color = essence;
        }
        else if (equipped == Enums.Potions.Float)
        {
            body.sprite = ingredientHandler.GetBodySprite(0);
            liquid.sprite = ingredientHandler.GetLiquidSprite(0);
            liquid.color = floatColor;
        }
        else if (equipped == Enums.Potions.Erosion)
        {
            body.sprite = ingredientHandler.GetBodySprite(1);
            liquid.sprite = ingredientHandler.GetLiquidSprite(1);
            liquid.color = erosion;
        }
        else if (equipped == Enums.Potions.Vapor)
        {
            body.sprite = ingredientHandler.GetBodySprite(2);
            liquid.sprite = ingredientHandler.GetLiquidSprite(2);
            liquid.color = vapor;
        }
        else if (equipped == Enums.Potions.Sludge)
        {
            body.sprite = ingredientHandler.GetBodySprite(3);
            liquid.sprite = ingredientHandler.GetLiquidSprite(3);
            liquid.color = sludge;
        }
        else if (equipped == Enums.Potions.Crystal)
        {
            body.sprite = ingredientHandler.GetBodySprite(0);
            liquid.sprite = ingredientHandler.GetLiquidSprite(0);
            liquid.color = crystal;
        }
        else if (equipped == Enums.Potions.Magma)
        {
            body.sprite = ingredientHandler.GetBodySprite(1);
            liquid.sprite = ingredientHandler.GetLiquidSprite(1);
            liquid.color = magma;
        }
        else if (equipped == Enums.Potions.Obsidian)
        {
            body.sprite = ingredientHandler.GetBodySprite(2);
            liquid.sprite = ingredientHandler.GetLiquidSprite(2);
            liquid.color = obsidian;
        }
        else if (equipped == Enums.Potions.BlueFire)
        {
            body.sprite = ingredientHandler.GetBodySprite(3);
            liquid.sprite = ingredientHandler.GetLiquidSprite(3);
            liquid.color = blueFire;
        }
        else if (equipped == Enums.Potions.Star)
        {
            body.sprite = ingredientHandler.GetBodySprite(0);
            liquid.sprite = ingredientHandler.GetLiquidSprite(0);
            liquid.color = star;
        }
        else if (equipped == Enums.Potions.Void)
        {
            body.sprite = ingredientHandler.GetBodySprite(1);
            liquid.sprite = ingredientHandler.GetLiquidSprite(1);
            liquid.color = voidColor;
        }
        name.SetText(equipped.ToString());

    }
}
