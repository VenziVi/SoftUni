function solve(arr){
    const calorieDict = {};

    for(let i = 0; i < arr.length; i+=2){
        
        calorieDict[arr[i]] = Number([arr[i + 1]]);
    }

    console.log(calorieDict);
}


solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);