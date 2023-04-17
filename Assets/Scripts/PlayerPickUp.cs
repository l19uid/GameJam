using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    public enum PickupType { None, Water, Fire, Electricity, Air };
    public PickupType currentPickup = PickupType.None;
    public GameObject pickupPosition;
    public int pickupCount = 0;
    public int pickupRange = 1;
    
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
    }

    private void PickUp()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(pickupPosition.transform.position, pickupRange);
        foreach (Collider2D collider in colliders)
        {
            Debug.Log(collider.gameObject.layer + " " + fluidLayer);
            if (collider.gameObject.layer == fluidLayer)
            {
                currentPickup = collider.gameObject.transform.tag == "Water" ? PickupType.Water : PickupType.None;
                
                pickupCount++;
                Destroy(collider.gameObject);
            }
        }
    }
    
}
