function solve(arr){
    arr.sort(compareNumbers);

    function compareNumbers(a, b) {
        return a - b;
    }

    let result = [];
    
    if(arr.length % 2 == 0){

        let firstNums = arr.slice(0, arr.length / 2);
        let secondNums = arr.slice(arr.length / 2, arr.length);

        for(let i = 1; i <= arr.length / 2; i++){
            result.push(firstNums[i-1]);
            result.push(secondNums[secondNums.length - i]);
        }
    }else{
        let firstNums = arr.slice(0, (arr.length / 2) + 1 );
        let secondNums = arr.slice((arr.length / 2) + 1, arr.length);

        for(let i = 1; i <= firstNums.length; i++){

            result.push(firstNums[i-1]);

            if(i < firstNums.length){
                result.push(secondNums[secondNums.length - i]);
            }
        }
    }

    return result;
}

console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));