using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    AstroidSpawnManager astroidManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnFire(InputValue value)
    {
        //  Get a new astroid
        Astroid newAstroid = astroidManager.GetAstroid();

        //  Set the astroid's position to the current mouse pos
        Vector3 clickPos = Mouse.current.position.ReadValue();
        clickPos = Camera.main.ScreenToWorldPoint(clickPos);
        clickPos.z = 0;
        newAstroid.transform.position = clickPos;

        //  Set a random direction for the new astoid


        //  Turn the new astroid on
        newAstroid.gameObject.SetActive(true);
    }
}
