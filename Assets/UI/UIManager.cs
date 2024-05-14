using PavleM.SI.PrebivalisteS3;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Singleton
    public static UIManager instance;

    void Awake()
        => instance = this;
    #endregion

    public GameObject defaultHotbarGUI;

    private void Start()
    {
        defaultHotbarGUI.SetActive(true);
    }

    public void SetHotbarGUI(Building building)
    {
        defaultHotbarGUI.SetActive(false);
        building.hotbarGUI.SetActive(true);
    }

    public void UnsetHotbarGUI(Building building)
    {
        building.hotbarGUI.SetActive(false);
        defaultHotbarGUI.SetActive(true);
    }
}
