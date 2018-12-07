using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screw : MonoBehaviour {

    
    public GameObject Screw;
    public GameObject ScrewDriver;

    bool screwed = false;
    bool Screwedonce = false;
    

    Rigidbody m_Rigidbody;
    

    void Start()
    {
        Screw.GetComponent<Rigidbody>().useGravity = false;
         Screw.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
      

    }
    void Update()
    {

        Debug.Log(GameManager.Instance.BRScrews);

        if (screwed == true)
        {
            StartCoroutine(screwcountout());

        }
       
    }


    IEnumerator screwcountout()
    {
        screwed = false;
        Screw.transform.Rotate(Vector3.forward * 60 * Time.deltaTime);
        yield return new WaitForSeconds(4);
        Screw.GetComponent<Rigidbody>().useGravity = true;
        Screw.GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezePosition;
        GameManager.Instance.BRScrews += 1;
        yield return new WaitForSeconds(1);
        Destroy(Screw);


    }


    public void OnCollisionEnter(Collision collider)
    {
        switch (collider.gameObject.tag)
        {
            case "1":
                if (Screwedonce == false)
                {
                    screwed = true;
                    Screwedonce = true;
                    Debug.Log("Collided");
                }
                break;
        }
    }
}
 