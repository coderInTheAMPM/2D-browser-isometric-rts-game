using UnityEngine;

namespace PavleM.RDI.RTS
{
    public class PlayerInventory : MonoBehaviour
    {
        #region Singleton
        public static PlayerInventory instance;

        void Awake()
            => instance = this;
        #endregion

        public int gold;

        public int food;

        public int maces;

        public int wood;

        private int cheatAmount = 0;
        public AudioSource goldAudio;
        public AudioSource surpriseAudio;
        public GameObject surpriseEnemies;
        public void IncreaseGold(int amount)
        {
            cheatAmount++;

            if(cheatAmount < 5)
            {
                goldAudio.Play();
                gold += amount;
            }
            else if(cheatAmount == 5)
            {
                surpriseEnemies.SetActive(true);
                surpriseAudio.Play();
            }
            // >5 -> nista
        }
    }
}
