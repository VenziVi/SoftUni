function solve(arr){
    let result = arr.reduce((a, c) => a + c);
    return result;
}

function solve1(arr){
    let average = arr.reduce((a,c,i, arr) => a + (c / arr.length), 0);
    return average;
}

console.log(solve1([3, 54, 32, 12, 6, 13]));