function sortArray(arr, type){
    let result = arr;

    const sorter = {
        asc: function(result) {
            arr.sort((a,b) => a - b);
        },
        desc: function(result) {
            arr.sort((a,b) => b - a);
        }
    }

    sorter[type](result);
    return result;

}

console.log(sortArray([14, 7, 17, 6, 8], 'asc'));
console.log(sortArray([14, 7, 17, 6, 8], 'desc'));