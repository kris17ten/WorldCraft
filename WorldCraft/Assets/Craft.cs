using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craft : MonoBehaviour
{

    public GameObject brick;
    public GameObject bush;
    public GameObject grass;
    public GameObject sand;
    public GameObject stone;
    public GameObject water;

    private Touch touch;
    private Vector2 touchPos;
    private string cube;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Debug.Log(Input.touchCount);
            touch = Input.GetTouch(0);
            RaycastHit hitTouch;
            Ray rayTouch = Camera.main.ScreenPointToRay(touch.position);
            touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                if (Physics.Raycast(rayTouch, out hitTouch))
                {
                    Debug.Log("found " + hitTouch.transform.name + " at distance: " + hitTouch.distance);
                    switch (cube)
                    {
                        case "bush":
                            Instantiate(bush, hitTouch.point, Quaternion.identity);
                            break;
                        case "brick":
                            Instantiate(brick, hitTouch.point, Quaternion.identity);
                            break;
                        case "sand":
                            Instantiate(sand, hitTouch.point, Quaternion.identity);
                            break;
                        case "stone":
                            Instantiate(stone, hitTouch.point, Quaternion.identity);
                            break;
                        case "water":
                            Instantiate(water, hitTouch.point, Quaternion.identity);
                            break;
                        default:
                            Instantiate(grass, hitTouch.point, Quaternion.identity);
                            break;
                    }
                    

                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("found " + hit.transform.name + " at distance: " + hit.distance);
                //Instantiate(cube, hit.point, Quaternion.identity);
            }
        }


    }

    public void clickBlock(string whichCube)
    {
        cube = whichCube;
    }



}
