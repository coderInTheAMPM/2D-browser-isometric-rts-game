using UnityEngine;

namespace PavleM.RDI.RTS
{
    public class Market : Building
    {
        #region Singleton
        public static Market instance;

        void Awake()
            => instance = this;
        #endregion

        // methods for buying/selling...
    }
}
