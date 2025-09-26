using UnityEngine;
using UnityEngine.UI;

public class CreditsUI : UIWindow
{
    #region Game implementation
    
    #region serialized Fields
    [Header("Credits UI")]
    [SerializeField] private Button _buttonClose;
    #endregion
    
    public override void Initialize()
    {
        base.Initialize();
        _buttonClose.onClick.AddListener(CloseClick);
    }
    private void CloseClick()
    {
        UIManager.Instance.ShowUI(WindowsIDs.Menu);
        Hide();
        Debug.Log("Close clicked");
    }
    #endregion
}
