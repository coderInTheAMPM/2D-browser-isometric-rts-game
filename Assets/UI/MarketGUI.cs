using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PavleM.RDI.RTS
{
    public class MarketGUI : MonoBehaviour
    {
        public Button buyMenuButton;
        public Button sellMenuButton;
        public Button[] backButtons;
        public Button buyMaceButton;
        public Button sellWoodButton;

        public GameObject buyOrSellMenu;
        public GameObject buyMenu;
        public GameObject sellMenu;

        private void Awake()
        {
            buyMenu.SetActive(false);
            sellMenu.SetActive(false);
            buyOrSellMenu.SetActive(true);
            
            buyMenuButton.onClick.AddListener(ShowBuyMenu);
            sellMenuButton.onClick.AddListener(ShowSellMenu);

            foreach(Button backButton in backButtons)
                backButton.onClick.AddListener(GoBack);

            buyMaceButton.onClick.AddListener(TryBuyMace);
            sellWoodButton.onClick.AddListener(TrySellWood);
        }

        private void ShowBuyMenu()
        {
            buyOrSellMenu.SetActive(false);
            buyMenu.SetActive(true);
        }

        private void ShowSellMenu()
        {
            buyOrSellMenu.SetActive(false);
            sellMenu.SetActive(true);
        }

        private void GoBack()
        {
            buyMenu.SetActive(false);
            sellMenu.SetActive(false);
            buyOrSellMenu.SetActive(true);
        }

        private void TryBuyMace()
        {
            if(PlayerInventory.instance.gold > 60)
            {
                PlayerInventory.instance.gold -= 60;
                PlayerInventory.instance.maces++;
            }
        }

        private void TrySellWood()
        {
            if (PlayerInventory.instance.wood > 20)
            {
                PlayerInventory.instance.wood -= 20;
                PlayerInventory.instance.gold += 10;
            }
        }
    }
}
