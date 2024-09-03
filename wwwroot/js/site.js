let cart = [];

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
  renderCart();
}

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
  renderCart();
}

function clearCart() {
  cart = [];
  renderCart();
}

function checkoutCart() {
  alert("Proceed to payment options.");
  // Here you can add your payment integration or redirect to another page.
}

function renderCart() {
  const cartElement = document.getElementById("cart");
  const cartItemsElement = document
    .getElementById("cart-items")
    .getElementsByTagName("tbody")[0];
  const cartTotalElement = document.getElementById("cart-total");

  if (cart.length > 0) {
    cartElement.style.display = "block";
  } else {
    cartElement.style.display = "none";
  }

  cartItemsElement.innerHTML = ""; // Clear previous items

  // Function to format a number as Ksh
  function formatAsKsh(amount) {
    const formatter = new Intl.NumberFormat("en-KE", {
      style: "currency",
      currency: "KES",
      minimumFractionDigits: 2,
      maximumFractionDigits: 2,
    });
    return formatter.format(amount);
  }

  let totalCost = 0;
  cart.forEach((item) => {
    totalCost += item.total;

    const row = cartItemsElement.insertRow();
    row.insertCell(0).textContent = item.product;
    row.insertCell(1).textContent = item.quantity;
    row.insertCell(2).textContent = `Ksh${item.total.toLocaleString({
      minimumFractionDigits: 2,
      maximumFractionDigits: 2,
    })}`;
    const deleteCell = row.insertCell(3);
    deleteCell.innerHTML = `<button type="button" class="btn btn-danger btn-sm" onclick="removeFromCart('${item.product}')">Remove</button>`;
  });

  cartTotalElement.textContent = totalCost.toLocaleString();
}
