class Parking{
    constructor(capacity){
        this.capacity = capacity;
        this.vehicles = [];
    }

    addCar( carModel, carNumber ){
        if (this.capacity <= this.vehicles.length) {
            throw new Error('Not enough parking space.');
        }

        let newCar = {
            carModel: carModel,
            carNumber: carNumber,
            payed: false,
        }
        this.vehicles.push(newCar);
        return `The ${carModel}, with a registration number ${carNumber}, parked.`;
    }

    removeCar( carNumber ){
        if (!this.vehicles.find(x => x.carNumber === carNumber)) {
            throw new Error(`The car, you're looking for, is not found.`);
        }

        let carIndex = this.vehicles.findIndex(x => x.carNumber === carNumber);
        if (!this.vehicles[carIndex].payed) {
            throw new Error(`${carNumber} needs to pay before leaving the parking lot.`);
        }

        this.vehicles.splice(carIndex, 1);
        return `${carNumber} left the parking lot.`;
    }

    pay( carNumber ){
        if (!this.vehicles.find(x => x.carNumber === carNumber)) {
            throw new Error(`${carNumber} is not in the parking lot.`);
        }

        let carIndex = this.vehicles.findIndex(x => x.carNumber === carNumber);
        if (this.vehicles[carIndex].payed) {
            throw new Error(`${carNumber}'s driver has already payed his ticket.`);
        }

        this.vehicles[carIndex].payed = true;
        return `${carNumber}'s driver successfully payed for his stay.`;
    }

    getStatistics(carNumber){
        if (carNumber === undefined) {
            result = `The Parking Lot has ${this.capacity - this.vehicles.length} empty spots left.\n`;
            this.vehicles.sort((a,b) => a.carModel.localeCompare(b.carModel))
            .forEach(x => {
                result += `${x.carModel} == ${x.carNumber} - ${x.payed === true? `Has payed`: `Not payed`}\n`;
            })
            return result.trimEnd();
        }else{
            let currIndex = this.vehicles.findIndex(x => x.carNumber === carNumber);
            return `${this.vehicles[currIndex].carModel} == ${this.vehicles[currIndex].carNumber} - ${this.vehicles[currIndex].payed === true? `Has payed`: `Not payed`}`;
        }
    }
}

const parking = new Parking(12);

console.log(parking.addCar("Volvo t600", "TX3691CA"));
console.log(parking.getStatistics());

console.log(parking.pay("TX3691CA"));
console.log(parking.removeCar("TX3691CA"));
