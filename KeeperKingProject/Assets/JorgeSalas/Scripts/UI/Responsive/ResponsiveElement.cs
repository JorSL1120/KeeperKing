using NaughtyAttributes;
using UnityEngine;
using NaughtyAttributes;


public class ResponsiveElement : MonoBehaviour
{
<<<<<<< HEAD
    [Header("Settings")]
    [SerializeField] private RectTransform rectTransform;
 
    [Header("Mobile Anchors")]
    [SerializeField] private Vector2 mobileAnchorMin = new Vector2(0, 0);
    [SerializeField] private Vector2 mobileAnchorMax = new Vector2(0, 0);
    
    [Header("Tablet Anchors")]
    [SerializeField] private Vector2 tabletAnchorMin = new Vector2(0, 0);
    [SerializeField] private Vector2 tabletAnchorMax = new Vector2(0, 0);
    
    ResponsiveManager _responsiveManager;
    
=======

    [Header("Settings")]
    [SerializeField] private RectTransform rectTransform;

    [Header("Mobile Anchors")]
    [SerializeField] private Vector2 mobileAnchorMin = new Vector2(0, 0);
    [SerializeField] private Vector2 mobileAnchorMax = new Vector2(0, 0);

    [Header("Tablet Anchors")]
    [SerializeField] private Vector2 tabletAnchorMin = new Vector2(0, 0);
    [SerializeField] private Vector2 tabletAnchorMax = new Vector2(0, 0);

    ResponsiveManager _responsiveManager;

>>>>>>> cd08fa84f4428953db06be15fc192eb905ccd509
    void Start()
    {
        _responsiveManager = ResponsiveManager.Instance;
        _responsiveManager.OnScreenSizeChanged.AddListener(UpdateAnchors);
<<<<<<< HEAD
        UpdateAnchors();    
    }
    
    
    public void UpdateAnchors()
    {
        if(_responsiveManager == null) return;
        
        if(_responsiveManager.CurrentDeviceType == DeviceType.Mobile)
        {
            SetMobileAnchors();
        }
        else if(_responsiveManager.CurrentDeviceType == DeviceType.Tablet)
        {
            SetTabletAnchors();
        }
    }

    
    private void SetTabletAnchors()
    {
=======
        UpdateAnchors();
    }


    public void UpdateAnchors()
    {
        if (_responsiveManager == null) return;

        if (_responsiveManager.CurrentDeviceType == DeviceType.Mobile)
        {
            SetMobileAnchors();
        }
        else if (_responsiveManager.CurrentDeviceType == DeviceType.Tablet)
        {
            SetTabletAnchors();
        }
    }


    private void SetTabletAnchors()
    {
>>>>>>> cd08fa84f4428953db06be15fc192eb905ccd509
        rectTransform.anchorMin = tabletAnchorMin;
        rectTransform.anchorMax = tabletAnchorMax;
    }

<<<<<<< HEAD
   
=======

>>>>>>> cd08fa84f4428953db06be15fc192eb905ccd509
    private void SetMobileAnchors()
    {
        rectTransform.anchorMin = mobileAnchorMin;
        rectTransform.anchorMax = mobileAnchorMax;
    }

    [Button]
    private void SaveMobileAnchors()
    {
        Vector2 maxAnchors = rectTransform.anchorMax;
        Vector2 minAnchors = rectTransform.anchorMin;
<<<<<<< HEAD
        
        mobileAnchorMax = maxAnchors;
        mobileAnchorMin = minAnchors;
    }
    
=======

        mobileAnchorMax = maxAnchors;
        mobileAnchorMin = minAnchors;
    }

>>>>>>> cd08fa84f4428953db06be15fc192eb905ccd509
    [Button]
    private void SaveTabletAnchors()
    {
        Vector2 maxAnchors = rectTransform.anchorMax;
        Vector2 minAnchors = rectTransform.anchorMin;
<<<<<<< HEAD
        
=======

>>>>>>> cd08fa84f4428953db06be15fc192eb905ccd509
        tabletAnchorMax = maxAnchors;
        tabletAnchorMin = minAnchors;
    }
}
