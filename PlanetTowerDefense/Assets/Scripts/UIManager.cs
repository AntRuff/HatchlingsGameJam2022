using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Image loseScreen;
    [SerializeField]
    private Image winScreen;

    public void enableLossUI()
    {
        loseScreen.enabled = false;
    }

    public void enableWinUI()
    {
        
    }
}
