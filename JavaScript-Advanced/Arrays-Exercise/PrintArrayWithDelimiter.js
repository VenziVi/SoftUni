function solve(arr, delimiter){
    let result = '';
    for(let i = 0; i < arr.length; i++){
        if(i == arr.length - 1){
            result += arr[i];
        }else{
            result += arr[i];
            result += delimiter;
        }
    }

    return result;
}

function solve1(arr, delimiter){
    return arr.join(delimiter);
}

console.log(solve1(['One', 
'Two', 
'Three', 
'Four', 
'Five'], 
'-'
));

console.log(solve(['How about no?', 
'I',
'will', 
'not', 
'do', 
'it!'], 
'_'
));