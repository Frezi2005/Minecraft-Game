using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugScreen : MonoBehaviour {

    World world;
    Text text;

    float frameRate;
    float timer;

    int halfWorldSizeInVoxels;
    int halfWorldSizeInChunks;

    void Start() {
        
        world = GameObject.Find("World").GetComponent<World>();
        text = GetComponent<Text>();

        halfWorldSizeInChunks = VoxelData.WorldSizeInChunks / 2;
        halfWorldSizeInVoxels = VoxelData.WorldSizeInVoxels / 2;

    }

    void Update() {
        
        string debugText = "Minecraft Vanilla\n";
        debugText += "version: 1.0.0\n";
        debugText += frameRate + " fps\n";
        debugText += "XYZ: " + (Mathf.FloorToInt(world.player.transform.position.x) - halfWorldSizeInVoxels) + " / " + Mathf.FloorToInt(world.player.transform.position.y) + " / " + (Mathf.FloorToInt(world.player.transform.position.z) - halfWorldSizeInVoxels) + "\n";
        debugText += "Chunk: " + (world.playerChunkCoord.x - halfWorldSizeInChunks) + " / " + (world.playerChunkCoord.z - halfWorldSizeInChunks) + "\n";


        text.text = debugText;

        if (timer > 1f) {

            frameRate = (int)(1f / Time.unscaledDeltaTime);
            timer = 0;

        } else 
            timer += Time.deltaTime;

    }
    
}
