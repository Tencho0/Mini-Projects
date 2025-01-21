function add(num1: number, num2: number) {
    return num1 + num2;
}

console.log(add(10, 20));

const sub = (num1: number, num2: number): number => num1 - num2;

console.log(sub(2, 3));

const mult = function (num1: number, num2: number) {
    return num1 * num2;
}

function getItems<Type>(items: Type[]): Type[] {
    return new Array<Type>().concat(items);
}

let concatResult = getItems([1, 2, 3, 4, 5]);
let concatStrings = getItems(["A", "B", "C"]);

console.log(concatResult);
console.log(concatStrings);

