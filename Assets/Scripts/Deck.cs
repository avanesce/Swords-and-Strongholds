using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour{
    // Editor prefab references
    public GameObject SwordCardPrefab;
    public GameObject DiplomacyCardPrefab;
    public GameObject StrongholdCardPrefab;

    const int TOTAL_CARDS = 30;
    private float deckHeight = 0.0f;
    List<Card> deck = new List<Card>();

    void Start()
    {
        GenerateDeck();
    }

    void Update()
    {

    }

    //Initializes deck of cards in order and returns no values.
    //Shuffle() will reorder the cards randomly.
    //Cards are moved into a stack structure after shuffled for simple removal.
    void GenerateDeck(){
        deckHeight = 0.0f;
        deck.Clear();
        for (int i = 0; i < TOTAL_CARDS; i++){
            Card _card;
            
            if (i < 10){
               _card = ((GameObject)Instantiate(
                            SwordCardPrefab,
                            new Vector3(4, deckHeight, 6),
                            Quaternion.Euler(0, 0, 90))).GetComponent<SwordCard>();
            }
            else if (i >= 10 && i < 20){
                _card = ((GameObject)Instantiate(
                            DiplomacyCardPrefab,
                            new Vector3(4, deckHeight, 6),
                            Quaternion.Euler(0, 0, 90))).GetComponent<DiplomacyCard>();
            }       
            else{
                _card = ((GameObject)Instantiate(
                            StrongholdCardPrefab,
                            new Vector3(4, deckHeight, 6),
                            Quaternion.Euler(0, 0, 90))).GetComponent<StrongholdCard>();
            }
            deck.Add(_card);
            deckHeight += 0.035f;
        }
        Shuffle();
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
            temp = deck[a];
            deck[a] = deck[b];
            deck[b] = temp;
        }
        //Debug.Log("Deck contents: "+ helperDeck.ToString());
    }

    //Returns the top 'last' (top) card of the deck and destroys it in the deck.
    //todo: destroy cards that are drawn, taken card will be drawn by another script.
    public Card DrawCard(){
        deckHeight -= 0.05f;
        Card temp = deck[deck.Count];
        deck.RemoveAt(deck.Count);
        return temp;
    }
}

