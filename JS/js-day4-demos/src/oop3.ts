let productsDiv = document.querySelector('#products');

interface Product {
  description: string;
  name: string;
  photo: string;
  price: number;
  rating: number;
}

function renderProduct(product: Product) {
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
  productsDiv?.appendChild(container);
}

async function loadData() {
  try {
    let response = await fetch('https://pw-uiewg-walletapp.firebaseio.com/products.json');
    let products: Product[] = await response.json();

    if (productsDiv) {
      productsDiv.innerHTML = '';
    }

    for (let product of products) {
      renderProduct(product);
    }
  } catch (e) {
    alert((e as Error).message);
  }
}

document.addEventListener('DOMContentLoaded', loadData);

enum Status {
  ACTIVE,
  INACTIVE,
  CLOSED
}

let accountStatus: Status = Status.ACTIVE;