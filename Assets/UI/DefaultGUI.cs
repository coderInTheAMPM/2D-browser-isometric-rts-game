using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PavleM.RDI.RTS
{
    public class DefaultGUI : MonoBehaviour
    {
        #region Singleton
        public static DefaultGUI instance;

        void Start()
            => instance = this;
        #endregion

        public Button checkStockpileButton;
        public Button recruitTroopsButton;
        public Button inspectFoodButton;

        private void Awake()
        {
            checkStockpileButton.onClick.AddListener(CheckStockpile);
            recruitTroopsButton.onClick.AddListener(OpenRecruitMenu);
            inspectFoodButton.onClick.AddListener(InspectFood);
        }

        private void CheckStockpile()
        {
            UIManager.instance.SetHotbarGUI(Stockpile.instance);
        }

        private void OpenRecruitMenu()
        {
            UIManager.instance.SetHotbarGUI(Barracks.instance);
        }

        private void InspectFood()
        {
            UIManager.instance.SetHotbarGUI(Granary.instance);
        }
    }
}
