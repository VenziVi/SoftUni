function solve(num = 5){
    let n = Number(num);

    let firstLine = ('* '.repeat(n));

    for(let i = 0; i < n; i++){
        console.log(firstLine);
    }   
}

solve();