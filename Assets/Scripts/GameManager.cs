using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	const int HAND_SIZE = 3;
    bool gameWon = false;
    bool player1 = true;
    //c37 10

	Board board;
	Piece[] playerPieces;
	Card[] playerHand;
	Piece[] enemyPieces;
	Card[] enemyHand;
    Deck deck;

	//Use this for initialization
	void Start () {
        //Board Setup
        board = new Board();
        //Deck and Hand Setup
        deck = new Deck();
        deck.MakeDeck();
        playerHand = new Card[HAND_SIZE];
        enemyHand = new Card[HAND_SIZE];
        for (int i = 0; i < HAND_SIZE; i++){
            playerHand[i] = deck.DrawCard();
            enemyHand[i] = deck.DrawCard();
        }
        //Piece Placement Phase

        //Gameplay Phase
        while (!gameWon){
            //Player 1's turn
            if (player1)
            {
                player1 = false;
            }
            //Player 2's turn
            else
            {
                player1 = true;
            }
        }

	}

   //Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.Escape)) {
             SceneManager.LoadScene("Esc Menu");
         }
    }
    
    // If a human player is present.
    void PlayerPhase() {

    }

    // If a AI player is present.
    void AIPhase() {

    }
}
