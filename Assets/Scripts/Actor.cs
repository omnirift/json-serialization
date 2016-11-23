using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

public class Actor : MonoBehaviour {

    public ActorData data = new ActorData();

    public string name = "actor";

    public float health = 100;

    public void StoreData()
    {
        data.name = name;
        Vector3 pos = transform.position;
        data.posX = pos.x;
        data.posY = pos.y;
        data.posZ = pos.z;
        data.health = health;
    }

    public void LoadData()
    {
        name = data.name;
        transform.position = new Vector3(data.posX, data.posY, data.posZ);
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

public class ActorData
{
    [XmlAttribute("Name")]
    public string name;

    [XmlElement("PosX")]
    public float posX;

    [XmlElement("PosY")]
    public float posY;

    [XmlElement("PosZ")]
    public float posZ;

    [XmlElement("Health")]
    public float health;
}
