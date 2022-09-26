using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChangeableScriptableObjects", menuName = "ChangeableScriptableObjects", order = 0)]
public class ChangeableScriptableObjects : ScriptableObject 
{
    [SerializeField]
    int itemId;
    [SerializeField]
    int counter=0;
    [SerializeField]
    string itemName;
    [SerializeField]
    Sprite buttonSprite;
    [SerializeField]
    Sprite [] itemArray;
    [SerializeField]
    GameObject[] transformArray;

    //Getters are here of above variables
    #region
    public int ItemId { get => itemId;}
    public int Counter { get => counter; set => counter = value; }
    public string ItemName { get => itemName;}
    
    public Sprite ButtonSprite { get => buttonSprite; }
    public Sprite[] ItemArray { get => itemArray; set => itemArray = value; }
    public GameObject[] TransformArray { get => transformArray; set => transformArray = value; }
    #endregion
}
