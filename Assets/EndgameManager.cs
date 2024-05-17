using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PavleM.RDI.RTS
{
    public class EndgameManager : MonoBehaviour
    {
        public Button secretButton;
        public GameObject secretBuyMenu;
        public GameObject[] otherMarketMenus;

        public GameObject beholder;

        public Button secretBuyButton;
        public TextMeshProUGUI price;
        public Image secretImage;
        public Sprite under500Image;
        public Sprite over500Image;
        public Sprite over1000Image;

        public AudioSource noGoldSound;

        public TextMeshProUGUI currentAmountOfGoldTxt;

        public Button backButton;

        private void Start()
        {
            secretButton.onClick.AddListener(ShowSecretBuyMenu);
            secretButton.gameObject.SetActive(false);

            secretBuyButton.onClick.AddListener(CantBuySound);

            backButton.onClick.AddListener(HideSecretMenu);
        }

        private void ShowSecretBuyMenu()
        {
            foreach (var menu in otherMarketMenus)
                menu.SetActive(false);
            secretBuyMenu.SetActive(true);
        }

        private void Update()
        {
            if (beholder == null)
                secretButton.gameObject.SetActive(true);

            if (PlayerInventory.instance.gold < 500)
            {
                price.text = "500";
                secretImage.sprite = under500Image;
            }
            else if (PlayerInventory.instance.gold < 1000)
            {
                price.text = "1000";
                secretImage.sprite = over500Image;
            }
            else
            {
                price.text = "999999999";
                secretImage.sprite = over1000Image;
            }

            currentAmountOfGoldTxt.text = PlayerInventory.instance.gold.ToString();
        }

        private void CantBuySound()
            => noGoldSound.Play();

        private void HideSecretMenu()
            => secretBuyMenu.SetActive(false);
    }
}
