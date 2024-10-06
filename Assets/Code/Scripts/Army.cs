using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

public class Army : MonoBehaviour
{
    public static List<GameObject> units;
    [SerializeField] private Button spawnButton;
    [SerializeField] private GameUIController gameUIController;
    [SerializeField] public Text moneyCounter;
    [SerializeField] public Text unitCounter;
    public void SpawnUnit()
    {
        if (G.MoneyChange(-G.unitPrice))
        {
            float cyclesCounter = 0;
            while (true)
            {
                Vector2 spawnPos = new Vector2(Random.Range(-3f, 0f), Random.Range(-4f, 0f));
                if (Physics2D.OverlapCircleAll(spawnPos, 1f - cyclesCounter).Length == 0)
                {
                    units.Add(Instantiate(G.unitPref, spawnPos, Quaternion.identity));
                    G.unitCount += 1;
                    GameUIController.ChangeValue(moneyCounter, G.money);
                    GameUIController.ChangeValue(unitCounter, G.unitCount);
                    break;
                }
                cyclesCounter += 0.05f;
            }
            if (G.unitCount == 20)
                spawnButton.enabled = false;
        }
        GameUIController.RedBlinking(moneyCounter.gameObject);
            
    }
    public void UnitDeath()
    {
        spawnButton.enabled = true;
    }
}
