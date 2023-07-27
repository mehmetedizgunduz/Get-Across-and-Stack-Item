using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatesSpawnandTransport : MonoBehaviour
{
    public int pallet;
    public int randomboxnumber;
    public int spawnedbox = 0;
    public int transportingbox = 0;
    private float bosluk = 0;
    public bool birakmaAlani1;
    public bool birakmaAlani2;
    public bool birakmaAlani3;
    public bool kutuAlindi = true;
    public bool kutuspawnlandi = true;
    private float delay;
    public GameObject kutu;
    public Transform Spawner;
    public Transform HolderParent;
    Stack<Transform> collectedTrans = new Stack<Transform>();
    Vector3 DropPos;
    public GameManagement gameManagement;
    
    void Update()
    {
        CreatesSpawn();
        if (transportingbox == 0)
        {
            kutuAlindi = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "birakmaalani1")
        {
            birakmaAlani1 = true;
            DropPos = other.transform.position;
            StartCoroutine(DropSlow(.5f));
        }
        if (other.tag == "birakmaalani2")
        {
            birakmaAlani2 = true;
            DropPos = other.transform.position;
            StartCoroutine(DropSlow(.5f));

        }
        if (other.tag == "birakmaalani3")
        {
            birakmaAlani3 = true;
            DropPos = other.transform.position;
            StartCoroutine(DropSlow(.5f));
            gameManagement.PuanEkle();
        }
        if (other.tag == "kutu")
        {
            Item localItem = null;
            other.TryGetComponent(out localItem);

            if (other.CompareTag("kutu") && localItem.IsCollected == false)
            {
                other.transform.SetParent(HolderParent);
                other.transform.localPosition = new Vector3(0, collectedTrans.Count * .25f, .1f);
                other.transform.localRotation = Quaternion.identity;
                collectedTrans.Push(other.transform);
                localItem.IsCollected = true;
                other.GetComponent<BoxCollider>().enabled = false;
                transportingbox++;
                Debug.Log("taþýnan" + transportingbox);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        birakmaAlani1 = false;
        birakmaAlani2 = false;
        birakmaAlani3 = false;
    }
    IEnumerator DropSlow(float _delay = 0)
    {
        while ((birakmaAlani1 == true) || (birakmaAlani2 == true) || (birakmaAlani3 == true))
        {
            yield return new WaitForSeconds(_delay);
            if (collectedTrans.Count > 0)
            {
                Transform newItem = collectedTrans.Pop();
                newItem.parent = null;
                newItem.DOJump(DropPos, 2, 1, 1f).OnComplete(() =>
                newItem.DOPunchScale(new Vector3(.2f, .2f, .2f), .1f).OnComplete(() =>
                Destroy(newItem.gameObject)));
                transportingbox--;
                gameManagement.PuanEkle();
                Debug.Log("Kutu tasindi");
                kutuAlindi = false;
                //birakma = "adasda";
                if(transportingbox == 0)
                {
                    randomboxnumber = 0;
                    kutuspawnlandi = false;
                }
            }
            
            Debug.Log("bosluk sifirlandi");
        }
        yield return null;
    }
    void CreatesSpawn()
    {
        if (kutuspawnlandi == false)
        {
            randomboxnumber = Random.Range(3, 16);
            for(spawnedbox=0; spawnedbox < randomboxnumber; spawnedbox++)
            {
                Instantiate(kutu, new Vector3(bosluk, 0, 0) + Spawner.position, Quaternion.identity);
                delay = Time.time;
                bosluk = bosluk + 0.4f;
            }
            if (randomboxnumber == spawnedbox)
            {
                kutuspawnlandi = true;
            }
            spawnedbox = 0;
            bosluk = 0;
        }
    }
}
