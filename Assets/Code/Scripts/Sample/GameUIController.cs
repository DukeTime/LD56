using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class GameUIController : UIController
{
    [SerializeField] Image pauseIm;
    public void GamePause()
    {
        if (pauseIm != null)
        {

        }
    }

    public static void ChangeValue(Text counter, int val, bool punch = true)
    {
        counter.text = val.ToString();
        if (counter.transform.localScale == Vector3.one)
            counter.transform.DOPunchScale(counter.transform.localScale, 0.1f);
    } 

    public static void RedBlinking(GameObject obj, float duration = 0.25f)
    {
        if (obj.GetComponent<Text>() != null)
        {
            obj.GetComponent<Text>().DOColor(Color.red, duration)
                .OnComplete(() => obj.GetComponent<Text>().DOColor(Color.white, duration));
        }
        else if (obj.GetComponent<SpriteRenderer>() != null)
        {
            obj.GetComponent<SpriteRenderer>().DOColor(Color.red, duration)
                .OnComplete(() => obj.GetComponent<SpriteRenderer>().DOColor(Color.white, duration));
        }
    }
}
