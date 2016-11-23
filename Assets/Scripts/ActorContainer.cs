using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.Collections.Generic;

[XmlRoot("ActorCollection")]
public class ActorContainer {

    [XmlArray("Actors")]
    [XmlArrayItem("Actor")]
    public List<ActorData> actors = new List<ActorData>();

}
