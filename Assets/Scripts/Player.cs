using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
   public const int PIECE_AMOUNT = 4;
   public Piece[] pieces;
}

public class HumanPlayer : Player {
   void Start() {
      pieces = new PlayerPiece[PIECE_AMOUNT];

      for (int i = 0; i < PIECE_AMOUNT; i++)
         pieces[i] = new PlayerPiece();
   }

   void Update() {

   }
}

public class AIPlayer : Player {
   void Start() {
      pieces = new EnemyPiece[PIECE_AMOUNT];

      for (int i = 0; i < PIECE_AMOUNT; i++)
         pieces[i] = new EnemyPiece();
   }

   void Update() {

   }
}