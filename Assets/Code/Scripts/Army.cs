using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

public class Army : MonoBehaviour
{
    public List<GameObject> units;
    [SerializeField] private Button spawnButton;
    [SerializeField] private GameUIController gameUIController;
    [SerializeField] public Text moneyCounter;
    [SerializeField] public Text unitCounter;
    [SerializeField] private GameObject startUnitPref;
    public void SpawnUnit()
    {
        if (G.MoneyChange(-G.unitPrice))
        {
            GameUIController.ChangeValue(moneyCounter, G.money);
            GameUIController.ChangeValue(unitCounter, G.unitCount);
            G.unitCount += 1;
            float cyclesCounter = 0;
            while (true)
            {
                Vector2 spawnPos = new Vector2(Random.Range(-3f, 0f), Random.Range(-4f, 0f));
                if (Physics2D.OverlapCircleAll(spawnPos, 1f - cyclesCounter).Length == 0)
                {
                    units.Add(Instantiate(startUnitPref, spawnPos, Quaternion.identity));
                    break;
                }
                cyclesCounter += 0.05f;
            }
            if (G.unitCount == 20)
                Debug.Log(G.unitCount);
                spawnButton.enabled = false;
                GameUIController.RedBlinking(unitCounter.gameObject);
        }
        else
            GameUIController.RedBlinking(moneyCounter.gameObject);
            
    }
    public void UnitDeath()
    {
        spawnButton.enabled = true;
    }
}
