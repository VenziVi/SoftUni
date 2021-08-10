const assert = require('chai').assert;

class HolidayPackage {
    constructor(destination, season) {
        this.vacationers = [];
        this.destination = destination;
        this.season = season;
        this.insuranceIncluded = false; // Default value
    }

    showVacationers() {
        if (this.vacationers.length > 0)
            return "Vacationers:\n" + this.vacationers.join("\n");
        else
            return "No vacationers are added yet";
    }

    addVacationer(vacationerName) {
        if (typeof vacationerName !== "string" || vacationerName === ' ') {
            throw new Error("Vacationer name must be a non-empty string");
        }
        if (vacationerName.split(" ").length !== 2) {
            throw new Error("Name must consist of first name and last name");
        }
        this.vacationers.push(vacationerName);
    }

    get insuranceIncluded() {
        return this._insuranceIncluded;
    }

    set insuranceIncluded(insurance) {
        if (typeof insurance !== 'boolean') {
            throw new Error("Insurance status must be a boolean");
        }
        this._insuranceIncluded = insurance;
    }

    generateHolidayPackage() {
        if (this.vacationers.length < 1) {
            throw new Error("There must be at least 1 vacationer added");
        }
        let totalPrice = this.vacationers.length * 400;

        if (this.season === "Summer" || this.season === "Winter") {
            totalPrice += 200;
        }

        totalPrice += this.insuranceIncluded === true ? 100 : 0;

        return "Holiday Package Generated\n" +
            "Destination: " + this.destination + "\n" +
            this.showVacationers() + "\n" +
            "Price: " + totalPrice;
    }
}

describe('test', () => {
    it('test showVacationers', () => {
        let test = new HolidayPackage('plovdiv', 'summer');
        assert.strictEqual(test.destination, 'plovdiv');
        assert.strictEqual(test.season, 'summer');
    })

    it('test insuranceIncluded', () => {
        let test = new HolidayPackage('plovdiv', 'summer');
        assert.isFalse(test._insuranceIncluded);

        assert.throw(() => new Error(test.insuranceIncluded ='nop', "Insurance status must be a boolean"));
        assert.throw(() => new Error(test.insuranceIncluded = 1, "Insurance status must be a boolean"));
        assert.throw(() => new Error(test.insuranceIncluded = undefined, "Insurance status must be a boolean"));

        test.insuranceIncluded = true;
        assert.isTrue(test._insuranceIncluded);
    });

    it('test showVacationers', () => {
        let test = new HolidayPackage('plovdiv', 'summer');

        assert.strictEqual(test.showVacationers(), "No vacationers are added yet");

        test.addVacationer('Ivan Ivanov');
        test.addVacationer('Stoqn Todorov');

        let result = 'Vacationers:\nIvan Ivanov\nStoqn Todorov';
        assert.strictEqual(test.showVacationers(), result);
    });

    it('test addVacationer', () => {
        let test = new HolidayPackage('plovdiv', 'summer');

        assert.equal(test.vacationers.length, 0);
        
        assert.throw(()=> new Error(test.addVacationer(1), "Vacationer name must be a non-empty string"));
        assert.throw(()=> new Error(test.addVacationer(' '), "Vacationer name must be a non-empty string"));
    
        assert.throw(()=> new Error(test.addVacationer('ivan'), "Name must consist of first name and last name"));
        assert.throw(()=> new Error(test.addVacationer('ivan ivanov ivanov'), "Name must consist of first name and last name"));

        test.addVacationer('Ivan Ivanov');
        assert.equal(test.vacationers.length, 1);
    });

    it('test generateHolidayPackage', () => {
        let test = new HolidayPackage('plovdiv', 'autumn');

        assert.throw(()=> new Error(test.generateHolidayPackage(), "There must be at least 1 vacationer added"));

        test.addVacationer('Ivan Ivanov');
        let expected = 'Holiday Package Generated\nDestination: plovdiv\nVacationers:\nIvan Ivanov\nPrice: 400';
        assert.strictEqual(test.generateHolidayPackage(), expected);

    });

    it('test generateHolidayPackage with summer', ()=> {
        let test = new HolidayPackage('plovdiv', 'Summer');
        test.addVacationer('Ivan Ivanov');
        let expected = 'Holiday Package Generated\nDestination: plovdiv\nVacationers:\nIvan Ivanov\nPrice: 600';
        assert.strictEqual(test.generateHolidayPackage(), expected);
    });
});
