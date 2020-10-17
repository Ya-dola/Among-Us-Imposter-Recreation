using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : MonoBehaviour
{
    public int ID = 0;
    public VentsSystem ventsSystem;

    public Vector3 GetPos()
    {
        return this.transform.position;
    }

    #region Triggers
    void OnTriggerEnter2D(Collider2D other)
    {
        //When the Imposter Enters the Vent Area
        if (other.gameObject.tag == "Imposter")
        {
            //If the Imposter is activated skip
            //This is used to move the imposter around without activating the triggers
            if (other.GetComponent<PlayerMovement>().IsInVent())
            {
                ventsSystem.CanEnterVentSystem(other.GetComponent<PlayerMovement>(), ID);
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        //When the Imposter Exits the Vent Area
        if (other.gameObject.tag == "Imposter")
        {
            //If the Imposter is activated skip
            //This is used to move the imposter around without activating the triggers
            if (other.GetComponent<PlayerMovement>().IsInVent())
                ventsSystem.CantEnterVentSystem();
        }
    }
    #endregion 
}
