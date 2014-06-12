using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Facebook;
public class FBUtil {
	private static string actionsLogin="email,publish_actions,user_friends";
	public static void init(){
	
			FB.Init(delegate {
			}, delegate {
			});
		
	}
	public static void friendsScores(){
		if (!FB.IsLoggedIn)
			FB.Login(actionsLogin, delegate {
				if (FB.IsLoggedIn){
				
					FB.API ("/"+FB.AppId+"/scores", HttpMethod.GET, delegate(FBResult result){
						//252232634964826/scores?user.id=660260877354538
						Debug.Log(result);
					});
				}
			});
		else{

			FB.API ("/"+FB.AppId+"/scores", HttpMethod.GET, delegate(FBResult res) {
				Debug.Log(res);
			});
		}
	}

	public static bool login(){
		if (!FB.IsLoggedIn){
			FB.Login(actionsLogin);
			return false;
		}
		return true;
	}
	public static void score(string score,FacebookDelegate callback){

		if (!FB.IsLoggedIn)
			FB.Login(actionsLogin, delegate {
				if (FB.IsLoggedIn){
					Dictionary<string, string> dic= new Dictionary<string, string>(){{"score",score}};
					FB.API ("/me/scores", HttpMethod.POST, callback, dic);
				}
			});
		else{
			Dictionary<string, string> dic= new Dictionary<string, string>() {{"score", score}};
			FB.API ("/me/scores", HttpMethod.POST,callback, dic);
		}


	}


	public static void share(FacebookDelegate callback){

		if (!FB.IsLoggedIn)
			FB.Login(actionsLogin, delegate {
				if (FB.IsLoggedIn)
					internalShare(callback);
			});
		else 
			internalShare(callback);
		
	}
	private static void internalShare(FacebookDelegate del){
		FB.Feed(
			linkCaption: "Titulo Run",
			picture: "http://www.exiconglobal.com/corp/wp-content/uploads/2012/10/App-Icon-copy.png",
			linkName: "Checkout my Friend",
			link: "http://apps.facebook.com/" + FB.AppId + "/?challenge_brag=" + (FB.IsLoggedIn ? FB.UserId : "guest"),
			callback: del
			);
	}

	
}
