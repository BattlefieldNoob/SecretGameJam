using UnityEngine;
using System.Collections;

public class FollowObject : MonoBehaviour {


    public GameObject toFollow;
    RectTransform rectTransform;
	// Use this for initialization
	void Start () {
        GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (toFollow != null)
        {
            transform.position = Camera.main.WorldToScreenPoint(toFollow.transform.position);
        }
	}
}
