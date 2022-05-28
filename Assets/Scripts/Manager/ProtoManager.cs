using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoManager : MonoBehaviour
{
    [SerializeField] Transform boxRoot;

    [SerializeField] BoxConfig boxConfig;
    public BoxConfig BoxConfig { get => boxConfig; }

    [SerializeField] PlayerController player;
    public PlayerController Player { get => player; }

    [SerializeField] List<Box> spawnedBoxes;
    public List<Box> SpawnedBoxes { get => spawnedBoxes; set => spawnedBoxes = value; }

    #region EVENTS
    public static event System.Action<Box> OnPlayerRangeStarted;
    public static event System.Action<Box> OnPlayerRangeExited;
    #endregion

    public static ProtoManager Instance;

    void Awake()
    {
        Instance = this;
        InitGame();
    }

    public void InitGame() {

        for (int i = 0; i < BoxConfig.boxes.Count; i++) {
            Box newBox = Instantiate(BoxConfig.boxPrefab, boxRoot);
            newBox.name = "Box" + i;
            newBox.Init(BoxConfig.boxes[i]);
            spawnedBoxes.Add(newBox);
        }
    }

    public static void RaisePlayerRangeStarted(Box box) {
        OnPlayerRangeStarted?.Invoke(box);        
    }

    public static void RaisePlayerRangeExited(Box box)
    {
        OnPlayerRangeExited?.Invoke(box);
    }



}
