using System;
using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;

public class AdsManager : GenericSingleton<AdsManager>
{
    private BannerView bannerView;

    private InterstitialAd interstitial;

    AdRequest request;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

        List<String> ls = new List<string>();
        ls.Add("b6b9183982cd4a1d393765dce40e5e4f");
        ls.Add("1a40a587cea7b065917608300cae6e0b");

        RequestConfiguration requestConfiguration = new RequestConfiguration.Builder()
        .SetTagForChildDirectedTreatment(TagForChildDirectedTreatment.True)
        .SetTestDeviceIds(ls)
        .build();
        MobileAds.SetRequestConfiguration(requestConfiguration);
        


       // this.RequestBanner();
        this.RequestInterstitial();
    }

    //Subscribe to
    public void OnEnable()
    {
        EventHandler.Instance.OnShowInterstitialAd += GameOver;
    }
    

    private void OnDestroy()
    {
//        bannerView.Destroy();
    }

    private void RequestBanner()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-8179797674906935/9544807207";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-8179797674906935/2432603949";
#else
            string adUnitId = "unexpected_platform";
#endif
        AdSize adaptiveSize =
                AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);
        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, adaptiveSize, AdPosition.Bottom);
        //print("Banner Size "+bannerView.GetWidthInPixels() + " x " + bannerView.GetHeightInPixels());
        print("Banner Size " + adaptiveSize.Width + " x " + adaptiveSize.Height);


        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }


    public void RequestInterstitial()
    {
        
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-8179797674906935/6918643865";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-8179797674906935/4867195592";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);

        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        

        // Create an empty ad request.
         request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }


    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
        
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.LoadAdError);
        this.interstitial.LoadAd(request);
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
        this.interstitial.LoadAd(request);
    }

    private void GameOver()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }

}

/*
 iOS
App id -
ca-app-pub-8179797674906935~5309214571
Banner - ca-app-pub-8179797674906935/2432603949
Interstitial - ca-app-pub-8179797674906935/4867195592

Android
App id - ca-app-pub-8179797674906935~9660357271
Banner - ca-app-pub-8179797674906935/9544807207
Interstitial - ca-app-pub-8179797674906935/6918643865
*/

