using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinCounter = default;
    [SerializeField] private TextMeshProUGUI diamondCounter = default;

    public void UpdateCoinAmmount(int ammount)
    {
        coinCounter.text = ammount.ToString();
    }
    public void UpdateDiamondAmmount(int ammount)
    {
        diamondCounter.text = ammount.ToString();
    }
}
