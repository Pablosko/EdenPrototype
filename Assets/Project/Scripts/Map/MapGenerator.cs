using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int floor;
    public int maxRooms;
    public int lootRooms;
    public int minLootRange;
    public int maxLootRange;

    int currentRoom;
    List<int> lootRoomsIndexs = new List<int>();
    List<GameObject> CurrentFloorRoomsPrefabs = new List<GameObject>();
    List<GameObject> CurrentFloorLootRoomsPrefabs = new List<GameObject>();
    List<Room> InstanciatedRooms = new List<Room>();
    Transform spawnTransform;
    List<int> indexs;
    void Start()
    {
        NextFloor();
        MoveRoom(0);
    }

    void Update()
    {
    }
    void NextFloor() 
    {
        floor++;
        GetRooms();
        GenLootRoomsIndexs();
        GenRooms();
    }
    int GetLootRoomIndex() 
    {
        return (int)Random.Range(minLootRange, maxLootRange);
    }
    void GetRooms() 
    {
        spawnTransform = new GameObject("---" + floor + "---").transform;
        spawnTransform.SetParent(transform.Find("Floors"));
        //set cameraconfiner


        CurrentFloorRoomsPrefabs = new List<GameObject>();
        CurrentFloorRoomsPrefabs.AddRange(Resources.LoadAll<GameObject>("Prefabs/Floors/"+ floor +"/Rooms"));

        CurrentFloorLootRoomsPrefabs = new List<GameObject>();
        CurrentFloorLootRoomsPrefabs.AddRange(Resources.LoadAll<GameObject>("Prefabs/Floors/" + floor + "/LootRooms"));
    }
    void GenLootRoomsIndexs() 
    {
        lootRoomsIndexs = new List<int>();
        for (int i = 0; i < lootRooms; i++)
        {
            int index = GetLootRoomIndex();
            while (lootRoomsIndexs.Contains(index))
            {
                index = GetLootRoomIndex();
            }
            lootRoomsIndexs.Add(index);
        }
    }
    void GenRooms() 
    {
        indexs = new List<int>();
        InstanciatedRooms = new List<Room>();
        for (int i = 0; i < maxRooms; i++)
        {
            if (lootRoomsIndexs.Contains(i))
            {
                InstantiteAndSave(CurrentFloorLootRoomsPrefabs,false);
                continue;
            }

            InstantiteAndSave(CurrentFloorRoomsPrefabs,true);

        }
    }
    public GameObject GetRoom(List<GameObject> list,int index) 
    {
        return list[index];
    }
    public void InstantiteAndSave(List<GameObject> rooms,bool storeIndexs) 
    {
        int nextRoomIndex = GetRandomRoomIndexWithParameters(ref rooms);
        if(storeIndexs)
            indexs.Add(nextRoomIndex);
        GameObject instantiteRoom = Instantiate(GetRoom(rooms, nextRoomIndex), spawnTransform);
        instantiteRoom.SetActive(false);
        InstanciatedRooms.Add(instantiteRoom.GetComponent<Room>());
        instantiteRoom.name = "Room "+InstanciatedRooms.Count;
    }
    public void MoveRoom(int addIndex) 
    {
        GameController.Instance.hud.PlayFadeOffStartingBack(1);

        InstanciatedRooms[currentRoom].gameObject.SetActive(false);
        currentRoom += addIndex;
        InstanciatedRooms[currentRoom].gameObject.SetActive(true);
        SetCameraLimits();

        GameController.Instance.player.transform.position = InstanciatedRooms[currentRoom].playerSpawnPos;
        GameController.Instance.player.charDash.InterruptAllDashes();
    }
    public void SetCameraLimits() 
    {
        GameController.Instance.cameraConfiner.m_BoundingShape2D = InstanciatedRooms[currentRoom].cameraLimits;
    }
    public Room GetCurrentRoom() 
    {
        return InstanciatedRooms[currentRoom];
    }
    public int GetRandomRoomIndexWithParameters(ref List<GameObject> rooms) 
    {
        int nextRoomIndex;
        do
        {
            nextRoomIndex = Random.Range(0, rooms.Count);

        } while (!Instantiable(nextRoomIndex,rooms[nextRoomIndex].GetComponent<Room>(), ref rooms));
        return nextRoomIndex;
    }
    public bool Instantiable(int index,Room room, ref List<GameObject> rooms) 
    {
        if (TimesSpawnedInRoom(index) >= room.maxTimesPerFloor) 
        {
            rooms.Remove(room.gameObject);
            return false;
        }
        if (TimesSpawnedInaRowRoom(index) > room.maxTimesInaRow) 
        {
            return false;
        }

        return true;
    }
    public int TimesSpawnedInRoom(int index) 
    {
        int times = 0;
        for (int i = 0; i < indexs.Count; i++)
        {

            if (indexs[i] == index)
                times++;
        }
        return times;
    }
    public int TimesSpawnedInaRowRoom(int index)
    {
        int times = 0;
        int arrayIndex = indexs.Count;
        for (int i = 0; i < indexs.Count; i++)
        {
            arrayIndex--;
            if (arrayIndex < 0)
                return times;
            if (indexs[arrayIndex] == index)
                times++;
            else
               return times;
        }
        return times;
    }

}
