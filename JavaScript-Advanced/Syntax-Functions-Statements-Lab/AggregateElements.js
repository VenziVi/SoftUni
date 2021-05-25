function solve(array){
    let result = 0;
    for(let i = 0; i < array.length; i++){
        result += array[i];
    }
    console.log(result)
}

solve([1, 2, 3]);