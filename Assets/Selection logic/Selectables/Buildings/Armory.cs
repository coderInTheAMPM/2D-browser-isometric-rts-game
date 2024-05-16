namespace PavleM.RDI.RTS
{
    public class Armory : Building
    {
        #region Singleton
        public static Armory instance;

        void Awake()
            => instance = this;
        #endregion

        public int maces = 10;
    }
}
