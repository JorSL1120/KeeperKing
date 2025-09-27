using UnityEngine;
using UnityEngine.UI;

public class MenuUI : UIWindow
{
    #region Popup implementation
    
    #region serialized Fields
    [Header("Menu UI")]
    [SerializeField] private Button _buttonStart;
    [SerializeField] private Button _buttonCredits;
    [SerializeField] private Button _buttonQuit;
    [SerializeField] private CreditsUI _creditsUI;
    #endregion
    
    public override void Initialize()
    {
        //base.Initialize();
        _buttonStart.onClick.AddListener(StartClick);
        _buttonCredits.onClick.AddListener(CreditsClick);
        _buttonQuit.onClick.AddListener(QuitClick);
    }
    private void StartClick()
    {
        UIManager.Instance.ShowUI(WindowsIDs.Level);
        Hide();
        Debug.Log("Start clicked");
    }
    private void CreditsClick()
    {
        UIManager.Instance.ShowUI(WindowsIDs.Credits);
        _creditsUI.creditBack = 1;
        Hide();
        Debug.Log("Credits Clicked");
    }
    private void QuitClick()
    {
        Application.Quit();
        Debug.Log("Quit clicked");
    }

    #endregion
}
