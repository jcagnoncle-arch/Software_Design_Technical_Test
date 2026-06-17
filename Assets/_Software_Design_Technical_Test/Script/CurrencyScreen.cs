using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyScreen : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI coinAmmount = default;
    [SerializeField] protected TextMeshProUGUI diamondAmmount = default;
    [SerializeField] public Transform diamondIcon = default;
    [SerializeField] public Transform coinIcon = default;
}
