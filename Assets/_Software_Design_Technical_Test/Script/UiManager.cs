using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Made by Julien Cagnoncle

public class UiManager : MonoBehaviour
{
	// Reference to the unique instance of this script
    private const float TIME_PER_PARTICLE = 0.2F;

	public static UiManager instance = default;
    [SerializeField] private HUDManager hud = default;
    [SerializeField] private TradeShopManager shop = default;
    [SerializeField] private GameObject particleDiamond = default;
    [SerializeField] private GameObject particleCoin = default;
    [SerializeField] private Transform particleParent = default;

    private bool tradeOpen = default;

    private Coroutine resetDiamond = default;
    private Coroutine resetCoin = default;

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
        
        if (tradeOpen)
        {
            ToggleTradeMenu();
        }
        else
        {
            shop.HideMenu();
            Invoke("ToggleTradeMenu", 0.36F);
        }
    }

    private void ToggleTradeMenu()
    {
        shop.gameObject.SetActive(tradeOpen);
    }

    public void ShopTrade()
    {

        StartCoroutine(Purchase(shop.ExcheableDiamond));
    }

    private IEnumerator Purchase(int ammountPurchased)
    {
        int particleCount = 0;

        while (particleCount<ammountPurchased)
        {
            particleCount++;
            BuyDiamond();
            yield return new WaitForSeconds(TIME_PER_PARTICLE);
        }
    }

    private IEnumerator ResetCoin()
    {
        yield return new WaitForSeconds(TIME_PER_PARTICLE+0.1F);
        hud.ChangeCurrency(true, 0);
    }

    private IEnumerator ResetDiamond()
    {
        yield return new WaitForSeconds(TIME_PER_PARTICLE + 0.1F);
        hud.ChangeCurrency(false, 0);
    }

    private void BuyDiamond()
    {
        GameManager.instance.ChangeCoinAmmount(-100);
        hud.ChangeCurrency(true, -1);
        if (resetCoin != null) StopCoroutine(resetCoin);
        resetCoin = StartCoroutine(ResetCoin());
        GameObject particle = GameObject.Instantiate(particleCoin, particleParent);
        particle.GetComponent<UiParticle>().Init(hud.coinIcon, shop.coinIcon);
        particle = GameObject.Instantiate(particleDiamond, particleParent);
        particle.GetComponent<UiParticle>().Init(shop.diamondIcon, hud.diamondIcon);
        particle.GetComponent<UiParticle>().OnDone.AddListener(IncreaseDiamond);
    }
    private void IncreaseDiamond()
    {
        GameManager.instance.ChangeDiamondAmount(1);
        hud.ChangeCurrency(false, +1);
        if(resetDiamond!=null)StopCoroutine(resetDiamond);
        resetDiamond = StartCoroutine(ResetDiamond());
    }

}
