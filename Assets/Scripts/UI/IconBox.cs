using UnityEngine;
using UnityEngine.UI;

public class IconBox : MonoBehaviour
{

	public Image icon;
	public GameObject iconBubble;
	public LeanTweenType easeType;

	private void Start()
	{
		LeanTween.scale(iconBubble, new Vector3(0.5f, 0.5f, 0.5f), 0).setEase(easeType).setOnComplete(SetInactive);
	}

	public void SetIcon(Sprite s)
	{
		icon.sprite = s;
		iconBubble.SetActive(true);
		LeanTween.scale(iconBubble, new Vector3(1, 1, 1), 0.1f).setEase(easeType);
	}

	public void Close()
	{
		LeanTween.scale(iconBubble, new Vector3(0.5f, 0.5f, 0.5f), 0.1f).setEase(easeType).setOnComplete(SetInactive);
	}

	public void SetInactive()
	{
		iconBubble.SetActive(false);
	}

}
