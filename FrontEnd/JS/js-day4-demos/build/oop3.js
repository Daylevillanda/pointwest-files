"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
let productsDiv = document.querySelector('#products');
function renderProduct(product) {
    // create container div
    let container = document.createElement('div');
    container.setAttribute('class', 'product');
    // create img
    let img = document.createElement('img');
    img.setAttribute('src', product.photo);
    container.appendChild(img);
    // create product name
    let productName = document.createElement('h3');
    productName.textContent = product.name;
    container.appendChild(productName);
    // create price
    let price = document.createElement('p');
    price.textContent = 'PHP ' + product.price.toFixed(2);
    container.appendChild(price);
    // append to parent div
    productsDiv === null || productsDiv === void 0 ? void 0 : productsDiv.appendChild(container);
}
function loadData() {
    return __awaiter(this, void 0, void 0, function* () {
        try {
            let response = yield fetch('https://pw-uiewg-walletapp.firebaseio.com/products.json');
            let products = yield response.json();
            if (productsDiv) {
                productsDiv.innerHTML = '';
            }
            for (let product of products) {
                renderProduct(product);
            }
        }
        catch (e) {
            alert(e.message);
        }
    });
}
document.addEventListener('DOMContentLoaded', loadData);
var Status;
(function (Status) {
    Status[Status["ACTIVE"] = 0] = "ACTIVE";
    Status[Status["INACTIVE"] = 1] = "INACTIVE";
    Status[Status["CLOSED"] = 2] = "CLOSED";
})(Status || (Status = {}));
let accountStatus = Status.ACTIVE;
