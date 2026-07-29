"use strict";
let lname;
lname = 'Tencho';
let newName = lname.toUpperCase();
console.log(newName);
let age;
age = 20;
let isValid;
isValid = true;
console.log(isValid);
let strarr;
strarr = ['Ivan', 'Mitko', 'Sasho'];
let numarr;
numarr = [1, 2, 3, 4, 5];
let results = numarr.filter((num) => num > 2);
let sum = numarr.reduce((acc, num) => acc + num);
let num = numarr.find((num) => num === 2);
let emp = strarr.find((emp) => emp === 'Sasho');
console.log(results);
console.log(sum);
console.log(num);
console.log(emp);
var Color;
(function (Color) {
    Color[Color["Red"] = 0] = "Red";
    Color[Color["Green"] = 1] = "Green";
    Color[Color["Blue"] = 2] = "Blue";
})(Color || (Color = {}));
let c = Color.Green;
let swapNumbs;
function swapNumbers(num1, num2) {
    return [num2, num1];
}
swapNumbs = swapNumbers(10, 20);
let department; // Avoid 'any'
department = "IT";
department = 10;
// function add(num1: number, num2: number){
//     return num1 + num2;
// }
// let newSum = add(10, 20);
