using TMPro;
using UnityEngine;

public class GranaryGUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI foodAmountText;

    private void FixedUpdate()
    {
        foodAmountText.text = PlayerInventory.instance.food.ToString();
    }
}
