using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    public Particle.ParticleType currentPickup = Particle.ParticleType.None;
    public GameObject pickupPosition;
    public int pickupCount = 0;
    public int pickupRange = 1;
    public GameObject currentPickupObject;
    
    public int fluidLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
            PickUp();
        if (Input.GetKeyDown(KeyCode.Mouse1) && currentPickup != Particle.ParticleType.None)
            DeployPickup();
    }

    private void PickUp()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(pickupPosition.transform.position, pickupRange);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.layer == fluidLayer && currentPickup == Particle.ParticleType.None ||
                collider.TryGetComponent(out Particle particle) && currentPickup == particle.particleType
                )
            {
                currentPickupObject = collider.gameObject;
                pickupCount++;
                
                Destroy(collider.gameObject);
            }
        }
    }
    private void DeployPickup()
    {
        if(pickupCount > 0)
            pickupCount--;
        else
            return;
        
        GameObject GO = Instantiate(currentPickupObject, pickupPosition.transform.position, Quaternion.identity);
        GO.GetComponent<Rigidbody2D>().AddForce(new Vector2(pickupPosition.transform.localPosition.x, pickupPosition.transform.localPosition.y));
    }
}
