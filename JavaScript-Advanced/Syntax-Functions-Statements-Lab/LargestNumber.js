function maxNum(a, b, c){
    let number;

    if(a > b && a > c){
        number = a;
    } else if(b > a && b > c){
        number = b;
    } else if(c > a && c > b){
        number = c;
    }
    console.log('The largest number is ' + number + '.');
}


maxNum(5, -3, 16);