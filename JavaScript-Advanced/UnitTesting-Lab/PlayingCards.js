function playingCards(f, s) {

    function createCard(f, s) {
        let validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
        let validSuits = new Map();
        validSuits.set('S', '\u2660');
        validSuits.set('H', '\u2665');
        validSuits.set('D', '\u2666');
        validSuits.set('C', '\u2663');

        if (!validFaces.includes(f) || !validSuits.has(s)) {
            throw new Error('Erorr')
        }

        let face = validFaces.filter(x => x === f)[0];
        let suit = validSuits.get(s);

        let card = {
            face, suit, toString: () => {
                return face + suit;
            }
        }

        return card.toString();
    }

    return createCard(f, s);
}

console.log(playingCards('A', 'S'));