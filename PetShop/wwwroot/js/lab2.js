const uri = 'api/Products';
let products = [];

function getProducts() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayProducts(data))
        .catch(error => console.error('Unable to get products.', error));
}

function addProducts() {
    const addNameTextbox = document.getElementById('add-name');
    const addInfoTextbox = document.getElementById('add-info');
    const addPriceTextbox = document.getElementById('add-price');
    const addCategories_IdTextbox = document.getElementById('add-categories_Id');
    const addProviders_IdTextbox = document.getElementById('add-providers_Id');

    const product = {
        name: addNameTextbox.value.trim(),
        info: addInfoTextbox.value.trim(),
        price: addPriceTextbox.value.trim(),
        categoriesId: addCategories_IdTextbox.value.trim(),
        providersId: addProviders_IdTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(product)
    })
        .then(response => response.json())
        .then(() => {
            getProducts();
            addNameTextbox.value = '';
            addInfoTextbox.value = '';
            addPriceTextbox.value = '';
            addCategories_IdTextbox.value = '';
            addProviders_IdTextbox.value = '';
        })
        .catch(error => console.error('Unable to add product.', error));
}

function deleteProduct(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getProducts())
        .catch(error => console.error('Unable to delete product.', error));
}

function displayEditForm(id) {
    const product = products.find(product => product.id === id);

    document.getElementById('edit-id').value = product.id;
    document.getElementById('edit-name').value = product.name;
    document.getElementById('edit-info').value = product.info;
    document.getElementById('edit-price').value = product.price;
    document.getElementById('edit-categories_Id').value = product.categoriesId;
    document.getElementById('edit-providers_Id').value = product.providersId;
    document.getElementById('editForm').style.display = 'block';
}

function updateProduct() {
    const productId = document.getElementById('edit-id').value;
    const product = {
        id: parseInt(productId, 10),
        name: document.getElementById('edit-name').value.trim(),
        info: document.getElementById('edit-info').value.trim(),
        price: document.getElementById('edit-price').value.trim(),
        categoriesId: document.getElementById('edit-categories_Id').value.trim(),
        providersId: document.getElementById('edit-providers_Id').value.trim()
    };

    fetch(`${uri}/${productId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(product)
    })
        .then(() => getProducts())
        .catch(error => console.error('Unable to update product.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}


function _displayProducts(data) {
    const tBody = document.getElementById('products');
    tBody.innerHTML = '';


    const button = document.createElement('button');

    data.forEach(product => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${product.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteProduct(${product.id})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(product.name);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let textNodeInfo = document.createTextNode(product.info);
        td2.appendChild(textNodeInfo);

        let td3 = tr.insertCell(2);
        let textNodePrice = document.createTextNode(product.price);
        td3.appendChild(textNodePrice);

        let td6 = tr.insertCell(3);
        td6.appendChild(editButton);

        let td7 = tr.insertCell(4);
        td7.appendChild(deleteButton);
    });

    products = data;
}
