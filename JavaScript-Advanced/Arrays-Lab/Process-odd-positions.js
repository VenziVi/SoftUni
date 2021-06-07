function solve (arr){
    let result = [];

    for (let i = 0; i < arr.length; i++) {
        if (i % 2 != 0) {
            result.unshift(arr[i] * 2)
        }
    }
    return result.join(' ');
}

console.log(solve([3, 0, 10, 4, 7, 3]));