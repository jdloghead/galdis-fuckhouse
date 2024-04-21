using System.Collections;
using GameJolt.API;
using UnityEngine;
using UnityEngine.UI;

public class GameJoltAvatar : MonoBehaviour
{
	public Image Avatar;

	private void Start()
	{
		StartCoroutine(UpdateRoutine());
	}

	private IEnumerator UpdateRoutine()
	{
		var wait = new WaitForSeconds(1f);

		while (enabled)
		{
			UpdateInfos();
			yield return wait;
		}
	}

	private void UpdateInfos()
	{
		var user = GameJoltAPI.Instance.CurrentUser;

		if (user != null)
		{
			if (user.Avatar == null)
				user.DownloadAvatar();

			Avatar.sprite = user.Avatar;
		}
		else if (user == null)
		{
			Avatar.sprite = null;
		}
	}
}
