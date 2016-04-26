using UnityEngine;

public class AdBuddizExample : MonoBehaviour {
	
	void Start() // Init SDK on app start
	{ 
		AdBuddizBinding.SetLogLevel(AdBuddizBinding.ABLogLevel.Info);         // log level
		AdBuddizBinding.SetAndroidPublisherKey("TEST_PUBLISHER_KEY_ANDROID"); // replace with your Android app publisher key
		AdBuddizBinding.SetIOSPublisherKey("TEST_PUBLISHER_KEY_IOS");         // replace with your iOS app publisher key
		AdBuddizBinding.SetTestModeActive();                                  // to delete before submitting to store
		AdBuddizBinding.CacheAds();                                           // start caching ads
	}

	public void OnGUI()
	{
		GUIStyle style = new GUIStyle(GUI.skin.button);
		style.fontSize = 50;

		if (GUI.Button (new Rect (40, 40, Screen.width - 80, 120), "Show Interstitial Ad", style) == true) {
			AdBuddizBinding.ShowAd();
		}
		if (GUI.Button (new Rect (40, 240, Screen.width - 80, 120), "Fetch Rewarded Video Ad", style) == true) {
			AdBuddizBinding.RewardedVideo.Fetch();
		}
		if (GUI.Button (new Rect (40, 400, Screen.width - 80, 120), "Show Rewarded Video Ad", style) == true) {
			AdBuddizBinding.RewardedVideo.Show();
		}
	}
	
	void OnEnable()
	{
		// Listen to AdBuddiz events
		AdBuddizManager.didFailToShowAd += DidFailToShowAd;
		AdBuddizManager.didCacheAd += DidCacheAd;
		AdBuddizManager.didShowAd += DidShowAd;
		AdBuddizManager.didClick += DidClick;
		AdBuddizManager.didHideAd += DidHideAd;

		//Listen to AdBuddiz events for incentivized video
		AdBuddizRewardedVideoManager.didFetch += DidFetch;
		AdBuddizRewardedVideoManager.didFail += DidFail;
		AdBuddizRewardedVideoManager.didComplete += DidComplete;
		AdBuddizRewardedVideoManager.didNotComplete += DidNotComplete;
	}
	
	void OnDisable()
	{
		// Remove all event handlers
		AdBuddizManager.didFailToShowAd -= DidFailToShowAd;
		AdBuddizManager.didCacheAd -= DidCacheAd;
		AdBuddizManager.didShowAd -= DidShowAd;
		AdBuddizManager.didClick -= DidClick;
		AdBuddizManager.didHideAd -= DidHideAd;

		AdBuddizRewardedVideoManager.didFetch -= DidFetch;
		AdBuddizRewardedVideoManager.didFail -= DidFail;
		AdBuddizRewardedVideoManager.didComplete -= DidComplete;
		AdBuddizRewardedVideoManager.didNotComplete -= DidNotComplete;
	}
	
	void DidFailToShowAd(string adBuddizError) {
		AdBuddizBinding.LogNative("DidFailToShowAd: " + adBuddizError);
		AdBuddizBinding.ToastNative("DidFailToShowAd: " + adBuddizError);
		Debug.Log ("Unity: DidFailToShowAd: " + adBuddizError);
	}
	
	void DidCacheAd() {
		AdBuddizBinding.LogNative ("DidCacheAd");
		AdBuddizBinding.ToastNative ("DidCacheAd");
		Debug.Log ("Unity: DidCacheAd");
	}

	void DidShowAd() {
		AdBuddizBinding.LogNative ("DidShowAd");
		AdBuddizBinding.ToastNative ("DidShowAd");
		Debug.Log ("Unity: DidShowAd");
	}
	
	void DidClick() {
		AdBuddizBinding.LogNative ("DidClick");
		AdBuddizBinding.ToastNative ("DidClick");
		Debug.Log ("Unity: DidClick");
	}
	
	void DidHideAd() {
		AdBuddizBinding.LogNative ("DidHideAd");
		AdBuddizBinding.ToastNative ("DidHideAd");
		Debug.Log ("Unity: DidHideAd");
	}

	void DidFetch() {
		AdBuddizBinding.LogNative ("DidFetch");
		AdBuddizBinding.ToastNative ("DidFetch");
		Debug.Log ("Unity: DidFetch");
	}

	void DidFail(string adBuddizError) {
		AdBuddizBinding.LogNative ("DidFail: " + adBuddizError);
		AdBuddizBinding.ToastNative ("DidFail: " + adBuddizError);
		Debug.Log ("Unity: DidFail: " + adBuddizError);
	}

	void DidComplete() {
		AdBuddizBinding.LogNative ("DidComplete");
		AdBuddizBinding.ToastNative ("DidComplete");
		Debug.Log ("Unity: DidComplete");
	}

	void DidNotComplete() {
		AdBuddizBinding.LogNative ("DidNotComplete");
		AdBuddizBinding.ToastNative ("DidNotComplete");
		Debug.Log ("Unity: DidNotComplete");
	}
}


