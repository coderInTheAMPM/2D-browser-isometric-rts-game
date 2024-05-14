using PavleM.SI.PrebivalisteS3;
using System.Collections;
using UnityEngine;

public class Granary : Building
{
    #region Singleton
    public static Granary instance;

    void Awake()
        => instance = this;
    #endregion

    private void Start()
        => StartCoroutine(FoodLowering());

    private IEnumerator FoodLowering()
    {
        while(true)
        {
            yield return new WaitForSeconds(3);
            PlayerInventory.instance.food--;
        }
    }
}
