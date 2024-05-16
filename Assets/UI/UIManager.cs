using UnityEngine;

namespace PavleM.RDI.RTS
{
    public class UIManager : MonoBehaviour
    {
        #region Singleton
        public static UIManager instance;

        void Awake()
            => instance = this;
        #endregion

        public GameObject defaultHotbarGUI;
        private GameObject currentlySelectedBuildingGUI;

        private void Start()
            => defaultHotbarGUI.SetActive(true);

        public void SetHotbarGUI(Building building)
        {
            currentlySelectedBuildingGUI?.SetActive(false); // popravka bug-a za pravilan rad default menija

            defaultHotbarGUI.SetActive(false);
            building.hotbarGUI.SetActive(true);

            currentlySelectedBuildingGUI = building.hotbarGUI;
        }

        public void SetHotbarGUI(GameObject GUI)
        {
            if (GUI == null)
                return;

            currentlySelectedBuildingGUI?.SetActive(false);

            defaultHotbarGUI.SetActive(false);
            GUI.SetActive(true);

            currentlySelectedBuildingGUI = GUI;
        }

        public void UnsetHotbarGUI(Building building)
        {
            building.hotbarGUI.SetActive(false);
            defaultHotbarGUI.SetActive(true);
        }
    }
}
