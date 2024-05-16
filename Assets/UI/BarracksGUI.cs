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

        // TODO: čitati cenu iz baze podataka ili nešto

        private void Awake()
        {
            recruitButton.onClick.AddListener(TryToRecruit);
        }

        private void TryToRecruit()
        {
            if(PlayerInventory.instance.gold >= 20 && PlayerInventory.instance.maces >= 1)
            {
                PlayerInventory.instance.gold -= 20;
                PlayerInventory.instance.maces -= 1;

                var troop = GameObject.Instantiate(troopPrefab);
                troop.transform.position = recruitSpawnLocation.position;
                troop.transform.SetParent(troopsContainer);
            }
            else
            {
                Debug.Log("Can't recruit"); // dodaj audio
            }
        }
    }
}
