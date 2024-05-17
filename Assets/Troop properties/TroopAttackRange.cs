using UnityEngine;
using UnityEngine.AI;

namespace PavleM.RDI.RTS
{
    public class TroopAttackRange : MonoBehaviour
    {
        public GameObject angryGif;
        public Transform target;
        public Troop targetInfo;
        public Troop thisTroopComponent;

        private float timer = 0;

        public AudioSource swingingSounds;

        private void Start()
        {
            target = null;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Troop>(out Troop otherTroop))
            {
                if (otherTroop.Team != thisTroopComponent.Team)
                {
                    target = otherTroop.transform;
                    targetInfo = otherTroop;

                    thisTroopComponent.isFighting = true;
                    swingingSounds.Play();
                }
            }
        }

        private void Update()
        {
            if (target == null)
            {
                angryGif.SetActive(false);
                thisTroopComponent.isFighting = false;
                swingingSounds.Stop();
                return;
            }

            if(target != null)
            {
                angryGif.SetActive(true);

                timer += Time.deltaTime;

                if (timer > 2)
                {
                    timer = 0;

                    if (!thisTroopComponent.isSpecialTroop && targetInfo.isSpecialTroop)
                        return;
                    // Specijalnim trupama mogu raditi damage samo druge specijalne trupe

                    targetInfo.health -= 5;
                    
                    if(targetInfo.health <= 0)
                    {
                        swingingSounds.Stop();
                        thisTroopComponent.deathSound.Play(); // nema smisla al nek bude da radi
                    }
                }
            }
        }
    }
}
