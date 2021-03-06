﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateInkTalkOnPlayerEnter : CreateInkTalk
{
	public List<string> require = new List<string>();
	public List<string> without = new List<string>();

	private void OnTriggerEnter(Collider other)
	{
		if (!enabled) return;

		if (other.tag == "Player")
		{
			if (FlagBag.Instance.HasFlags(require) &&
				FlagBag.Instance.WithoutFlags(without))
			{
				UIManager.Instance.pressToTalk.SetActive(true);
				var btn = UIManager.Instance.pressToTalk.GetComponent<Button>();
				btn.onClick.RemoveAllListeners();
				btn.onClick.AddListener(() => { Create(); });
			}
		}
	}
}
