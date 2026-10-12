const apiUrl = "http://localhost:5035/api/items"

async function fetchItems() {
    const response = await fetch(apiUrl);
    const items = await response.json();
    console.log(items);

    const itemsList = document.getElementById("items-list");
    itemsList.innerHTML = '';

    items.forEach(item => {
        const li = document.createElement('li');
        li.textContent = `${item.id} - Quantity: ${item.quantity} - Price: $${item.price.toFixed(2)}`;
        itemsList.appendChild(li);
        const deleteButton = document.createElement('button');
        deleteButton.textContent = "Delete";
        deleteButton.onclick = () => deleteItem(item.id);
        li.appendChild(deleteButton);
    });
}


async function addItem() {
    const name = document.getElementById("item-name").value;
    const quantity = document.getElementById("item-quantity").value;
    const price = document.getElementById("item-price").value;

    const item = {name, quantity: parseInt(quantity), price: parseFloat(price)};

    await fetch(apiUrl, {
        method: 'POST',
        headers: {
            'Content-Type': 'Application/json'
        },
        body: JSON.stringify(item)
    });

    fetchItems();
        
}


async function deleteItem(id) {
    
}


window.onload = fetchItems();