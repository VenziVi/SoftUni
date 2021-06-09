function solve(arr){
    let result = [];

    for(let i = 0; i < arr.length; i++){
        if(arr[i] == 'add'){
            result.push(i + 1);
        }else{
            result.pop();
        }
    }

    if(result.length == 0){
        console.log('Empty')
    }else{
        result.forEach(element => console.log(element))
    }
}

solve(['add', 'add', 'add', 'add']);
solve(['add', 'add', 'remove', 'add', 'add']);
solve(['remove', 'remove', 'remove']);
