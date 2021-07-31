function solve(arr, firstIndex, lastIndex) {
    let sum = 0;

    if (!Array.isArray(arr)) {
        return NaN;
    }
    let part = arr.splice(firstIndex, lastIndex);
    console.log(part);
    sum = part.reduce((acc, c) => acc + c, 0);
    return Number(sum);

}