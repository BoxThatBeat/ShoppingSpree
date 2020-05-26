using UnityEngine;
using UnityEngine.UI;

public class IconBox : MonoBehaviour
{

	public Image icon;

	public void SetIcon(Sprite s)
	{
		icon.sprite = s;
		if (s == null)
		{
			//use lean tween to animate the obj
		}
		else
		{

		}
	}

	public void Close()
	{

	}

}
