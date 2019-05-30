using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Outline = cakeslice.Outline;

[CreateAssetMenu(fileName = "PropController", menuName = "Misc/PropController")]
public class PropController : ScriptableObject
{
    public Dictionary<string, GameObject> props = new Dictionary<string, GameObject>();

    public void ActivateBookExample(){
        props["Table"].SetActive(true);
        props["Book"].SetActive(true);
    }

    public void HighlightProp(string propTitle){
        props[propTitle].GetComponent<PropBase>().Highlight();
    }

    public void UnhighlightProp(string propTitle){
        props[propTitle].GetComponent<PropBase>().Unhighlight();
    }
}
