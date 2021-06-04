function solve(matrix){
    let firstSum = 0;
    let secondSum = 0;

    for (let row = 0; row < matrix.length; row++) {
        firstSum += matrix[row][row];
        secondSum += matrix[row][matrix.length - row - 1];
    }

    return `${firstSum} ${secondSum}`;
}

console.log(solve([[3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]]
   ));