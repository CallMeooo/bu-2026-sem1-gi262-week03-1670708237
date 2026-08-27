using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
public class OOPMapGenerator : MonoBehaviour
{
    [Header("Set MapGenerator")]
    public int X;
    public int Y;

    [Header("Set Player")]
    public OOPPlayer player;
    public Vector2Int playerStartPos;

    [Header("Set Exit")]
    public OOPExit Exit;

    [Header("Set Prefab")]
    public GameObject[] floorsPrefab;
    public GameObject[] wallsPrefab;
    public GameObject[] demonWallsPrefab;
    public GameObject[] itemsPrefab;

    [Header("Set Transform")]
    public Transform floorParent;
    public Transform wallParent;
    public Transform itemPotionParent;

    [Header("Set object Count")]
    public int obsatcleCount;
    public int itemPotionCount;

    public string[,] mapdata;

    public OOPWall[,] walls;
    public OOPItemPotion[,] potions;

    // block types ...
    [HideInInspector]
    public string empty = "";
    [HideInInspector]
    public string demonWall = "demonWall";
    [HideInInspector]
    public string potion = "potion";
    [HideInInspector]
    public string bonuesPotion = "bonuesPotion";
    [HideInInspector]
    public string exit = "exit";
    [HideInInspector]
    public string playerOnMap = "player";

    // Start is called before the first frame update
    void Start()
    {
        mapdata = new string[X, Y];
        for (int x = -1; x < X + 1; x++)
        {
            for (int y = -1; y < Y + 1; y++)
            {
                if (x == -1 || x == X || y == -1 || y == Y)
                {
                    int r = Random.Range(0, wallsPrefab.Length);
                    GameObject obj = Instantiate(wallsPrefab[r], new Vector3(x, y, 0), Quaternion.identity);
                    obj.transform.parent = wallParent;
                    obj.name = "Wall_" + x + ", " + y;
                }
                else
                {
                    int r = Random.Range(0, floorsPrefab.Length);
                    GameObject obj = Instantiate(floorsPrefab[r], new Vector3(x, y, 1), Quaternion.identity);
                    obj.transform.parent = floorParent;
                    obj.name = "floor_" + x + ", " + y;
                    mapdata[x, y] = empty;
                }
            }
        }

        player.mapGenerator = this;
        player.positionX = playerStartPos.x;
        player.positionY = playerStartPos.y;
        player.transform.position = new Vector3(playerStartPos.x, playerStartPos.y, -0.1f);
        mapdata[playerStartPos.x, playerStartPos.y] = playerOnMap;

        walls = new OOPWall[X, Y];
        int count = 0;

        int preventInfiniteLoop = 100;
        while (count < obsatcleCount)
        {
            if (--preventInfiniteLoop < 0) break;
            int x = Random.Range(0, X);
            int y = Random.Range(0, Y);
            if (mapdata[x, y] == empty)
            {
                PlaceDemonWall(x, y);
                count++;
            }
        }

        potions = new OOPItemPotion[X, Y];
        count = 0;
        preventInfiniteLoop = 100;
        while (count < itemPotionCount)
        {
            if (--preventInfiniteLoop < 0) break;
            int x = Random.Range(0, X);
            int y = Random.Range(0, Y);
            if (mapdata[x, y] == empty)
            {
                PlaceItem(x, y);
                count++;
            }
        }
        mapdata[X - 1, Y - 1] = exit;
        Exit.transform.position = new Vector3(X - 1, Y - 1, 0);
    }

    public string GetMapData(float x, float y)
    {
        if (x >= X || x < 0 || y >= Y || y < 0) return "invalid";
        return mapdata[(int)x, (int)y];
    }

    public void PlaceItem(int x, int y)
    {
        int r = Random.Range(0, itemsPrefab.Length);
        GameObject obj = Instantiate(itemsPrefab[r], new Vector3(x, y, 0), Quaternion.identity);
        obj.transform.parent = itemPotionParent;
        mapdata[x, y] = potion;
        potions[x, y] = obj.GetComponent<OOPItemPotion>();
        potions[x, y].positionX = x;
        potions[x, y].positionY = y;
        potions[x, y].mapGenerator = this;
        obj.name = $"Item_{potions[x, y].Name} {x}, {y}";
    }

    public void PlaceDemonWall(int x, int y)
    {
        int r = Random.Range(0, demonWallsPrefab.Length);
        GameObject obj = Instantiate(demonWallsPrefab[r], new Vector3(x, y, 0), Quaternion.identity);
        obj.transform.parent = wallParent;
        mapdata[x, y] = demonWall;
        walls[x, y] = obj.GetComponent<OOPWall>();
        walls[x, y].positionX = x;
        walls[x, y].positionY = y;
        walls[x, y].mapGenerator = this;
        obj.name = $"DemonWall_{walls[x, y].Name} {x}, {y}";
    }
}