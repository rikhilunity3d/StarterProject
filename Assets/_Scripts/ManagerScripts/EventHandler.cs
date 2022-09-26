using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventHandler : GenericSingleton<EventHandler>
{
    public event Action OnNextScene;
    public event Action OnBack;

    public event Action OnRateApp;
    public event Action OnRestoreApp;
    public event Action OnMoreApps;
    public event Action OnShareApp;

    public event Action<Sounds> OnButtonClickSound;
    public event Action<Sounds> OnPlayBackGroundSound;
    public event Action OnMuteSound;

    public  event Action<int> OnLoadLevelAction;

    ChangeableScriptableObjects changeableSO;
    public  event Action<ChangeableScriptableObjects> onChangeableAction;

    #region
    public  event Action OnShowInterstitialAd;
    #endregion

    

    public void InvokeOnNextScene() => OnNextScene?.Invoke();
    public void InvokeOnBack() => OnBack?.Invoke();
    public void InvokeOnButtonClickSound() => OnButtonClickSound?.Invoke(Sounds.ButtonClick);
    public void InvokeOnPlayBackGroundSound() => OnPlayBackGroundSound?.Invoke(Sounds.BgMusic);
    public void InvokeOnShowInterstitialAd() => OnShowInterstitialAd?.Invoke();

    public void InvokeOnMuteSound()
    {
        OnMuteSound?.Invoke();
    }

    public void InvokeOnLoadLevel(int id)=>OnLoadLevelAction?.Invoke(id);

    public void InvokeOnChangeableAction(ChangeableScriptableObjects changeableScriptableObjects)
        =>onChangeableAction?.Invoke(changeableScriptableObjects);

    public void InvokeOnRateApp()=> OnRateApp?.Invoke();
    public void InvokeOnRestoreApp() => OnRestoreApp?.Invoke();
    public void InvokeOnMoreApps() => OnMoreApps?.Invoke();
    public void InvokeOnShareApp() => OnShareApp?.Invoke();
}
