function solve(...array){
    let num = Number(array[0]);

    for (let i = 1; i < array.length; i++) {
        
        if (array[i] == 'chop') {
            num /= 2;
            console.log(num); 
        }else if (array[i] == 'dice') {
            num = Math.sqrt(num);
            console.log(num);
        }else if (array[i] == 'spice') {
            num += 1;
            console.log(num);
        }else if (array[i] == 'bake') {
            num *= 3;
            console.log(num);
        }else if (array[i] == 'fillet') {
            num = num * 0.8;
            console.log(num);
        }
    }
}

solve('32', 'chop', 'chop', 'chop', 'chop', 'chop');