using UnityEngine;
using System.Collections;
using System.IO;

public enum ResourceNamePrefab {StatePrefab};

public class ResourceLoader : MonoBehaviour {

	private static string pathToPrefabs = "Prefabs/";

	public static GameObject LoadPrefab(ResourceNamePrefab prefabName)
	{
		return Resources.Load <GameObject>(pathToPrefabs + prefabName.ToString());
	}
}