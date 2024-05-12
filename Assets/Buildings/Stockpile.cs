using PavleM.SI.PrebivalisteS3;
using UnityEngine;

public class Stockpile : Building
{
    #region Singleton
    public static Stockpile instance;

    void Awake()
        => instance = this;
    #endregion

    public int wood = 10;
}
