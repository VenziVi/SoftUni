function solve(steps, footprint, speed) {
    let time = 0;
    let distance = Math.round(steps * footprint);

    time = ((distance/ speed) * 60 * 60) / 1000;

    let timeForBreak = distance;

    while (timeForBreak >= 500) {
        time += 60;
        timeForBreak -= 500;
    }

    let hour = Math.trunc((time / 60) / 60);
    let min = Math.trunc(time/ 60);
    let sec = Math.round((time / 60 - min) * 60); 

    if (hour < 10) {
        hour = `0${hour}`;
    }
    if (min < 10) {
        min = `0${min}`;
    }
    if (sec < 10) {
        sec = `0${sec}`;
    }

    console.log(`${hour}:${min}:${sec}`);
}

solve(8000, 0.60, 5);
solve(2564, 0.70, 5.5);