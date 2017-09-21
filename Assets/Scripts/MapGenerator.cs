using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MapGenerator : MonoBehaviour
{

    public int width;
    public int height;

    public string seed;
    public bool useRandomSeed;

    [Range(0, 100)]
    public int randomFillPercent;

    int[,] map;
    int numberOfBiomes = 1;

    void Start()
    {
        GenerateMap();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GenerateMap();
        }
    }

    void GenerateMap()
    {
        numberOfBiomes = 1;
        map = new int[width, height];
        RandomFillMap();

        for (int i = 0; i < 5; i++)
        {
            SmoothMap();
        }
        GrowMap();
        //SetRegionTiles((int)UnityEngine.Random.Range((float)(width * .1), (float)(width - width * .1)), (int)UnityEngine.Random.Range((float)(height * .1), (float)(height - height * .1)), 2, 15000);
        //SetRegionTiles((int)UnityEngine.Random.Range((float)(width * .1), (float)(width - width * .1)), (int)UnityEngine.Random.Range((float)(height * .1), (float)(height - height * .1)), 3, 10000);
        ProcessMap();
        int borderSize = 1;
        int[,] borderedMap = new int[width + borderSize * 2, height + borderSize * 2];

        for (int x = 0; x < borderedMap.GetLength(0); x++)
        {
            for (int y = 0; y < borderedMap.GetLength(1); y++)
            {
                if (x >= borderSize && x < width + borderSize && y >= borderSize && y < height + borderSize)
                {
                    borderedMap[x, y] = map[x - borderSize, y - borderSize];
                }
                else
                {
                    borderedMap[x, y] = 1;
                }
            }
        }

        MeshGenerator meshGen = GetComponent<MeshGenerator>();
        meshGen.GenerateMesh(borderedMap, 1);
    }

    void ProcessMap()
    {

        List<List<Coord>> WallRegions = GetRegions(1);
        List<List<int>> outerEdgeRegion = new List<List<int>>();
        int wallThresholdSize = 50;
        foreach (List<Coord> wallRegion in WallRegions)
        {
            if (wallRegion.Count < wallThresholdSize)
            {
                foreach (Coord tile in wallRegion)
                {
                    map[tile.tileX, tile.tileY] = 0;
                }
            }
        }

        List<List<Coord>> RoomRegions = GetRegions(0);
        int roomThresholdSize = 700;
        foreach (List<Coord> roomRegion in RoomRegions)
        {
            if (roomRegion.Count < roomThresholdSize)
            {
                foreach (Coord tile in roomRegion)
                {
                    map[tile.tileX, tile.tileY] = 1;
                }
            }
        }
        SetRegions(0);
        for (int i = 0; i < WallRegions.Count; i++)
        {
            outerEdgeRegion.Add(new List<int>());
            
            if (WallRegions[i].Count >= wallThresholdSize)
            {
                foreach (Coord tile in WallRegions[i])
                {
                    int outerTile = GetSurroundingGroundTileTypes(tile.tileX, tile.tileY);
                    if (outerTile != 1 && !outerEdgeRegion[i].Contains(outerTile))
                    {
                        outerEdgeRegion[i].Add(outerTile);
                    }
                }
                if (outerEdgeRegion[i].Count > 1)
                {
                    foreach (Coord tile in WallRegions[i])
                    {
                        //verander 25 weer naar 1 voor normale muren
                        map[tile.tileX, tile.tileY] = 25;
                    }
                }
                else
                {
                    foreach (Coord tile in WallRegions[i])
                    {
                        //verander 26 weer naar 1 voor normale muren
                        map[tile.tileX, tile.tileY] = 26;
                    }
                }
            }
        }
        for (int i = 0; i < outerEdgeRegion.Count; i++)
        {
            for (int j = 0; j < outerEdgeRegion[i].Count; j++)
            {
                Debug.Log("outeredge tileGroup:" + i + " tileNmr:" + j + " value:" + outerEdgeRegion[i][j]);
            }
            //Debug.Log("outeredge tile: " + i + " value: "+ outerEdgeRegion[i]);
        }
    }

    List<List<Coord>> GetRegions(int tileType)
    {
        List<List<Coord>> regions = new List<List<Coord>>();
        int[,] mapFlags = new int[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (mapFlags[x, y] == 0 && map[x, y] == tileType)
                {
                    List<Coord> newRegion = GetRegionTiles(x, y, 10000);
                    regions.Add(newRegion);

                    foreach (Coord tile in newRegion)
                    {
                        mapFlags[tile.tileX, tile.tileY] = 1;

                    }
                }
            }
        }
        return regions;
    }
    List<List<Coord>> SetRegions(int tileType)
    {
        List<List<Coord>> regions = new List<List<Coord>>();
        int[,] mapFlags = new int[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (mapFlags[x, y] == 0 && map[x, y] == tileType)
                {
                    List<Coord> newRegion = GetRegionTiles(x, y, UnityEngine.Random.Range(15000, 30000));
                    if (newRegion.Count > 2000)
                    {
                        numberOfBiomes++;
                        regions.Add(newRegion);
                        //int index = 0;
                        foreach (Coord tile in newRegion)
                        {
                            //index ++;
                            mapFlags[tile.tileX, tile.tileY] = 1;
                            //if (index > 9000)
                            //{
                            //				map[tile.tileX, tile.tileY] = 1;
                            //}
                            //else
                            //{
                            map[tile.tileX, tile.tileY] = numberOfBiomes;
                            //}

                        }
                    }
                    else
                    {
                        foreach (Coord tile in newRegion)
                        {
                            map[tile.tileX, tile.tileY] = 1;

                        }
                    }
                }
            }
        }
        return regions;
    }
    List<Coord> SetRegionTiles(int startX, int startY, int biomeNumber, int limit = 1000000)
    {
        List<Coord> tiles = new List<Coord>();
        int[,] mapFlags = new int[width, height];
        int tileType = 0;
        map[startX, startY] = biomeNumber;
        Queue<Coord> queue = new Queue<Coord>();
        queue.Enqueue(new Coord(startX, startY));
        mapFlags[startX, startY] = 1;
        int lowestX = width;
        int highestX = 0;
        int lowestY = height;
        int highestY = 0;

        while (queue.Count > 0 && tiles.Count < limit)
        {
            Coord tile = queue.Dequeue();
            tiles.Add(tile);
            for (int x = tile.tileX - 1; x <= tile.tileX + 1; x++)
            {
                for (int y = tile.tileY - 1; y <= tile.tileY + 1; y++)
                {
                    if (IsInMapRange(x, y) && (y == tile.tileY || x == tile.tileX))
                    {
                        if (mapFlags[x, y] == 0 && map[x, y] == tileType)
                        {
                            float distanceFromCenter = Vector2.Distance(new Vector2(x, y), new Vector2(startX, startY));
                            if (lowestX > x)
                            {
                                lowestX = x;
                            }
                            if (highestX < x)
                            {
                                highestX = x;
                            }
                            if (lowestY > y)
                            {
                                lowestY = y;
                            }
                            if (highestY < y)
                            {
                                highestY = y;
                            }
                            if (distanceFromCenter < Mathf.Sqrt(limit) * 0.5)
                            {
                                map[x, y] = biomeNumber;
                                if (distanceFromCenter > 0.4 * Mathf.Sqrt(limit))
                                {
                                    map[x, y] = 1;
                                }
                                if (y > highestY * 0.9f)
                                {
                                    map[x, y] = biomeNumber;
                                }
                            }
                            mapFlags[x, y] = 1;
                            queue.Enqueue(new Coord(x, y));
                        }
                    }
                }
            }
        }
        return tiles;
    }
    List<Coord> GetRegionTiles(int startX, int startY, int size)
    {
        List<Coord> tiles = new List<Coord>();
        int[,] mapFlags = new int[width, height];
        int tileType = map[startX, startY];
        Queue<Coord> queue = new Queue<Coord>();
        queue.Enqueue(new Coord(startX, startY));
        mapFlags[startX, startY] = 1;

        while (queue.Count > 0)
        {
            Coord tile = queue.Dequeue();
            tiles.Add(tile);
            if (tiles.Count < size)
            {
                for (int x = tile.tileX - 1; x <= tile.tileX + 1; x++)
                {
                    for (int y = tile.tileY - 1; y <= tile.tileY + 1; y++)
                    {
                        if (IsInMapRange(x, y) && (y == tile.tileY || x == tile.tileX))
                        {
                            if (mapFlags[x, y] == 0 && map[x, y] == tileType)
                            {

                                mapFlags[x, y] = 1;
                                queue.Enqueue(new Coord(x, y));
                            }
                        }
                    }
                }
            }
        }
        return tiles;
    }

    bool IsInMapRange(int x, int y)
    {
        return x >= 0 && x < width && y >= 0 && y < height;
    }

    void RandomFillMap()
    {
        if (useRandomSeed)
        {
            seed = Time.time.ToString();
        }

        System.Random pseudoRandom = new System.Random(seed.GetHashCode());

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                {
                    map[x, y] = 1;
                }
                else
                {
                    map[x, y] = (pseudoRandom.Next(0, 100) < randomFillPercent) ? 1 : 0;
                }
            }
        }
    }

    void SmoothMap()
    {

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int neighbourWallTiles = GetSurroundingWallCount(x, y);

                if (neighbourWallTiles > 4)
                    map[x, y] = 1;
                else if (neighbourWallTiles < 4)
                    map[x, y] = 0;

            }
        }
    }

    private void GrowMap()
    {
        List<Coord> regionEdgeTiles = new List<Coord>();
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int neighbourWallTiles = GetSurroundingWallCount(x, y);
                if (neighbourWallTiles > 0 && map[x, y] == 0)
                {
                    regionEdgeTiles.Add(new Coord(x, y));
                }

            }
        }
        Debug.Log(regionEdgeTiles.Count);
        foreach (Coord tile in regionEdgeTiles)
        {
            //map[tile.tileX, tile.tileY] = 5;
            ClearSurroundingWalls(tile.tileX, tile.tileY);
        }
    }

    void ClearSurroundingWalls(int gridX, int gridY, int range = 1)
    {
        for (int neighbourX = gridX - range; neighbourX <= gridX + range; neighbourX++)
        {
            for (int neighbourY = gridY - range; neighbourY <= gridY + range; neighbourY++)
            {
                if (IsInMapRange(neighbourX, neighbourY))
                {
                    if (neighbourX != gridX || neighbourY != gridY)
                    {
                        if (map[gridX, gridY] == 0)
                        {
                            map[neighbourX, neighbourY] = 0;
                        }
                    }
                }
            }
        }

    }
    int GetSurroundingWallCount(int gridX, int gridY, int range = 1)
    {
        int wallCount = 0;
        for (int neighbourX = gridX - range; neighbourX <= gridX + range; neighbourX++)
        {
            for (int neighbourY = gridY - range; neighbourY <= gridY + range; neighbourY++)
            {
                if (IsInMapRange(neighbourX, neighbourY))
                {
                    if (neighbourX != gridX || neighbourY != gridY)
                    {
                        if (map[neighbourX, neighbourY] < 2)
                            wallCount += map[neighbourX, neighbourY];
                    }
                }
                else
                {
                    wallCount++;
                }
            }
        }

        return wallCount;
    }
    int GetSurroundingGroundTileTypes(int gridX, int gridY, int range = 1)
    {
        int tileType = -1;
        for (int neighbourX = gridX - range; neighbourX <= gridX + range; neighbourX++)
        {
            for (int neighbourY = gridY - range; neighbourY <= gridY + range; neighbourY++)
            {
                if (IsInMapRange(neighbourX, neighbourY))
                {
                    if (neighbourX != gridX || neighbourY != gridY)
                    {
                        //Debug.Log(map[neighbourX, neighbourY]);
                        if (map[neighbourX, neighbourY] != -1)
                        {
                            tileType = (map[neighbourX, neighbourY]);
                        }
                    }
                }
            }
        }

        return tileType;
    }


    struct Coord
    {
        public int tileX;
        public int tileY;

        public Coord(int x, int y)
        {
            tileX = x;
            tileY = y;
        }
    }

    struct Biome
    {
        public int biomeType;
        public int size;

        public Biome(int biometype, int size_)
        {
            biomeType = biometype;
            size = size_;
        }
    }

    void OnDrawGizmos()
    {
        Color orange = new Color(255, 165, 0);
        if (map != null)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (map[x, y] == 0)
                        Gizmos.color = Color.white;
                    if (map[x, y] == 1)
                        Gizmos.color = Color.black;
                    if (map[x, y] == 2)
                        Gizmos.color = Color.green;
                    if (map[x, y] == 3)
                        Gizmos.color = Color.yellow;
                    if (map[x, y] == 4)
                        Gizmos.color = Color.blue;
                    if (map[x, y] == 5)
                        Gizmos.color = Color.cyan;
                    if (map[x, y] == 6)
                        Gizmos.color = Color.magenta;
                    if (map[x, y] == 7)
                        Gizmos.color = Color.red;
                    if (map[x, y] == 8)
                        Gizmos.color = Color.white;
                    if (map[x, y] == 9)
                        Gizmos.color = Color.gray;
                    if (map[x, y] == 10)
                        Gizmos.color = Color.red;
                    if (map[x, y] == 11)
                        Gizmos.color = Color.green;
                    if (map[x, y] == 12)
                        Gizmos.color = Color.yellow;
                    if (map[x, y] == 13)
                        Gizmos.color = Color.blue;
                    if (map[x, y] == 14)
                        Gizmos.color = Color.cyan;
                    if (map[x, y] == 15)
                        Gizmos.color = Color.magenta;
                    if (map[x, y] == 16)
                        Gizmos.color = Color.gray;
                    if (map[x, y] == 17)
                        Gizmos.color = Color.red;

                    if (map[x, y] == 25)
                        Gizmos.color = Color.yellow;
                    if (map[x, y] == 26)
                        Gizmos.color = Color.magenta;

                    if (map[x, y] == 300)
                        Gizmos.color = orange;

                    Vector3 pos = new Vector3(-width / 2 + x + .5f, 0, -height / 2 + y + .5f);
                    Gizmos.DrawCube(pos, Vector3.one);
                }
            }
        }
    }
}