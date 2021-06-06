function solve(arr){
    let result = [];

    for (let i = 0; i < arr.length; i++) {
        if (arr[i] < 0) {
            result.unshift(arr[i])
        }
    }
    for (let j = 0; j < arr.length; j++) {
        if (arr[j] >= 0) {
            result.push(arr[j])
        }      
    }
    for (let k = 0; k < result.length; k++) {
        console.log(result[k]);        
    }
}

solve([7, -2, 8, 9]);
solve([3, -2, 0, -1]);