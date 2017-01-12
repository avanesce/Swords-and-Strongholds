using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	const int HAND_SIZE = 3;

	Board board;
	Piece[] playerPieces;
	Card[] playerHand;
	Piece[] enemyPieces;
	Card[] enemyHand;
    Deck deck;

	// Use this for initialization
	void Start () {
        //Board Setup
        board = new Board();
        //Deck and Hand Setup
        deck.MakeDeck();
        playerHand = new Card[HAND_SIZE];
        enemyHand = new Card[HAND_SIZE];
        for (int i = 0; i < HAND_SIZE; i++){
            playerHand[i] = deck.DrawCard();
            enemyHand[i] = deck.DrawCard();
        }
        //
	}

   // Update is called once per frame
   void Update() {
      if (Input.GetKey(KeyCode.Escape)) {
         SceneManager.LoadScene("Esc Menu");
      }
   }
}
