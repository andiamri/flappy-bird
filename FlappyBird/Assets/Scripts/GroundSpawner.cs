using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class GroundSpawner : MonoBehaviour
{
    [SerializeField] private Ground groundRef;
    

    private Ground prevGround;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnGround()
    {
        if(prevGround != null)
        {
            Ground newGround = Instantiate(groundRef);

            newGround.gameObject.SetActive(true);
            prevGround.SetNextGroundObject(newGround.gameObject);
            

            

        }
        
    }
   
    private void OnTriggerExit2D(Collider2D collision)
    {
        Ground ground = collision.GetComponent<Ground>();
        

        if (ground)
        {
            prevGround = ground;

            SpawnGround();
        }
        
        
    }
}
