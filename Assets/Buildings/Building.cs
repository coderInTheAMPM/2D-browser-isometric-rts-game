using UnityEngine;

namespace PavleM.SI.PrebivalisteS3
{
    public abstract class Building : MonoBehaviour, Selectable
    {
        private int team = 1;
        public int Team { get => team; set { team = value; } }

        public GameObject hotbarGUI;

        public void OnSelect()
        {
            //GameManager.instance.ShowHotbar();
            hotbarGUI.SetActive(true);
        }

        public void OnDeselect()
        {
            //GameManager.instance.HideHotbar();
            hotbarGUI.SetActive(false);
        }
    }
}
