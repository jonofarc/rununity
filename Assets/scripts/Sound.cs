using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sound {
	private static Dictionary<string, AudioClip > tracks= new Dictionary<string, AudioClip>();
	static Sound(){
		AudioClip song = (AudioClip)Resources.Load("sounds/theme");
		tracks.Add("theme",song);
		song = (AudioClip)Resources.Load("sounds/splash");
		tracks.Add("splash",song);
		song = (AudioClip)Resources.Load("sounds/suck");
		tracks.Add("suck",song);
		song = (AudioClip)Resources.Load("sounds/jump");
		tracks.Add("jump",song);
	}
	private static AudioSource theme=null;
	public static void playTheme(GameObject gameObject){
		if (theme == null) {
						theme = gameObject.AddComponent<AudioSource> ();		
						theme.clip = tracks ["theme"];
						theme.loop = true;
						theme.Play ();
		} else {
			theme.Play();
		}
	}
	public static void pauseTheme(GameObject gameObject){
		theme.Pause ();
	}
	public static void playTrack(GameObject gameObject,string sound){
		AudioSource audio = gameObject.AddComponent<AudioSource>();		
		audio.clip = tracks [sound];
		audio.Play();
	}
	



}
