using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterList {

	string[] characters = {"Paige", "Ryan", "Steve", "Natalie", "Justin", "Cassandra"};
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

/**
* Determine if the current object is a character
*/
	public bool isInList(string character)
	{
		int pos = Array.IndexOf(characters, character);
		if (pos > -1) {
			return true;
		}
		return false;
	}
}
