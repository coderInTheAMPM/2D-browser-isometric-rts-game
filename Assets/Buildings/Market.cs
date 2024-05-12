using PavleM.SI.PrebivalisteS3;
using UnityEngine;

public class Market : Building
{
    #region Singleton
    public static Market instance;

    void Awake()
        => instance = this;
    #endregion

    // methods for buying/selling...
}
