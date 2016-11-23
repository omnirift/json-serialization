using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Button saveButton;
    public Button loadButton;

	public GameObject playerPrefab;
    public const string playerPath = "Prefabs/Player";

    private static string dataPath = string.Empty;

    void Awake()
    {
    	dataPath = System.IO.Path.Combine(Application.persistentDataPath, "actors.json");
    }

    void Start()
    {
        //CreateActor(playerPath, new Vector3(0, 1.6f, 0), Quaternion.identity);
        //CreateActor(playerPath, new Vector3(5, 1.6f, 0), Quaternion.identity);
        //CreateActor(playerPath, new Vector3(-5, 1.6f, 0), Quaternion.identity);
    }

    public static Actor CreateActor(string path, Vector3 position, Quaternion rotation)
    {
        GameObject prefab = Resources.Load<GameObject>(path);

        GameObject go = Instantiate(prefab, position, rotation) as GameObject;

		Actor actor = go.GetComponent<Actor>() ?? go.AddComponent<Actor>();

        return actor;
    }

    public static Actor CreateActor(ActorData data, string path, Vector3 position, Quaternion rotation)
    {
		Actor actor = CreateActor(path, position, rotation);

        actor.data = data;

        return actor;
    }

	void Save()
	{
		SaveData.Save(dataPath, SaveData.actorContainer);
	}

	void Load()
	{
		SaveData.Load(dataPath);
	}

    void OnEnable()
    {
        saveButton.onClick.AddListener(Save);
        loadButton.onClick.AddListener(Load);
    }
    void OnDisable()
    {
        saveButton.onClick.RemoveListener(Save);
		loadButton.onClick.RemoveListener(Load);
    }
}
