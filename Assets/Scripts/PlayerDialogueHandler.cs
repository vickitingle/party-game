using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class PlayerDialogueHandler : MonoBehaviour {

  [Header("Optional")]
  public TextAsset scriptToLoad;
  public CharacterList chars;
  public Character currentCharacter;

  // Use this for initialization
	void Start ()
  {
    if (scriptToLoad != null) {
        FindObjectOfType<Yarn.Unity.DialogueRunner>().AddScript(scriptToLoad);
    }
    chars = new CharacterList();
	}

  void OnCollisionEnter (Collision col)
  {
    // Have we interacted with a character?
    var currentObject = col.gameObject;
    var objectName = currentObject.name;
    if (chars.isInList(objectName)) {
     currentCharacter = currentObject.GetComponent<Character>();
}
 }

	// Update is called once per frame
	void Update () {
    if (Input.GetKeyDown("e") && currentCharacter != null)
    {
        FindObjectOfType<DialogueRunner> ().StartDialogue (currentCharacter.nextNode);
    }
	}
}
