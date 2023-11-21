function openCity(evt, cityName) {
    // Declare all variables
    var i, tabcontent, tablinks;

    // Get all elements with class="tabcontent" and hide them
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }

    // Get all elements with class="tablinks" and remove the class "active"
    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
    }

    // Show the current tab, and add an "active" class to the button that opened the tab
    document.getElementById(cityName).style.display = "block";
    evt.currentTarget.className += " active";
}
document.getElementById("defaultOpen").click();


let imgList = document.querySelectorAll('.zoomer img')
let mirror = document.querySelector('#mirror')
let scope = 4

imgList.forEach(function (img) {
    img.addEventListener('mousemove', function (e) {
        mirror.classList.remove('hide')
        var percentMouseOfWidth = (e.offsetX / this.offsetWidth) * 100
        var percentMouseOfHeight = (e.offsetY / this.offsetHeight) * 100
        mirror.style.top = `${e.clientY}px`
        mirror.style.left = `${e.clientX}px`
        mirror.style.backgroundSize = '800px 800px'
        mirror.style.backgroundPosition = `${percentMouseOfWidth}% ${percentMouseOfHeight}%`
    })

    img.addEventListener('mouseleave', function (e) {
        mirror.classList.add('hide')
    })

})

let amountElement = document.getElementById('amount');
let amount = amountElement.value;
// console.log(amount);
let render = (amount) => {
    amountElement.value = amount
}
// Handle Plus
let handlePlus = () => {
    console.log(amount);
    amount++
    render(amount);
}

//Handle Minus
let handleMinus = () => {
    console.log(amount);
    if (amount > 1)
        amount--;
    render(amount);
}

amountElement.addEventListener('input', () => {
    console.log(amount);
    amount = amountElement.value;
    amount = parseInt(amount);
    amount = (isNaN(amount) || amount == 0) ? 1 : amount;
    render(amount);
    console.log(amount);
})

//thông tin đặt hàng 
let selectedProduct;
let selectedPrice;

function hienModal(tenSanPham, giaSanPham) {
    selectedProduct = tenSanPham;
    selectedPrice = giaSanPham;

    const modal = document.getElementById('modal');
    const overlay = document.getElementById('overlay');
    const donGiaElement = document.getElementById('donGia');

    // Hiển thị thông tin sản phẩm trong modal
    donGiaElement.textContent = `${selectedPrice.toFixed()}VNĐ`;

    // Hiển thị modal và overlay
    modal.style.display = 'flex';
    overlay.style.display = 'block';
}

function anModal() {
    const modal = document.getElementById('modal');
    const overlay = document.getElementById('overlay');

    // Ẩn modal và overlay
    modal.style.display = 'none';
    overlay.style.display = 'none';
}

function datHang() {
    const soLuong = document.getElementById('soLuong').value;
    const tongTien = selectedPrice * soLuong;
    // Ẩn modal và overlay sau khi đặt hàng
    anModal();
}
