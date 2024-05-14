using PavleM.SI.PrebivalisteS3;
using System.Collections.Generic;
using UnityEngine;

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
}
