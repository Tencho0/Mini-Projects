let lname : string;

lname = 'Tencho';

let newName= lname.toUpperCase();

console.log(newName);

let age: number;
age = 20;

let isValid: boolean;
isValid = true;
console.log(isValid);

let strarr: string[];
strarr = ['Ivan', 'Mitko', 'Sasho'];

let numarr: number[];
numarr = [1, 2, 3, 4, 5];

let results = numarr.filter((num) => num > 2);
let sum = numarr.reduce((acc, num) => acc + num);
let num = numarr.find((num) => num === 2);

let emp = strarr.find((emp) => emp === 'Sasho');

console.log(results);
console.log(sum);
console.log(num);
console.log(emp);


enum Color{
    Red, 
    Green,
    Blue
}

let c: Color = Color.Green;

let swapNumbs: [number, number];

function swapNumbers(num1 : number, num2 : number) : [number, number]{
    return [num2, num1];
}

swapNumbs = swapNumbers(10, 20);

let department: any;    // Avoid 'any'

department = "IT";
department = 10;

// function add(num1: number, num2: number){
//     return num1 + num2;
// }

// let newSum = add(10, 20);