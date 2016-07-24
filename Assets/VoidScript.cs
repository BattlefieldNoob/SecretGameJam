using UnityEngine;
using System.Collections;

public class VoidScript : MonoBehaviour
{

    public GameObject[] walls;
    CameraScript camera;
    public float speed = 0.1f;
    float counter;
    bool done = false;

    // Use this for initialization
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScript>();
        camera.duration = 10;
        camera.magnitude = 4;
        camera.StartShaking();
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter <= 17)
        {
            walls[0].transform.localScale += new Vector3(0, speed, 0);
            walls[1].transform.localScale += new Vector3(0, speed, 0);
            walls[2].transform.localScale += new Vector3(0, speed * 2, 0);
            walls[3].transform.localScale += new Vector3(0, speed * 2, 0);
        }
        if (counter >= 13)
        {
            if (!done)
                ShowFinalText();
        }

    }

    void ShowFinalText()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        done = true;
        GameObject.Find("FinalText").SendMessage("DoIt");
    }
}
