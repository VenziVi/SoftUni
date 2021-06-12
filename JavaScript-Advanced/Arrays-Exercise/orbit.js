function orbit(arr){

    let[rows, cols, currRow, currCol] = arr;

    let matrix = Array(rows).fill(0).map(() => Array(cols).fill(0));

    matrix[currRow][currCol] = 1;

    for (let row = 0; row < matrix.length; row++) {
        console.log(matrix[row]);
        
    }
}




orbit([5, 5, 2, 2]);