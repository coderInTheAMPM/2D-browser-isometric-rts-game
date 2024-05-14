using UnityEngine;

namespace PavleM.RDI.RTS
{
    public class Stockpile : Building
    {
        #region Singleton
        public static Stockpile instance;

        void Awake()
            => instance = this;
        #endregion

        public int wood = 10;
    }
}
