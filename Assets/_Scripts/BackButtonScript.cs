using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButtonScript : MonoBehaviour
{
    [SerializeField]
    Button btnBackPrefab;
    // Start is called before the first frame update
    void Start()
    {
        btnBackPrefab.onClick.AddListener(UnHideGameObject);
        btnBackPrefab.onClick.AddListener(UIManager.Instance.ShowInterestratialAd);
    }

    public void UnHideGameObject()
    {
        Debug.Log("UnHide Game Object Method");
        EventHandler.Instance.InvokeOnBack();    
        EventHandler.Instance.InvokeOnButtonClickSound();    
    }
}
