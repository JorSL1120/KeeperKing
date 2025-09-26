using System;
using Dino.UtilityTools.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SettingsUI : UIWindow
{
    #region Popup implementation
    
    #region serialized Fields
    [Header("Popup Settings")]
    [SerializeField] private Button _buttonBack;
    [SerializeField] private Button _buttonCredits;
    [SerializeField] private Button _buttonMenu;
    [SerializeField] private Button _buttonQuit;
    #endregion
    
    public override void Initialize()
    {
        base.Initialize();
        _buttonBack.onClick.AddListener(BackClick);
        _buttonCredits.onClick.AddListener(CreditsClick);
        _buttonMenu.onClick.AddListener(MenuClick);
        _buttonQuit.onClick.AddListener(QuitClick);
    }
    private void BackClick()
    {
        Hide();
        Debug.Log("Back clicked");
    }
    private void CreditsClick()
    {
        UIManager.Instance.ShowUI(WindowsIDs.Credits);
        Debug.Log("Credits Clicked");
    }
    private void MenuClick()
    {
        UIManager.Instance.ShowUI(WindowsIDs.Menu);
        Debug.Log("Menu Clicked");
    }
    private void QuitClick()
    {
        Application.Quit();
        Debug.Log("Quit clicked");
    }
    #endregion
}
