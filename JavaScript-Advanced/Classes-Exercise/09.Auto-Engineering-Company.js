function cars(arr){
    let cars = new Map();

    for (const input of arr) {
        let [make, model, quantity] = input.split(' | ');
        quantity = Number(quantity);
        
        if (!cars.has(make)) {
            cars.set(make, {[model]:quantity});
        }else{
            let currCar = cars.get(make);
            if (!currCar[model]) {
                currCar[model] = quantity;
            }else{
                currCar[model] += quantity;
            }
        }
    }
    
    let carsArr = [...cars];

    for (const make of carsArr) {
        let makeArr = [...make];
        console.log(makeArr[0]);
        
        let obj = Object.entries(makeArr[1]);
        for (const iterator of obj) {
           console.log(`###${iterator[0]} -> ${iterator[1]}`);
       }
    }
}
cars(['Audi | Q7 | 1000',
'Audi | Q6 | 100',
'BMW | X5 | 1000',
'BMW | X6 | 100',
'Citroen | C4 | 123',
'Volga | GAZ-24 | 1000000',
'Lada | Niva | 1000000',
'Lada | Jigula | 1000000',
'Citroen | C4 | 22',
'Citroen | C5 | 10']
);