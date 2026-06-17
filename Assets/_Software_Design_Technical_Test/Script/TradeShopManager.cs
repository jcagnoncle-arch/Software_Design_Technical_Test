using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TradeShopManager : MonoBehaviour
{

    [SerializeField] private int price = 100;
    [SerializeField] private TextMeshProUGUI coinAmmount = default;
    [SerializeField] private TextMeshProUGUI diamondAmmount = default;
    [SerializeField] private Toggle maxToggle = default;
    [SerializeField] private CanvasGroup tradeInterractableGroup = default;

    private int exchangingCoin = 100;
    public int CoinExchanged => exchangingCoin;
    public int ExcheableDiamond => exchangingCoin / price;

    public void UpdateShopUi()
    {

        diamondAmmount.text = ExcheableDiamond.ToString();
        coinAmmount.text = "x " + exchangingCoin + " / " + GameManager.instance.CoinAmmount;
        tradeInterractableGroup.interactable = GameManager.instance.CoinAmmount >= price;
    }


    public void ToggleMaxPressed()
    {
        if (maxToggle.isOn)
        {
            exchangingCoin = GameManager.instance.CoinAmmount;
        }
        else
        {
            exchangingCoin = price;
        }

        UpdateShopUi();
    }
}
