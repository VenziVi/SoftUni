function carFactory(input){
    
    function selectEngine(hp) {
        let engine = {};
        if (hp <= 90) {
            engine.power = 90;
            engine.volume = 1800;
        }else if (hp <= 120) {
            engine.power = 120;
            engine.volume = 2400;
        }else  {
            engine.power = 200;
            engine.volume = 3500;
        }
        return engine;
    }

    function createCarriage(color, choosenCarriage){
        return carriage = {
            type: choosenCarriage,
            color: color
        };
    }

    function createWheels(size){
        let wheels = [];

        if (size % 2 == 0) {
            size--;
        }
        wheels = [size, size, size, size];
        return wheels;
    }

    return {
        model: input.model,
        engine: selectEngine(input.power),
        carriage: createCarriage(input.color, input.carriage),
        wheels: createWheels(input.wheelsize)
    }
    
}



console.log(carFactory({ model: 'VW Golf II',
power: 90,
color: 'blue',
carriage: 'hatchback',
wheelsize: 14 }
));