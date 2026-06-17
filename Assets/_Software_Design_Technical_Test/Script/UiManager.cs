using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Made by Julien Cagnoncle

public class UiManager : MonoBehaviour
{
	// Reference to the unique instance of this script
	public static UiManager instance = default;
    [SerializeField] private HUDManager hud = default;
    [SerializeField] private TradeShopManager shop = default;

    private bool tradeOpen = default;

    private void Awake()
    {
        // Checker of the unicity of the instance
        if (instance == null) instance = this;
        else Destroy(this);
        shop.gameObject.SetActive(false);
    }

    public void UpdateCurrencyUIAmmount(int coinAmmount, int diamondAmmount)
    {
        hud.UpdateCoinAmmount(coinAmmount);
        hud.UpdateDiamondAmmount(diamondAmmount);
        shop.UpdateShopUi();
    }

    public void ToggleTradeShop()
    {
        tradeOpen = !tradeOpen;
        shop.gameObject.SetActive(tradeOpen);
    }

    public void ShopTrade()
    {
        GameManager.instance.ChangeCoinAmmount(-shop.CoinExchanged);
        GameManager.instance.ChangeDiamondAmount(shop.ExcheableDiamond);
        UpdateCurrencyUIAmmount(GameManager.instance.CoinAmmount, GameManager.instance.DiamondAmmount);
    }

}
