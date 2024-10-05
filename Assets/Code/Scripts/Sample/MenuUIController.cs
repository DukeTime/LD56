using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIController : UIController
{
    public void PanelAppear(Image panel)
    {
        if (panel.transform.localScale.x == 0)
            panel.transform.DOScaleX(1, 0.2f)
                .SetEase(Ease.InCubic);
        else
            panel.transform.DOScaleX(0, 0.2f)
                .SetEase(Ease.InCubic);
    }
}
