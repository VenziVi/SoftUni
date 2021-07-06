function juice(arr){
    let juice = new Map();
    let bottle = new Map();

    for (const currJuice of arr) {
        let [type, quantity] = currJuice.split(' => ');

        quantity = Number(quantity);

        if (!juice.has(type)) {
            juice.set(type, 0);
        }
        let currQuntity = juice.get(type);
        currQuntity += quantity;
        let currBottle = 0;
        let leftQuantity = 0;
        if (currQuntity >= 1000) {
            currBottle = Math.trunc(currQuntity / 1000);
            leftQuantity = currQuntity - (currBottle * 1000);

            if(!bottle.has(type)){
                bottle.set(type, 0)
            }

            let bottleQuantity = bottle.get(type);
            bottleQuantity += currBottle;

            bottle.set(type, bottleQuantity);
            juice.set(type, leftQuantity);
        }else{
            juice.set(type, currQuntity);
        }
    }

    let bottleArr = [...bottle];

    for (const bottle of bottleArr) {
        console.log(`${bottle[0]} => ${bottle[1]}`);
    }

}

juice(['Kiwi => 234',
'Pear => 2345',
'Watermelon => 3456',
'Kiwi => 4567',
'Pear => 5678',
'Watermelon => 6789']

);