function solve(area, vol, input) {
    let cordinatesInput = JSON.parse(input);
    let resultArray = [];

    for (const element of cordinatesInput) {
        let currArea = area.call(element)
        let currVol = vol.call(element)
        let obj = {
            area: currArea,
            volume: currVol,
        }
        resultArray.push(obj);
    }
    return resultArray;
}

function vol() {
    return Math.abs(this.x * this.y * this.z);
}

function area() {
    return Math.abs(this.x * this.y);
}

solve(area, vol, '[{"x":"1","y":"2","z":"10"},{"x":"7","y":"7","z":"10"},{"x":"5","y":"2","z":"10"}]')