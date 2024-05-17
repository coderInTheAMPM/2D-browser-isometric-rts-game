using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PavleM.RDI.RTS
{
    public class AltarGUI : MonoBehaviour
    {
        public Button recruitButton;
        public Transform recruitSpawnLocation;

        public GameObject specialTroopPrefab;
        public Transform troopsContainer;

        public TextMeshProUGUI currentAmountOfGoldInfo;

        public AudioSource specialTroopBuySound;
        public AudioSource notEnoughGoldSound;

        private void Awake()
        {
            recruitButton.onClick.AddListener(TryToRecruit);
        }

        private void TryToRecruit()
        {
            if(PlayerInventory.instance.gold >= 100)
            {
                specialTroopBuySound.Play();
                PlayerInventory.instance.gold -= 100;

                var specialTroop = GameObject.Instantiate(specialTroopPrefab);
                specialTroop.transform.position = recruitSpawnLocation.position;
                specialTroop.transform.SetParent(troopsContainer);
            }
            else
            {
                notEnoughGoldSound.Play();
            }
        }

        private void Update()
        {
            currentAmountOfGoldInfo.text = PlayerInventory.instance.gold.ToString();
        }
    }
}
