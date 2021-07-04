using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject cube;
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var layerMask = LayerMask.GetMask("Plane");
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit,Mathf.Infinity,layerMask))
            {
                if (hit.transform.name == "Plane")
                {
                    Vector3 spawnPoint = new Vector3(hit.point.x,cube.transform.localScale.y/2,hit.point.z);
                    Instantiate(cube, spawnPoint, Quaternion.identity);
                }
            }
        }
    }
}
