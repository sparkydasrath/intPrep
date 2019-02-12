
class MyFakeClass {
    handleStuff(stuff: string): void {
        console.log(stuff);
    }
}

(function () {
    let c = new MyFakeClass();
    c.handleStuff("stufffff");
})();