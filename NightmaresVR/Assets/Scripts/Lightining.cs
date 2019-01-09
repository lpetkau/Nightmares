using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightining : MonoBehaviour
{

    public GameObject Lightning1;
    public bool Isrunning = false;
    public AudioSource short1;
    public AudioSource Medium1;
    public AudioSource Long1;


    IEnumerator WaitTime()
    {

        
        float num = Random.Range(5, 10);
        yield return new WaitForSeconds(num);
     
        Isrunning = false;

    }


    IEnumerator Strike1()
    {

        Debug.Log("Strike1");
        Lightning1.SetActive(true);
        float num = Random.Range(.1f, .3f);
        yield return new WaitForSeconds(num);
        Lightning1.SetActive(false);
         num = Random.Range(.1f, .3f);
        yield return new WaitForSeconds(num);
        short1.Play();
    }
    IEnumerator Strike2()
    {

        Debug.Log("Strike21");
        float num = Random.Range(.1f, .3f);
        Lightning1.SetActive(true);
        yield return new WaitForSeconds(num);
        Lightning1.SetActive(false);
        Debug.Log("Strike22");
        num = Random.Range(.1f, .3f);
        yield return new WaitForSeconds(num);
        Lightning1.SetActive(true);
        num = Random.Range(.1f, .3f);
        yield return new WaitForSeconds(num);
        Lightning1.SetActive(false);
        num = Random.Range(.1f, .3f);
        yield return new WaitForSeconds(num);
        Medium1.Play();


    }
    IEnumerator Strike3()
    {

        Debug.Log("Strike31");
        float num = Random.Range(.1f, .3f);
        Lightning1.SetActive(true);
        yield return new WaitForSeconds(num);
        Lightning1.SetActive(false);
        Debug.Log("Strike32");
        num = Random.Range(.1f, .3f);
        yield return new WaitForSeconds(num);
        Lightning1.SetActive(true);
        num = Random.Range(.1f, .3f);
        yield return new WaitForSeconds(num);
        Lightning1.SetActive(false);
        Debug.Log("Strike33");
        num = Random.Range(.1f, .3f);
        yield return new WaitForSeconds(num);
        Lightning1.SetActive(true);
        num = Random.Range(.1f, .3f);
        yield return new WaitForSeconds(num);
        Lightning1.SetActive(false);
        num = Random.Range(.1f, .3f);
        yield return new WaitForSeconds(num);
        Long1.Play();

    }
    // Update is called once per frame
    void Update()
    {
        float Strikenum = Random.Range(1, 100);

        if (Isrunning == false && Strikenum <= 60)
        {
            Isrunning = true;
            StartCoroutine(Strike1());
            StartCoroutine(WaitTime());
        }

        if (Isrunning == false && Strikenum <= 90 && Strikenum >= 61)
        {
            Isrunning = true;
            StartCoroutine(Strike2());
            StartCoroutine(WaitTime());
        }
        if (Isrunning == false && Strikenum <= 101 && Strikenum >= 91)
        {
            Isrunning = true;
            StartCoroutine(Strike3());
            StartCoroutine(WaitTime());

        }
    } 
}

