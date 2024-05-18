using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PavleM.RDI.RTS
{
    public class GranaryGUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI foodAmountText;
        [SerializeField] private Slider foodTimerSlider;

        private float timer;

        private void FixedUpdate()
        {
            foodAmountText.text = PlayerInventory.instance.food.ToString();

            timer += Time.fixedDeltaTime;

            if(timer > 5)
            {
                PlayerInventory.instance.food--;
                timer = 0;
            }

            foodTimerSlider.value = 1 - (timer / 5.0f);
        }
    }
}
