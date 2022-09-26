using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateBtn : MonoBehaviour
{
    [SerializeField]
    GameObject buttonPrefab;
    [SerializeField]
    GameObject buttonParent;
    [SerializeField]
    LevelSetUpScriptableObject[] LevelSetUpSO;


    public static event Action<ChangeableScriptableObjects> onChangeableAction;
    private void OnEnable()
    {
        EventHandler.Instance.OnLoadLevelAction += GenerateUIButtons;
    }

    private void OnDisable()
    {
        EventHandler.Instance.OnLoadLevelAction -= GenerateUIButtons;
    }

    void GenerateUIButtons(int levelId)
    {
        print("GenerateButtons & Level id is" + levelId);
        if (levelId <= LevelSetUpSO.Length)
        {
            int i = levelId - 1;
            float width = Screen.safeArea.size.x;
            float height = Screen.safeArea.size.y;

            #region
            float buttonWidth = width / LevelSetUpSO[i].WidthDivide; // Change this hardcore number 7f if your
                                                                     // button is not in aspect ratio aplicable
                                                                     // for height as well below

            float buttonHeight = height / LevelSetUpSO[i].HeighDivide;
            #endregion

            //preserve aspect ratio of button's Image component

            Button[] btn = buttonParent.transform.GetComponentsInChildren<Button>();
            for (int k = 0; k < btn.Length; k++)
            {
                print("bttonArray Lenght" + btn.Length);
                Destroy(btn[k].gameObject);
            }
                for (int j = 0; j < LevelSetUpSO[i].ChangeableSO.Length; j++)
                {
                    int id = j + 1;
                    GameObject newButton = Instantiate(buttonPrefab, buttonParent.transform);

                

                    newButton.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, buttonHeight);
                    newButton.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, buttonWidth);
                    newButton.GetComponent<Image>().preserveAspect = true;

                    newButton.GetComponent<Image>().sprite = LevelSetUpSO[i].ChangeableSO[j].ButtonSprite;
                    newButton.GetComponent<Button>().onClick.AddListener(() =>
                    ChangeableButtonClick(LevelSetUpSO[i].ChangeableSO[id - 1]));
                }           
        }
    }

    private void ChangeableButtonClick(ChangeableScriptableObjects changeableScriptableObjects)
    {
        EventHandler.Instance.InvokeOnChangeableAction(changeableScriptableObjects);
        EventHandler.Instance.InvokeOnButtonClickSound();
    } 
}
