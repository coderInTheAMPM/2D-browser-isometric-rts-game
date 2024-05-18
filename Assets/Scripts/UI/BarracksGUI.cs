using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PavleM.RDI.RTS
{
    public class BarracksGUI : MonoBehaviour
    {
        public Button recruitButton;

        public Transform recruitSpawnLocation;

        public GameObject troopPrefab;
        public Transform troopsContainer;

        public TextMeshProUGUI currentAmountOfGoldInfo;
        public TextMeshProUGUI currentAmountOfMacesInfo;

        public AudioSource troopBuySound;
        public AudioSource notEnoughResourcesSound;

        // TODO: čitati cenu iz baze podataka ili nešto

        private void Awake()
        {
            recruitButton.onClick.AddListener(TryToRecruit);
        }

        private void TryToRecruit()
        {
            if(PlayerInventory.instance.gold >= 20 && PlayerInventory.instance.maces >= 1)
            {
                troopBuySound.Play();
                PlayerInventory.instance.gold -= 20;
                PlayerInventory.instance.maces -= 1;

                var troop = GameObject.Instantiate(troopPrefab);
                troop.transform.position = recruitSpawnLocation.position;
                troop.transform.SetParent(troopsContainer);
            }
            else
            {
                notEnoughResourcesSound.Play();
            }
        }

        private void FixedUpdate()
        {
            currentAmountOfGoldInfo.text = PlayerInventory.instance.gold.ToString();
            currentAmountOfMacesInfo.text = PlayerInventory.instance.maces.ToString();
        }
    }
}
