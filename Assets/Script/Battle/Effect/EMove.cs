using ProtoMsg;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EMove : MonoBehaviour
{
   

    
    void FixedUpdate()
    {
        if (eConfig!=null)
        {
            if (eConfig.moveSpeed==0)
            {
                return;
            }
            if (eConfig.moveType== MoveType.DirectMove)
            {
                transform.position += (transform.forward) * (eConfig.moveSpeed * Time.deltaTime);
            }
            else
            {
                if (Vector3.Distance(eConfig.trackObject.position, transform.position) >= 0.01f)
                {
                    transform.transform.LookAt(eConfig.trackObject);
                    transform.position += (transform.forward) * (eConfig.moveSpeed * Time.deltaTime);
                }
            }
        }
        
       
    }

    EConfig eConfig;
    internal void Init(EConfig eConfig)
    {
        this.eConfig = eConfig;
    }
}
