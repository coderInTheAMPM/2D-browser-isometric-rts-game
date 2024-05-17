using TMPro;
using UnityEngine;

namespace PavleM.RDI.RTS
{
    public class ArmoryGUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI maceAmountText;

        private void FixedUpdate()
        {
            maceAmountText.text = PlayerInventory.instance.maces.ToString();
        }
    }
}
