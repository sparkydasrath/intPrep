const car = {
    maker: 'Ford',
    model: 'Fiesta',
    drive: () => 
        console.log(`Driving a ${this.maker}`)
}
car.drive()