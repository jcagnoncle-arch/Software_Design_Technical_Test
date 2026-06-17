using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Made by Julien Cagnoncle

public class GameManager : MonoBehaviour
{
	// Reference to the unique instance of this script
	public static GameManager instance = default;

    private int diamondAmmount = 30;
    public int DiamondAmmount => diamondAmmount;

    private int coinAmmount = 1000;
    public int CoinAmmount => coinAmmount;

    private void Awake()
    {
        // Checker of the unicity of the instance
        if (instance == null) instance = this;
        else Destroy(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateCurrencyAmmount();

    }

    //Update the HUD and Shope currency counter
    private void UpdateCurrencyAmmount()
    {
        UiManager.instance.UpdateCurrencyUIAmmount(coinAmmount,diamondAmmount);
    }

    public void ChangeDiamondAmount(int ammount)
    {
        diamondAmmount += ammount;
    }

    public void ChangeCoinAmmount(int ammount)
    {
        coinAmmount += ammount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
}
