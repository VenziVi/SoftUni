function solve(towns){
    let data = {};

    for (let i = 0; i < towns.length; i++) {
        let tokens = towns[i].split(' <-> ');
        let name = tokens[0];
        let population = Number(tokens[1]);

        if (data[name] != undefined) {
            population += data[name];
        }
        data[name] = population;
    }
    
    for (const town in data) {
        console.log(`${town} : ${data[town]}`);
    }
}


function solve1(arr){
    let data = {};

    for (const town of arr) {
        let [name, population] = town.split(' <-> ');
        population = Number(population);

        if (data[name] != undefined) {
            population += data[name];
        }
        data[name] = population;
    }

    for (const town in data) {
        console.log(`${town} : ${data[town]}`);
    }
}

solve1(['Istanbul <-> 100000',
'Honk Kong <-> 2100004',
'Jerusalem <-> 2352344',
'Mexico City <-> 23401925',
'Istanbul <-> 1000']
);