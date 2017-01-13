using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	const int HAND_SIZE = 3;
    bool gameWon = false;
    bool player1 = true;

	Board board;
	Piece[] playerPieces;
	Card[] playerHand;
	Piece[] enemyPieces;
	Card[] enemyHand;
    Deck deck;

    public Text turnText;

	//Use this for initialization
	void Start () {
        //Board Setup
        board = new Board();
        Debug.Log("Board has been created");
        //Deck and Hand Setup
        deck = new Deck();
        Debug.Log("Deck has been created");
        playerHand = new Card[HAND_SIZE];
        enemyHand = new Card[HAND_SIZE];
        /*for (int i = 0; i < HAND_SIZE; i++){
            playerHand[i] = deck.DrawCard();
            enemyHand[i] = deck.DrawCard();
        }*/
        turnText.text = "Player 1's turn...";
        //Piece Placement Phase

        //Gameplay Phase
        
        while (!gameWon){
            //Player 1's turn
            if (player1)
            {
                turnText.text = "Player 1's turn...";
                player1 = false;
            }
            //Player 2's turn
            else
            {
                turnText.text = "Player 2's turn...";
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
