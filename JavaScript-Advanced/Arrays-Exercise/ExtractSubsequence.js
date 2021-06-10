function solve(arr){
    let result = [];
    for(let i = 0; i < arr.length; i++){
        let max = Math.max.apply(null, result);
        if(arr[i] >= max){
            result.push(arr[i])
        }
    }
    
    return result;
}


console.log(solve([1, 3, 8, 4, 10, 12, 3, 2, 24]));