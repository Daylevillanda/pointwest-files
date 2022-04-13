"use strict";
let myNumber = 2;
function add(num1, num2) {
    return num1 + num2;
}
console.log(add(1, 2));
const data = JSON.parse('{"id":123,"name":"JM","position":"SE"}');
var AccountStatus;
(function (AccountStatus) {
    AccountStatus[AccountStatus["ACTIVE"] = 0] = "ACTIVE";
    AccountStatus[AccountStatus["DORMANT"] = 1] = "DORMANT";
    AccountStatus[AccountStatus["CLOSED"] = 2] = "CLOSED";
})(AccountStatus || (AccountStatus = {}));
let myAccount = {
    accountNumber: '1234567890',
    accountName: 'JM Flores Lovelife Mo Sagot Ko Foundation, Inc.',
    status: AccountStatus.ACTIVE
};
class CustomPromise {
    constructor(resolveFn) {
        resolveFn(this.resolve);
    }
    resolve(value) {
        if (this.thenFn) {
            this.thenFn(value);
        }
    }
    then(handler) {
        this.thenFn = handler;
        return this;
    }
}
let pramise = new CustomPromise(resolve => {
    setTimeout(() => {
        resolve(123);
    }, 1000);
});
pramise.then(value => console.log(value));
