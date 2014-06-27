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

	

	public static void friendsScores(FacebookDelegate deleg){
		if (!FB.IsLoggedIn)
			FB.Login(actionsLogin, delegate(FBResult result) {
				if (FB.IsLoggedIn){

					//252232634964826/scores?user.id=660260877354538
					FB.API ("/"+FB.AppId+"/scores", HttpMethod.GET, deleg);
				}
			});
		else{
			FB.API ("/"+FB.AppId+"/scores", HttpMethod.GET, deleg);
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
			linkCaption: "El Gran Ciclo",
			picture: "http://blog.osdamv.com/content/256.png",
			linkName: "Ven ayuda a gonti!!!",
			link: "http://apps.facebook.com/" + FB.AppId + "/?challenge_brag=" + (FB.IsLoggedIn ? FB.UserId : "guest"),
			callback: del
			);
	}

	
}
