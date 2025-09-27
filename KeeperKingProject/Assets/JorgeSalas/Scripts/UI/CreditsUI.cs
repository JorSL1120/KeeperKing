using UnityEngine;
using UnityEngine.UI;

public class CreditsUI : UIWindow
{
    #region Game implementation
    
    #region serialized Fields
    [Header("Credits UI")]
    [SerializeField] private Button _buttonClose;
    #endregion

    public int creditBack = 0;
    
    public override void Initialize()
    {
        base.Initialize();
        _buttonClose.onClick.AddListener(CloseClick);
    }
    private void CloseClick()
    {
        if (creditBack == 1)
        {
            UIManager.Instance.ShowUI(WindowsIDs.Menu);
            creditBack = 0;
        }
        else if (creditBack == 2)
        {
            UIManager.Instance.ShowUI(WindowsIDs.Settings);
            creditBack = 0;
        }
        Hide();
        Debug.Log("Close clicked");
    }
    #endregion
}
