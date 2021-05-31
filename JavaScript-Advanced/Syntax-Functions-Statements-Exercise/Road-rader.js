function solve(speed, area){
    let result ='';
    let speedLimit = 0;

    if (area === 'motorway') {
        speedLimit = 130;

        if (speed <= speedLimit) {
            result = `Driving ${speed} km/h in a ${speedLimit} zone`;

        }else if (speed > speedLimit && speed <= speedLimit + 20) {
            result = `The speed is ${speed - speedLimit} km/h faster than the allowed speed of ${speedLimit} - speeding`;

        }else if (speed > speedLimit + 20 && speed <= speedLimit + 40) {
            result = `The speed is ${speed - speedLimit} km/h faster than the allowed speed of ${speedLimit} - excessive speeding`;

        }else{
            result = `The speed is ${speed - speedLimit} km/h faster than the allowed speed of ${speedLimit} - reckless driving `;
        }
        
    }else if (area === 'interstate') {
        speedLimit = 90;

        if (speed <= speedLimit) {
            result = `Driving ${speed} km/h in a ${speedLimit} zone`
        }else if (speed > speedLimit && speed <= speedLimit + 20) {
            result = `The speed is ${speed - speedLimit} km/h faster than the allowed speed of ${speedLimit} - speeding`;

        }else if (speed > speedLimit + 20 && speed <= speedLimit + 40) {
            result = `The speed is ${speed - speedLimit} km/h faster than the allowed speed of ${speedLimit} - excessive speeding`;

        }else{
            result = `The speed is ${speed - speedLimit} km/h faster than the allowed speed of ${speedLimit} - reckless driving `;
        }
        
    }else if (area === 'city') {
        speedLimit = 50;

        if (speed <= speedLimit) {
            result = `Driving ${speed} km/h in a ${speedLimit} zone`
        }else if (speed > speedLimit && speed <= speedLimit + 20) {
            result = `The speed is ${speed - speedLimit} km/h faster than the allowed speed of ${speedLimit} - speeding`;

        }else if (speed > speedLimit + 20 && speed <= speedLimit + 40) {
            result = `The speed is ${speed - speedLimit} km/h faster than the allowed speed of ${speedLimit} - excessive speeding`;

        }else{
            result = `The speed is ${speed - speedLimit} km/h faster than the allowed speed of ${speedLimit} - reckless driving `;
        }
        
    }else if (area === 'residential') {
        speedLimit = 20;

        if (speed <= speedLimit) {
            result = `Driving ${speed} km/h in a ${speedLimit} zone`
        }else if (speed > speedLimit && speed <= speedLimit + 20) {
            result = `The speed is ${speed - speedLimit} km/h faster than the allowed speed of ${speedLimit} - speeding`;

        }else if (speed > speedLimit + 20 && speed <= speedLimit + 40) {
            result = `The speed is ${speed - speedLimit} km/h faster than the allowed speed of ${speedLimit} - excessive speeding`;

        }else{
            result = `The speed is ${speed - speedLimit} km/h faster than the allowed speed of ${speedLimit} - reckless driving `;
        }
        
    }

    console.log(result);

}

solve(40, 'city');
solve(200, 'motorway');