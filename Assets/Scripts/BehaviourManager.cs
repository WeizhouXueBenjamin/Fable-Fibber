using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class BehaviourManager : MonoBehaviour
{

    GameObject IdeaBubble;
    
    public void CallBubble(Item item)
    {
        GameObject bubble = Instantiate(IdeaBubble, transform);
        bubble.GetComponent<SpriteRenderer>().sprite = item.image;
    }

}