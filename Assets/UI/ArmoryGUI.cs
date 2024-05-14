using TMPro;
using UnityEngine;

public class ArmoryGUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI maceAmountText;

    private void FixedUpdate()
    {
        maceAmountText.text = PlayerInventory.instance.maces.ToString();
    }
}
