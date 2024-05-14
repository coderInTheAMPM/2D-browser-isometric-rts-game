using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PavleM.RDI.RTS
{
    public class BarracksGUI : MonoBehaviour
    {
        public Button recruitButton;

        public Transform recruitSpawnLocation;

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
                Debug.Log("Recruited troop");
            }
            else
            {
                Debug.Log("Can't recruit");
            }
        }
    }
}
