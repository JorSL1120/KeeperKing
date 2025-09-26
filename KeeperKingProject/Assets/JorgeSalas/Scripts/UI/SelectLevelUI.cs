using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SelectLevelUI : UIWindow
{
    #region Popup implementation
    
    #region serialized Fields
    [Header("Level UI")]
    [SerializeField] private Button _buttonEasy;
    [SerializeField] private Button _buttonNormal;
    [SerializeField] private Button _buttonHard;
    [SerializeField] private Button _buttonClose;
    #endregion
    
    public override void Initialize()
    {
        base.Initialize();
        _buttonEasy.onClick.AddListener(EasyClick);
        _buttonNormal.onClick.AddListener(NormalClick);
        _buttonHard.onClick.AddListener(HardClick);
        _buttonClose.onClick.AddListener(CloseClick);
    }
    private void EasyClick()
    {
        GameManager.Instance.SetDifficulty(Difficulty.Easy);
        UIManager.Instance.ShowUI(WindowsIDs.Game);
        Hide();
        Debug.Log("Easy clicked");
    }
    private void NormalClick()
    {
        GameManager.Instance.SetDifficulty(Difficulty.Normal);
        UIManager.Instance.ShowUI(WindowsIDs.Game);
        Hide();
        Debug.Log("Normal Clicked");
    }
    private void HardClick()
    {
        GameManager.Instance.SetDifficulty(Difficulty.Hard);
        UIManager.Instance.ShowUI(WindowsIDs.Game);
        Hide();
        Debug.Log("Hard clicked");
    }
    private void CloseClick()
    {
        UIManager.Instance.ShowUI(WindowsIDs.Menu);
        Hide();
        Debug.Log("Close clicked");
    }
    #endregion
}
