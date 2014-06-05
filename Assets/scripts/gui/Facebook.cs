using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Facebook;
public class FBUtil {

	public static void init(ref bool conFace){
		try{
			FB.Init(delegate {
	


			}, delegate {
			});
			conFace=true;
		}catch(System.Exception de){
			Debug.LogError(de);
			conFace = false;					
		}
	}
	public static bool login(){
		if (!FB.IsLoggedIn){
			FB.Login("email,publish_actions");
			return false;
		}
		return true;
	}
	public static void score(string score,FacebookDelegate callback){

		if (!FB.IsLoggedIn)
			FB.Login("email,publish_actions", delegate {
				if (FB.IsLoggedIn){
					Dictionary<string, string> dic= new Dictionary<string, string>(){{"score",score}};
					FB.API ("/me/scores", HttpMethod.POST, callback, dic);
				}
			});
		else{
			Dictionary<string, string> dic= new Dictionary<string, string>() {{"score", score}};
			FB.API ("/me/scores", HttpMethod.POST, callback, dic);
		}


	}


	public static void share(FacebookDelegate callback){

		if (!FB.IsLoggedIn)
			FB.Login("email,publish_actions", delegate {
				if (FB.IsLoggedIn)
					internalShare(callback);
			});
		else 
			internalShare(callback);
		
	}
	private static void internalShare(FacebookDelegate del){
		FB.Feed(
			linkCaption: "Titulo Run",
			picture: "http://www.friendsmash.com/images/logo_large.jpg",
			linkName: "Checkout my Friend",
			link: "http://apps.facebook.com/" + FB.AppId + "/?challenge_brag=" + (FB.IsLoggedIn ? FB.UserId : "guest"),
			callback: del
			);
	}

	
}
