using UnityEngine;
using UnityEngine.UI;

namespace PavleM.RDI.RTS
{
    public class P2WSpawner : MonoBehaviour
    {
        public Transform recruitSpawnLocation;

        public GameObject specialTroopPrefab;
        public Transform troopsContainer;

        public AudioSource troopBuySound;

        public void RecruitSpecialTroop()
        {
            troopBuySound.Play();
            // Resursi se skidaju sa web naloga, ne u igrici

            var troop = GameObject.Instantiate(specialTroopPrefab);
            troop.transform.position = recruitSpawnLocation.position;
            troop.transform.SetParent(troopsContainer);
        }
    }
}
