let productList = document.querySelector('#products');

function addToList(productName) {
  let li = document.createElement('li');
  li.innerHTML = productName;
  productList.appendChild(li);
}

// CONVENTIONAL SYNTAX
// function loadData() {
//   fetch('https://pw-uiewg-walletapp.firebaseio.com/products.json')
//     .then(response => response.json())
//     .then(products => {
//       for (let product of products) {
//         addToList(product.name);
//       }
//     })
//     .catch(error => {
//       alert(error.message);
//     });
// }

function sleep(seconds) {
  return new Promise((resolve) => {
    setTimeout(resolve, seconds * 1000);
  });
}

// ASYNC/AWAIT
async function loadData() {
  try {
    let response = await fetch('https://pw-uiewg-walletapp.firebaseio.com/products.json');
    let products = await response.json();
    
    for (let product of products) {
      addToList(product.name);
      await sleep(1);
    }
  } catch (error) {
    alert(error.message);
  }
}

document.addEventListener('DOMContentLoaded', () => {
  loadData();
});