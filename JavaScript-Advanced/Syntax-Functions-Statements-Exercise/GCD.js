function solve(n, m){
    let num = 0;
    for (let i = 0; i <= 10; i++) {
        if (n % i == 0 && m % i == 0) {
            num = i;
        }       
    }
    console.log(num);
}

solve(15, 5);
solve(2154, 458);