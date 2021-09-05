using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour {
	public GameObject textContainer;
	public GameObject textPrefab;

	private readonly List<FloatingText> floatingTexts = new List<FloatingText>();

	private FloatingText GetFloatingText() {
		FloatingText ftext = floatingTexts.Find(t => !t.active);
		if (ftext == null) {
			ftext = new FloatingText {
				gameObject = Instantiate(textPrefab)
			};
			ftext.gameObject.transform.SetParent(textContainer.transform);
			ftext.text = ftext.gameObject.GetComponent<Text>();
			floatingTexts.Add(ftext);
		}
		return ftext;
	}

	public void Show(string message, int fontSize, Color color, Vector3 position, Vector3 motion, float duration) {
		FloatingText ftext = GetFloatingText();
		ftext.text.text = message;
		ftext.text.fontSize = fontSize;
		ftext.text.color = color;

		// Transfer world space to screen space
		ftext.gameObject.transform.position = Camera.main.WorldToScreenPoint(position);
		ftext.motion = motion;
		ftext.duration = duration;

		ftext.Show();
	}

	// Update is called once per frame
	private void Update() {
		// Update every floating text in our current container
		foreach (FloatingText ftext in floatingTexts) {
			ftext.UpdateFloatingText();
		}
	}
}
