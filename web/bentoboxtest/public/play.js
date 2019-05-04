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

let a = [1,2,3,4,5];

a.forEach(i => console.log(i));
let b = a.map(i => i * 2);
console.log(b);
let c = a.find(i => i === 3);
console.log(c);