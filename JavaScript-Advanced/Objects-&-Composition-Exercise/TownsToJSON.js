function towns(arr){
    let output =[];

    
    for (let i = 1; i < arr.length; i++) {
        let [town, lat, lon] = arr[0].split(' '). filter(x => x.length > 1);
        let[currTown, currLat, currLon] =arr[i].split("|")
        .filter((s) => s.length > 0)
        .map((x) => x.trim());

        let latitude = Number(Number(currLat).toFixed(2));
        let longitude = Number(Number(currLon).toFixed(2));
        
        obj = {
            [town]: currTown,
            [lat]: latitude,
            [lon]: longitude,
        };

        output.push(obj);
    }

    let result = JSON.stringify(output);

    console.log(result);
}



function parseTownsToJSON(towns) {
    let townsArr = [];
    for (let town of towns.slice(1)) {
        let [empty, townName, lat, lng] =
            town.split(/\s*\|\s*/);
        let townObj = { Town: townName, Latitude:
                Number(Number(lat).toFixed(2)), Longitude: Number(Number(lng).toFixed(2))};
        townsArr.push(townObj);
    }
    console.log(JSON.stringify(townsArr));;
}


towns(['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |']
);