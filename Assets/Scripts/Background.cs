using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    void Start()
    {

    }

    void Update()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        Material mat = mr.material;

        Vector2 offset = mat.mainTextureOffset;

        offset.y += Time.deltaTime / 25;

        mat.mainTextureOffset = offset;
    }
}
