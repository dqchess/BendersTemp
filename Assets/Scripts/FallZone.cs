﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallZone : MonoBehaviour
{
    public float GravityModifier = 20f;


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Bender")
        {
            if (other.GetComponent<AIAgent>() != null && other.GetComponent<AIAgent>().isInTrainingCamp)
            {
                other.GetComponent<Bender>().Defeat();
                Debug.Log("training");
            }
            else
            {
                other.GetComponent<Bender>().NavAgent.enabled = false;
                other.attachedRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                other.attachedRigidbody.AddForce(transform.forward * GravityModifier);
            }
        }
    }
}