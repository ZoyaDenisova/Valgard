using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EconomyWinCounter : Singleton<EconomyManager>
{
    private TMP_Text goldText;
    private int currentGold = 0;

    const string COIN_AMOUNT_TEXT = "Gold Amount Text Win";

    public void UpdateCurrentGold() {
        currentGold += 1;

        if (goldText == null) {
            goldText = GameObject.Find(COIN_AMOUNT_TEXT).GetComponent<TMP_Text>();
        }

        goldText.text = currentGold.ToString("D3");
    }
}
