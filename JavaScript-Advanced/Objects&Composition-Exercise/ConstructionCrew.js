function constructor(obj) {

    function intakeWater() {
        if (obj.dizziness) {
            obj.levelOfHydrated += obj.weight * 0.1 * obj.experience;
        }
        obj.dizziness = false;
    }
    intakeWater(obj);
    return obj;
}

console.log(constructor({
    weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true
}
));