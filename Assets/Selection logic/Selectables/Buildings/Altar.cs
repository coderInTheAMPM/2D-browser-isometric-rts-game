namespace PavleM.RDI.RTS
{
    public class Altar : Building
    {
        #region Singleton
        public static Altar instance;

        void Awake()
            => instance = this;
        #endregion

        // expose methods for creating Troop prefab
    }
}
