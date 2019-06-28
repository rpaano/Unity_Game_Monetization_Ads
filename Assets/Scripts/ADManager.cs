using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class ADManager : MonoBehaviour
{

    private string APP_API = "ca-app-pub-2790492244434188~6203386122";

    private BannerView bannerAD;
    private InterstitialAd interstitialAd;
    private RewardBasedVideoAd rewardVideoAd;

    void Start()
    {
        //MobileAds.Initialize(APP_API);
        RequestBanner();
        RequestInterstitial();
        RequestVideoAD();

    }

    // Update is called once per frame
    void RequestBanner()
    {
        string banner_ID = "ca-app-pub-3940256099942544/6300978111";

        bannerAD = new BannerView(banner_ID, AdSize.SmartBanner, AdPosition.Top);

        //AdRequest adRequest = new AdRequest.Builder().Build();

        AdRequest adRequest = new AdRequest.Builder().
            AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        bannerAD.LoadAd(adRequest);
    }

    void RequestInterstitial()
    {
        string interstitial_ID = "ca-app-pub-2790492244434188/2970718124";

        interstitialAd = new InterstitialAd(interstitial_ID);

        //AdRequest adRequest = new AdRequest.Builder().Build();

        AdRequest adRequest = new AdRequest.Builder().
            AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        interstitialAd.LoadAd(adRequest);
    }

    void RequestVideoAD()
    {
        string video_ID = "ca-app-pub-2790492244434188/9217805549";

        rewardVideoAd = RewardBasedVideoAd.Instance;

        //AdRequest adRequest = new AdRequest.Builder().Build();

        AdRequest adRequest = new AdRequest.Builder().
            AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        rewardVideoAd.LoadAd(adRequest, video_ID);
    }

    public void Display_Banner()
    {
        bannerAD.Show();
    }

    public void Diplay_IntertitialAD()
    {
        if (interstitialAd.IsLoaded())
        {
            interstitialAd.Show();
        }
    }

    public void Display_Reward_Video()
    {
        if (rewardVideoAd.IsLoaded())
        {
            rewardVideoAd.Show();
        }
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        //ad is loaded show it
        Display_Banner(); 
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        //ad failed to load load it again
        RequestBanner();
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

    void HandleBannerADEvents(bool subscribe)
    {
        if (subscribe)
        {
            // Called when an ad request has successfully loaded.
            bannerAD.OnAdLoaded += HandleOnAdLoaded;
            // Called when an ad request failed to load.
            bannerAD.OnAdFailedToLoad += HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            bannerAD.OnAdOpening += HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            bannerAD.OnAdClosed += HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            bannerAD.OnAdLeavingApplication += HandleOnAdLeavingApplication;
        }
        else
        {
            // Called when an ad request has successfully loaded.
            bannerAD.OnAdLoaded -= HandleOnAdLoaded;
            // Called when an ad request failed to load.
            bannerAD.OnAdFailedToLoad += HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            bannerAD.OnAdOpening -= HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            bannerAD.OnAdClosed -= HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            bannerAD.OnAdLeavingApplication -= HandleOnAdLeavingApplication;
        }
    }

    void OnEnable()
    {
        HandleBannerADEvents(true);
    }

    void OnDisable()
    {
        HandleBannerADEvents(false);
    }
}
