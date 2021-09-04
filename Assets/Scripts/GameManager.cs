using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public static GameManager instance;

	// GameResources
	public List<Sprite> playerSprites;
	public List<Sprite> weaponSprites;
	public List<int> weaponPrices;
	public List<int> xpTable;

	// References
	public Player player;

	// PlayerResources
	public int gold;
	public int experience;

	// Start is called before the first frame update
	private void Awake() {
		if (instance != null) {
			Destroy(gameObject);
			return;
		}

		instance = this;
		SceneManager.sceneLoaded += LoadState;
		DontDestroyOnLoad(gameObject);
	}

	// Saving and Loading the Game State
	/*
	* int playerSkin
	* int gold
	* int experience
	* int weaponLevel
	*/
	public void SaveState() {
		string s = "";

		// playerSkin
		s += "0|";

		// gold
		s += $"{gold}|";

		// experience
		s += $"{experience}|";

		// weaponLevel
		s += $"0";
		PlayerPrefs.SetString("SaveState", s);
	}

	public void LoadState(Scene scene, LoadSceneMode mode) {
		if (!PlayerPrefs.HasKey("SaveState")) {
			return;
		}

		string[] data = PlayerPrefs.GetString("SaveState").Split('|');

		// playerSkin

		// gold
		gold = int.Parse(data[1]);

		// experience
		experience = int.Parse(data[2]);

		// weaponLevel
	}
}
