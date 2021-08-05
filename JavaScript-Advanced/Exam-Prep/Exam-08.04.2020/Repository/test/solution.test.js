let expect = require('chai').expect;

class Repository {
    constructor(props) {
        this.props = props;
        this.data = new Map();

        let id = 0;
        this.nextId = function () {
            return id++;
        }
    }

    get count() {
        return this.data.size;
    }

    add(entity) {
        this._validate(entity);
        let id = this.nextId();
        this.data.set(id, entity);
        return id;
    }

    getId(id) {
        if (!this.data.has(id)) {
            throw new Error(`Entity with id: ${id} does not exist!`);
        }

        return this.data.get(id);
    }

    update(id, newEntity) {
        if (!this.data.has(id)) {
            throw new Error(`Entity with id: ${id} does not exist!`);
        }

        this._validate(newEntity);
        this.data.set(id, newEntity);
    }

    del(id) {
        if (!this.data.has(id)) {
            throw new Error(`Entity with id: ${id} does not exist!`);
        }

        this.data.delete(id);
    }

    _validate(entity) {
        //Validate existing property
        for (let propName in this.props) {
            if (!entity.hasOwnProperty(propName)) {
                throw new Error(`Property ${propName} is missing from the entity!`);
            }
        }

        //Validate property type
        for (let propName in entity) {
            let val = entity[propName];
            if (typeof val !== this.props[propName]) {
                throw new TypeError(`Property ${propName} is not of correct type!`);
            }
        }
    }
}



describe("Repository", function () {
    describe("constructor", function () {
        it("Should set initialize with valid data", function () {
            let props = { name: 'string', age: 'number'};
            let rep = new Repository(props);
            expect(rep.props).to.eql(props);
            expect(rep.data.size).to.equal(0);
            expect(rep.nextId()).to.equal(0);
 
            expect(rep instanceof Repository);
        });
    });
 
    describe("count", function () {
        it("Should reflect correct count", function () {
            let props = { name: 'string', age: 'number'};
            let rep = new Repository(props);
            let obj1 = { name: 'ivan', age: 20};
 
            expect(rep.count).to.equal(0);
            rep.add(obj1);
            expect(rep.count).to.equal(1);
            rep.update(0, obj1);
            expect(rep.count).to.equal(1);
            rep.del(0);
            expect(rep.count).to.equal(0);
        });
    });
 
    describe("add", function () {
        it("Should reflect add entity correctly", function () {
            let props = { name: 'string', age: 'number'};
            let rep = new Repository(props);
            let obj1 = { name: 'ivan', age: 20};
            let obj2 = { name: 'ivan2', age: 22};
            let id = rep.add(obj1);
            expect(id).to.equal(0);
            let id2 = rep.add(obj2);
            expect(id2).to.equal(1);
 
            let actual = rep.data.get(id2);
            expect(actual).to.eql(obj2);
        });
 
        it("Should throw when props are not matched", function () {
            let props = { name: 'string', age: 'number'};
            let rep = new Repository(props);
            let obj1 = { name: 'ivan'};
            let obj2 = { name: 'ivan2', age: true, };
            let obj3 = { name: 'ivan3', age: 22, hobby: true };
            expect(()=> rep.add(obj1)).to.throw(Error, `Property age is missing from the entity!`);
            expect(()=> rep.add(obj2)).to.throw(TypeError, `Property age is not of correct type!`);
            expect(()=> rep.add(obj3)).to.throw(TypeError, `Property hobby is not of correct type!`);
        });
    });
 
    describe("getId", function () {
        it("Should reflect getId entity correctly", function () {
            let props = { name: 'string', age: 'number'};
            let rep = new Repository(props);
            let obj1 = { name: 'ivan', age: 20};
            let obj2 = { name: 'ivan2', age: 22};
            let id = rep.add(obj1);
            let id2 = rep.add(obj2);
 
            let actual = rep.getId(1);
            expect(actual).to.eql(obj2);
            let actual2 = rep.getId(0);
            expect(actual2).to.eql(obj1);
        });
 
        it("Should throw when id does not exist", function () {
            let props = { name: 'string', age: 'number'};
            let rep = new Repository(props);
            let obj1 = { name: 'ivan', age: 12};
            expect(()=> rep.getId(0)).to.throw(Error, `Entity with id: 0 does not exist!`);
            let id = rep.add(obj1);
            expect(()=> rep.getId(1)).to.throw(Error, `Entity with id: 1 does not exist!`);
        });
    });
 
    describe("update", function () {
        it("Should reflect update entity correctly", function () {
            let props = { name: 'string', age: 'number'};
            let rep = new Repository(props);
            let obj1 = { name: 'ivan', age: 20};
            let obj2 = { name: 'ivan2', age: 22};
            let obj3 = { name: 'gosho', age: 15};
            let obj4 = { name: 'peter', age: 40};
            let id = rep.add(obj1);
            let id2 = rep.add(obj2);
 
            rep.update(1, obj3);
            expect(rep.data.get(1)).to.eql(obj3);
            rep.update(0, obj4);
            expect(rep.data.get(0)).to.eql(obj4);
        });
 
        it("Should throw when when parameters are incorrect", function () {
            let props = { name: 'string', age: 'number'};
            let rep = new Repository(props);
            let obj1 = { name: 'ivan', age: 12};
            let obj2 = { name: 'ivan'};
            let obj3 = { name: 'ivan', age: true};
            let obj4 = { name: 'ivan', age: 12, hobby: true};
            expect(()=> rep.update(0, obj1)).to.throw(Error, `Entity with id: 0 does not exist!`);
            let id = rep.add(obj1);
            expect(()=> rep.update(1, obj1)).to.throw(Error, `Entity with id: 1 does not exist!`);
 
            expect(()=> rep.update(0,obj2)).to.throw(Error, `Property age is missing from the entity!`);
            expect(()=> rep.update(0,obj3)).to.throw(TypeError, `Property age is not of correct type!`);
            expect(()=> rep.update(0,obj4)).to.throw(TypeError, `Property hobby is not of correct type!`);
        });
    });
 
    describe("del", function () {
        it("Should reflect delete correctly", function () {
            let props = { name: 'string', age: 'number'};
            let rep = new Repository(props);
            let obj1 = { name: 'ivan', age: 20};
            let obj2 = { name: 'ivan2', age: 22};
            let obj3 = { name: 'gosho', age: 15};
            let obj4 = { name: 'peter', age: 40};
            let id = rep.add(obj1);
            let id2 = rep.add(obj2);
 
            rep.del(0);
            expect(rep.data.get(1)).to.eql(obj2);
            rep.del(1);
            expect(rep.data.size).to.equal(0);
        });
 
        it("Should throw when parameters are incorrect", function () {
            let props = { name: 'string', age: 'number'};
            let rep = new Repository(props);
            let obj1 = { name: 'ivan', age: 12};
            let obj2 = { name: 'ivan'};
            let obj3 = { name: 'ivan', age: true};
            let obj4 = { name: 'ivan', age: 12, hobby: true};
            expect(()=> rep.del(0)).to.throw(Error, `Entity with id: 0 does not exist!`);
            let id = rep.add(obj1);
            expect(()=> rep.del(1)).to.throw(Error, `Entity with id: 1 does not exist!`);
        });
    });
});