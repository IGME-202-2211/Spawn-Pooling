using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidSpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject astroidPrefab;

    [SerializeField]
    int initSpawnCount;

    public bool useDestory = false;

    public int createdCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < initSpawnCount; ++i)
        {
            CreateAstroid();
        }
    }

    /// <summary>
    /// Create a new object and add it to the spawn pool
    /// </summary>
    /// <returns>A jreference to the Astroid script on the new object</returns>
    Astroid CreateAstroid()
    {
        ++createdCount;

        Astroid newAstroid = Instantiate(astroidPrefab, transform, false).GetComponent<Astroid>();

        newAstroid.manager = this;

        newAstroid.gameObject.SetActive(false);

        return newAstroid;
    }

    public Astroid GetAstroid()
    {
        //  Only get the first in the line
        Astroid currentAstroid = transform.GetChild(0).GetComponent<Astroid>();

        //  Check if all the objects in pool are in use
        if(currentAstroid == null || currentAstroid.gameObject.activeInHierarchy)
        {
            currentAstroid = CreateAstroid();
        }

        //  Move it to the end of the line
        currentAstroid.transform.SetAsLastSibling();

        return currentAstroid;
    }

    public void ReturnAstroid(Astroid usedAstroid)
    {
        if (useDestory)
        {
            Destroy(usedAstroid.gameObject);
        }
        else
        {
            //  Reset the transform values
            usedAstroid.transform.position = transform.position;
            usedAstroid.transform.rotation = Quaternion.identity;

            //  Turn the object off
            usedAstroid.gameObject.SetActive(false);

            //  Move it to the front of the line
            usedAstroid.transform.SetAsFirstSibling();
        }
    }
}
