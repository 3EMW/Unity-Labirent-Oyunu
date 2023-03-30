using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TopKontrol : MonoBehaviour
{
    public TextMeshProUGUI Zaman, Durum;
    private Rigidbody rg;
    public float Hiz = 2.5f;
    float zamanSayaci = 35;
    bool oyunDevam = true;
    bool oyunTamam = false;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (oyunDevam && !oyunTamam)  //E�er oyun tamamlanad�ysa devam ediyorsa saya� devam etsin
        {
            zamanSayaci -= Time.deltaTime; //zamanSayaci=zamanSayaci - Time.deltaTime;
            Zaman.text = (int)zamanSayaci + "";
        } 
        else if (!oyunTamam) //Oyun tamamlanmad�ysa 
        {
            Durum.text = "Labirenti Bitiremedin";
        }
        if (zamanSayaci < 0)
            oyunDevam = false;
    }
    void FixedUpdate()
    {
        if (oyunDevam && !oyunTamam)
        {
            float yatay = Input.GetAxis("Horizontal");
            float dikey = Input.GetAxis("Vertical");
            Vector3 kuvvet = new Vector3(-dikey, 0, yatay);
            rg.AddForce(kuvvet * Hiz);
        }
        else
        {
            rg.velocity = Vector3.zero; //Zaman doldu�unda topun hareketini keser.
            rg.angularVelocity = Vector3.zero; //D�ng�sel h�z� keser. 
        }
        
    }
    void OnCollisionEnter(Collision collision)
    {
        string objIsmi = collision.gameObject.name;
        if (objIsmi.Equals("Biti�"))
        {
            //print("Labirenti Bitirdin.");
            oyunTamam = true;
            Durum.text = "Labirenti Bitirdin.";
        }
    }    
}
