using PavleM.SI.PrebivalisteS3;
using UnityEngine;

public class Barracks : Building
{
    #region Singleton
    public static Barracks instance;

    void Awake()
        => instance = this;
    #endregion

    // expose methods for creating Troop prefab
}
