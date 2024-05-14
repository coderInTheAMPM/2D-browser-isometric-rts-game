using UnityEngine;

namespace PavleM.RDI.RTS
{
    public abstract class Building : MonoBehaviour, Selectable
    {
        private int team = 1;
        public int Team { get => team; set { team = value; } }

        public GameObject hotbarGUI;

        public void OnSelect()
        {
            UIManager.instance.SetHotbarGUI(this);
            //hotbarGUI.SetActive(true);
        }

        public void OnDeselect()
        {
            UIManager.instance.UnsetHotbarGUI(this);
            //hotbarGUI.SetActive(false);
        }
    }
}
