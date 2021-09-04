using UnityEngine;

public class PortalCollidable : Collidable {
	public string[] sceneNames;

	protected override void OnCollide(Collider2D collider) {
		if (collider.name == "Player") {
			// TP the player to another random dungeon
			string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
			UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
		}
	}
}
