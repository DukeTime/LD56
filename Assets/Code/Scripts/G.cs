using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G : MonoBehaviour
{
    public static int money = 0;
    public static int unitCount = 0;
    public static int unitLvl = 0;
    public static int lvl = 0;

    public static GameObject[] objectsOnStage;
    public static GameObject unitPref;

    [SerializeField] private GameObject startUnitPref;

    private void Start()
    {
        unitPref = startUnitPref;
    }
}
