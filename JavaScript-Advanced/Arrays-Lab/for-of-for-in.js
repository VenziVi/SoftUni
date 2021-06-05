function solve(arr, name) {


    for (const i of arr) {
        console.log(i);
    }
    for (const n of name) {
        console.log(n);
    }
    for (const i in arr) {
        console.log(arr[i]);
    }

    for (const n in name) {
        console.log(name[n]);
    }
}


function solve1(name){
    for (const n in name) {
        console.log(`letter ${n} is ${name[n]}`);
    }
}


//solve([3, 6, 2, 8], 'Ivan');
solve1('Stoqn');