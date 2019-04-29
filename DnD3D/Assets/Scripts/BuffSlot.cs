﻿using UnityEngine;
using UnityEngine.UI;

public class BuffSlot : MonoBehaviour {
    private Buff buff;
    public Image icon;
    public GameObject hoverPanel;

    public void AddBuff (Buff newBuff) {
        GetComponent<Image> ().enabled = true;
        buff = newBuff;
        icon.sprite = buff.GetIcon ();
        icon.enabled = true;
    }
    public void ClearSlot () {
        buff = null;
        GetComponent<Image> ().enabled = false;
        icon.sprite = null;
        icon.enabled = false;
    }
    public void OnMouseOver () {
        hoverPanel.GetComponent<HoverUI> ().SetPosition (gameObject.transform.position, new Vector3 (10, 6.7f, 0), buff.GetName (), buff.GetDescription ());
        hoverPanel.SetActive (true);
    }
    public void OnMouseOverP () {
        hoverPanel.GetComponent<HoverUI> ().SetPosition (gameObject.transform.position, new Vector3 (10, -6.7f, 0), buff.GetName (), buff.GetDescription ());
        hoverPanel.SetActive (true);
    }
    public void OnMouseExit () {
        hoverPanel.GetComponent<HoverUI> ().SetPositioned (false);
        hoverPanel.SetActive (false);
    }
}