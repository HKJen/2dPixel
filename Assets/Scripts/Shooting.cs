using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] Transform shootPoint;
    [SerializeField] GameObject bullet;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    private void Shoot() {
        Instantiate(bullet, shootPoint.position, shootPoint.rotation);
    }
}
