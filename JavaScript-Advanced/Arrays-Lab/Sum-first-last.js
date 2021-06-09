function solve(array){
    let firstNum = Number(array[0]);
    let lastNum = Number(array[array.length - 1]);

    return firstNum + lastNum;

}

console.log(solve(['20', '30', '40']));
console.log(solve(['5', '10']));