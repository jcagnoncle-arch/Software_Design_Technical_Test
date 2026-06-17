using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : CurrencyScreen
{
    [SerializeField] private TextMeshProUGUI coinCounter = default;
    [SerializeField] private TextMeshProUGUI diamondCounter = default;
    [SerializeField] public Animator diamondCounterAnimator = default;
    [SerializeField] public Animator coinCounterAnimator = default;

    public void ChangeCurrency(bool coin ,int variation)
    {
        if (coin)
        {
            coinCounterAnimator.SetInteger("AmmountChange", variation);
        }
        else
        {
            diamondCounterAnimator.SetInteger("AmmountChange", variation);
        }
    }

    public void UpdateCoinAmmount(int ammount)
    {
        coinAmmount.text = ammount.ToString();
    }
    public void UpdateDiamondAmmount(int ammount)
    {
        diamondAmmount.text = ammount.ToString();
    }
}
