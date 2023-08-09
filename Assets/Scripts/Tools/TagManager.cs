using System;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
// https://assetstore.unity.com/packages/tools/utilities/naughtyattributes-129996
using UnityEngine;

// Component used to store multiple tags
public class TagManager : MonoBehaviour
{
	[SerializeField, Tag] string[] _tags;

	[Header("Search")]
	[SerializeField, Tag] string _tag;
	[SerializeField, ReadOnly] List<GameObject>	_result;
	[Button("Search")]
	void	SearchButton() => SearchObjectsWithTags(_tag);

	public string[]								Tags => GetAllTags();

	/// <summary>
	/// Check whether the GameObject has the given tag in its TagManager.
	/// </summary>
	/// <param name="tag"></param>
	/// <returns>Whether the tag match with one of the GameObject's</returns>
	public bool	HasTag(string tag) => Tags.Contains(tag);

	void	SearchObjectsWithTags(string tag)
	{
		bool	isTagFound;

		_result.Clear();
		if (string.IsNullOrEmpty(tag))
			{ Debug.LogWarning("Please select a Tag first"); return; }
		isTagFound = false;
		foreach (GameObject obj in FindObjectsOfType<GameObject>())
		{
			if (obj.tag == tag ||
					obj.TryGetComponent(out TagManager manager) && manager.HasTag(tag))
			{
				_result.Add(obj);
				isTagFound = true;
			}
		}
		if (!isTagFound)
			Debug.LogWarning($"Tag \"{tag}\" not found");
	}

	string[]	GetAllTags()
	{
		string[] allTags;

		allTags = new string[_tags.Length + 1];
		allTags[0] = gameObject.tag;
		_tags.CopyTo(allTags, 1);
		return (allTags);
	}
}

public static partial class	Tools
{
	/// <summary>
	/// Check if a given gameObject has a certain tag (including TagManager's)
	/// </summary>
	/// <param name="gameObject">The target gameObject to test</param>
	/// <param name="tag"></param>
	/// <returns>Whether the game has the given tag</returns>
	public static bool CompareTag(GameObject gameObject, string tag)
		=> gameObject.tag == tag ||
				gameObject.TryGetComponent(out TagManager manager) && manager.HasTag(tag);
}
