function solve(arr, start, end){
    let startingIndex = arr.indexOf(start);
    let endIndex = arr.indexOf(end);

    let result = arr.slice(startingIndex, endIndex + 1);
    return result;
}


console.log(solve(['Apple Crisp',
'Mississippi Mud Pie',
'Pot Pie',
'Steak and Cheese Pie',
'Butter Chicken Pie',
'Smoked Fish Pie'],
'Pot Pie',
'Smoked Fish Pie'
));