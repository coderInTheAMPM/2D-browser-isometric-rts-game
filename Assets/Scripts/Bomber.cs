using System.Linq;
using UnityEngine;

namespace PavleM.RDI.RTS
{
    public class Bomber : MonoBehaviour
    {
        private bool isBombed = false;

        public GameObject[] aliveWoodcutters;
        public GameObject aliveFarmer;
        public GameObject[] deadWoodcutters;
        public GameObject deadFarmer;

        public GameObject standardBuildings;
        public GameObject destoryedBuildings;

        public GameObject[] explosionGifs;

        public AudioSource explosionSound;
        public GameObject defaultGUIbuttons;

        private void Start()
        {
            foreach (var woodcutter in deadWoodcutters)
                woodcutter.SetActive(false);
            deadFarmer.SetActive(false);

            destoryedBuildings.SetActive(false);
        }

        public void Bomb()
        {
            if (isBombed)
                return;

            for(int i = 0; i < aliveWoodcutters.Count(); i++)
            {
                deadWoodcutters[i].transform.position = aliveWoodcutters[i].transform.position;
                aliveWoodcutters[i].SetActive(false);
                deadWoodcutters[i].SetActive(true);
            }
            deadFarmer.transform.position = aliveFarmer.transform.position;
            aliveFarmer.SetActive(false);
            deadFarmer.SetActive(true);

            standardBuildings.SetActive(false);
            destoryedBuildings.SetActive(true);

            foreach(var explosion in explosionGifs)
            {
                explosion.SetActive(true);
                Destroy(explosion, 1.5f);
            }

            explosionSound.Play();
            defaultGUIbuttons.SetActive(false);

            isBombed = true;
        }
    }
}
