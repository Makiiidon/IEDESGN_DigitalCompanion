using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPotionHandler : MonoBehaviour
{
    [SerializeField] GameObject PotionMenuUI;
    [SerializeField] GameObject ButtonPrefab;
    [SerializeField] Transform PotionHolder;

    [SerializeField] GameObject PlayerCountUI;

    [SerializeField] GameObject UseButton;
    BossBehaviour bossBehaviour;
    Enums.Potions equipped = Enums.Potions.None;

    [SerializeField] List<int> playerScores;
    int currentPlayer = 0;

    bool isOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        bossBehaviour = FindAnyObjectByType<BossBehaviour>();
        PotionMenuUI.SetActive(false);
        PlayerCountUI.SetActive(true);
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
        }
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

}
