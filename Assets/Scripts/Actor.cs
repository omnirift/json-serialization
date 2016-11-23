using UnityEngine;
using System.Collections;
using System;

public class Actor : MonoBehaviour {

    public ActorData data = new ActorData();

    public string name = "actor";
 
    public float health = 100;

    public void StoreData()
    {
        data.name = name;
        data.pos = transform.position;
        data.health = health;
    }

    public void LoadData()
    {
        name = data.name;
		transform.position = data.pos;
        health = data.health;
    }

	public void ApplyData()
	{
		SaveData.AddActorData(data);
	}

    void OnEnable()
    {
        SaveData.OnLoaded += LoadData;
		SaveData.OnBeforeSave += StoreData;
		SaveData.OnBeforeSave += ApplyData;
    }

    void OnDisable()
    {
		SaveData.OnLoaded -= LoadData;
		SaveData.OnBeforeSave -= StoreData;
		SaveData.OnBeforeSave -= ApplyData;
    }

}

[Serializable]
public class ActorData
{
    public string name;

	public Vector3 pos;

    public float health;
}
