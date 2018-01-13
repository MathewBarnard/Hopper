using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using Assets.Source.Overworld.Map;
using Assets.Source.Overworld.Map.MapEditor;

public class HexGridGenerator : MonoBehaviour {

    /// <summary>
    /// Generate a HexGrid by providing a filename to be read, and then generated from.
    /// </summary>
    /// <param name="grid"></param>
    /// <param name="filename"></param>
    public static void GenerateFromFile(HexGrid grid, string filename) {

        List<HexMapCsv> file = HexMapFileSaver.ReadFile(filename);

        // Create a throwaway tile so that we can get the dimensions of it.
        Vector2 spriteSize = GetTileSize();

        foreach (HexMapCsv row in file) {

            if(row.TileType != TileType.Empty) {
                Debug.Log("HELLO");
            }

            int x = row.X;
            int z = row.Z;

            float mod = z % 2;

            Vector2 position = new Vector2((x * spriteSize.x) + ((spriteSize.x * 0.5f) * mod), (z * spriteSize.y) * 0.75f);

            grid.Tiles.Add(HexTile.Create(grid, row.TileType, position, new Vector2(x, z)));
        }
    }

    /// <summary>
    /// Generate a HexGrid using a file that has already been read.
    /// </summary>
    /// <param name="grid"></param>
    /// <param name="file"></param>
    public static void GenerateFromFile(HexGrid grid, List<HexMapCsv> file) {

        // Create a throwaway tile so that we can get the dimensions of it.
        Vector2 spriteSize = GetTileSize();

        foreach (HexMapCsv row in file) {

            int x = row.X;
            int z = row.Z;

            float mod = x % 2;

            Vector2 position = new Vector2((x * spriteSize.x) * 0.75f, (z * spriteSize.y) + ((spriteSize.y * 0.5f) * mod));

            grid.Tiles.Add(HexTile.Create(grid, row.TileType, position, new Vector2(x, z)));
        }

        grid.StoreToArray();

        SetNeighbours(grid);
    }

    public static void GenerateDefault(HexGrid grid, int width, int height) {

        // Create a throwaway tile so that we can get the dimensions of it.
        Vector2 spriteSize = GetTileSize();

        // Z
        for (int x = 0; x < width; x++) {

            // X
            for (int z = 0; z < height; z++) {

                float mod = x % 2;

                Vector2 position = new Vector2((x * spriteSize.x) * 0.75f, (z * spriteSize.y) + ((spriteSize.y * 0.5f) * mod));

                grid.Tiles.Add(HexTile.Create(grid, TileType.Empty, position, new Vector2(x, z)));
            }
        }
    }

    private static void SetNeighbours(HexGrid grid) {
        foreach(HexTile tile in grid.Tiles) {

            tile.SetNeighbours(grid.GetAdjacentNodes(tile));
        }
    }

    private static Vector2 GetTileSize() {
        // Create a throwaway tile so that we can get the dimensions of it.
        GameObject tile = Instantiate((GameObject)Resources.Load("Prefabs/Overworld/Map/BaseTile"), Vector2.zero, Quaternion.identity);
        SpriteRenderer renderer = tile.GetComponent<SpriteRenderer>();
        Vector2 spriteSize = renderer.sprite.bounds.size;
        Vector2 scale = tile.transform.localScale;
        Destroy(tile);
        return new Vector2(spriteSize.x * scale.x, spriteSize.y * scale.y);
    }

}