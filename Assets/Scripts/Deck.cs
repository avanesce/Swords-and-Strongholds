using System.Collections;
using UnityEngine;

public class Deck : MonoBehaviour{
    const int TOTAL_CARDS = 30;
    Card[] helperDeck;
    Stack mainDeck;

    //Initializes deck of cards in order and returns no values.
    //Shuffle() will reorder the cards randomly.
    //Cards are moved into a stack structure after shuffled for simple removal.
    public void MakeDeck(){
        helperDeck = new Card[TOTAL_CARDS];
        for (int i = 0; i < TOTAL_CARDS; i++){
            if (i < 10)
                helperDeck[i] = new SwordCard();
            else if (i >= 10 && i < 20)
                helperDeck[i] = new StrongholdCard();
            else
                helperDeck[i] = new DiplomacyCard();
        }
        Shuffle();
        for (int i = 0; i < TOTAL_CARDS; i++){
            mainDeck.Push(helperDeck[i]);
        }
    }

    //Shuffles cards and returns no values.
    //Is used only when MakeDeck() is called.
    private void Shuffle()
    {
        int a, b;
        Card temp;
        //increase if deck isn't shuffled enough
        for (int i = 0; i < 50; i++)
        {
            a = Random.Range(0, 30);
            b = Random.Range(0, 30);
            temp = helperDeck[a];
            helperDeck[a] = helperDeck[b];
            helperDeck[b] = temp;
        }
        //Debug.Log("Deck contents: "+ helperDeck.ToString());
    }

    //Pops and returns a card off the top of the deck when called.
    //Should only be called by the GameManager after a card has been played.
    //Card should be assigned to a player's hand.
    public Card DrawCard(){
        return (Card) mainDeck.Pop();
    }
}

