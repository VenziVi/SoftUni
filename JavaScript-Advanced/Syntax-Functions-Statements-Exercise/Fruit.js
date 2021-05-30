function solve(name, weight, price){
    let weightNew = weight/ 1000;
    let money = weightNew * price;

    console.log('I need $' + money.toFixed(2) + ' to buy ' + weightNew.toFixed(2) + ' kilograms ' + name +'.');
}

solve('apple', 1563, 2.35);