﻿using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {

	public virtual void PlayCard() {
		// Specific function of what a card will do when played
	}
}

public class SwordCard :Card {
	void Start () {

	}

	void Update () {

	}

	// Sword card will allow the player to move in any direction
	// THEN move either left or right based on first direction
	// Ex: If they move up or down first then they can move right or left
	// OR if they move left or right first then they can move up or down
	public override void PlayCard(Piece piece) {
		Point location = piece.getPosition();
		
		//value to determine the first direction moved
		int xLocation = location.GetX();
		
		//Array of possible spaces to move to
		Point[] possible = new Point[4];
		
		//moving rows shifts TWO indices, cols only shifts ONE
		possible[0] = new point(location.GetX()+2, location.GetY());	
		possible[1] = new point(location.GetX(), location.GetY()+1);	
		possible[2] = new point(location.GetX()-2, location.GetY());
		possible[3] = new point(location.GetX(), location.GetY()-1);
		
		//TODO Receive coordinates from board -> (newX, newY)
		location = location;//returned location -- replace location
		piece.SetPosition(location.GetX(), location.GetY());//need this to redraw the piece
		//set 2 possible locations to out of bounds to avoid comparison
		possible[2].SetPoint(-1, -1);
		possible[3].SetPoint(-1, -1);
		
		if(xLocation != location.GetX()){//x changed after first move
			possible[0] = new point(location.GetX(), location.GetY()+1);
			possible[1] = new point(location.GetX(), location.GetY()-1);
		}
		else{//x did not change after first move
			possible[0] = new point(location.GetX()+2, location.GetY());
			possible[1] = new point(location.GetX()-2, location.GetY());
		}
		location = location;//returned location -- replace location
		piece.SetPosition(location.GetX(), location.GetY());
		
	}
}

public class StrongholdCard :Card {
	void Start () {

	}

	void Update () {

	}

	// Stronghold card will place the piece in one of the four surrounding
	// squares. At that point, the four intersections around that square
	// will be untraversable
	public override void PlayCard() {
		
	}
}

public class DiplomacyCard :Card {
	// NOTE: If this card is hovered over then it should highlight the nearest piece
	// so that the player can undo their move to find a better nearest piece
	void Start () {

	}

	void Update () {

	}

	// Diplomacy will calculate the nearest piece:
	// If the piece is a stronghold, then the person playing the card will pick which
	// intersection that piece will move to
	// f the piece isn't a stronghold, then the player will switch pieces with nearest
	public override void PlayCard() {
		
	}
}

public class Deck {
	const int TOTAL_CARDS = 30;
	Card[] deck;

	// Initializes deck of cards in order
	Deck () {
		deck = new Card[TOTAL_CARDS];

		for (int i = 0; i < TOTAL_CARDS; i++) {
			if (i < 10)
				deck [i] = new SwordCard ();
			else if (i >= 10 && i < 20)
				deck [i] = new StrongholdCard ();
			else
				deck [i] = new DiplomacyCard ();
		}
	}

	// Shuffles cards
	public void Shuffle () {

	}

	// Draws first avaiable card
	public Card DrawCard () {
		return new Card();
	}
}

public class Hand {
	const int HAND_SIZE = 3;

	Card[] hand;

	Hand () {
		hand = new Card[HAND_SIZE];
	}

	public void AddCard (Card card) {
		
	}
}