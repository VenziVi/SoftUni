function magic(matrix){
    let isMagic = true;
    let firstSum = 0;
    let sum = 0;

    for (let j = 0; j < matrix.length; j++) {
        
        sum = 0;

        for (let i = 0; i < matrix.length; i++) {
            
            sum += matrix[j][i];   
        }
        if (j == 0) {
            firstSum = sum;
        }
        if (firstSum != sum) {
            isMagic = false;
        }
        firstSum = sum;
    }
    console.log(isMagic);
}

magic([[11, 32, 45],
       [21, 0, 1],
       [21, 1, 1]]);


