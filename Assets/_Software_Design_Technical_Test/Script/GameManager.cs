using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Made by Julien Cagnoncle

public class GameManager : MonoBehaviour
{
	// Reference to the unique instance of this script
	private static GameManager instance = default;

    // Start is called before the first frame update
    void Start()
    {
        
		// Checker of the unicity of the instance
        if(instance==null)instance = this;
        else Destroy(this);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
}
