using UnityEngine;
using System.Collections;

public class Intersection : Space {
   bool isEdge = false;
   bool isTraversable = false;

   void OnMouseEnter() {
      transform.GetComponent<Renderer>().material.color = Color.blue;
   }

   void OnMouseExit() {
      transform.GetComponent<Renderer>().material.color = Color.clear;
   }

   // Only applicable function call since there are no renderer components to intersection prefabs
   void OnMouseDown() {
      Debug.Log("Intersection Coordinates are (" + coordinates.x + ", " + coordinates.z + ")");
   }

   // If a piece is moved onto an edge it will be destroyed
   public bool IsEdge() {
      return isEdge;
   }

   public bool IsTraversable() {
      return isTraversable;
   }

   // While creating the board, the edges of the board will be marked
   public override void Edge() {
      isEdge = true;
      isTraversable = false;
   }

   // When a piece is selected the traversable spaces will be highlighted
   public void Traversable() {
      isTraversable = true;
   }
}
