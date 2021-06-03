function solve(arr){
    let result = [];
    arr.sort((a, b) => (b - a));

    if (arr.length % 2 == 0) {
        result = arr.slice(0, arr.length / 2)
    }else{

        result = arr.slice(0, arr.length / 2 + 1)
    }
    
    result.reverse();
    return result;
}

//console.log(solve([4, 7, 2, 5]));
console.log(solve([3, 19, 14, 7, 2, 19, 6]));