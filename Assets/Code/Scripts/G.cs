using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class G : MonoBehaviour
{
    public static int money = 100;
    public static int unitCount = 0;
    public static int unitLvl = 0;
    public static int lvl = 0;

    public static int unitPrice = 10;

    public static GameObject[] objectsOnStage;
    public static GameObject unitPref;

    [SerializeField] private GameObject startUnitPref;

    public static G Instance { get; private set; }

    private void Awake()
    {
        money = 100;
        unitCount = 0;
        unitLvl = 1;
        lvl = 1;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        unitPref = startUnitPref;
    }

    public static bool MoneyChange(int val)
    {
        if (money + val >= 0)
        {
            money += val;
            return true;
        }
        return false;
    }
}
