function solution(num){
    let currNum = num;

    return function add(n){
        return currNum + n;
    }
}


let add5 = solution(5);
console.log(add5(2));
console.log(add5(3));
