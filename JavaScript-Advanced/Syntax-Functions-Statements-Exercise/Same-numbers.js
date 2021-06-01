function solve(num){
    let sum = 0;
    let areSame = true;
    let number = String(num);

    for (let i = 0; i < number.length; i++) {
        sum += Number(number[i]);

        if (i != number.length - 1) {
            if (number[i] != number[i+1]) {
                areSame = false;
            }
        }
    }

    console.log(areSame);
    console.log(sum);
}

solve(2222222);
solve(1234);