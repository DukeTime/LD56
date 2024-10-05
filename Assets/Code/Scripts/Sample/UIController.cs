using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Image blackoutIm;

    private void Start()
    {
        if (blackoutIm != null)
        {
            blackoutIm.color = Color.black;
            blackoutIm.DOFade(0, 0.5f);
        }
    }

    public void ChangeScene(int sceneNum)
    {
        if (blackoutIm != null)
        {
            blackoutIm.DOFade(1, 0.5f)
                .OnKill(() => SceneManager.LoadScene(sceneNum));
        }
        else
            SceneManager.LoadScene(sceneNum);
    }

    public void GameQuit()
    {
        Application.Quit();
    }
}
