using System;
using Dino.UtilityTools.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameUI : UIWindow
{
    #region Game implementation
    
    #region serialized Fields
    [Header("Game UI")]
    [SerializeField] private Button _buttonPause;
    
    [Header("References")]
    [SerializeField] private PopupUI popupUI;
    #endregion
    
    public override void Initialize()
    {
        base.Initialize();
        _buttonPause.onClick.AddListener(PauseClick);
    }
    private void PauseClick()
    {
        popupUI.Show();
        Debug.Log("Pause clicked");
    }
    #endregion
}
