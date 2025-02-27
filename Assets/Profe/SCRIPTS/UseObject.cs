using Profe;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseObject : MonoBehaviour
{
    public SOItem item;
    private InventoryHandler inventoryHandler;

    public string animationName;
    public Animator animator;
    public bool triggerAnimation;
    
    public bool destroyObject;
    public GameObject objectToDestroy;


    private void Start()
    {
        inventoryHandler = FindObjectOfType<InventoryHandler>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && inventoryHandler.inventory.Contains(item))
        {
            if (triggerAnimation) // Significa que al usar x objeto se activa una animacion
            {
                animator.Play(animationName);
            }
            else if (destroyObject)
            {
                Destroy(objectToDestroy);
            }
        }
    }

}
