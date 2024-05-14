using TMPro;
using UnityEngine;

namespace PavleM.RDI.RTS
{
    public class StockpileGUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI woodAmountText;

        private void FixedUpdate()
        {
            woodAmountText.text = PlayerInventory.instance.wood.ToString();
        }
    }
}
