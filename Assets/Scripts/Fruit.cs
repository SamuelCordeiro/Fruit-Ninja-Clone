using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fruit : MonoBehaviour
{
    public GameObject slicedFruitModel;
    private float force;
    private Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        force = Random.Range(10f, 14f);
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
            GameController.instance.score += 1;
            GameController.instance.ScoreTextUpdate();
            Vector2 direction = (collider.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            GameObject slicedFruit = Instantiate(slicedFruitModel, transform.position, rotation);
            Destroy(slicedFruit,3f);
            Destroy(gameObject);
        }  

        if(collider.tag == "Game Over")
        {
            GameController.instance.life--;
            GameController.instance.LifeTextUpdate();
        }  
    }
}
