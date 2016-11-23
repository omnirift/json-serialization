using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Button saveButton;
    public Button loadButton;
    public const string playerPath = "Prefabs/Player";

    private static string dataPath = string.Empty;

    void Awake()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
            dataPath = System.IO.Path.Combine(Application.persistentDataPath, "Resources/actors.xml");
        else
            dataPath = System.IO.Path.Combine(Application.dataPath, "Resources/actors.xml");
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

        GameObject go = GameObject.Instantiate(prefab, position, rotation) as GameObject;

        Actor actor = go.GetComponent<Actor>() ?? go.AddComponent<Actor>();

        return actor;
    }

    public static Actor CreateActor(ActorData data, string path, Vector3 position, Quaternion rotation)
    {
        GameObject prefab = Resources.Load<GameObject>(path);

        GameObject go = GameObject.Instantiate(prefab, position, rotation) as GameObject;

        Actor actor = go.GetComponent<Actor>() ?? go.AddComponent<Actor>();

        actor.data = data;

        return actor;
    }

    void OnEnable()
    {
        saveButton.onClick.AddListener(delegate { SaveData.Save(dataPath, SaveData.actorContainer); });
        loadButton.onClick.AddListener(delegate { SaveData.Load(dataPath); });
    }
    void OnDisable()
    {
        saveButton.onClick.RemoveListener(delegate { SaveData.Save(dataPath, SaveData.actorContainer); });
        loadButton.onClick.RemoveListener(delegate { SaveData.Load(dataPath); });
    }
}
