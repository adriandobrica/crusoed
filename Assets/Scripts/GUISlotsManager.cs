﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GUISlotsManager : MonoBehaviour {

    int lastSelected;
    public GameObject player;
    public InventoryNew inventory;
    InfoInventoryUI selectedItemInfo;
    // Use this for initialization
    void Start () {
        lastSelected = -1;
        inventory = player.GetComponent<InventoryNew>();
        selectedItemInfo = transform.parent.GetChild(2).GetComponent<InfoInventoryUI>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // select a child slot; deselect the previously selected
    void selectChild(int position)
    {
        //int position = System.Convert.ToInt32(msgPosition);
        if (lastSelected != -1)
        {
            transform.GetChild(lastSelected).GetComponent<GUISlotInventory>().deselect();
			selectedItemInfo.clearInfo ();
        }

        if (lastSelected != position)
        {
            transform.GetChild(position).GetComponent<GUISlotInventory>().select();
            lastSelected = position;

            if (position < inventory.stacks.Count)
            {
                Stack selectedStack = inventory.stacks[position];
                Item selectedItem = selectedStack.item;

                string itemInfo = selectedItem.name + "\n" + selectedItem.description;
                selectedItemInfo.updateSelectedItemInfo(selectedStack.size, itemInfo);
            }

            else
            {
                selectedItemInfo.updateSelectedItemInfo(0, "");
            }
        }

        else
        {
            lastSelected = -1;
			selectedItemInfo.clearInfo ();
        }
    }

	public void deselectAll()
	{
		if (lastSelected != -1)
			transform.GetChild (lastSelected).GetComponent<GUISlotInventory> ().deselect ();
		selectedItemInfo.clearInfo ();
	}

    // match each slot with its corresponding icon
    public void mapIcons(List<Stack> inventory)
    {
        int position = 0;
        foreach(Stack stackItem in inventory)
        {
            transform.GetChild(position).GetComponent<GUISlotInventory>().setSprite(stackItem.item.icon);
            position++;
        }

        for(int i = position; i <= 20; i++)
        {
            transform.GetChild(position).GetComponent<GUISlotInventory>().setDefaultSprite();
        }
    }

    public int getLastSelected()
    {
        return lastSelected;
    }
}
