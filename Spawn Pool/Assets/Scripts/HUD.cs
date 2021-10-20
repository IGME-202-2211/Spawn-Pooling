using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    Text fpsLabel;
    const string k_FPS_STR = "FPS: {0}";
    [SerializeField]
    float tickTime;
    float timer = 1f;

    [SerializeField]
    Text createdLabel;

    const string k_CREATED_STR = "Created: {0}";

    [SerializeField]
    Text spawnCountLabel;
    const string k_SPAWN_COUNT_STR = "Spawned Per Click: {0}";

    [SerializeField]
    Text useDestoryLabel;
    const string k_USE_DESTORY_STR = "Use Destory: {0}";

    [SerializeField]
    AstroidSpawnManager astroidManager;

    [SerializeField]
    Player player;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0)
        {
            fpsLabel.text = string.Format(k_FPS_STR, 1f / Time.deltaTime);

            timer = tickTime;
        }

        createdLabel.text = string.Format(k_CREATED_STR, astroidManager.createdCount);

        spawnCountLabel.text = string.Format(k_SPAWN_COUNT_STR, player.perClickCount);

        useDestoryLabel.text = string.Format(k_USE_DESTORY_STR, astroidManager.useDestory.ToString());
    }
}
