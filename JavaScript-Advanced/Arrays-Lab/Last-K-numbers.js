function solve(n, k){
    let result = [1];

    for (let i = 1; i < n; i++) {
        
        if (result.length < k) {
            let current = 0;
            for (let j = 0; j < result.length; j++) {
                current += result[j];               
            }
            result.push(current);
        }else{
            let current = 0;
            for (let l = i - k; l < result.length; l++) {
                current += result[l];                
            }
            result.push(current);
        }
    }

    return result;    
}

console.log(solve(6, 3));
console.log(solve(8, 2));
