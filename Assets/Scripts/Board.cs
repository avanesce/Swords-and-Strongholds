using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Board : MonoBehaviour {
   // Board object
   public Board GameBoard;

   // Editor prefab references
   public GameObject TilePrefab;
   public GameObject IntersectionPrefab;

   // Board variables
   const int Board_X = 6;
   const int Board_Y = 8;

   // Tile and Intersection portions both comprise of the board
   List<List<Tile>> TileBoard = new List<List<Tile>>();
   List<List<Intersection>> IntersectionBoard = new List<List<Intersection>>();

   // Use this for initialization
   void Start() {
      GenerateTiles();
      GenerateIntersections();
   }

   // Update is called once per frame
   void Update() {

   }

   void GenerateTiles() {
      // Create the columns of tiles
      for (int i = 0; i < Board_X; i++) {
         // Rows of tiles
         List<Tile> TileBoardRows = new List<Tile>();

         // Fill the rows 
         for (int j = 0; j < Board_Y; j++) {
            Tile _tile = ((GameObject)Instantiate(
                            TilePrefab,
                            new Vector3(i - Mathf.Floor(Board_X / 2) + 3, 0, -j + Mathf.Floor(Board_X / 2)),
                            Quaternion.Euler(0, 0, 0))).GetComponent<Tile>();
                // Creates their coordinates
                _tile.coordinates = new Vector3(i, 0, j);
                // Add them to the rows
                TileBoardRows.Add(_tile);
         }
         // Add the rows to the columns 
         TileBoard.Add(TileBoardRows);
      }
   }

   // Same as Generating tiles
   void GenerateIntersections() {
      for (int i = 0; i < Board_X + 1; i++) {
         List<Intersection> IntersectionBoardRows = new List<Intersection>();

         for (int j = 0; j < Board_Y + 1; j++) {
                Intersection _intersection = ((GameObject)Instantiate(
                                            IntersectionPrefab,
                                            new Vector3(i - Mathf.Floor(Board_X / 2) + 2.5f, 0.455f, -j + Mathf.Floor(Board_X / 2) + 0.5f),
                                            Quaternion.Euler(0, 0, 0))).GetComponent<Intersection>();
                if (i == 0 || i == 6 || j == 0 || j == 8)
                {
                    //_intersection.GetComponentInChildren<MeshRenderer>().enabled = false;
                }
                _intersection.coordinates = new Vector3(i, 0, j);
                _intersection.transform.GetComponent<Renderer>().material.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                IntersectionBoardRows.Add(_intersection);
                
         }
         IntersectionBoard.Add(IntersectionBoardRows);
      }
   }
}