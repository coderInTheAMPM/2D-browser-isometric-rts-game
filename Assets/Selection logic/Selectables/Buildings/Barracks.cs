namespace PavleM.RDI.RTS
{
    public class Barracks : Building
    {
        #region Singleton
        public static Barracks instance;

        void Awake()
            => instance = this;
        #endregion

        // expose methods for creating Troop prefab
    }
}
