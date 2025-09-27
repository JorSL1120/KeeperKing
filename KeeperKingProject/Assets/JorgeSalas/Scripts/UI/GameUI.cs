using System;
using System.Collections.Generic;
using Dino.UtilityTools.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using NaughtyAttributes;

public class GameUI : UIWindow
{
    #region Game implementation
    
    #region serialized Fields
    [Header("Game UI")]
    [SerializeField] private Button _buttonPause;
    
    [Header("Difficulty")]
    [SerializeField] private GameObject easyImage;
    [SerializeField] private GameObject normalImage;
    [SerializeField] private GameObject hardImage;
    #endregion
    
    public override void Initialize()
    {
        base.Initialize();
        _buttonPause.onClick.AddListener(PauseClick);
        ShowDifficulty();
    }
    public override void Show(bool instant = false)
    {
        base.Show(instant);
        ShowDifficulty();
    }
    private void PauseClick()
    {
        UIManager.Instance.ShowUI(WindowsIDs.Settings);
        Debug.Log("Pause clicked");
    }
    private void ShowDifficulty()
    {
        easyImage.SetActive(GameManager.Instance.SelectedDifficulty == Difficulty.Easy);
        normalImage.SetActive(GameManager.Instance.SelectedDifficulty == Difficulty.Normal);
        hardImage.SetActive(GameManager.Instance.SelectedDifficulty == Difficulty.Hard);
    }


    [Button]
    public void ToCanvasWin()
    {
        UIManager.Instance.ShowUI(WindowsIDs.Win);
        Hide();
    }
    [Button]
    public void ToCanvasLose()
    {
        UIManager.Instance.ShowUI(WindowsIDs.Lose);
        Hide();
    }
    #endregion
}
