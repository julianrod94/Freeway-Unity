using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Standard_Assets.Scripts {

	public class AudioManager : MonoBehaviour
	{
		
		[SerializeField]
		private AudioClip player1ScoresSound;
		[SerializeField]
		private AudioClip player2ScoresSound;
		[SerializeField]
		private AudioClip deathSound;
		[SerializeField]
		private AudioClip winnedGameSound;
		[SerializeField]
		private AudioClip tiedGameSound;
		[SerializeField]
		private AudioClip mainTheme;


		private AudioSource mainThemeLoop;

		private void Start() {
			mainThemeLoop = GetComponent<AudioSource>();
			mainThemeLoop.loop = true;
			mainThemeLoop.clip = mainTheme;
			playMainTheme();
		}
		
		private static AudioManager _instance = null;

		public static AudioManager Instance
		{
			get { return _instance ?? (_instance = new AudioManager()); }
			private set { _instance = value; }
		}

		// Use this for initialization
		void Awake()
		{
			_instance = this;
		}

		public void playPlayer1Score()
		{
			GetComponent<AudioSource>().PlayOneShot(player1ScoresSound);
		}
		
		public void playPlayer2Score()
		{
			GetComponent<AudioSource>().PlayOneShot(player2ScoresSound);
		}
		
		public void playPlayerDeath()
		{
			GetComponent<AudioSource>().PlayOneShot(deathSound);
		}
		
		public void playGameWinnedSound()
		{
			GetComponent<AudioSource>().PlayOneShot(winnedGameSound);
		}
		
		public void playGameTiedSound()
		{
			GetComponent<AudioSource>().PlayOneShot(tiedGameSound);
		}
	
		public void playMainTheme() {
			mainThemeLoop.Play();
		}

		public void stopMainTheme() {
			mainThemeLoop.Stop();
		}
	}
}
