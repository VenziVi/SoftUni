function solve(arr){
    arr.sort(function(a,b){return a.localeCompare(b); });

    for(let i = 0; i < arr.length; i++){
        console.log(`${i + 1}.${arr[i]}`)
    }
}

solve(["John", "Bob", "Christina", "Ema"]);