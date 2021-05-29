function solve(num1, num2){
    let result = 0;
    let n = Number(num1);
    let m = Number(num2);
    
    for(let i = n; i <= m; i++){
        result += i;
    }
    console.log(result);
}

solve('-8', '20');