using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float force;
    private Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        //force = Random.Range(10f, 14f);
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(transform.up * force, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.tag == "Blade")
        {
            GameController.instance.life--;
            GameController.instance.LifeTextUpdate();
            Destroy(gameObject);
        }
    }
}
