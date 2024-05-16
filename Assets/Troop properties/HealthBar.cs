using UnityEngine;
using UnityEngine.UI;

namespace PavleM.RDI.RTS
{
    public class HealthBar : MonoBehaviour
    {
        private GameObject healthBarInstance;
        public Transform healthBarContainer;

        public bool IsVisible
            => (healthBarInstance.activeInHierarchy);

        [SerializeField] private float offsetFromTroop = 0.7f; // Kolko je pomeren na gore u odnosu na poziciju trupe

        /*static HealthBar() ne moze sa monobehaviour jbg
        {
            healthBarContainer = GameObject.Find("Health bar container").transform;
        }*/
        // TODO: Možda se može cela ova skripta pretvoriti u non-monobehaviour?

        private void Awake()
        {
            healthBarContainer = GameObject.Find("Health bars container").transform;
            
            GameObject healthBarPrefab = Resources.Load("Health bar prefab") as GameObject;
            healthBarInstance = GameObject.Instantiate(healthBarPrefab);
            healthBarInstance.transform.SetParent(healthBarContainer);
            healthBarInstance.SetActive(false);
        }

        private void FixedUpdate()
        {
            if (!IsVisible)
                return;

            UpdatePosition();
            UpdateGFX();
        }

        private void UpdatePosition()
            => healthBarInstance.transform.position = CameraSelection.playerCamera.WorldToScreenPoint(transform.position + Vector3.up * offsetFromTroop);

        private void UpdateGFX()
        {
            healthBarInstance.GetComponent<Slider>().value = GetComponent<Troop>().health / 100f;
        }

        public void Show()
        {
            UpdatePosition();
            healthBarInstance.SetActive(true);
        }

        public void Hide()
            => healthBarInstance.SetActive(false);
    }
}
