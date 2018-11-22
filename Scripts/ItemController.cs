using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour {

	public LayerMask _itemLayer;
	public Transform _uiInformation;

	private bool activeObj;

	// Use this for initialization
	void Start () {
		_uiInformation.gameObject.SetActive(false);
		activeObj = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp(0)) {
			Transform clickingOnItem = GetClickingOnItem();
			ShowInformation(clickingOnItem);
		}
	}

	Transform GetClickingOnItem() {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Transform clickingOnItem = null;
		if (Physics.Raycast(ray, out hit, 50)) {
			clickingOnItem = hit.transform;
		}
		return clickingOnItem;
	}

	void ShowInformation(Transform item) {
		var component = _uiInformation.gameObject.transform.Find("DataPanel").gameObject;
		var textComponent = component.transform.Find("TextData").gameObject;
		var textContent = textComponent.GetComponent<UnityEngine.UI.Text>();
		if (!activeObj) {
			var itemObject = item.gameObject.GetComponent<ItemData>();
			if (itemObject != null) {
				textContent.text = itemObject.description;
				_uiInformation.gameObject.SetActive(true);
				activeObj = true;
			}
		} else {
			textContent.text = "";
			activeObj = false;
			_uiInformation.gameObject.SetActive(false);
		}
	}
}
