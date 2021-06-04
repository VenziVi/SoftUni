function solve(matrix){
    return Math.max(...[].concat(...matrix));
}

console.log(solve([[3, 5, 7, 12],
    [-1, 4, 33, 2],
    [8, 3, 0, 4]]
   ));      