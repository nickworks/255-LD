using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    [Tooltip("A reference to the scene's camera.")]
    public MainMenuCameraControl camera;

    [Tooltip("A reference to the details menu GUI.")]
    public DetailsMenu detailsMenu;

    [Tooltip("A prefab button to spawn for each level.")]
    public MainMenuButton prefabButton;

    [Tooltip("A list of all the levels to display on this screen.")]
    public LevelInfo[] levels;

    private List<MainMenuButton> bttns = new List<MainMenuButton>();
    
    EventSystem events;

    void Start() {
        events = GetComponentInChildren<EventSystem>();
        BuildMenu();
    }
    void BuildMenu() {
        foreach (LevelInfo level in levels) {
            bttns.Add(MakeButton().Init(level, () => {
                detailsMenu.Init(level);
                camera.lookAtLevelDetails = true;
            }));
        }
        bttns.Add(MakeButton().Init("Quit", () => { }));
    }
    MainMenuButton MakeButton() {
        MainMenuButton bttn = Instantiate(prefabButton, transform);

        int y = 0;
        if (bttns.Count > 0) {
            MainMenuButton lastBttn = bttns[bttns.Count - 1];
            int height = (int)lastBttn.GetSize().y;
            int position = (int)lastBttn.transform.localPosition.y;
            y = position - height - 10;
        }
        bttn.transform.localPosition = new Vector3(0, y, 0);
        return bttn;
    }

    void Update() {
        if (camera.lookAtLevelDetails) return;
        Focus();
    }
    void Focus() {
        if(events.currentSelectedGameObject == null) {
            if(bttns.Count > 0) bttns[0].Focus();
        }
    }
}
