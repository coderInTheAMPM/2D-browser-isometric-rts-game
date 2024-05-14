using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Diagnostics;

namespace PavleM.SI.PrebivalisteS3
{
    public class HealthBar : MonoBehaviour
    {
        /*private GameObject healthBarInstance;
        public Transform healthBarContainer;

        public bool IsVisible
            => (healthBarInstance.activeInHierarchy);

        private float offsetFromTroop = 4; // Kolko je pomeren na gore u odnosu na poziciju trupe

        *//*static HealthBar() // možda staviti ovo kao non monobeh kao i druge propertye
         *                   // da bi mogo static constructor, injectujem transform playera
         *                   // i pozivam health bar update unutar playera
        {
            healthBarContainer = GameObject.Find("Health bar container").transform;
        }*//*

        private void Awake()
        {
            // Idealno ovaj izraz ne bi bio pozvan pri svakoj kreaciji health bara, ali mi ne dozvoljava da pozovem .Find funkciju unutar statičnog GameObject konstruktora
            // Srećom nije toliko skup poziv
            healthBarContainer = GameObject.Find("Health bar container").transform;
            // TODO: Možda se može cela ova skripta pretvoriti u non-monobehaviour?

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
        }

        private void UpdatePosition()
            => healthBarInstance.transform.position = CameraSelection.playerCamera.WorldToScreenPoint(transform.position + Vector3.up * offsetFromTroop);

        public void Show()
        {
            UpdatePosition();
            healthBarInstance.SetActive(true);
        }

        public void Hide()
            => healthBarInstance.SetActive(false);
    */
    }
}
