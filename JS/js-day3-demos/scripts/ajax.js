document.querySelector('#load-data-btn').addEventListener('click', () => {
  fetch('https://pw-uiewg-walletapp.firebaseio.com/tasks.json')
    .then(response => response.json())
    .then(data => {
      let ul = document.querySelector('#data')
      for (let key of Object.keys(data)) {
        let li = document.createElement('li');
        li.textContent = data[key].task;
        ul.appendChild(li);
      }
    })
    .catch(error => {
      alert('error!' + error.message);
    });
});