using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinCounter = default;
    [SerializeField] private TextMeshProUGUI diamondCounter = default;
    [SerializeField] public Transform diamondIcon = default;
    [SerializeField] public Transform coinIcon = default;
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
        coinCounter.text = ammount.ToString();
    }
    public void UpdateDiamondAmmount(int ammount)
    {
        diamondCounter.text = ammount.ToString();
    }
}
