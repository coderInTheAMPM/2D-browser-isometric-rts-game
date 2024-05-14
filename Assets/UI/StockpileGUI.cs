using TMPro;
using UnityEngine;

public class StockpileGUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI woodAmountText;

    private void FixedUpdate()
    {
        woodAmountText.text = PlayerInventory.instance.wood.ToString();
    }
}
