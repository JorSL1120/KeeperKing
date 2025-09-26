using UnityEngine;
using UnityEngine.UI;

public class LoseUI : UIWindow
{
    #region Game implementation
    
    #region serialized Fields
    [Header("Lose UI")]
    [SerializeField] private Button _buttonMenu;
    [SerializeField] private Button _buttonQuit;
    #endregion
    
    public override void Initialize()
    {
        base.Initialize();
        _buttonMenu.onClick.AddListener(MenuClick);
        _buttonQuit.onClick.AddListener((QuitClick));
    }
    private void MenuClick()
    {
        UIManager.Instance.ShowUI(WindowsIDs.Menu);
        Hide();
        Debug.Log("Menu clicked");
    }
    private void QuitClick()
    {
        Application.Quit();
        Debug.Log("Quit clicked");
    }
    #endregion
}
