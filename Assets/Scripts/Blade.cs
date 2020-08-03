using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private bool isCutting;
    private Vector2 lastPos;
    private Camera cam;
    private Rigidbody2D rig;
    private CircleCollider2D circle;
    private GameObject currentCutLine;
    public GameObject cutLinePrefab;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rig = GetComponent<Rigidbody2D>();
        circle = GetComponent<CircleCollider2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        CheckMouseClick();
        if(isCutting)
        {
            UpdateCut();
        }
    }

    private void CheckMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCut();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            StopCut();
        }
    }

    private void StartCut()
    {
        isCutting = true;
        currentCutLine = Instantiate(cutLinePrefab, transform);
        circle.enabled = true;
        lastPos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void StopCut()
    {
        isCutting = false;
        currentCutLine.transform.SetParent(null);
        Destroy(currentCutLine,2f);
        circle.enabled = false;
    }

    private void UpdateCut() 
    {
        Vector2 newPos;
        float velocity;
        newPos = cam.ScreenToWorldPoint(Input.mousePosition);
        rig.position = newPos;
        velocity = (newPos - lastPos).magnitude * Time.deltaTime;
        if(velocity > 0.0001f)
        {
            circle.enabled = true;
        }
        else{
            circle.enabled = false;
        }
        lastPos = newPos;
    }
}
