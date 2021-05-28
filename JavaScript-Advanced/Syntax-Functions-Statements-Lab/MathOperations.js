function solve(num1, num2, symbol){
    let result;

    if(symbol == '+'){
        result = num1 + num2;
    }else if(symbol == '-'){
        result = num1 - num2;
    }else if(symbol == '*'){
        result = num1 * num2;
    }else if(symbol == '/'){
        result = num1 / num2;
    }else if(symbol == '%'){
        result = num1 % num2;
    }else if(symbol == '**'){
        result = num1 ** num2;
    }

    console.log(result);
}

solve(3, 5.5, '*');