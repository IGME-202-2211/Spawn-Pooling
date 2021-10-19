using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    AstroidSpawnManager astroidManager;

    public int perClickCount = 1;

    Vector2 input;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(input.y > 0)
        {
            ++perClickCount;
        }
        else if(input.y < 0)
        {
            --perClickCount;

            if(perClickCount <= 0)
            {
                perClickCount = 1;
            }
        }
    }

    public void OnClickChange(InputValue value)
    {
        input = value.Get<Vector2>();
    }

    public void OnFire(InputValue value)
    {
        //  Created any number of astorids per click
        //      Using this to quickly show lag spikes
        for (int i = 0; i < perClickCount; ++i)
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

    public void OnToggleDestroy(InputValue value)
    {
        astroidManager.useDestory = !astroidManager.useDestory;
    }
}
