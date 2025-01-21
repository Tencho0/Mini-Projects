"use strict";
function add(num1, num2) {
    return num1 + num2;
}
console.log(add(10, 20));
const sub = (num1, num2) => num1 - num2;
console.log(sub(2, 3));
const mult = function (num1, num2) {
    return num1 * num2;
};
function getItems(items) {
    return new Array().concat(items);
}
let concatResult = getItems([1, 2, 3, 4, 5]);
let concatStrings = getItems(["A", "B", "C"]);
console.log(concatResult);
console.log(concatStrings);
