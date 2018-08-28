using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Standard_Assets.Scripts {

	public class AudioManager : MonoBehaviour
	{
		
		[SerializeField]
		private AudioClip player1Scores;
		[SerializeField]
		private AudioClip player2Scores;

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
			GetComponent<AudioSource>().PlayOneShot(player1Scores);
		}
		
		public void playPlayer2Score()
		{
			GetComponent<AudioSource>().PlayOneShot(player2Scores);
		}
	}
}
