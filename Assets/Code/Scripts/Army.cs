using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

public class Army : MonoBehaviour
{
    [SerializeField] private Button spawnButton;
    public void SpawnUnit()
    {
        float cyclesCounter = 0;
        while (true)
        {
            Vector2 spawnPos = new Vector2(Random.Range(-3f, 0f), Random.Range(-4f, 0f));
            if (Physics2D.OverlapCircleAll(spawnPos, 1f - cyclesCounter).Length == 0)
            {
                Instantiate(G.unitPref, spawnPos, Quaternion.identity);
                G.unitCount += 1;
                break;
            }
            cyclesCounter += 0.05f;
        }
        if (G.unitCount == 20)
            spawnButton.enabled = false;
            
    }
    public void UnitDeath()
    {
        spawnButton.enabled = true;
    }
}
