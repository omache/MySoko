let cart = loadCartFromLocalStorage();

// Load cart from localStorage
function loadCartFromLocalStorage() {
  const cartData = localStorage.getItem("cart");
  return cartData ? JSON.parse(cartData) : [];
}

// Save cart to localStorage
function saveCartToLocalStorage() {
  localStorage.setItem("cart", JSON.stringify(cart));
}

// Add product to cart
function addToCart(productName, price) {
  const existingItem = cart.find((item) => item.product === productName);
  
  if (existingItem) {
    existingItem.quantity += 1;
    existingItem.total = existingItem.quantity * existingItem.price;
  } else {
    cart.push({
      product: productName,
      quantity: 1,
      price: price,
      total: price,
    });
  }
  
  saveCartToLocalStorage();
  renderCart();
}

// Remove product from cart or decrease quantity
function removeFromCart(productName) {
  const item = cart.find((item) => item.product === productName);
  
  if (item) {
    if (item.quantity > 1) {
      item.quantity -= 1;
      item.total = item.quantity * item.price;
    } else {
      cart = cart.filter((item) => item.product !== productName);
    }
  }
  
  saveCartToLocalStorage();
  renderCart();
}

// Clear the entire cart
function clearCart() {
  cart = [];
  saveCartToLocalStorage();
  renderCart();
}

// Checkout the cart, display in a modal
function checkoutCart() {
  const modalCartItemsElement = document.getElementById("modal-cart-items");
  const modalCartTotalElement = document.getElementById("modal-cart-total");

  modalCartItemsElement.innerHTML = ""; // Clear previous items

  let totalCost = 0;
  
  cart.forEach((item) => {
    totalCost += item.total;

    const row = modalCartItemsElement.insertRow();
    row.insertCell(0).textContent = item.product;
    row.insertCell(1).textContent = item.quantity;
    row.insertCell(2).textContent = `Ksh ${item.total.toLocaleString('en-KE', {
      minimumFractionDigits: 2,
      maximumFractionDigits: 2,
    })}`;
  });

  // Display total cost formatted as Kenyan Shillings
  modalCartTotalElement.textContent = `Ksh ${totalCost.toLocaleString('en-KE', {
    minimumFractionDigits: 2,
    maximumFractionDigits: 2,
  })}`;

  // Trigger the modal
  var checkoutModal = new bootstrap.Modal(document.getElementById('checkoutModal'), {
    keyboard: false
  });
  checkoutModal.show();
}

// Render the cart items on the page
function renderCart() {
  const cartElement = document.getElementById("cart");
  const cartItemsElement = document.getElementById("cart-items").getElementsByTagName("tbody")[0];
  const cartTotalElement = document.getElementById("cart-total");

  if (cart.length > 0) {
    cartElement.style.display = "block";
  } else {
    cartElement.style.display = "none";
  }

  cartItemsElement.innerHTML = ""; // Clear previous items

  let totalCost = 0;
  
  cart.forEach((item) => {
    totalCost += item.total;

    const row = cartItemsElement.insertRow();
    row.insertCell(0).textContent = item.product;
    row.insertCell(1).textContent = item.quantity;
    row.insertCell(2).textContent = `Ksh ${item.total.toLocaleString('en-KE', {
      minimumFractionDigits: 2,
      maximumFractionDigits: 2,
    })}`;
    
    // Add delete button
    const deleteCell = row.insertCell(3);
    deleteCell.innerHTML = `<a type="button" onclick="removeFromCart('${item.product}')"><i class="fa-solid fa-trash fa-bounce" style="color:red"></i></a>`;
  });

  // Display total cost formatted as Kenyan Shillings
  cartTotalElement.textContent = `Ksh ${totalCost.toLocaleString('en-KE', {
    minimumFractionDigits: 2,
    maximumFractionDigits: 2,
  })}`;
}

// Initialize the cart rendering on page load
window.onload = function () {
  renderCart();
};
