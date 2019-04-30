let myObj = {
    name: "hello",
    age: 1,
    print() {
        console.log(this.name)
    }
}
console.log(myObj);
myObj.print()

function MyO(name) {
    this.name = name;
    this.print = () => console.log("printing" + this.name);

}

let o = new MyO("sparky");
o.print();

class Vehicle {
    constructor(name, make) {
        this.name = name;
        this.make = make;
    }

    details() {
        console.log(`${this.name} test ${this.make}`)
    }
}

let v = new Vehicle("v1", "ford");
console.log(`showing vehicle ${v.toString()}`);
console.log(v.details())

const car = {
    maker: 'Ford',
    model: 'Fiesta',
    drive: () => console.log(`Driving a ${this.maker}`)
}
car.drive()