using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButtonScript : MonoBehaviour
{
    [SerializeField]
    Button btnMutePrefab;

    // Start is called before the first frame update
    void Start()
    {
        btnMutePrefab.onClick.AddListener(MuteButtonClick);  
    }

    public void MuteButtonClick()
    {
        EventHandler.Instance.InvokeOnMuteSound();
    }
}
