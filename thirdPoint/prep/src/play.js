var MyFakeClass = /** @class */ (function () {
    function MyFakeClass() {
    }
    MyFakeClass.prototype.handleStuff = function (stuff) {
        console.log(stuff);
    };
    return MyFakeClass;
}());
(function () {
    var c = new MyFakeClass();
    c.handleStuff("stufffff");
})();
